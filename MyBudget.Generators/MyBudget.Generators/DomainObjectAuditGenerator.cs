using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using Microsoft.CodeAnalysis;
using Microsoft.CodeAnalysis.CSharp.Syntax;
using Microsoft.CodeAnalysis.Text;

namespace MyBudget.Generators;

[Generator]
public class DomainObjectAuditGenerator : ISourceGenerator
{
    private const string DomainObjectsProject = "MyBudget.Domain";


    public void Initialize(GeneratorInitializationContext context)
    {
#if DEBUG
        if (!Debugger.IsAttached)
        {
            Debugger.Launch();
        }
#endif
    }

    public void Execute(GeneratorExecutionContext context)
    {
        var syntaxTrees = context.Compilation.SyntaxTrees.ToList();

        if (syntaxTrees.Any(x => x.FilePath.Contains(DomainObjectsProject)))
        {
            context.AddSource($"AuditRevisionEntity.g.cs",
                SourceText.From(GetAuditRevisionEntityDeclaration, Encoding.UTF8));
            context.AddSource("BaseEntityAudit.g.cs",
                SourceText.From(GetBaseEntityAuditDeclaration, Encoding.UTF8));
            context.AddSource("RevisionType.g.cs",
                SourceText.From(GetRevisionTypeDeclaration, Encoding.UTF8));
        }

        foreach (var syntaxTree in syntaxTrees)
        {
            var auditableTypeDeclarations = syntaxTree.GetRoot()
                .DescendantNodes()
                .OfType<TypeDeclarationSyntax>()
                .Where(x => x.AttributeLists.Any(a => a.ToString().StartsWith("[Auditable")))
                .ToList();

            foreach (var auditableTypeDeclaration in auditableTypeDeclarations)
            {
                var usingDirectives = syntaxTree.GetRoot().DescendantNodes().OfType<UsingDirectiveSyntax>();
                var usingDirectivesAsText = string.Join("\r\n", usingDirectives);
                var sourceBuilder = new StringBuilder(usingDirectivesAsText);

                var className = auditableTypeDeclaration.Identifier.ToString();
                var generatedClassName = $"{className}Audit";

                var classTypeSymbol = context.Compilation.GetTypeByMetadataName($"MyBudget.Domain.{className}");
                if (classTypeSymbol != null)
                {
                    sourceBuilder.Append(GetAuditClassDeclaration(classTypeSymbol, generatedClassName));

                    context.AddSource($"{generatedClassName}.g.cs",
                        SourceText.From(sourceBuilder.ToString(), Encoding.UTF8));
                }
            }
        }
    }

    private string GetAuditClassDeclaration(INamedTypeSymbol classTypeSymbol, string generatedClassName)
    {
        var sourceBuilder = new StringBuilder();

        var baseTypes = new List<INamedTypeSymbol>();
        INamedTypeSymbol? currentType = classTypeSymbol;
        while (currentType != null)
        {
            if (!currentType.Name.Contains("BaseEntity"))
            {
                baseTypes.Add(currentType);
            }

            currentType = currentType.BaseType;
        }

        baseTypes.Reverse(); // Reversing to get base types in the inheritance hierarchy order

        sourceBuilder.Append($@"

namespace MyBudget.Domain.Audit.Generated 
{{
    public class {generatedClassName}: BaseEntityAudit
    {{");

        foreach (var baseType in baseTypes)
        {
            List<IPropertySymbol> properties = new List<IPropertySymbol>();
            foreach (var member in baseType.GetMembers())
            {
                if (member.Kind == SymbolKind.Property)
                {
                    properties.Add((IPropertySymbol)member);
                }
            }

            foreach (var property in properties.Where(x => !x.IsVirtual && !x.Name.Equals("Id")))
            {
                sourceBuilder.Append(this.GetPropertiesDeclarationsString(property));
            }
        }

        sourceBuilder.Append("\n\t}\n}");

        return sourceBuilder.ToString();
    }

    private string GetPropertiesDeclarationsString(IPropertySymbol property)
    {
        var propertyTypeString = property.Type.ToString().Replace("?", "");

        return $@"

        public {propertyTypeString}? {property.Name} {{ get; set; }}
        public bool? {property.Name + "_MOD"} {{ get; set; }}";
    }

    private const string GetAuditRevisionEntityDeclaration =
        "using System;\n\nnamespace MyBudget.Domain.Audit.Generated\n{\n    public class AuditRevisionEntity\n    {\n        public int Id { get; set; }\n\n        public DateTime RevisionDate { get; set; }\n\n        public string Author { get; set; }\n    }\n}";

    private const string GetBaseEntityAuditDeclaration =
        "using System;\n\nnamespace MyBudget.Domain.Audit.Generated\n{\n    public class BaseEntityAudit\n    {\n        public AuditRevisionEntity Rev { get; set; }\n\n        public int RevId { get; set; }\n\n        public Guid Id { get; set; }\n\n        public RevisionType RevType { get; set; }\n\n        public bool? Active { get; set; }\n\n        public bool? Active_MOD { get; set; }\n\n        public DateTime? CreateDate { get; set; }\n\n        public bool? CreateDate_MOD { get; set; }\n\n        public string? CreatedBy { get; set; }\n\n        public bool? CreatedBy_MOD { get; set; }\n\n        public DateTime? ModifyDate { get; set; }\n\n        public bool? ModifyDate_MOD { get; set; }\n\n        public string? ModifiedBy { get; set; }\n\n        public bool? ModifiedBy_MOD { get; set; }\n    }\n}";

    private const string GetRevisionTypeDeclaration =
        "namespace MyBudget.Domain.Audit.Generated;\n\npublic enum RevisionType\n{\n    Add = 0,\n    Update = 1,\n    Delete = 2\n}";
}
