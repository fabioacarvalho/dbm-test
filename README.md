# Estrutura do Projeto

O projeto está dividido em modulos sendo eles:

- backend: Contém os arquivos do projeto back-end em ASP .NET Core Web API;
- frontend: Desenvolvimento do projeto front-end;
- server: Contém pré configurações do Nginx.

<br>

```bash
.
├── backend
│   ├── Dbm
│   │   ├── Api
│   │   │   └── Products
│   │   │       ├── Controllers
│   │   │       │   └── ProductController.cs
│   │   │       ├── Dtos
│   │   │       │   ├── ProductDetailResponse.cs
│   │   │       │   ├── ProductRequest.cs
│   │   │       │   └── ProductSummaryResponse.cs
│   │   │       ├── Mappers
│   │   │       │   ├── IProductMapper.cs
│   │   │       │   └── ProductMapper.cs
│   │   │       ├── Services
│   │   │       │   ├── IProductService.cs
│   │   │       │   └── ProductService.cs
│   │   │       └── Validators
│   │   │           └── ProductRequestValidator.cs
│   │   ├── Core
│   │   │   ├── Config
│   │   │   │   ├── Databaseconfig.cs
│   │   │   │   ├── DocumentationConfig.cs
│   │   │   │   ├── MappersConfig.cs
│   │   │   │   ├── RepositoriesConfig.cs
│   │   │   │   ├── ServicesConfig.cs
│   │   │   │   └── ValidatorsConfig.cs
│   │   │   ├── Data
│   │   │   │   ├── Contexts
│   │   │   │   │   └── DbmDbContext.cs
│   │   │   │   └── EntityConfigs
│   │   │   │       └── ProductEntityConfig.cs
│   │   │   ├── Models
│   │   │   │   └── Product.cs
│   │   │   └── Repositories
│   │   │       ├── ICrudRepository.cs
│   │   │       └── Products
│   │   │           ├── IProductRepository.cs
│   │   │           └── ProductRepository.cs
│   │   ├── Dbm.csproj
│   │   ├── Dbm.http
│   │   ├── Dockerfile
│   │   ├── Migrations
│   │   │   ├── 20250208122155_CreateProductTable.Designer.cs
│   │   │   ├── 20250208122155_CreateProductTable.cs
│   │   │   └── DbmDbContextModelSnapshot.cs
│   │   ├── Program.cs
│   │   ├── Properties
│   │   │   └── launchSettings.json
│   │   ├── appsettings.Development.json
│   │   └── appsettings.json
│   ├── README.md
│   └── backend.sln
├── db
├── docker-compose.yaml
├── frontend
│   └── Dockerfile
└── server
    ├── Dockerfile
    ├── README.md
    └── nginx.conf
```

<br>

## Imagens Docker

- Backend: [DockerHub Image Backend](https://hub.docker.com/r/ofabioacarvalho/dbm-api)
- Frontend: [DockerHub Image Frontend](https://hub.docker.com/r/ofabioacarvalho/dbm-frontend)

<br>

## Backend

O back-end está divido da seguinte forma:

### Core
Dentro da pasta `/Core` contém todos os arquivos principais da aplição, como:

- __Config:__ Contém todas as configurações padrão do projeto, todos os `*Config.cs` seguem um padrão de nomenclatura e são importados dentro do `Program.cs`.
- __Data:__ Contém os contexts e os Entity configs, ou seja, tudo que está relacionado com a camada de dados da aplicação.
- __Models:__ Contém os modelos da aplicação.
- __Repositories:__ Contém os arquivos de comunicação e interfaces para implementação dos métodos CRUD.

> Toda implementação deve ser realizada de forma a desacoplar a core da aplicação sendo desenvolvida uma interface e sua implementação separada, utilizando assim os conceitos do SOLID.

<br>

### Api

Contém todos os itens que são relacionados a camada de API da aplicação. Dentro de cada camada teremos a seguinte estrutura padrão a ser implementada:

```bash
Api
└── Modelo
    ├── Controllers
    │   └── *Controller.cs
    ├── Dtos
    │   ├── *DetailResponse.cs*
    │   ├── *Resquest.cs
    │   └── *SummaryResponse.cs
    ├── Mappers
    │   ├── I*Mapper.cs
    │   └── *Mapper.cs
    ├── Services
    │   ├── I*Service.cs
    │   └── *Service.cs
    └──  Validators
        └── *ResquestValidator.cs
```

> Substitua o * pelo nome do seu modelo como por exemplo ProdutoController.cs
> Os itens que começam com `I**.cs` representam as interfaces do objeto. 

<br>

---


# Alguns comandos importantes

Para iniciar o projeto basta rodar o seguinte comando abaixo:

```bash
docker compose up --build
```

> Este comando vai gerar o build do projeto e subir a aplicação, para rodar novamente basta remover a flag --build do comando.

---

# Documentação da API

Para ter acesso a documentação da API, rode a aplicação atráves do container Docker já configurado e acesso o link:

[Documentação API com Swagger](http://127.0.0.1:8000/swagger)

> Observação: A aplicação está rodando na porta 8000 ao inves da 5000 exposta do container, ou seja, ao acessar a aplicação, lembre-se de acessar pela porta 8000 `127.0.0.1:8000`.