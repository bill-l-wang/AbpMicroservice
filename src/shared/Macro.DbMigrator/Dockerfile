#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/runtime:8.0 AS base
WORKDIR /app

FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
WORKDIR /src
COPY ["services/administration/NuGet.Config", "services/administration/"]
COPY ["services/identity/NuGet.Config", "services/identity/"]
COPY ["services/saas/NuGet.Config", "services/saas/"]
COPY ["shared/Macro.DbMigrator/Macro.DbMigrator.csproj", "shared/Macro.DbMigrator/"]
COPY ["services/administration/src/Macro.Administration.Application.Contracts/Macro.Administration.Application.Contracts.csproj", "services/administration/src/Macro.Administration.Application.Contracts/"]
COPY ["services/administration/src/Macro.Administration.Domain.Shared/Macro.Administration.Domain.Shared.csproj", "services/administration/src/Macro.Administration.Domain.Shared/"]
COPY ["services/administration/src/Macro.Administration.EntityFrameworkCore/Macro.Administration.EntityFrameworkCore.csproj", "services/administration/src/Macro.Administration.EntityFrameworkCore/"]
COPY ["services/administration/src/Macro.Administration.Domain/Macro.Administration.Domain.csproj", "services/administration/src/Macro.Administration.Domain/"]
COPY ["services/identity/src/Macro.IdentityService.Application.Contracts/Macro.IdentityService.Application.Contracts.csproj", "services/identity/src/Macro.IdentityService.Application.Contracts/"]
COPY ["services/identity/src/Macro.IdentityService.Domain.Shared/Macro.IdentityService.Domain.Shared.csproj", "services/identity/src/Macro.IdentityService.Domain.Shared/"]
COPY ["services/identity/src/Macro.IdentityService.EntityFrameworkCore/Macro.IdentityService.EntityFrameworkCore.csproj", "services/identity/src/Macro.IdentityService.EntityFrameworkCore/"]
COPY ["services/identity/src/Macro.IdentityService.Domain/Macro.IdentityService.Domain.csproj", "services/identity/src/Macro.IdentityService.Domain/"]
COPY ["services/saas/src/Macro.SaaS.Application.Contracts/Macro.SaaS.Application.Contracts.csproj", "services/saas/src/Macro.SaaS.Application.Contracts/"]
COPY ["services/saas/src/Macro.SaaS.Domain.Shared/Macro.SaaS.Domain.Shared.csproj", "services/saas/src/Macro.SaaS.Domain.Shared/"]
COPY ["services/saas/src/Macro.SaaS.EntityFrameworkCore/Macro.SaaS.EntityFrameworkCore.csproj", "services/saas/src/Macro.SaaS.EntityFrameworkCore/"]
COPY ["services/saas/src/Macro.SaaS.Domain/Macro.SaaS.Domain.csproj", "services/saas/src/Macro.SaaS.Domain/"]
COPY ["shared/Macro.Microservice.Shared/Macro.Microservice.Shared.csproj", "shared/Macro.Microservice.Shared/"]
COPY ["shared/Macro.Hosting.Shared/Macro.Hosting.Shared.csproj", "shared/Macro.Hosting.Shared/"]
RUN dotnet restore "shared/Macro.DbMigrator/Macro.DbMigrator.csproj"
COPY . .
WORKDIR "/src/shared/Macro.DbMigrator"
RUN dotnet build "Macro.DbMigrator.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "Macro.DbMigrator.csproj" -c Release -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "Macro.DbMigrator.dll"]