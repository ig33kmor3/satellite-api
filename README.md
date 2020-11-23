# SatelliteAPI Demo Application

## Docker

```bash
docker build -t satellite-api:1.0.0 . 
docker run -p 5000:5000 satellite-api:1.0.0
```

```dockerfile
FROM mcr.microsoft.com/dotnet/core/sdk:3.1 AS build-env
WORKDIR /app

# Copy csproj and restore as distinct layers
COPY src/SatelliteApi/*.csproj ./
RUN dotnet restore

# Copy everything else and build
COPY src/SatelliteApi ./
RUN dotnet publish -c Release -o out
RUN ls -la /app/out/*

# Build runtime image
FROM mcr.microsoft.com/dotnet/core/aspnet:3.1
WORKDIR /app
COPY --from=build-env /app/out .
ENTRYPOINT ["dotnet", "SatelliteApi.dll"]
EXPOSE 5000/tcp
```

## Initial Project Setup
```bash
mkdir SatelliteApi
mkdir {src,test}
dotnet new webapi -n SatelliteApi --no-https
dotnet new xunit -n SatelliteApi.Tests
dotnet new sln --name SatelliteApi
dotnet sln SatelliteApi.sln add src/SatelliteApi/SatelliteApi.csproj test/SatelliteApi.Tests/SatelliteApi.Tests.csproj
dotnet add test/SatelliteApi.Tests/SatelliteApi.Tests.csproj reference src/SatelliteApi/SatelliteApi.csproj
```