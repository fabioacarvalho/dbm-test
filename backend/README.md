## Estrutura do Projeto

### Core

A concentração dos arquivos do projeto está dentro da pasta `Core`;

### Data

Dentro desta pasta deverá conter todos os arquivos e configurações relacionadas a dados e banco de dados, tal como `Contexts`, `Entitys` e `Migrations`.

### Models

Todos os nossos modelos deverão ser organizados dentro desta pasta.

### Repositories



### Config

Será a pasta onde contém nosso arquivo de configuração com o banco de dados, onde é importado dentro de `Program.cs` como `builder.Services.RegisterDatabase();`.

## Comandos importantes

- Iniciar o projeto <br>

```bash
dotnet watch
```

<br>

- Rodar o migrations <br>

```bash
dotnet ef migrations add Create_SEU_MODELO_Table
```

<br>

> Se prefirir adicionar suas migrations em outro local adicioner uma flag `-o` no comando passando o caminho, por exemplo `-o Core\Data\Migrations`, isso serve para manter o projeto organizado dentro da pasta que desejar.
<br>

Se você quiser remover as migrations rode:

```bash
dotnet ef migrations remove
```

<br>

Agora para aplicar as migrações rode o comando:

```bash
dotnet ef database update
```

<br>

