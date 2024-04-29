# Readme

## Setup local environment (API+DB)
`docker-compose up --build --force-recreate -d`

## Setup database
## Appsettings for localhost, execute update command in local , remember server must be db when contenerized
Connect to database
## In docker
 "ServerDB": "Server=db;Database=Teatro;Uid=sa;Pwd=<YourStrong@Passw0rd>;TrustServerCertificate=True"
## In local
 "ServerDB": "Server=localhost, 8002;Database=Teatro;Uid=sa;Pwd=<YourStrong@Passw0rd>;TrustServerCertificate=True"

## Migrations folder ,not neccesary already created
dotnet ef migrations add InitialCreate -p .\Data\FlashGamingHub.Data.csproj -s .\API\FlashGamingHub.API.csproj
## Run OnModelCreating very important
dotnet ef database update  -p .\Data\FlashGamingHub.Data.csproj -s .\API\FlashGamingHub.API.csproj
## Drop database only when really is not needed anymore
dotnet ef database drop  -p .\Data\FlashGamingHub.Data.csproj -s .\API\FlashGamingHub.API.csproj

