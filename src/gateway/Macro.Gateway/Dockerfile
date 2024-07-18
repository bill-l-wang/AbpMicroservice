#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:7.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:7.0 AS build
WORKDIR /src
COPY ["gateway/Macro.Gateway/Macro.Gateway.csproj", "gateway/Macro.Gateway/"]
RUN dotnet restore "gateway/Macro.Gateway/Macro.Gateway.csproj"
COPY . .
WORKDIR "/src/gateway/Macro.Gateway"
RUN dotnet build "Macro.Gateway.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "Macro.Gateway.csproj" -c Release -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "Macro.Gateway.dll"]