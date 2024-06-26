#See https://aka.ms/customizecontainer to learn how to customize your debug container and how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS base
WORKDIR /app
EXPOSE 5300
EXPOSE 80

FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
ARG BUILD_CONFIGURATION=Release
WORKDIR /src
COPY ["src/Services/Posts/InstaConnect.Posts.Web/InstaConnect.Posts.Web.csproj", "src/Services/Posts/InstaConnect.Posts.Web/"]
COPY ["src/Services/Shared/InstaConnect.Shared.Web/InstaConnect.Shared.Web.csproj", "src/Services/Shared/InstaConnect.Shared.Web/"]
COPY ["src/Services/Shared/InstaConnect.Shared.Business/InstaConnect.Shared.Business.csproj", "src/Services/Shared/InstaConnect.Shared.Business/"]
COPY ["src/Services/Shared/InstaConnect.Shared.Data/InstaConnect.Shared.Data.csproj", "src/Services/Shared/InstaConnect.Shared.Data/"]
COPY ["src/Services/Posts/InstaConnect.Posts.Business/InstaConnect.Posts.Business.csproj", "src/Services/Posts/InstaConnect.Posts.Business/"]
COPY ["src/Services/Posts/InstaConnect.Posts.Data/InstaConnect.Posts.Data.csproj", "src/Services/Posts/InstaConnect.Posts.Data/"]
RUN dotnet restore "./src/Services/Posts/InstaConnect.Posts.Web/InstaConnect.Posts.Web.csproj"
COPY . .
WORKDIR "/src/src/Services/Posts/InstaConnect.Posts.Web"
RUN dotnet build "./InstaConnect.Posts.Web.csproj" -c $BUILD_CONFIGURATION -o /app/build

FROM build AS publish
ARG BUILD_CONFIGURATION=Release
RUN dotnet publish "./InstaConnect.Posts.Web.csproj" -c $BUILD_CONFIGURATION -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "InstaConnect.Posts.Web.dll"]