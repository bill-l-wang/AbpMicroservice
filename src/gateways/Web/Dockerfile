#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
WORKDIR /src
COPY ["gateways/Web/Macro.WebGateway.csproj", "gateways/Web/"]
RUN dotnet restore "gateways/Web/Macro.WebGateway.csproj"
COPY . .
WORKDIR "/src/gateways/Web"
RUN dotnet build "Macro.WebGateway.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "Macro.WebGateway.csproj" -c Release -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "Macro.WebGateway.dll"]