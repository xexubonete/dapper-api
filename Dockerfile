##Imagen base que se va a basar nuestro contenedor (DEBE ESTAR DESCARGADA EN NUESTRA MAQUINA!)
## y le cambia el nombre a build
FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build

##Nombre de la aplicación
WORKDIR /dapper-api

# RUN apt-get update && \
#     apt-get install -y curl apt-transport-https gnupg2 && \
#     curl https://packages.microsoft.com/keys/microsoft.asc | apt-key add - && \
#     curl https://packages.microsoft.com/config/ubuntu/20.04/prod.list > /etc/apt/sources.list.d/mssql-release.list && \
#     apt-get update && \
#     ACCEPT_EULA=Y apt-get install -y msodbcsql17 mssql-tools unixodbc-dev && \
#     echo 'export PATH="$PATH:/opt/mssql-tools/bin"' >> ~/.bashrc && \
#     /bin/bash -c "source ~/.bashrc" && \
#     apt-get clean && \
#     rm -rf /var/lib/apt/lists/*

# Copiar el script SQL al contenedor
COPY ./dapper-api/Scripts/dbo_init.sql /tmp/dbo_init.sql

##Exponer los puertos con los que vamos a trabajar
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
