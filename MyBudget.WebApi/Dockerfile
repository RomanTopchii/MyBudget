FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS base
WORKDIR /app
EXPOSE 5000

FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
WORKDIR /src
COPY ["MyBudget.WebApi/MyBudget.WebApi.csproj", "MyBudget.WebApi/"]
COPY ["MyBudget.Infrastructure/MyBudget.Infrastructure.csproj", "MyBudget.Infrastructure/"]
COPY ["MyBudget.Application/MyBudget.Application.csproj", "MyBudget.Application/"]
COPY ["MyBudget.Domain/MyBudget.Domain.csproj", "MyBudget.Domain/"]
RUN dotnet restore "MyBudget.WebApi/MyBudget.WebApi.csproj"
COPY . .
WORKDIR "/src/MyBudget.WebApi"
RUN dotnet build "MyBudget.WebApi.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "MyBudget.WebApi.csproj" -c Release -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "MyBudget.WebApi.dll"]
