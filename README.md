# SecureAPI_JWT

API REST de autenticação e gerenciamento de usuários construída com C#.NET, Entity Framework Core, MySQL e JWT.  
Este projeto foi desenvolvido como estudo prático e portfólio, demonstrando habilidades de backend, boas práticas e segurança, ideal para quem busca se tornar um grande Desenvolvedor.

---

## 🚀 Tecnologias

- C# / .NET 6  
- Entity Framework Core  
- MySQL  
- JWT (JSON Web Token) para autenticação  
- Swagger (Documentação)  
- HMACSHA512 (Hash seguro de senhas)  
- Visual Studio 2022  

---

## 📌 Funcionalidades

- Registro de usuários com validação de email e senha  
- Login com geração de token JWT  
- Proteção de endpoints com `[Authorize]`  
- Criptografia de senha (Hash + Salt)  
- Documentação Swagger com autenticação Bearer  

---

## ⚙️ Como Rodar o Projeto

- Configure o arquivo `appsettings.Development.json` com seu token JWT e conexão MySQL local:

"AppSettings": {
  "Token": "SUA_CHAVE_SECRETA_AQUI"
},
"ConnectionStrings": {
  "DefaultConnection": "Server=localhost;Database=ProjetoAutenticacaoJWT;Uid=root;Pwd=SUA_SENHA_AQUI"
}

- Atualize o banco de dados com as migrations já incluídas:

dotnet ef database update

- Execute a API:

dotnet run

## 💡 Boas práticas aplicadas

- DTOs para validação e segurança de dados  
- Validações de entrada com `[Required]`, `[EmailAddress]`, `[Compare]`  
- Swagger documentado com autenticação  
- Código organizado por camadas (Context, Models, DTOs, Services, Controllers)  

---

## 🎯 Objetivo do Projeto

Demonstrar habilidades práticas em C#.NET, API REST e segurança.
O projeto evidencia boas práticas em estrutura de código, autenticação segura e documentação de endpoints, servindo como referência de desenvolvimento e aprendizado contínuo.
