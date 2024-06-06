FROM mcr.microsoft.com/dotnet/sdk:7.0 as build
WORKDIR /app
EXPOSE 5500
EXPOSE 5501

# copy all .csproj files and restore as distinct layers.   Use of the same COPY command
# for every dockerfile in the project to take advantage of docker caching
COPY InstaConnect.sln InstaConnect.sln
COPY src/Services/InstaConnect.Users.Web/InstaConnect.Users.Web.csproj src/Services/InstaConnect.Users.Web/InstaConnect.Users.Web.csproj
COPY src/Services/InstaConnect.Users.Business/InstaConnect.Users.Business.csproj src/Services/InstaConnect.Users.Business/InstaConnect.Users.Business.csproj
COPY src/Services/InstaConnect.Users.Data/InstaConnect.Users.Data.csproj src/Services/InstaConnect.Users.Data/InstaConnect.Users.Data.csproj
COPY src/Services/InstaConnect.Posts.Web/InstaConnect.Posts.Web.csproj src/Services/InstaConnect.Posts.Web/InstaConnect.Posts.Web.csproj
COPY src/Services/InstaConnect.Posts.Business/InstaConnect.Posts.Business.csproj src/Services/InstaConnect.Posts.Business/InstaConnect.Posts.Business.csproj
COPY src/Services/InstaConnect.Posts.Data/InstaConnect.Posts.Data.csproj src/Services/InstaConnect.Posts.Data/InstaConnect.Posts.Data.csproj
COPY src/Services/InstaConnect.Messages.Web/InstaConnect.Messages.Web.csproj src/Services/InstaConnect.Messages.Web/InstaConnect.Messages.Web.csproj
COPY src/Services/InstaConnect.Messages.Business/InstaConnect.Messages.Business.csproj src/Services/InstaConnect.Messages.Business/InstaConnect.Messages.Business.csproj
COPY src/Services/InstaConnect.Messages.Data/InstaConnect.Messages.Data.csproj src/Services/InstaConnect.Messages.Data/InstaConnect.Messages.Data.csproj
COPY src/Services/InstaConnect.Follows.Web/InstaConnect.Follows.Web.csproj src/Services/InstaConnect.Follows.Web/InstaConnect.Follows.Web.csproj
COPY src/Services/InstaConnect.Follows.Business/InstaConnect.Follows.Business.csproj src/Services/InstaConnect.Follows.Business/InstaConnect.Follows.Business.csproj
COPY src/Services/InstaConnect.Follows.Data/InstaConnect.Follows.Data.csproj src/Services/InstaConnect.Follows.Data/InstaConnect.Follows.Data.csproj
COPY src/Services/InstaConnect.Gateway.Web/InstaConnect.Gateway.Web.csproj src/Services/InstaConnect.Gateway.Web/InstaConnect.Gateway.Web.csproj

# Restore package deps
RUN dotnet restore InstaConnect.sln

# Copy the app folders over
COPY src/Services/InstaConnect.Follows.Web src/Services/InstaConnect.Follows.Web
COPY src/Services/InstaConnect.Follows.Business src/Services/InstaConnect.Follows.Business
COPY src/Services/InstaConnect.Follows.Data src/Services/InstaConnect.Follows.Data
COPY src/Services/InstaConnect.Shared.Web src/Services/InstaConnect.Shared.Web
COPY src/Services/InstaConnect.Shared.Business src/Services/InstaConnect.Shared.Business
COPY src/Services/InstaConnect.Shared.Data src/Services/InstaConnect.Shared.Data
WORKDIR /app/src/Services/InstaConnect.Posts.Web
RUN dotnet publish -c Release -o /app/src/Services/out

# Build runtime image
FROM mcr.microsoft.com/dotnet/aspnet:7.0
WORKDIR /app
COPY --from=build /app/src/Services/out .
ENTRYPOINT [ "dotnet", "InstaConnect.Follows.Web" ]