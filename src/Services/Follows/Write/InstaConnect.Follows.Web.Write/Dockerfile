#See https://aka.ms/customizecontainer to learn how to customize your debug container and how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS base
USER app
WORKDIR /app
EXPOSE 5800
EXPOSE 80

FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
ARG BUILD_CONFIGURATION=Release
WORKDIR /src
COPY ["Services/Follows/Write/InstaConnect.Follows.Web.Write/InstaConnect.Follows.Web.Write.csproj", "Services/Follows/Write/InstaConnect.Follows.Web.Write/"]
COPY ["Services/Shared/InstaConnect.Shared.Web/InstaConnect.Shared.Web.csproj", "Services/Shared/InstaConnect.Shared.Web/"]
COPY ["Services/Shared/InstaConnect.Shared.Business/InstaConnect.Shared.Business.csproj", "Services/Shared/InstaConnect.Shared.Business/"]
COPY ["Services/Shared/InstaConnect.Shared.Data/InstaConnect.Shared.Data.csproj", "Services/Shared/InstaConnect.Shared.Data/"]
COPY ["Services/Follows/Write/InstaConnect.Follows.Business.Write/InstaConnect.Follows.Business.Write.csproj", "Services/Follows/Write/InstaConnect.Follows.Business.Write/"]
COPY ["Services/Follows/Write/InstaConnect.Follows.Data.Write/InstaConnect.Follows.Data.Write.csproj", "Services/Follows/Write/InstaConnect.Follows.Data.Write/"]
RUN dotnet restore "./Services/Follows/Write/InstaConnect.Follows.Web.Write/InstaConnect.Follows.Web.Write.csproj"
COPY . .
WORKDIR "/src/Services/Follows/Write/InstaConnect.Follows.Web.Write"
RUN dotnet build "./InstaConnect.Follows.Web.Write.csproj" -c $BUILD_CONFIGURATION -o /app/build

FROM build AS publish
ARG BUILD_CONFIGURATION=Release
RUN dotnet publish "./InstaConnect.Follows.Web.Write.csproj" -c $BUILD_CONFIGURATION -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "InstaConnect.Follows.Web.Write.dll"]