FROM mcr.microsoft.com/dotnet/sdk:5.0 AS build-env
WORKDIR /App

# Copy csproj and restore as distinct layers
COPY ./Album.Api/Album.Api.csproj ./
RUN dotnet restore

# Copy everything else and build
COPY ./Album.Api ./
RUN dotnet publish -c Release -o out

# Build runtime image
FROM mcr.microsoft.com/dotnet/aspnet:5.0
WORKDIR /App
COPY --from=build-env /App/out .
ENTRYPOINT ["dotnet", "Album.Api.dll"]