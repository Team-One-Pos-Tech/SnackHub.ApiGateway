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
