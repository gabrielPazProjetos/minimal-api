--- Minimal API - CRUD com Autenticação JWT (FORK)
Este projeto é uma API minimalista em ASP.NET Core que implementa autenticação via JWT, validação de dados e operações CRUD para veículos e administradores.

--- Tecnologias Utilizadas
- ASP.NET Core 7+
- Entity Framework Core
- MySQL
- JWT (JSON Web Token)
- C#

--- Autenticação
A autenticação é feita via JWT. Apenas administradores autenticados com perfil válido podem acessar os endpoints protegidos.

-- Perfis disponíveis:
- Adm
- Editor

--- Funcionalidades
-- Administrador
POST /login → Autentica e retorna token
POST /administradores → Cria novo administrador
GET /administradores → Lista administradores (paginado)
GET /administradores/{id} → Busca por ID

-- Veículo
POST /veiculos → Cria novo veículo
GET /veiculos → Lista veículos (paginado, com filtro por nome e marca)
GET /veiculos/{id} → Busca por ID
PUT /veiculos/{id} → Atualiza veículo
DELETE /veiculos/{id} → Remove veículo

--- Validação
Todos os DTOs são validados antes de persistência. Erros são retornados em formato padronizado:

json
{
  "mensagens": [
    "O campo Nome é obrigatório.",
    "O campo Ano deve ser maior que zero."
  ]
}
🔧 Configuração
1. Banco de Dados
Configure a string de conexão no appsettings.json:

json
"ConnectionStrings": {
  "MySql": "Server=localhost;Database=MinimalApiDb;User=root;Password=senha;"
}
2. JWT
Configure as chaves no appsettings.json:

json
"Jwt": {
  "Key": "sua-chave-secreta-aqui",
  "Issuer": "MinimalApi",
  "Audience": "MinimalApiUsers"
}

--- Executando o Projeto
- bash
dotnet restore
dotnet ef database update
dotnet run

--- Testes
Testes unitários podem ser adicionados na pasta Testes/Servicos/.
