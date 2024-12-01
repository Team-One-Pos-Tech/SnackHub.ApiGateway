# SnackHub API Gateway Project

This project is an API gateway that manages the SnackHub application services, organized into microservices for ordering, payments, customers, products and production functionality. The system uses Docker for orchestration and dependencies such as RabbitMQ, MongoDB and PostgreSQL.

## Documentation Resources
More about the Architecture Overview [here](https://github.com/Team-One-Pos-Tech/SnackHub.ApiGateway/wiki/Architecture-Overview)
More about the Message Broker events catalog [here](https://github.com/Team-One-Pos-Tech/SnackHub.ApiGateway/wiki/Events-Catalog)

## Project Structure

- **SnackHub.Gateway**: API gateway that centralizes communication routes between microservices.
- **Microservices**:
- `snack-hub-order-app`: Manages orders.
- `snack-hub-payment-app`: Manages payments.
- `snack-hub-client-app`: Manages customer information.
- `snack-hub-product-app`: Manages products.
- `snack-hub-production-app`: Manages production.
- **Dependencies**:
- `RabbitMQ`: Message queue for communication between services.
- `MongoDB`: Database used by some services.
- `PostgreSQL`: Database used by other services.

## Technologies Used

- **Docker**: Container orchestration.
- **RabbitMQ**: Communication between microservices.
- **MongoDB and PostgreSQL**: Databases for storage.
- **ASP.NET Core**: Development of microservices and the gateway.

## Prerequisites

- Docker and Docker Compose installed.
- Port 8080 released for communication.

## Container Configuration

### Services

- **`snack-hub-order-app`**
- Port: `5688`
- Database: MongoDB (`snack-hub-order`)

- **`snack-hub-payment-app`**
- Port: `5588`
- Database: PostgreSQL (`snack-hub-payment`)
- Integration: Mercado Pago API

- **`snack-hub-client-app`**
- Port: `5488`
- Database: PostgreSQL (`snack-hub-client`)

- **`snack-hub-product-app`**
- Port: `5388`
- Database: MongoDB (`snack-hub-product`)

- **`snack-hub-production-app`**
- Port: `5288`
- Database: PostgreSQL (`snack-hub-production`)

- **`snack-hub-gateway-app`**
- Port: `5188`
- API routing.

### Dependencies

- **RabbitMQ**
- Port: `5672` (Queue) and `15672` (Admin Panel).

- **PostgreSQL**
- Port: `5432`
- Database used by `payment-app`, `client-app` and `production-app` services.

- **MongoDB**
- Port: `27017`
- Database used by `order-app` and `product-app` services.

## How to Run

1. Clone the repository:
```bash
git clone https://github.com/Team-One-Pos-Tech/SnackHub.ApiGateway.git

### Start the Docker Containers

Run the following command to start the Docker services:

```bash
docker-compose up -d
```

### Check the Services

After starting the containers, make sure the following services are available:

- **Gateway**: [http://localhost:5188](http://localhost:5188)
- **RabbitMQ**: [http://localhost:15672](http://localhost:15672)
- Username: `guest`
- Password: `guest`

### Set the Environment Variables

Make sure the environment variables are set correctly for the services.

#### RabbitMQ
- `RabbitMQ__Host`: `rabbitmq`
- `RabbitMQ__User`: `guest`
- `RabbitMQ__Password`: `guest`

#### MongoDB
- `Storage__MongoDb__ConnectionString`: `mongodb://admin:admin@snack-hub-mongodb:27017/`
- `Storage__MongoDb__Database`: Name of the corresponding database.

#### PostgreSQL
- `Storage__PostgreSQL__Host`: `snack-hub-db`
- `Storage__PostgreSQL__User`: `postgres`
- `Storage__PostgreSQL__Password`: `postgres`
- `Storage__PostgreSQL__Database`: Name of the corresponding database.

---

## Testing the APIs

The `.http` files available in the project contain sample requests to test the APIs. Use tools like the [Rest Client](https://marketplace.visualstudio.com/items?itemName=humao.rest-client) in Visual Studio Code.

### Request Examples

#### Auth API

- **`POST /signup`**
Payload example:
```json
{
"name": "John Doe",
"cpf": "61189242010",
"email": "rosquinha@mail.com"
}
```

- **`POST /signin`**
Payload example:
```json
{
"cpf": "61189242010"
}
```

---

#### Order API

- **`POST /Confirm`**
Payload example:
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
 Payload example:
 ```json
 {
 "name": "Coca-Cola",
 "category": 2,
 "price": 7.45,
 "description": "Cold Coke!"
 }
 ```

---

#### Production API

- **`POST /CreateProductionOrder`**
 Payload example:
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

## Available Services

- **`snack-hub-order-app`**
 - Port: `5688`
 - Bank: MongoDB (`snack-hub-order`)

- **`snack-hub-payment-app`**
 - Port: `5689`
 - Bank: PostgreSQL (`snack-hub-payment`)

- **`snack-hub-gateway`**
 - Port: `5188`

---

## Notes

- Make sure all APIs are working properly before moving on to integrations.

- For more information about services, see the specific documentation for each API.

---

## License

This project is licensed under the [MIT License](LICENSE).
