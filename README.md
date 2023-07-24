# Satellite API Demo with EKS Pipeline

## API Routes

| Method        | Route                  |
| ---           | ---                    |
| GET -->       | /v1/satellites         |
| GET -->       | /healthcheck           |

## Initial .Net 7 Project Setup
```bash
mkdir SatelliteApi
mkdir {src,test}
dotnet new webapi -n SatelliteApi --no-https
dotnet new xunit -n SatelliteApi.Tests
dotnet new sln --name SatelliteApi
dotnet sln SatelliteApi.sln add src/SatelliteApi/SatelliteApi.csproj test/SatelliteApi.Tests/SatelliteApi.Tests.csproj
dotnet add test/SatelliteApi.Tests/SatelliteApi.Tests.csproj reference src/SatelliteApi/SatelliteApi.csproj
```

## Docker Configuration 

```dockerfile
FROM mcr.microsoft.com/dotnet/sdk:7.0 AS build-env
WORKDIR /app

# Copy csproj and restore as distinct layers
COPY src/SatelliteApi/*.csproj ./
RUN dotnet restore

# Copy everything else and build
COPY src/SatelliteApi ./
RUN dotnet publish -c Release -o out
RUN ls -la /app/out/*

# Build runtime image
FROM mcr.microsoft.com/dotnet/aspnet:7.0
WORKDIR /app
COPY --from=build-env /app/out .
ENTRYPOINT ["dotnet", "SatelliteApi.dll"]
EXPOSE 5000/tcp
```

```bash
docker build -t satellite-api:1.0.0 . 
docker run -p 5298:5298 satellite-api:1.0.0
```
