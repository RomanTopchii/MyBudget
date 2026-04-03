using System.Collections.Generic;
using System.Collections.Immutable;
using System.Diagnostics;
using System.Linq;
using System.Text;
using Microsoft.CodeAnalysis;
using Microsoft.CodeAnalysis.CSharp.Syntax;
using Microsoft.CodeAnalysis.Text;

namespace MyBudget.Generators;

[Generator(LanguageNames.CSharp)]
public class DomainObjectAuditGenerator : IIncrementalGenerator
{
    private const string DomainObjectsProject = "MyBudget.Domain";

    public void Initialize(IncrementalGeneratorInitializationContext context)
    {
#if DEBUG
        if (!Debugger.IsAttached)
        {
            Debugger.Launch();
        }
#endif
        // 1. Generate Static Files once
        context.RegisterPostInitializationOutput(i =>
        {
            i.AddSource("AuditRevisionEntity.g.cs", SourceText.From(GetAuditRevisionEntityDeclaration, Encoding.UTF8));
            i.AddSource("BaseEntityAudit.g.cs", SourceText.From(GetBaseEntityAuditDeclaration, Encoding.UTF8));
            i.AddSource("RevisionType.g.cs", SourceText.From(GetRevisionTypeDeclaration, Encoding.UTF8));
        });

        // 2. Filter for Classes with [Auditable] attribute
        IncrementalValuesProvider<TypeDeclarationSyntax> classDeclarations = context.SyntaxProvider
            .CreateSyntaxProvider(
                predicate: static (s, _) => IsSyntaxTargetForGeneration(s),
                transform: static (ctx, _) => GetSemanticTargetForGeneration(ctx))
            .Where(static m => m is not null)!;

        // 3. Combine with Compilation to perform generation
        IncrementalValueProvider<(Compilation, ImmutableArray<TypeDeclarationSyntax>)> compilationAndClasses = 
            context.CompilationProvider.Combine(classDeclarations.Collect());

        context.RegisterSourceOutput(compilationAndClasses, static (spc, source) => Execute(source.Item1, source.Item2, spc));
    }

    private static bool IsSyntaxTargetForGeneration(SyntaxNode node) =>
        node is TypeDeclarationSyntax tds && tds.AttributeLists.Count > 0;

    private static TypeDeclarationSyntax? GetSemanticTargetForGeneration(GeneratorSyntaxContext context)
    {
        var typeDeclaration = (TypeDeclarationSyntax)context.Node;
        foreach (AttributeListSyntax attributeList in typeDeclaration.AttributeLists)
        {
            foreach (AttributeSyntax attribute in attributeList.Attributes)
            {
                if (attribute.Name.ToString().Contains("Auditable"))
                    return typeDeclaration;
            }
        }
        return null;
    }

    private static void Execute(Compilation compilation, ImmutableArray<TypeDeclarationSyntax> classes, SourceProductionContext context)
    {
        if (classes.IsDefaultOrEmpty) return;

        foreach (var typeDecl in classes)
        {
            var semanticModel = compilation.GetSemanticModel(typeDecl.SyntaxTree);
            if (semanticModel.GetDeclaredSymbol(typeDecl) is not INamedTypeSymbol classSymbol) continue;

            var className = classSymbol.Name;
            var generatedClassName = $"{className}Audit";

            // Extract usings from original file
            var usings = string.Join("\r\n", typeDecl.SyntaxTree.GetRoot().DescendantNodes().OfType<UsingDirectiveSyntax>());
            var sourceBuilder = new StringBuilder(usings);

            sourceBuilder.Append(GetAuditClassDeclaration(classSymbol, generatedClassName));

            context.AddSource($"{generatedClassName}.g.cs", SourceText.From(sourceBuilder.ToString(), Encoding.UTF8));
        }
    }

    private static string GetAuditClassDeclaration(INamedTypeSymbol classTypeSymbol, string generatedClassName)
    {
        var sourceBuilder = new StringBuilder();
        var baseTypes = new List<INamedTypeSymbol>();
        INamedTypeSymbol? currentType = classTypeSymbol;

        while (currentType != null)
        {
            if (!currentType.Name.Contains("BaseEntity"))
                baseTypes.Add(currentType);
            currentType = currentType.BaseType;
        }

        baseTypes.Reverse();

        sourceBuilder.Append($@"
namespace MyBudget.Domain.Audit.Generated
{{
    public class {generatedClassName} : BaseEntityAudit
    {{");

        foreach (var baseType in baseTypes)
        {
            var properties = baseType.GetMembers().OfType<IPropertySymbol>();
            foreach (var property in properties.Where(x => !x.IsVirtual && !x.Name.Equals("Id")))
            {
                sourceBuilder.Append(GetPropertiesDeclarationsString(property));
            }
        }

        sourceBuilder.Append("\n    }\n}");
        return sourceBuilder.ToString();
    }
    
    private static string GetPropertiesDeclarationsString(IPropertySymbol property)
    {
        ITypeSymbol type = property.Type;

        if (type is INamedTypeSymbol namedType && 
            namedType.OriginalDefinition.SpecialType == SpecialType.System_Nullable_T)
        {
            type = namedType.TypeArguments[0];
        }

        var typeName = type.WithNullableAnnotation(NullableAnnotation.None).ToDisplayString();

        return $@"
        public {typeName}? {property.Name} {{ get; set; }}
        public bool? {property.Name}_MOD {{ get; set; }}";
    }

    private const string GetAuditRevisionEntityDeclaration =
        "using System;\n\nnamespace MyBudget.Domain.Audit.Generated\n{\n    public class AuditRevisionEntity\n    {\n        public int Id { get; set; }\n\n        public DateTime RevisionDate { get; set; }\n\n        public string Author { get; set; }\n    }\n}";

    private const string GetBaseEntityAuditDeclaration =
        "using System;\n\nnamespace MyBudget.Domain.Audit.Generated\n{\n    public class BaseEntityAudit\n    {\n        public AuditRevisionEntity Rev { get; set; }\n\n        public int RevId { get; set; }\n\n        public Guid Id { get; set; }\n\n        public RevisionType RevType { get; set; }\n\n        public bool? Active { get; set; }\n\n        public bool? Active_MOD { get; set; }\n\n        public DateTime? CreateDate { get; set; }\n\n        public bool? CreateDate_MOD { get; set; }\n\n        public string? CreatedBy { get; set; }\n\n        public bool? CreatedBy_MOD { get; set; }\n\n        public DateTime? ModifyDate { get; set; }\n\n        public bool? ModifyDate_MOD { get; set; }\n\n        public string? ModifiedBy { get; set; }\n\n        public bool? ModifiedBy_MOD { get; set; }\n    }\n}";

    private const string GetRevisionTypeDeclaration =
        "namespace MyBudget.Domain.Audit.Generated;\n\npublic enum RevisionType\n{\n    Add = 0,\n    Update = 1,\n    Delete = 2\n}";
}
