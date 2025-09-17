# XPTOTel FaleMais API

## Descrição

API para cálculo de tarifas de telefonia com planos FaleMais, implementada em C# (.NET 8) seguindo Clean Architecture, CQRS, autenticação JWT e repositórios in-memory.

---

## Estrutura do Projeto

- **XPTOTel.Domain**: Entidades e interfaces do domínio.
- **XPTOTel.Application**: Serviços e lógica de aplicação.
- **XPTOTel.Infrastructure**: Implementação dos repositórios in-memory.
- **XPTOTel.API**: API REST com autenticação JWT e autorização por roles.
- **tests/XPTOTel.Application.Tests**: Testes unitários com XUnit e Moq.

---

## Requisitos

- [.NET 8 SDK](https://dotnet.microsoft.com/en-us/download/dotnet/8.0)
- Editor de código (Visual Studio, VS Code, Rider, etc.)

---

## Como executar

### 1. Clonar o repositório

```bash
git clone https://seu-repositorio.git
cd XPTOTel
# 2. Restaurar pacotes e compilar
bash

Run
Copy code
dotnet restore
dotnet build
3. Rodar a API
Navegue até a pasta do projeto API e execute:

bash

Run
Copy code
cd src/XPTOTel.API
dotnet run
A API estará disponível em:

https://localhost:5001 (HTTPS)
http://localhost:5000 (HTTP)
Endpoints principais
Autenticação
POST /api/auth/login

Body JSON:

json
4 lines
Copy code
Download code

{
"username": "admin",
...
Retorna token JWT para usar nos demais endpoints.

Cálculo de tarifa
POST /api/calculo

Header:


Run
Copy code
Authorization: Bearer {token}
Body JSON:

json
6 lines
Copy code
Download code

{
"origemDDD": "011",
...
Retorna:

json
4 lines
Copy code
Download code

{
"comFaleMais": 0,
...
Testes
1. Navegar até a pasta de testes
bash

Run
Copy code
cd tests/XPTOTel.Application.Tests
2. Rodar os testes
bash

Run
Copy code
dotnet test
Você verá o resultado dos testes no console.

Configurações importantes
A chave secreta JWT está configurada no Program.cs (exemplo: "SuaChaveSecretaSuperSecreta123!").
Em produção, use variáveis de ambiente ou appsettings.json para armazenar com segurança.

Os repositórios são in-memory, ou seja, os dados não persistem após reiniciar a aplicação.

Usuários, planos e tarifas podem ser pré-cadastrados no startup para facilitar testes.

Como adicionar usuários e planos para teste
No Program.cs ou em um serviço de inicialização, você pode adicionar dados assim:

csharp
9 lines
Copy code
Download code

var userRepo = app.Services.GetRequiredService<IUser Repository>();
await userRepo.AddAsync(new User("admin", "senha", UserRole.Admin));
...
Referências
Documentação .NET 8
Autenticação JWT no ASP.NET Core
XUnit
Moq
