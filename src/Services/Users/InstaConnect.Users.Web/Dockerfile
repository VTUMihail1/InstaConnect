#See https://aka.ms/customizecontainer to learn how to customize your debug container and how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:7.0 AS base
WORKDIR /app
EXPOSE 5200
EXPOSE 5201

FROM mcr.microsoft.com/dotnet/sdk:7.0 AS build
ARG BUILD_CONFIGURATION=Release
WORKDIR /src
COPY ["InstaConnect.Users.Web/InstaConnect.Users.Web.csproj", "InstaConnect.Users.Web/"]
COPY ["InstaConnect.Shared.Web/InstaConnect.Shared.Web.csproj", "InstaConnect.Shared.Web/"]
COPY ["InstaConnect.Users.Business/InstaConnect.Users.Business.csproj", "InstaConnect.Users.Business/"]
COPY ["InstaConnect.Shared.Business/InstaConnect.Shared.Business.csproj", "InstaConnect.Shared.Business/"]
COPY ["InstaConnect.Shared.Data/InstaConnect.Shared.Data.csproj", "InstaConnect.Shared.Data/"]
COPY ["InstaConnect.Users.Data/InstaConnect.Users.Data.csproj", "InstaConnect.Users.Data/"]
RUN dotnet restore "./InstaConnect.Users.Web/InstaConnect.Users.Web.csproj"
COPY . .
WORKDIR "/src/InstaConnect.Users.Web"
RUN dotnet build "./InstaConnect.Users.Web.csproj" -c $BUILD_CONFIGURATION -o /app/build

FROM build AS publish
ARG BUILD_CONFIGURATION=Release
RUN dotnet publish "./InstaConnect.Users.Web.csproj" -c $BUILD_CONFIGURATION -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "InstaConnect.Users.Web.dll"]