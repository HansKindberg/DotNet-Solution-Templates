#See https://aka.ms/customizecontainer to learn how to customize your debug container and how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS base
USER app
WORKDIR /app

FROM mcr.microsoft.com/dotnet/sdk:8.0 AS dotnetsdk-nodejs-npm
#RUN apt update && apt install -y nodejs npm # This may give a warning and can cause an error if you have "failOnStderr: true" in your script task. Example output: "WARNING: apt does not have a stable CLI interface. Use with caution in scripts."
# debconf: delaying package configuration, since apt-utils is not installed, https://github.com/phusion/baseimage-docker/issues/319
#ARG DEBIAN_FRONTEND="noninteractive"
ARG DEBCONF_NOWARNINGS="yes" # To avoid warnings so we can use "failOnStderr: true" in our script task.
RUN apt-get update && apt-get install -y nodejs npm

FROM dotnetsdk-nodejs-npm AS build
ARG BUILD_CONFIGURATION=Release
ARG DEBCONF_NOWARNINGS="yes" # To avoid warnings so we can use "failOnStderr: true" in our script task.
WORKDIR /src
COPY [".editorconfig", "."]
COPY ["Directory.Build.props", "."]
COPY ["Directory.Build.targets", "."]
COPY ["NuGet.config", "."]
COPY ["Source/Bff/Bff.csproj", "Bff/"]
COPY ["Source/Shared/Shared.csproj", "Shared/"]
COPY ["Source/Spa/Spa.csproj", "Spa/"]
RUN dotnet restore "./Bff/Bff.csproj"
COPY ["Source/", "."]
WORKDIR "/src/Bff"
RUN dotnet build "./Bff.csproj" -c $BUILD_CONFIGURATION -o /app/build

FROM build AS publish
ARG BUILD_CONFIGURATION=Release
ARG DEBCONF_NOWARNINGS="yes" # To avoid warnings so we can use "failOnStderr: true" in our script task.
RUN dotnet publish "./Bff.csproj" -c $BUILD_CONFIGURATION -o /app/publish /p:UseAppHost=false

FROM base AS final
ARG DEBCONF_NOWARNINGS="yes" # To avoid warnings so we can use "failOnStderr: true" in our script task.
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "Bff.dll"]