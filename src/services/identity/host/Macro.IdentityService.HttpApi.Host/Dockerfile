#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
WORKDIR /src
COPY ["services/identity/NuGet.Config", "services/identity/"]
COPY ["services/administration/NuGet.Config", "services/administration/"]
COPY ["services/saas/NuGet.Config", "services/saas/"]
COPY ["services/identity/host/Macro.IdentityService.HttpApi.Host/Macro.IdentityService.HttpApi.Host.csproj", "services/identity/host/Macro.IdentityService.HttpApi.Host/"]
COPY ["shared/Macro.Hosting.Shared/Macro.Hosting.Shared.csproj", "shared/Macro.Hosting.Shared/"]
COPY ["services/administration/src/Macro.AdministrationService.EntityFrameworkCore/Macro.AdministrationService.EntityFrameworkCore.csproj", "services/administration/src/Macro.AdministrationService.EntityFrameworkCore/"]
COPY ["services/administration/src/Macro.AdministrationService.Domain/Macro.AdministrationService.Domain.csproj", "services/administration/src/Macro.AdministrationService.Domain/"]
COPY ["services/administration/src/Macro.AdministrationService.Domain.Shared/Macro.AdministrationService.Domain.Shared.csproj", "services/administration/src/Macro.AdministrationService.Domain.Shared/"]
COPY ["services/saas/src/Macro.SaaS.EntityFrameworkCore/Macro.SaaS.EntityFrameworkCore.csproj", "services/saas/src/Macro.SaaS.EntityFrameworkCore/"]
COPY ["services/saas/src/Macro.SaaS.Domain/Macro.SaaS.Domain.csproj", "services/saas/src/Macro.SaaS.Domain/"]
COPY ["services/saas/src/Macro.SaaS.Domain.Shared/Macro.SaaS.Domain.Shared.csproj", "services/saas/src/Macro.SaaS.Domain.Shared/"]
COPY ["services/identity/src/Macro.IdentityService.HttpApi/Macro.IdentityService.HttpApi.csproj", "services/identity/src/Macro.IdentityService.HttpApi/"]
COPY ["services/identity/src/Macro.IdentityService.Application.Contracts/Macro.IdentityService.Application.Contracts.csproj", "services/identity/src/Macro.IdentityService.Application.Contracts/"]
COPY ["services/identity/src/Macro.IdentityService.Domain.Shared/Macro.IdentityService.Domain.Shared.csproj", "services/identity/src/Macro.IdentityService.Domain.Shared/"]
COPY ["services/identity/src/Macro.IdentityService.Application/Macro.IdentityService.Application.csproj", "services/identity/src/Macro.IdentityService.Application/"]
COPY ["services/identity/src/Macro.IdentityService.Domain/Macro.IdentityService.Domain.csproj", "services/identity/src/Macro.IdentityService.Domain/"]
COPY ["services/identity/src/Macro.IdentityService.EntityFrameworkCore/Macro.IdentityService.EntityFrameworkCore.csproj", "services/identity/src/Macro.IdentityService.EntityFrameworkCore/"]
RUN dotnet restore "services/identity/host/Macro.IdentityService.HttpApi.Host/Macro.IdentityService.HttpApi.Host.csproj"
COPY . .
WORKDIR "/src/services/identity/host/Macro.IdentityService.HttpApi.Host"
RUN dotnet build "Macro.IdentityService.HttpApi.Host.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "Macro.IdentityService.HttpApi.Host.csproj" -c Release -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "Macro.IdentityService.HttpApi.Host.dll"]