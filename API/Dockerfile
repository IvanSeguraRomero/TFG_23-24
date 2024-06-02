
FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build

WORKDIR /app

COPY ../API/FlashGamingHub.API.csproj .

RUN dotnet restore

COPY . .

RUN dotnet build -o /app/build ./API/FlashGamingHub.API.csproj

FROM build AS publish

RUN dotnet publish -o /app/publish ./API/FlashGamingHub.API.csproj

FROM mcr.microsoft.com/dotnet/aspnet:6.0 AS final


WORKDIR /app

EXPOSE 80

COPY --from=publish /app/publish .

ENTRYPOINT ["dotnet", "FlashGamingHub.API.dll"]
