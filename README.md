![example workflow](https://github.com/viiparente/DevReviews/actions/workflows/build.yml/badge.svg)

# DevReviews - Jornada .NET Direto ao Ponto
Foi desenvolvida uma API REST completa em .NET de gerenciamento de produtos e suas avaliações de um e-Commerce.

## Tecnologias e práticas utilizadas
* ASP.NET Core com .NET 5
* Entity Framework Core
* Azure SQL Server
* Swagger
* AutoMapper
* Injeção de Dependência
* Programação Orientada a Objetos
* Padrão Repository
* Logs com Serilog
* Publicação na nuvem com Azure App Service

## Funcionalidades
* Cadastro, Listagem, Detalhes, Atualização e Remoção de Produto.
* Cadastro e Detalhes de uma avaliação


## Build, EF Core Migrations using CLI and Run

```console
dotnet restore
```
```console
dotnet build --no-restore
```
```console
dotnet ef migrations add InitialMigration -o Persistence/Migrations
```
```console
dotnet ef database update
```
```console
dotnet run --project ./DevReviews.API/DevReviews.API.csproj
```

##

Ministrado pelo instrutor [Luis Felipe](https://www.linkedin.com/in/luisdeol/)
