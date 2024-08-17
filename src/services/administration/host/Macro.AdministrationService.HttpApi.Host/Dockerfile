#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
WORKDIR /src
COPY ["services/administration/NuGet.Config", "services/administration/"]
COPY ["services/administration/host/Macro.AdministrationService.HttpApi.Host/Macro.AdministrationService.HttpApi.Host.csproj", "services/administration/host/Macro.AdministrationService.HttpApi.Host/"]
COPY ["shared/Macro.Hosting.Shared/Macro.Hosting.Shared.csproj", "shared/Macro.Hosting.Shared/"]
COPY ["services/identity/src/Macro.IdentityService.Application.Contracts/Macro.IdentityService.Application.Contracts.csproj", "services/identity/src/Macro.IdentityService.Application.Contracts/"]
COPY ["services/identity/src/Macro.IdentityService.Domain.Shared/Macro.IdentityService.Domain.Shared.csproj", "services/identity/src/Macro.IdentityService.Domain.Shared/"]
COPY ["services/identity/src/Macro.IdentityService.EntityFrameworkCore/Macro.IdentityService.EntityFrameworkCore.csproj", "services/identity/src/Macro.IdentityService.EntityFrameworkCore/"]
COPY ["services/identity/src/Macro.IdentityService.Domain/Macro.IdentityService.Domain.csproj", "services/identity/src/Macro.IdentityService.Domain/"]
COPY ["services/administration/src/Macro.AdministrationService.HttpApi/Macro.AdministrationService.HttpApi.csproj", "services/administration/src/Macro.AdministrationService.HttpApi/"]
COPY ["services/administration/src/Macro.AdministrationService.Application.Contracts/Macro.AdministrationService.Application.Contracts.csproj", "services/administration/src/Macro.AdministrationService.Application.Contracts/"]
COPY ["services/administration/src/Macro.AdministrationService.Domain.Shared/Macro.AdministrationService.Domain.Shared.csproj", "services/administration/src/Macro.AdministrationService.Domain.Shared/"]
COPY ["services/administration/src/Macro.AdministrationService.Application/Macro.AdministrationService.Application.csproj", "services/administration/src/Macro.AdministrationService.Application/"]
COPY ["services/administration/src/Macro.AdministrationService.Domain/Macro.AdministrationService.Domain.csproj", "services/administration/src/Macro.AdministrationService.Domain/"]
COPY ["services/administration/src/Macro.AdministrationService.EntityFrameworkCore/Macro.AdministrationService.EntityFrameworkCore.csproj", "services/administration/src/Macro.AdministrationService.EntityFrameworkCore/"]
RUN dotnet restore "services/administration/host/Macro.AdministrationService.HttpApi.Host/Macro.AdministrationService.HttpApi.Host.csproj"
COPY . .
WORKDIR "/src/services/administration/host/Macro.AdministrationService.HttpApi.Host"
RUN dotnet build "Macro.AdministrationService.HttpApi.Host.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "Macro.AdministrationService.HttpApi.Host.csproj" -c Release -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "Macro.AdministrationService.HttpApi.Host.dll"]