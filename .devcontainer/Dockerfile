# Use a imagem oficial da Microsoft para .NET Core
FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build-env

# Instale ferramentas adicionais, se necessário
RUN apt-get update && apt-get install -y \
    git \
    curl \
    && rm -rf /var/lib/apt/lists/*

# Defina o diretório de trabalho
WORKDIR /app

# Copie os arquivos do projeto para o contêiner
COPY . .

# Defina o comando padrão para rodar quando o contêiner iniciar
CMD ["bash"]