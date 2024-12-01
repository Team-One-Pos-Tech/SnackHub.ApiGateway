# SnackHub API Gateway Project

Este projeto é um gateway API que gerencia os serviços da aplicação SnackHub, organizados em microserviços para funcionalidade de pedidos, pagamentos, clientes, produtos e produção. O sistema utiliza Docker para orquestração e dependências como RabbitMQ, MongoDB e PostgreSQL.

## Estrutura do Projeto

- **SnackHub.Gateway**: Gateway API que centraliza as rotas de comunicação entre os microserviços.
- **Microserviços**:
  - `snack-hub-order-app`: Gerencia pedidos.
  - `snack-hub-payment-app`: Gerencia pagamentos.
  - `snack-hub-client-app`: Gerencia informações de clientes.
  - `snack-hub-product-app`: Gerencia produtos.
  - `snack-hub-production-app`: Gerencia produção.
- **Dependências**:
  - `RabbitMQ`: Fila de mensagens para comunicação entre serviços.
  - `MongoDB`: Banco de dados usado por alguns serviços.
  - `PostgreSQL`: Banco de dados usado por outros serviços.

## Tecnologias Utilizadas

- **Docker**: Orquestração de containers.
- **RabbitMQ**: Comunicação entre microserviços.
- **MongoDB e PostgreSQL**: Bancos de dados para armazenamento.
- **ASP.NET Core**: Desenvolvimento dos microserviços e do gateway.

## Pré-requisitos

- Docker e Docker Compose instalados.
- Porta 8080 liberada para comunicação.

## Configuração dos Containers

### Serviços

- **`snack-hub-order-app`**
  - Porta: `5688`
  - Banco: MongoDB (`snack-hub-order`)

- **`snack-hub-payment-app`**
  - Porta: `5588`
  - Banco: PostgreSQL (`snack-hub-payment`)
  - Integração: Mercado Pago API

- **`snack-hub-client-app`**
  - Porta: `5488`
  - Banco: PostgreSQL (`snack-hub-client`)

- **`snack-hub-product-app`**
  - Porta: `5388`
  - Banco: MongoDB (`snack-hub-product`)

- **`snack-hub-production-app`**
  - Porta: `5288`
  - Banco: PostgreSQL (`snack-hub-production`)

- **`snack-hub-gateway-app`**
  - Porta: `5188`
  - Roteamento de APIs.

### Dependências

- **RabbitMQ**
  - Porta: `5672` (Fila) e `15672` (Painel de administração).

- **PostgreSQL**
  - Porta: `5432`
  - Banco de dados usado pelos serviços `payment-app`, `client-app` e `production-app`.

- **MongoDB**
  - Porta: `27017`
  - Banco de dados usado pelos serviços `order-app` e `product-app`.

## Como Executar

1. Clone o repositório:
   ```bash
   git clone https://github.com/Team-One-Pos-Tech/SnackHub.ApiGateway.git

2. Suba os containers Docker:
   Utilize o comando abaixo para iniciar todos os serviços necessários:
   ```bash
   docker-compose up -d
  ``
   Após executar o comando, verifique se os serviços estão funcionando corretamente:
   - Gateway: Acesse http://localhost:5188.
   - RabbitMQ: Acesse http://localhost:15672 com as credenciais padrão:
     - Usuário: guest
     - Senha: guest.

4. Configure as Variáveis de Ambiente:
   Certifique-se de que os seguintes valores estão configurados em cada serviço:

   - RabbitMQ:
     RabbitMQ__Host: rabbitmq
     RabbitMQ__User: guest
     RabbitMQ__Password: guest

   - MongoDB:
     Storage__MongoDb__ConnectionString: mongodb://admin:admin@snack-hub-mongodb:27017/
     Storage__MongoDb__Database: Nome do banco correspondente.

   - PostgreSQL:
     Storage__PostgreSQL__Host: snack-hub-db
     Storage__PostgreSQL__User: postgres
     Storage__PostgreSQL__Password: postgres
     Storage__PostgreSQL__Database: Nome do banco correspondente.

5. Teste os Arquivos `.http`:
   Utilize os arquivos `.http` para testar a API diretamente. Eles contêm exemplos de requisições que podem ser executadas em ferramentas como Rest Client no Visual Studio Code.

   Exemplos de requisições:

   - Autenticação (`auth-api`):
     @GatewayHostAddress = http://localhost:5188
     @GatewayPath = auth-api

     POST {{GatewayHostAddress}}/{{GatewayPath}}/signup
     Content-Type: application/json
     Accept: application/json

     {
       "name": "John Doe",
       "cpf": "61189242010",
       "email": "rosquinha@mail.com"
     }

   - Pedidos (`order-api`):
     @GatewayHostAddress = http://localhost:5188
     @GatewayPath = order-api

     POST {{GatewayHostAddress}}/{{GatewayPath}}/Confirm
     Content-Type: application/json
     Accept: application/json

     {
       "clientId": "1a296169-ac6e-431d-ae8e-148b6a458c93",
       "items": [
         {
           "productId": "0a2a1d42-5b08-45d7-83c8-5b9bb25b0aaa",
           "quantity": 3
         }
       ]
     }

   - Pagamentos (`payment-api`):
     @GatewayHostAddress = http://localhost:5188
     @GatewayPath = payment-api

     GET {{GatewayHostAddress}}/{{GatewayPath}}/Accepted
     Content-Type: application/json
     Accept: application/json

