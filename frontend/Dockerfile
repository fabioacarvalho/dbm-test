FROM mcr.microsoft.com/dotnet/sdk:8.0 AS dev
WORKDIR /app

COPY frontend.csproj ./
RUN dotnet restore

COPY . ./

EXPOSE 80

ENTRYPOINT ["dotnet", "watch", "run", "--urls", "http://0.0.0.0:80"]