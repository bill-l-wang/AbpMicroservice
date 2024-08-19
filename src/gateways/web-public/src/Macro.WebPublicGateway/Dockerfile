#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
WORKDIR /src
COPY ["gateways/web-public/src/Macro.WebPublicGateway/Macro.WebPublicGateway.csproj", "gateways/web-public/src/Macro.WebPublicGateway/"]
RUN dotnet restore "gateways/web-public/src/Macro.WebPublicGateway/Macro.WebPublicGateway.csproj"
COPY . .
WORKDIR "/src/gateways/web-public/src/Macro.WebPublicGateway"
RUN dotnet build "Macro.WebPublicGateway.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "Macro.WebPublicGateway.csproj" -c Release -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "Macro.WebPublicGateway.dll"]