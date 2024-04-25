#See https://aka.ms/customizecontainer to learn how to customize your debug container and how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS base
WORKDIR /app
EXPOSE 80

FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
ARG BUILD_CONFIGURATION=Release
WORKDIR /src
COPY ["src/dotnet-app/UniversityBookShop.Api/UniversityBookShop.Api.csproj", "src/dotnet-app/UniversityBookShop.Api/"]
COPY ["src/dotnet-app/UniversityBookShop.Application/UniversityBookShop.Application.csproj", "src/dotnet-app/UniversityBookShop.Application/"]
COPY ["src/dotnet-app/UniversityBookShop.Domain/UniversityBookShop.Domain.csproj", "src/dotnet-app/UniversityBookShop.Domain/"]
COPY ["src/dotnet-app/UniversityBookShop.Persistence/UniversityBookShop.Persistence.csproj", "src/dotnet-app/UniversityBookShop.Persistence/"]
RUN dotnet restore "./src/dotnet-app/UniversityBookShop.Api/UniversityBookShop.Api.csproj"
COPY . .
WORKDIR "/src/src/dotnet-app/UniversityBookShop.Api"
RUN dotnet build "./UniversityBookShop.Api.csproj" -c $BUILD_CONFIGURATION -o /app/build

FROM build AS publish
ARG BUILD_CONFIGURATION=Release
RUN dotnet publish "./UniversityBookShop.Api.csproj" -c $BUILD_CONFIGURATION -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "UniversityBookShop.Api.dll"]