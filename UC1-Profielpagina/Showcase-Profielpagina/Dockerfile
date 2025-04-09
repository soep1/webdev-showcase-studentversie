FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS base
USER $APP_UID
WORKDIR /app
EXPOSE 8080
EXPOSE 8081

FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
ARG BUILD_CONFIGURATION=Release
WORKDIR /src
COPY ["Showcase-Profielpagina/Showcase-Profielpagina.csproj", "Showcase-Profielpagina/"]
RUN dotnet restore "Showcase-Profielpagina/Showcase-Profielpagina.csproj"
COPY . .
WORKDIR "/src/Showcase-Profielpagina"
RUN dotnet build "Showcase-Profielpagina.csproj" -c $BUILD_CONFIGURATION -o /app/build

FROM build AS publish
ARG BUILD_CONFIGURATION=Release
RUN dotnet publish "Showcase-Profielpagina.csproj" -c $BUILD_CONFIGURATION -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "Showcase-Profielpagina.dll"]
