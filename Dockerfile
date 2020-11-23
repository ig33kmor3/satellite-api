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