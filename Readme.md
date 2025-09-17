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


git clone https://seu-repositorio.git
cd XPTOTel
dotnet run

