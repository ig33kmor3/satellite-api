FROM mcr.microsoft.com/dotnet/sdk:7.0-alpine AS build-env
WORKDIR /app

# Copy csproj and restore as distinct layers
COPY src/SatelliteApi/*.csproj ./
RUN dotnet restore

# Copy everything else and build
COPY src/SatelliteApi ./
RUN dotnet publish -c Release -o out
RUN ls -la /app/out/*

# Build runtime image
FROM mcr.microsoft.com/dotnet/aspnet:7.0-alpine
WORKDIR /app
COPY --from=build-env /app/out .
ENV ASPNETCORE_URLS=http://+:5298
ENTRYPOINT ["dotnet", "SatelliteApi.dll"]
EXPOSE 5298/tcp