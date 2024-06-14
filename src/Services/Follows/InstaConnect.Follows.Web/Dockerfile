#See https://aka.ms/customizecontainer to learn how to customize your debug container and how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS base
USER app
WORKDIR /app
EXPOSE 5500
EXPOSE 80

FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
ARG BUILD_CONFIGURATION=Release
WORKDIR /src
COPY ["src/Services/Follows/InstaConnect.Follows.Web/InstaConnect.Follows.Web.csproj", "src/Services/Follows/InstaConnect.Follows.Web/"]
COPY ["src/Services/Shared/InstaConnect.Shared.Web/InstaConnect.Shared.Web.csproj", "src/Services/Shared/InstaConnect.Shared.Web/"]
COPY ["src/Services/Shared/InstaConnect.Shared.Business/InstaConnect.Shared.Business.csproj", "src/Services/Shared/InstaConnect.Shared.Business/"]
COPY ["src/Services/Shared/InstaConnect.Shared.Data/InstaConnect.Shared.Data.csproj", "src/Services/Shared/InstaConnect.Shared.Data/"]
COPY ["src/Services/Follows/InstaConnect.Follows.Business/InstaConnect.Follows.Business.csproj", "src/Services/Follows/InstaConnect.Follows.Business/"]
COPY ["src/Services/Follows/InstaConnect.Follows.Data/InstaConnect.Follows.Data.csproj", "src/Services/Follows/InstaConnect.Follows.Data/"]
RUN dotnet restore "./src/Services/Follows/InstaConnect.Follows.Web/InstaConnect.Follows.Web.csproj"
COPY . .
WORKDIR "/src/src/Services/Follows/InstaConnect.Follows.Web"
RUN dotnet build "./InstaConnect.Follows.Web.csproj" -c $BUILD_CONFIGURATION -o /app/build

FROM build AS publish
ARG BUILD_CONFIGURATION=Release
RUN dotnet publish "./InstaConnect.Follows.Web.csproj" -c $BUILD_CONFIGURATION -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "InstaConnect.Follows.Web.dll"]