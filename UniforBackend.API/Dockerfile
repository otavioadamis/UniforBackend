#See https://aka.ms/customizecontainer to learn how to customize your debug container and how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:7.0 AS base
WORKDIR /app
RUN apt-get update \
	&& apt-get install -y curl
EXPOSE 80

FROM mcr.microsoft.com/dotnet/sdk:7.0 AS build
WORKDIR /src
# Copy and restore dependencies
COPY ["UniforBackend.API/UniforBackend.API.csproj", "UniforBackend.API/"]
COPY ["UniforBackend.DAL/UniforBackend.DAL.csproj", "UniforBackend.DAL/"]
COPY ["UniforBackend.Domain/UniforBackend.Domain.csproj", "UniforBackend.Domain/"]
COPY ["UniforBackend.Service/UniforBackend.Service.csproj", "UniforBackend.Service/"]
RUN dotnet restore "UniforBackend.API/UniforBackend.API.csproj"

COPY . .
WORKDIR "/src/UniforBackend.API"
RUN dotnet build "UniforBackend.API.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "UniforBackend.API.csproj" -c Release -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "UniforBackend.API.dll"]
HEALTHCHECK CMD curl --fail http://localhost:80/healthz || exit
