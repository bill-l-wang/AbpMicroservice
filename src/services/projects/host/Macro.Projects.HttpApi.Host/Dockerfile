#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:7.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:7.0 AS build
WORKDIR /src
COPY ["services/projects/NuGet.Config", "services/projects/"]
COPY ["services/projects/host/Macro.Projects.HttpApi.Host/Macro.Projects.HttpApi.Host.csproj", "services/projects/host/Macro.Projects.HttpApi.Host/"]
COPY ["services/projects/src/Macro.Projects.HttpApi/Macro.Projects.HttpApi.csproj", "services/projects/src/Macro.Projects.HttpApi/"]
COPY ["services/projects/src/Macro.Projects.Application.Contracts/Macro.Projects.Application.Contracts.csproj", "services/projects/src/Macro.Projects.Application.Contracts/"]
COPY ["services/projects/src/Macro.Projects.Domain.Shared/Macro.Projects.Domain.Shared.csproj", "services/projects/src/Macro.Projects.Domain.Shared/"]
COPY ["services/projects/src/Macro.Projects.Application/Macro.Projects.Application.csproj", "services/projects/src/Macro.Projects.Application/"]
COPY ["services/projects/src/Macro.Projects.Domain/Macro.Projects.Domain.csproj", "services/projects/src/Macro.Projects.Domain/"]
COPY ["services/projects/src/Macro.Projects.EntityFrameworkCore/Macro.Projects.EntityFrameworkCore.csproj", "services/projects/src/Macro.Projects.EntityFrameworkCore/"]
RUN dotnet restore "services/projects/host/Macro.Projects.HttpApi.Host/Macro.Projects.HttpApi.Host.csproj"
COPY . .
WORKDIR "/src/services/projects/host/Macro.Projects.HttpApi.Host"
RUN dotnet build "Macro.Projects.HttpApi.Host.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "Macro.Projects.HttpApi.Host.csproj" -c Release -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "Macro.Projects.HttpApi.Host.dll"]