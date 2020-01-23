
# we use ARGS here because they can be overriden for 'docker build' 

FROM mcr.microsoft.com/dotnet/core/aspnet:3.1 AS base
WORKDIR /app
EXPOSE 80

FROM mcr.microsoft.com/dotnet/core/sdk:3.1 as dotnet-build
WORKDIR /src

FROM dotnet-build as publish
WORKDIR /src
COPY . .

ARG BUILD_VERBOSITY=quiet
ARG BUILD_CONFIGURATION=Release

RUN chmod +x ./cli-linux/build-inside-docker.sh
RUN ./cli-linux/build-inside-docker.sh $BUILD_VERBOSITY $BUILD_CONFIGURATION

FROM base AS final

WORKDIR /app
COPY --from=publish /app .
ENTRYPOINT ["dotnet", "Sample.Web.dll"]
