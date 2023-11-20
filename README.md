# Nome da Aplicação API

Esta API foi desenvolvida utilizando ASP.NET Core 7 e segue a arquitetura DDD para implementar um CRUD de usuário, utilizando autenticação JWT. 
Conta também com interfaces e injeção de dependência para facilitar a manutenção e testabilidade do código.

## Estrutura do Projeto

A estrutura do projeto é organizada da seguinte forma:

- **/src**
  - **/Api**: Contém os controllers e configurações da API.
  - **/Application**: Lógica de aplicação, serviços e mapeamento de DTOs.
  - **/Domain**: Modelos de domínio, entidades e repositórios.
  - **/Infrastructure**: Implementação de infraestrutura, acesso a dados e autenticação.
  - **/Tests**: Testes unitários utilizando XUnit.

## Configuração

### Requisitos

- ASP.NET Core 7 SDK
- Banco de dados SQL Server

### Configuração do Banco de Dados

1. Configure a string de conexão com o banco de dados no arquivo `appsettings.json`.
2. Execute as migrações para criar o esquema do banco de dados:

   ```bash
   dotnet ef database update
