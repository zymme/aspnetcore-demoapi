FROM microsoft/aspnetcore-build:2.0 AS build-env
WORKDIR /app

MAINTAINER dave.zimmer@viawest.com

# Copy csproj and restore as distinct layers
COPY *.csproj ./
RUN dotnet restore

EXPOSE 5010

# Build runtime image
FROM microsoft/aspnetcore:2.0
WORKDIR /app

COPY --from=build-env /app/out .
ENTRYPOINT ["dotnet", "demoapi.dll"]