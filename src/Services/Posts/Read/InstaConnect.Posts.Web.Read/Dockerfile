#See https://aka.ms/customizecontainer to learn how to customize your debug container and how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS base
USER app
WORKDIR /app
EXPOSE 8080
EXPOSE 8081

FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
ARG BUILD_CONFIGURATION=Release
WORKDIR /src
COPY ["src/Services/Posts/Read/InstaConnect.Posts.Web.Read/InstaConnect.Posts.Web.Read.csproj", "src/Services/Posts/Read/InstaConnect.Posts.Web.Read/"]
COPY ["src/Services/Shared/InstaConnect.Shared.Web/InstaConnect.Shared.Web.csproj", "src/Services/Shared/InstaConnect.Shared.Web/"]
COPY ["src/Services/Shared/InstaConnect.Shared.Business/InstaConnect.Shared.Business.csproj", "src/Services/Shared/InstaConnect.Shared.Business/"]
COPY ["src/Services/Shared/InstaConnect.Shared.Data/InstaConnect.Shared.Data.csproj", "src/Services/Shared/InstaConnect.Shared.Data/"]
COPY ["src/Services/Posts/Read/InstaConnect.Posts.Business.Read/InstaConnect.Posts.Business.Read.csproj", "src/Services/Posts/Read/InstaConnect.Posts.Business.Read/"]
COPY ["src/Services/Posts/Read/InstaConnect.Posts.Data.Read/InstaConnect.Posts.Data.Read.csproj", "src/Services/Posts/Read/InstaConnect.Posts.Data.Read/"]
RUN dotnet restore "./src/Services/Posts/Read/InstaConnect.Posts.Web.Read/InstaConnect.Posts.Web.Read.csproj"
COPY . .
WORKDIR "/src/src/Services/Posts/Read/InstaConnect.Posts.Web.Read"
RUN dotnet build "./InstaConnect.Posts.Web.Read.csproj" -c $BUILD_CONFIGURATION -o /app/build

FROM build AS publish
ARG BUILD_CONFIGURATION=Release
RUN dotnet publish "./InstaConnect.Posts.Web.Read.csproj" -c $BUILD_CONFIGURATION -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "InstaConnect.Posts.Web.Read.dll"]