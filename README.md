
# DAPPER-API

.NET web API that leverage Automapper approach, Dapper for data access, and adhere to the principles of Clean Code. Tests also are included.


## Run Locally

Clone the project

```bash
  git clone https://github.com/xexubonete/dapper-api.git
```

Go to the project directory

```bash
  cd ./dapper-api/dapper-api
```

Check that you've dotnet installed

```bash
  dotnet --version
```

Start the server

```bash
  dotnet run
```


## Running Tests

To run tests, run the following command

```bash
  cd ./dapper-api-test
```

```bash
  dotnet run test
```


## API Reference

#### GET all clients

```http
  GET /api/Client
```

#### CREATE client

```http
  POST /api/Client
```
`{  "id": 0,    "name": "string",    "surname": "string"    }`

| Parameter | Type     | Description                |
| :-------- | :------- | :------------------------- |
| `  id   ` | ` int  ` |  **Required** Identifier   |
| `  Name ` | `string` |  **Nullable** Client name  |
| `Surname` | `string` |  **Nullable** Client surname|


#### PUT an existent client

```http
  PUT /api/Client
```
`{  "id": 0,    "name": "string",    "surname": "string"    }`

| Parameter | Type     | Description                |
| :-------- | :------- | :------------------------- |
| `  id   ` | ` int  ` |  **Required** Identifier   |
| `  Name ` | `string` |  **Nullable** Client name  |
| `Surname` | `string` |  **Nullable** Client surname|


#### GET client by id

```http
  GET /api/Client/${id}
```

| Parameter | Type     | Description                       |
| :-------- | :------- | :-------------------------------- |
| `id`      | `string` | **Required**. Id of client to search |

#### DELETE client by id

```http
  DELETE /api/Client/${id}
```

| Parameter | Type     | Description                       |
| :-------- | :------- | :-------------------------------- |
| `id`      | `string` | **Required**. Id of client to search |

## Authors

- [Author Github](https://www.github.com/xexubonete)
- [Author LinkedIn](https://www.linkedin.com/in/jesus-bonete-sanchez/)


## Feedback

If you have any feedback, please reach out to us at xexubonete@outlook.es


## Tech Stack

**Server:** C#, .NET 8.0


## Related

Here are some related projects

[crud-api](https://github.com/xexubonete/crud-api)  
[mediator-api](https://github.com/xexubonete/mediator-api)  
[pilot-api](https://github.com/xexubonete/pilot-api)


## Environment Variables

To run this project, you will not need any environment variables



## License

[MIT](https://choosealicense.com/licenses/mit/)

