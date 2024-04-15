#See https://aka.ms/customizecontainer to learn how to customize your debug container and how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS base
USER app
WORKDIR /app
EXPOSE 8080

FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
ARG BUILD_CONFIGURATION=Release
WORKDIR /src
COPY ["dotnet-app/Identity.Api/Identity.Api.csproj", "dotnet-app/Identity.Api/"]
COPY ["dotnet-app/Identity.Persistence/Identity.Persistence.csproj", "dotnet-app/Identity.Persistence/"]
COPY ["dotnet-app/Identity.Domain/Identity.Domain.csproj", "dotnet-app/Identity.Domain/"]
RUN dotnet restore "./dotnet-app/Identity.Api/Identity.Api.csproj"
COPY . .
WORKDIR "/src/dotnet-app/Identity.Api"
RUN dotnet build "./Identity.Api.csproj" -c $BUILD_CONFIGURATION -o /app/build

FROM build AS publish
ARG BUILD_CONFIGURATION=Release
RUN dotnet publish "./Identity.Api.csproj" -c $BUILD_CONFIGURATION -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "Identity.Api.dll"]