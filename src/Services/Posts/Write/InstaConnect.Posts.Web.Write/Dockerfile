#See https://aka.ms/customizecontainer to learn how to customize your debug container and how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS base
USER app
WORKDIR /app
EXPOSE 5300
EXPOSE 80

FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
ARG BUILD_CONFIGURATION=Release
WORKDIR /src
COPY ["Services/Posts/Write/InstaConnect.Posts.Web.Write/InstaConnect.Posts.Web.Write.csproj", "Services/Posts/Write/InstaConnect.Posts.Web.Write/"]
COPY ["Services/Shared/InstaConnect.Shared.Web/InstaConnect.Shared.Web.csproj", "Services/Shared/InstaConnect.Shared.Web/"]
COPY ["Services/Shared/InstaConnect.Shared.Business/InstaConnect.Shared.Business.csproj", "Services/Shared/InstaConnect.Shared.Business/"]
COPY ["Services/Shared/InstaConnect.Shared.Data/InstaConnect.Shared.Data.csproj", "Services/Shared/InstaConnect.Shared.Data/"]
COPY ["Services/Posts/Write/InstaConnect.Posts.Business.Write/InstaConnect.Posts.Business.Write.csproj", "Services/Posts/Write/InstaConnect.Posts.Business.Write/"]
COPY ["Services/Posts/Write/InstaConnect.Posts.Data.Write/InstaConnect.Posts.Data.Write.csproj", "Services/Posts/Write/InstaConnect.Posts.Data.Write/"]
RUN dotnet restore "./Services/Posts/Write/InstaConnect.Posts.Web.Write/InstaConnect.Posts.Web.Write.csproj"
COPY . .
WORKDIR "/src/Services/Posts/Write/InstaConnect.Posts.Web.Write"
RUN dotnet build "./InstaConnect.Posts.Web.Write.csproj" -c $BUILD_CONFIGURATION -o /app/build

FROM build AS publish
ARG BUILD_CONFIGURATION=Release
RUN dotnet publish "./InstaConnect.Posts.Web.Write.csproj" -c $BUILD_CONFIGURATION -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "InstaConnect.Posts.Web.Write.dll"]