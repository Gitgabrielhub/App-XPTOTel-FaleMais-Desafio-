# XPTOTel FaleMais API

## Descri��o

API para c�lculo de tarifas de telefonia com planos FaleMais, implementada em C# (.NET 8) seguindo Clean Architecture, CQRS, autentica��o JWT e reposit�rios in-memory.

---

## Estrutura do Projeto

- **XPTOTel.Domain**: Entidades e interfaces do dom�nio.
- **XPTOTel.Application**: Servi�os e l�gica de aplica��o.
- **XPTOTel.Infrastructure**: Implementa��o dos reposit�rios in-memory.
- **XPTOTel.API**: API REST com autentica��o JWT e autoriza��o por roles.
- **tests/XPTOTel.Application.Tests**: Testes unit�rios com XUnit e Moq.

---

## Requisitos

- [.NET 8 SDK](https://dotnet.microsoft.com/en-us/download/dotnet/8.0)
- Editor de c�digo (Visual Studio, VS Code, Rider, etc.)

---

## Como executar

### 1. Clonar o reposit�rio

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
Navegue at� a pasta do projeto API e execute:

bash

Run
Copy code
cd src/XPTOTel.API
dotnet run
A API estar� dispon�vel em:

https://localhost:5001 (HTTPS)
http://localhost:5000 (HTTP)
Endpoints principais
Autentica��o
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

C�lculo de tarifa
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
1. Navegar at� a pasta de testes
bash

Run
Copy code
cd tests/XPTOTel.Application.Tests
2. Rodar os testes
bash

Run
Copy code
dotnet test
Voc� ver� o resultado dos testes no console.

Configura��es importantes
A chave secreta JWT est� configurada no Program.cs (exemplo: "SuaChaveSecretaSuperSecreta123!").
Em produ��o, use vari�veis de ambiente ou appsettings.json para armazenar com seguran�a.

Os reposit�rios s�o in-memory, ou seja, os dados n�o persistem ap�s reiniciar a aplica��o.

Usu�rios, planos e tarifas podem ser pr�-cadastrados no startup para facilitar testes.

Como adicionar usu�rios e planos para teste
No Program.cs ou em um servi�o de inicializa��o, voc� pode adicionar dados assim:

csharp
9 lines
Copy code
Download code

var userRepo = app.Services.GetRequiredService<IUser Repository>();
await userRepo.AddAsync(new User("admin", "senha", UserRole.Admin));
...
Refer�ncias
Documenta��o .NET 8
Autentica��o JWT no ASP.NET Core
XUnit
Moq
Contato
Para d�vidas ou sugest�es, abra uma issue no reposit�rio ou envie um e-mail para: seu.email@exemplo.com

