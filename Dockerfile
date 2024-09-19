##Imagen base que se va a basar nuestro contenedor (DEBE ESTAR DESCARGADA EN NUESTRA MAQUINA!)
## y le cambia el nombre a build
FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build

##Nombre de la aplicación
WORKDIR /dapper-api

##Exponer los dos puertos con los que vamos a trabajar
EXPOSE 5024

### COPIAMOS EL CSPROJ
##Copia el csproj en la ruta donde se encuentra al mismo directorio
COPY ./dapper-api/*.csproj ./
##Verifica que el archivo del proyecto tenga todas las dependencias
RUN dotnet restore

### COPIAMOS LO DEMÁS
## Copiar todo lo demás
COPY . .
## Publicamos nuestro proyecto para que genere las dlls
RUN dotnet publish ./dapper-api/dapper-api.csproj -c Release -o /dapper-api/out

###CONSTRUIMOS LA IMAGEN
FROM mcr.microsoft.com/dotnet/aspnet:8.0
WORKDIR /dapper-api
COPY --from=build /dapper-api/out .
ENTRYPOINT ["dotnet", "dapper-api.dll"]
