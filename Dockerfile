# Runtime image
FROM mcr.microsoft.com/dotnet/aspnet:8.0-alpine AS base
WORKDIR /app
EXPOSE 8080

# Build stage
FROM mcr.microsoft.com/dotnet/sdk:8.0-alpine AS build
WORKDIR /src

# Copy solution and project files
COPY *.sln .
COPY LISWebApp/*.csproj LISWebApp/
COPY LISWebApp.Tests/*.csproj LISWebApp.Tests/

# Restore all projects
RUN dotnet restore

# Copy everything
COPY . .

# Build and publish
WORKDIR /src/LISWebApp
RUN dotnet publish -c Release -o /app/publish

# Final image
FROM base AS final
WORKDIR /app
COPY --from=build /app/publish .
ENTRYPOINT ["dotnet", "LISWebApp.dll"]
