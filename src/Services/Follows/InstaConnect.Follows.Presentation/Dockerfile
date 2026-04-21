# See https://aka.ms/customizecontainer to learn how to customize your debug container and how Visual Studio uses this Dockerfile to build your images for faster debugging.

# This stage is used when running from VS in fast mode (Default for Debug configuration)
FROM mcr.microsoft.com/dotnet/aspnet:10.0 AS base
USER $APP_UID
WORKDIR /app
EXPOSE 80


# This stage is used to build the service project
FROM mcr.microsoft.com/dotnet/sdk:10.0 AS build
ARG BUILD_CONFIGURATION=Release
WORKDIR /src
COPY ["Directory.Packages.props", "."]
COPY ["Directory.Build.props", "."]
COPY ["src/Services/Follows/InstaConnect.Follows.Presentation/InstaConnect.Follows.Presentation.csproj", "src/Services/Follows/InstaConnect.Follows.Presentation/"]
COPY ["src/Common/InstaConnect.Common.Presentation/InstaConnect.Common.Presentation.csproj", "src/Common/InstaConnect.Common.Presentation/"]
COPY ["src/Common/InstaConnect.Common.Application/InstaConnect.Common.Application.csproj", "src/Common/InstaConnect.Common.Application/"]
COPY ["src/Common/InstaConnect.Common.Domain/InstaConnect.Common.Domain.csproj", "src/Common/InstaConnect.Common.Domain/"]
COPY ["src/Common/InstaConnect.Common.Events/InstaConnect.Common.Events.csproj", "src/Common/InstaConnect.Common.Events/"]
COPY ["src/Common/InstaConnect.Common.Infrastructure/InstaConnect.Common.Infrastructure.csproj", "src/Common/InstaConnect.Common.Infrastructure/"]
COPY ["src/Services/Follows/InstaConnect.Follows.Application/InstaConnect.Follows.Application.csproj", "src/Services/Follows/InstaConnect.Follows.Application/"]
COPY ["src/Services/Follows/InstaConnect.Follows.Domain/InstaConnect.Follows.Domain.csproj", "src/Services/Follows/InstaConnect.Follows.Domain/"]
COPY ["src/Services/Follows/InstaConnect.Follows.Events/InstaConnect.Follows.Events.csproj", "src/Services/Follows/InstaConnect.Follows.Events/"]
COPY ["src/Services/Identity/InstaConnect.Identity.Events/InstaConnect.Identity.Events.csproj", "src/Services/Identity/InstaConnect.Identity.Events/"]
COPY ["src/Services/Follows/InstaConnect.Follows.Infrastructure/InstaConnect.Follows.Infrastructure.csproj", "src/Services/Follows/InstaConnect.Follows.Infrastructure/"]
RUN dotnet restore "./src/Services/Follows/InstaConnect.Follows.Presentation/InstaConnect.Follows.Presentation.csproj"
COPY . .
WORKDIR "/src/src/Services/Follows/InstaConnect.Follows.Presentation"
RUN dotnet build "./InstaConnect.Follows.Presentation.csproj" -c $BUILD_CONFIGURATION -o /app/build

# This stage is used to publish the service project to be copied to the final stage
FROM build AS publish
ARG BUILD_CONFIGURATION=Release
RUN dotnet publish "./InstaConnect.Follows.Presentation.csproj" -c $BUILD_CONFIGURATION -o /app/publish /p:UseAppHost=false

# This stage is used in production or when running from VS in regular mode (Default when not using the Debug configuration)
FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "InstaConnect.Follows.Presentation.dll"]
