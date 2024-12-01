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

### Suba os Containers Docker

Execute o seguinte comando para iniciar os serviços Docker:

```bash
docker-compose up -d
```

### Verifique os Serviços

Após iniciar os containers, certifique-se de que os seguintes serviços estão disponíveis:

- **Gateway**: [http://localhost:5188](http://localhost:5188)  
- **RabbitMQ**: [http://localhost:15672](http://localhost:15672)  
  - Usuário: `guest`
  - Senha: `guest`

### Configure as Variáveis de Ambiente

Certifique-se de que as variáveis de ambiente estão configuradas corretamente para os serviços.

#### RabbitMQ
- `RabbitMQ__Host`: `rabbitmq`  
- `RabbitMQ__User`: `guest`  
- `RabbitMQ__Password`: `guest`

#### MongoDB
- `Storage__MongoDb__ConnectionString`: `mongodb://admin:admin@snack-hub-mongodb:27017/`  
- `Storage__MongoDb__Database`: Nome do banco correspondente.

#### PostgreSQL
- `Storage__PostgreSQL__Host`: `snack-hub-db`  
- `Storage__PostgreSQL__User`: `postgres`  
- `Storage__PostgreSQL__Password`: `postgres`  
- `Storage__PostgreSQL__Database`: Nome do banco correspondente.

---

## Testando as APIs

Os arquivos `.http` disponíveis no projeto contêm exemplos de requisições para testar as APIs. Use ferramentas como o [Rest Client](https://marketplace.visualstudio.com/items?itemName=humao.rest-client) no Visual Studio Code.

### Exemplos de Requisições

#### Auth API

- **`POST /signup`**  
  Exemplo de payload:  
  ```json
  {
    "name": "John Doe",
    "cpf": "61189242010",
    "email": "rosquinha@mail.com"
  }
  ```

- **`POST /signin`**  
  Exemplo de payload:  
  ```json
  {
    "cpf": "61189242010"
  }
  ```

---

#### Order API

- **`POST /Confirm`**  
  Exemplo de payload:  
  ```json
  {
    "clientId": "1a296169-ac6e-431d-ae8e-148b6a458c93",
    "items": [
      {
        "productId": "0a2a1d42-5b08-45d7-83c8-5b9bb25b0aaa",
        "quantity": 3
      }
    ]
  }
  ```

---

#### Product API

- **`POST /`**  
  Exemplo de payload:  
  ```json
  {
    "name": "Coca-Cola",
    "category": 2,
    "price": 7.45,
    "description": "Coca geladinha!"
  }
  ```

---

#### Production API

- **`POST /CreateProductionOrder`**  
  Exemplo de payload:  
  ```json
  {
    "orderId": "{Order Id}",
    "items": [
      {
        "productId": "{product-id}",
        "quantity": 2
      }
    ]
  }
  ```

---

## Serviços Disponíveis

- **`snack-hub-order-app`**  
  - Porta: `5688`  
  - Banco: MongoDB (`snack-hub-order`)

- **`snack-hub-payment-app`**  
  - Porta: `5689`  
  - Banco: PostgreSQL (`snack-hub-payment`)

- **`snack-hub-gateway`**  
  - Porta: `5188`

---

## Observações

- Certifique-se de que todas as APIs estão funcionando corretamente antes de avançar para as integrações.  
- Para mais informações sobre os serviços, consulte a documentação específica de cada API.

---

## Licença

Este projeto está licenciado sob a [MIT License](LICENSE).
