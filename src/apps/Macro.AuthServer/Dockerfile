#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
WORKDIR /src
COPY ["services/administration/NuGet.Config", "services/administration/"]
COPY ["services/identity/NuGet.Config", "services/identity/"]
COPY ["services/saas/NuGet.Config", "services/saas/"]
COPY ["apps/Macro.AuthServer/Macro.AuthServer.csproj", "apps/Macro.AuthServer/"]
COPY ["services/administration/src/Macro.AdministrationService.EntityFrameworkCore/Macro.AdministrationService.EntityFrameworkCore.csproj", "services/administration/src/Macro.AdministrationService.EntityFrameworkCore/"]
COPY ["services/administration/src/Macro.AdministrationService.Domain/Macro.AdministrationService.Domain.csproj", "services/administration/src/Macro.AdministrationService.Domain/"]
COPY ["services/administration/src/Macro.AdministrationService.Domain.Shared/Macro.AdministrationService.Domain.Shared.csproj", "services/administration/src/Macro.AdministrationService.Domain.Shared/"]
COPY ["services/identity/src/Macro.IdentityService.EntityFrameworkCore/Macro.IdentityService.EntityFrameworkCore.csproj", "services/identity/src/Macro.IdentityService.EntityFrameworkCore/"]
COPY ["services/identity/src/Macro.IdentityService.Domain/Macro.IdentityService.Domain.csproj", "services/identity/src/Macro.IdentityService.Domain/"]
COPY ["services/identity/src/Macro.IdentityService.Domain.Shared/Macro.IdentityService.Domain.Shared.csproj", "services/identity/src/Macro.IdentityService.Domain.Shared/"]
COPY ["services/saas/src/Macro.SaaS.EntityFrameworkCore/Macro.SaaS.EntityFrameworkCore.csproj", "services/saas/src/Macro.SaaS.EntityFrameworkCore/"]
COPY ["services/saas/src/Macro.SaaS.Domain/Macro.SaaS.Domain.csproj", "services/saas/src/Macro.SaaS.Domain/"]
COPY ["services/saas/src/Macro.SaaS.Domain.Shared/Macro.SaaS.Domain.Shared.csproj", "services/saas/src/Macro.SaaS.Domain.Shared/"]
COPY ["shared/Macro.Microservice.Shared/Macro.Microservice.Shared.csproj", "shared/Macro.Microservice.Shared/"]
COPY ["shared/Macro.Hosting.Shared/Macro.Hosting.Shared.csproj", "shared/Macro.Hosting.Shared/"]
RUN dotnet restore "apps/Macro.AuthServer/Macro.AuthServer.csproj"
COPY . .
WORKDIR "/src/apps/Macro.AuthServer"
RUN dotnet build "Macro.AuthServer.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "Macro.AuthServer.csproj" -c Release -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "Macro.AuthServer.dll"]