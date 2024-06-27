#See https://aka.ms/customizecontainer to learn how to customize your debug container and how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS base
USER app
WORKDIR /app
EXPOSE 5600
EXPOSE 80

FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
ARG BUILD_CONFIGURATION=Release
WORKDIR /src
COPY ["Services/Messages/Write/InstaConnect.Messages.Web.Write/InstaConnect.Messages.Web.Write.csproj", "Services/Messages/Write/InstaConnect.Messages.Web.Write/"]
COPY ["Services/Shared/InstaConnect.Shared.Web/InstaConnect.Shared.Web.csproj", "Services/Shared/InstaConnect.Shared.Web/"]
COPY ["Services/Shared/InstaConnect.Shared.Business/InstaConnect.Shared.Business.csproj", "Services/Shared/InstaConnect.Shared.Business/"]
COPY ["Services/Shared/InstaConnect.Shared.Data/InstaConnect.Shared.Data.csproj", "Services/Shared/InstaConnect.Shared.Data/"]
COPY ["Services/Messages/Write/InstaConnect.Messages.Business.Write/InstaConnect.Messages.Business.Write.csproj", "Services/Messages/Write/InstaConnect.Messages.Business.Write/"]
COPY ["Services/Messages/Write/InstaConnect.Messages.Data.Write/InstaConnect.Messages.Data.Write.csproj", "Services/Messages/Write/InstaConnect.Messages.Data.Write/"]
RUN dotnet restore "./Services/Messages/Write/InstaConnect.Messages.Web.Write/InstaConnect.Messages.Web.Write.csproj"
COPY . .
WORKDIR "/src/Services/Messages/Write/InstaConnect.Messages.Web.Write"
RUN dotnet build "./InstaConnect.Messages.Web.Write.csproj" -c $BUILD_CONFIGURATION -o /app/build

FROM build AS publish
ARG BUILD_CONFIGURATION=Release
RUN dotnet publish "./InstaConnect.Messages.Web.Write.csproj" -c $BUILD_CONFIGURATION -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "InstaConnect.Messages.Web.Write.dll"]