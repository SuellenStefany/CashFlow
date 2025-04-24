# CashFlow Project

## Descri��o
O **CashFlow Project** � uma aplica��o desenvolvida em .NET 9 que gerencia transa��es financeiras, permitindo a cria��o de entradas de d�bito e cr�dito. A aplica��o utiliza autentica��o JWT para proteger suas rotas, seguindo boas pr�ticas de desenvolvimento com inje��o de depend�ncia e separa��o de responsabilidades.

## Funcionalidades
- **Entradas de D�bito**: Permite criar registros de d�bito.
- **Entradas de Cr�dito**: Permite criar registros de cr�dito.
- **Autentica��o JWT**: Garante que apenas usu�rios autenticados possam acessar as rotas protegidas.

## Tecnologias Utilizadas
- **.NET 9**
- **ASP.NET Core**
- **JWT Authentication**
- **OpenAPI** para documenta��o de APIs
- **xUnit** para testes unit�rios
- **Moq** para mocks em testes

## Pr�-requisitos
Antes de rodar a aplica��o, certifique-se de ter instalado:
- [.NET SDK 9.0](https://dotnet.microsoft.com/download/dotnet/9.0)
- Um editor de c�digo, como o [Visual Studio 2022](https://visualstudio.microsoft.com/)

# Aplica��o Transaction
### Configura��o do Ambiente
1. Clone o reposit�rio:
   ```git clone https://github.com/SuellenStefany/CashFlow.git``` 

   ```cd CashFlow/CashFlow.Transaction```
2. Restaure as depend�ncias:
  ``` dotnet restore CashFlow.Transaction.sln```

3. Configure as vari�veis de ambiente no arquivo `appsettings.json`:
   - Adicione as configura��es de conex�o com o banco de dados.
   - Configure as chaves de autentica��o JWT.

## Executando a Aplica��o Localmente
1. Compile o projeto:
  ``` dotnet build CashFlow.Transaction.sln```
2. Execute a aplica��o:
  ``` dotnet run CashFlow.Transaction.sln```
3. Acesse a aplica��o atrav�s da URL:
   - URL padr�o: [http://localhost:5233](http://localhost:5233)
4. Acesse a documenta��o da API (OpenAPI/Scalar/v1):
   - [http://localhost:5233/scalar/v1](http://localhost:5233/scalar/v1)

## Testes
Para rodar os testes unit�rios:

```cd CashFlow.Transaction.Test```

```dotnet test CashFlow.Transaction.Test.csproj```

# Aplica��o Consolidation
### Configura��o do Ambiente
1. Clone o reposit�rio:
   ```git clone https://github.com/SuellenStefany/CashFlow.git``` 

   ```cd CashFlow/CashFlow.Consolidation```
2. Restaure as depend�ncias:
  ``` dotnet restore CashFlow.Consolidation.sln```

3. Configure as vari�veis de ambiente no arquivo `appsettings.json`:
   - Adicione as configura��es de conex�o com o banco de dados.
   - Configure as chaves de autentica��o JWT.

## Executando a Aplica��o Localmente
1. Compile o projeto:
  ``` dotnet build CashFlow.Consolidation.sln```
2. Execute a aplica��o:
  ``` dotnet run CashFlow.Consolidation.sln```
3. Acesse a aplica��o atrav�s da URL:
   - URL padr�o: [http://localhost:5233](http://localhost:5233)
4. Acesse a documenta��o da API (OpenAPI/Scalar/v1):
   - [http://localhost:5233/scalar/v1](http://localhost:5233/scalar/v1)

## Testes
Para rodar os testes unit�rios:

```cd CashFlow.Consolidation.Test```

```dotnet test CashFlow.Consolidation.Test.csproj```

# Estrutura do Projeto
- **API**: Cont�m os controladores para gerenciar as rotas de d�bito, cr�dito e consolida��o.
- **Application**: Cont�m os servi�os, DTOs e Interfaces utilizadas pela aplica��o.
- **Domain**: Cont�m as entidades e enums.
- **Infrastructure**: Cont�m a l�gica de autentica��o, configura��es de depend�ncias, conex�o com o banco e os repositorios.
- **Tests**: Cont�m os testes unit�rios para os controladores.

## Arquitetura do Projeto
- **DDD**: O projeto foi estruturado seguindo os princ�pios de Domain-Driven Design (DDD), separando as responsabilidades em diferentes camadas.
- **SOLID**: O projeto segue os princ�pios SOLID para garantir um c�digo limpo e de f�cil manuten��o.
- **Melhores Pr�ticas**: O projeto utiliza boas pr�ticas de desenvolvimento, como inje��o de depend�ncia, separa��o de responsabilidades e testes automatizados.

## Arquitetura da Solu��o
<p align="center">
  <img src="./CashFlow/CashFlow.Transaction/Assets/arquitetura.png" width="400">
</p>