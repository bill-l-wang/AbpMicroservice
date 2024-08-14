#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
WORKDIR /src
COPY ["services/saas/NuGet.Config", "services/saas/"]
COPY ["services/administration/NuGet.Config", "services/administration/"]
COPY ["services/saas/host/Macro.Saas.HttpApi.Host/Macro.Saas.HttpApi.Host.csproj", "services/saas/host/Macro.Saas.HttpApi.Host/"]
COPY ["shared/Macro.Hosting.Shared/Macro.Hosting.Shared.csproj", "shared/Macro.Hosting.Shared/"]
COPY ["services/administration/src/Macro.AdministrationService.EntityFrameworkCore/Macro.AdministrationService.EntityFrameworkCore.csproj", "services/administration/src/Macro.AdministrationService.EntityFrameworkCore/"]
COPY ["services/administration/src/Macro.AdministrationService.Domain/Macro.AdministrationService.Domain.csproj", "services/administration/src/Macro.AdministrationService.Domain/"]
COPY ["services/administration/src/Macro.AdministrationService.Domain.Shared/Macro.AdministrationService.Domain.Shared.csproj", "services/administration/src/Macro.AdministrationService.Domain.Shared/"]
COPY ["services/saas/src/Macro.Saas.HttpApi/Macro.Saas.HttpApi.csproj", "services/saas/src/Macro.Saas.HttpApi/"]
COPY ["services/saas/src/Macro.Saas.Application.Contracts/Macro.Saas.Application.Contracts.csproj", "services/saas/src/Macro.Saas.Application.Contracts/"]
COPY ["services/saas/src/Macro.Saas.Domain.Shared/Macro.Saas.Domain.Shared.csproj", "services/saas/src/Macro.Saas.Domain.Shared/"]
COPY ["services/saas/src/Macro.Saas.Application/Macro.Saas.Application.csproj", "services/saas/src/Macro.Saas.Application/"]
COPY ["services/saas/src/Macro.Saas.Domain/Macro.Saas.Domain.csproj", "services/saas/src/Macro.Saas.Domain/"]
COPY ["services/saas/src/Macro.Saas.EntityFrameworkCore/Macro.Saas.EntityFrameworkCore.csproj", "services/saas/src/Macro.Saas.EntityFrameworkCore/"]
RUN dotnet restore "services/saas/host/Macro.Saas.HttpApi.Host/Macro.Saas.HttpApi.Host.csproj"
COPY . .
WORKDIR "/src/services/saas/host/Macro.Saas.HttpApi.Host"
RUN dotnet build "Macro.Saas.HttpApi.Host.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "Macro.Saas.HttpApi.Host.csproj" -c Release -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "Macro.Saas.HttpApi.Host.dll"]