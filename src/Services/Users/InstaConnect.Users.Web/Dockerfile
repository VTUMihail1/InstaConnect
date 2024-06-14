#See https://aka.ms/customizecontainer to learn how to customize your debug container and how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS base
WORKDIR /app
EXPOSE 5200
EXPOSE 80

FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
ARG BUILD_CONFIGURATION=Release
WORKDIR /src
COPY ["src/Services/Users/InstaConnect.Users.Web/InstaConnect.Users.Web.csproj", "src/Services/Users/InstaConnect.Users.Web/"]
COPY ["src/Services/Shared/InstaConnect.Shared.Web/InstaConnect.Shared.Web.csproj", "src/Services/Shared/InstaConnect.Shared.Web/"]
COPY ["src/Services/Shared/InstaConnect.Shared.Business/InstaConnect.Shared.Business.csproj", "src/Services/Shared/InstaConnect.Shared.Business/"]
COPY ["src/Services/Shared/InstaConnect.Shared.Data/InstaConnect.Shared.Data.csproj", "src/Services/Shared/InstaConnect.Shared.Data/"]
COPY ["src/Services/Users/InstaConnect.Users.Business/InstaConnect.Users.Business.csproj", "src/Services/Users/InstaConnect.Users.Business/"]
COPY ["src/Services/Users/InstaConnect.Users.Data/InstaConnect.Users.Data.csproj", "src/Services/Users/InstaConnect.Users.Data/"]
RUN dotnet restore "./src/Services/Users/InstaConnect.Users.Web/InstaConnect.Users.Web.csproj"
COPY . .
WORKDIR "/src/src/Services/Users/InstaConnect.Users.Web"
RUN dotnet build "./InstaConnect.Users.Web.csproj" -c $BUILD_CONFIGURATION -o /app/build

FROM build AS publish
ARG BUILD_CONFIGURATION=Release
RUN dotnet publish "./InstaConnect.Users.Web.csproj" -c $BUILD_CONFIGURATION -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "InstaConnect.Users.Web.dll"]