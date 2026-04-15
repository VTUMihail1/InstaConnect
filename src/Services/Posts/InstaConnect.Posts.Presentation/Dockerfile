# See https://aka.ms/customizecontainer to learn how to customize your debug container and how Visual Studio uses this Dockerfile to build your images for faster debugging.

# This stage is used when running from VS in fast mode (Default for Debug configuration)
FROM mcr.microsoft.com/dotnet/aspnet:10.0 AS base
USER $APP_UID
WORKDIR /app
EXPOSE 8080
EXPOSE 8081


# This stage is used to build the service project
FROM mcr.microsoft.com/dotnet/sdk:10.0 AS build
ENV ASPNETCORE_ENVIRONMENT=Docker
ARG BUILD_CONFIGURATION=Release
WORKDIR /src
COPY ["Directory.Packages.props", "."]
COPY ["Directory.Build.props", "."]
COPY ["src/Services/Posts/InstaConnect.Posts.Presentation/InstaConnect.Posts.Presentation.csproj", "src/Services/Posts/InstaConnect.Posts.Presentation/"]
COPY ["src/Common/InstaConnect.Common.Presentation/InstaConnect.Common.Presentation.csproj", "src/Common/InstaConnect.Common.Presentation/"]
COPY ["src/Common/InstaConnect.Common.Application/InstaConnect.Common.Application.csproj", "src/Common/InstaConnect.Common.Application/"]
COPY ["src/Common/InstaConnect.Common.Domain/InstaConnect.Common.Domain.csproj", "src/Common/InstaConnect.Common.Domain/"]
COPY ["src/Common/InstaConnect.Common.Events/InstaConnect.Common.Events.csproj", "src/Common/InstaConnect.Common.Events/"]
COPY ["src/Common/InstaConnect.Common.Infrastructure/InstaConnect.Common.Infrastructure.csproj", "src/Common/InstaConnect.Common.Infrastructure/"]
COPY ["src/Services/Posts/InstaConnect.Posts.Application/InstaConnect.Posts.Application.csproj", "src/Services/Posts/InstaConnect.Posts.Application/"]
COPY ["src/Services/Posts/InstaConnect.Posts.Domain/InstaConnect.Posts.Domain.csproj", "src/Services/Posts/InstaConnect.Posts.Domain/"]
COPY ["src/Services/Posts/InstaConnect.Posts.Events/InstaConnect.Posts.Events.csproj", "src/Services/Posts/InstaConnect.Posts.Events/"]
COPY ["src/Services/Identity/InstaConnect.Identity.Events/InstaConnect.Identity.Events.csproj", "src/Services/Identity/InstaConnect.Identity.Events/"]
COPY ["src/Services/Posts/InstaConnect.Posts.Infrastructure/InstaConnect.Posts.Infrastructure.csproj", "src/Services/Posts/InstaConnect.Posts.Infrastructure/"]
RUN dotnet restore "./src/Services/Posts/InstaConnect.Posts.Presentation/InstaConnect.Posts.Presentation.csproj"
COPY . .
WORKDIR "/src/src/Services/Posts/InstaConnect.Posts.Presentation"
RUN dotnet build "./InstaConnect.Posts.Presentation.csproj" -c $BUILD_CONFIGURATION -o /app/build

# This stage is used to publish the service project to be copied to the final stage
FROM build AS publish
ARG BUILD_CONFIGURATION=Release
RUN dotnet publish "./InstaConnect.Posts.Presentation.csproj" -c $BUILD_CONFIGURATION -o /app/publish /p:UseAppHost=false

# This stage is used in production or when running from VS in regular mode (Default when not using the Debug configuration)
FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "InstaConnect.Posts.Presentation.dll"]
