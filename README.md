# 🚀 DAPPER-API

Web API in .NET that implements Automapper, uses Dapper for data access, and follows Clean Code principles. Includes unit tests.

## ✨ Features

- ✨ Dapper implementation for efficient data access
- 🗺️ AutoMapper for object mapping
- 🧪 Unit tests included
- 🏗️ Clean architecture
- 📝 API documentation with Swagger

## 📋 Prerequisites

- .NET 8.0 SDK
- SQL Server (version 2019 or higher)
- IDE (Visual Studio 2022 recommended)

## 🛠️ Installation and Local Setup

Clone the project

```bash
git clone https://github.com/xexubonete/dapper-api.git
```

Go to project directory

```bash
cd ./dapper-api/dapper-api
```

Verify .NET installation

```bash
dotnet --version
```

Start the server

```bash
dotnet run
```

## 🧪 Testing

Run unit tests

```bash
cd ./dapper-api-test
dotnet test
```

## 📚 API Documentation

### 👥 Client Endpoints

#### Get all clients
```http
GET /api/Client
```

#### Create client
```http
POST /api/Client
```

**Request body:**
```json
{
    "id": 0,
    "name": "string",
    "surname": "string"
}
```

| Parameter | Type     | Description                |
| :-------- | :------- | :------------------------- |
| `id`      | `int`    | **Required** Identifier    |
| `name`    | `string` | **Optional** First name    |
| `surname` | `string` | **Optional** Last name     |

#### Update existing client
```http
PUT /api/Client
```

#### Get client by ID
```http
GET /api/Client/${id}
```

#### Delete client
```http
DELETE /api/Client/${id}
```

## 📁 Project Structure

```
dapper-api/
├── src/
│   ├── API/
│   ├── Core/
│   ├── Infrastructure/
│   └── Tests/
├── docs/
└── README.md
```

## 💻 Technologies Used

- .NET 8.0
- Dapper
- AutoMapper
- xUnit
- Swagger/OpenAPI

## 🔗 Related Projects

- [crud-api](https://github.com/xexubonete/crud-api)
- [mediator-api](https://github.com/xexubonete/mediator-api)
- [pilot-api](https://github.com/xexubonete/pilot-api)

## 👨‍💻 Author

- [GitHub](https://www.github.com/xexubonete)
- [LinkedIn](https://www.linkedin.com/in/jesus-bonete-sanchez/)

## 🤝 Contributing

Contributions are always welcome. Please read the `CONTRIBUTING.md` file for details on our code of conduct and the process for submitting pull requests.

## 📫 Contact

If you have any questions or suggestions, don't hesitate to contact:
- Email: xexubonete@outlook.es

## 📄 License

This project is under the [MIT](https://choosealicense.com/licenses/mit/) license
