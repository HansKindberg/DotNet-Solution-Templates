#See https://aka.ms/customizecontainer to learn how to customize your debug container and how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS base
USER app
WORKDIR /app

FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
ARG BUILD_CONFIGURATION=Release
WORKDIR /src
COPY [".editorconfig", "."]
COPY ["NuGet.config", "."]
COPY ["Source/Service/Service.csproj", "Service/"]
RUN dotnet restore "./Service/Service.csproj"
COPY ["Source/", "."]
WORKDIR "/src/Service"
RUN dotnet build "./Service.csproj" -c $BUILD_CONFIGURATION -o /app/build

FROM build AS publish
ARG BUILD_CONFIGURATION=Release
RUN dotnet publish "./Service.csproj" -c $BUILD_CONFIGURATION -o /app/publish /p:UseAppHost=false

FROM base AS final
ARG DEBCONF_NOWARNINGS="yes" # To avoid warnings so we can use "failOnStderr: true" in our script task.
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "Service.dll"]