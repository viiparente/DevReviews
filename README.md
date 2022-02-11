![example workflow](https://github.com/viiparente/DevReviews/actions/workflows/build.yml/badge.svg)

# DevReviews - Jornada .NET Direto ao Ponto
Foi desenvolvida uma API REST completa em .NET de gerenciamento de produtos e suas avaliações de um e-Commerce.

## Tecnologias e práticas utilizadas
* ASP.NET Core com .NET 6
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


## Executando o projeto em sua maquina local
-  Clone o projeto
```console
git clone https://github.com/viiparente/DevReviews.git
```
Caso não tenha uma instancia local do SQL Server Express, siga o seguinte passo:
 * Abra o arquivo Program.cs 
 * Comente a linha onde tem o UseSqlServer e descomente o UseInMemoryDatabase
 ```cs
//builder.Services.AddDbContext<DevReviewsDbContext>(o => o.UseSqlServer(connectionString));
```
```cs
builder.Services.AddDbContext<DevReviewsDbContext>(o => o.UseInMemoryDatabase("DevReviewsCs"));
```


* Agora vá na pasta onde está o arquivo de solução do projeto (DevReviews.sln) e rode no terminal
```console
dotnet restore
```
```console
dotnet build --no-restore
```
```console
cd .\DevReviews.API\
```
```console
dotnet ef migrations add InitialMigration -o Persistence/Migrations
```
```console
dotnet ef database update
```
```console
dotnet run
```

##

Ministrado pelo instrutor [Luis Felipe](https://www.linkedin.com/in/luisdeol/)
