#See https://aka.ms/customizecontainer to learn how to customize your debug container and how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:7.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:7.0 AS build
ARG BUILD_CONFIGURATION=Release
WORKDIR /src
COPY ["InstaConnect.Posts.Web/InstaConnect.Posts.Web.csproj", "InstaConnect.Posts.Web/"]
COPY ["InstaConnect.Posts.Business/InstaConnect.Posts.Business.csproj", "InstaConnect.Posts.Business/"]
COPY ["InstaConnect.Posts.Data/InstaConnect.Posts.Data.csproj", "InstaConnect.Posts.Data/"]
COPY ["InstaConnect.Shared.Data/InstaConnect.Shared.Data.csproj", "InstaConnect.Shared.Data/"]
COPY ["InstaConnect.Shared.Business/InstaConnect.Shared.Business.csproj", "InstaConnect.Shared.Business/"]
COPY ["InstaConnect.Shared.Web/InstaConnect.Shared.Web.csproj", "InstaConnect.Shared.Web/"]
COPY ["InstaConnect.Users.Business/InstaConnect.Users.Business.csproj", "InstaConnect.Users.Business/"]
COPY ["InstaConnect.Users.Data/InstaConnect.Users.Data.csproj", "InstaConnect.Users.Data/"]
RUN dotnet restore "./InstaConnect.Posts.Web/InstaConnect.Posts.Web.csproj"
COPY . .
WORKDIR "/src/InstaConnect.Posts.Web"
RUN dotnet build "./InstaConnect.Posts.Web.csproj" -c $BUILD_CONFIGURATION -o /app/build

FROM build AS publish
ARG BUILD_CONFIGURATION=Release
RUN dotnet publish "./InstaConnect.Posts.Web.csproj" -c $BUILD_CONFIGURATION -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "InstaConnect.Posts.Web.dll"]