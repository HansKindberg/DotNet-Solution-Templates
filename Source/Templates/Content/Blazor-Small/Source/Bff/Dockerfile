#See https://aka.ms/customizecontainer to learn how to customize your debug container and how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS base
WORKDIR /app

FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
ARG BUILD_CONFIGURATION=Release
ARG DEBCONF_NOWARNINGS="yes" # To avoid warnings so we can use "failOnStderr: true" in our script task.
WORKDIR /src
COPY [".editorconfig", "."]
COPY ["NuGet.config", "."]
COPY ["Source/Bff/Bff.csproj", "Bff/"]
COPY ["Source/Shared/Shared.csproj", "Shared/"]
COPY ["Source/Spa/Spa.csproj", "Spa/"]
RUN dotnet restore "./Bff/Bff.csproj"
COPY ["Source/", "."]
WORKDIR "/src/Bff"
RUN dotnet build "./Bff.csproj" -c $BUILD_CONFIGURATION -o /app/build -p:NpmBuild=false

FROM build AS publish
ARG BUILD_CONFIGURATION=Release
ARG DEBCONF_NOWARNINGS="yes" # To avoid warnings so we can use "failOnStderr: true" in our script task.
RUN dotnet publish "./Bff.csproj" -c $BUILD_CONFIGURATION -o /app/publish -p:NpmBuild=false;UseAppHost=false

FROM base AS final
ARG DEBCONF_NOWARNINGS="yes" # To avoid warnings so we can use "failOnStderr: true" in our script task.
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "Bff.dll"]