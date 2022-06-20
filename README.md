# Introducción

El proyecto de desarrollo de esta API ha sido desarrollada en Visual Studio y en este repositorio se encuentran los ficheros editables para que funcione su ejecución. La publicación de la **[API](https://es.wikipedia.org/wiki/Interfaz_de_programaci%C3%B3n_de_aplicaciones)** en una **[web service](https://es.wikipedia.org/wiki/Servicio_web)** de la nube permitirá trabajar con los datos directamente en JSON.
Esta API se integra en el proyecto **[bibliotecaonline](https://github.com/antoniojturel/bibliotecaonline)** cuyo entregable forma parte del curso **[Flutter y Dart](https://cftic.centrosdeformacion.empleo.madrid.org/curso-flutter-y-dart)** impartido en el Centro de Referencia Nacional de Desarrollo Informático y Comunicaciones (**[CFTIC](https://cftic.centrosdeformacion.empleo.madrid.org/)**) a través de la empresa **[CAS Training](https://cas-training.com/)**.

# Objetivo y alcance

Referencia al proyecto citado: **[README.md](https://github.com/antoniojturel/bibliotecaonline/blob/master/README.md)**

# Principales ficheros editables

## ~/Controllers/BibliotecaController.cs

La definición de las URI. A continuación, las principales:
- Consulta: HttpGet
- Inserción: HttpPost
- Modificación: HttpPut
- Elimininación: HttpDelete

## ~/Data/BibliotecaContext.cs

El contexto de la clase Biblioteca para realizar las operaciones necesarias con la base de datos.

## ~/Models/Biblioteca.cs

El modelo de la tabla y sus campos que ya se han creado en la base de datos (**[Azure SQL](https://azure.microsoft.com/en-us/products/azure-sql/?&ef_id=CjwKCAjwtcCVBhA0EiwAT1fY71fB2Y4Ii-PkQjHox3Zph1aTBaO5oDSw_7yO-8DsjSAeebg-4svAtRoCgcIQAvD_BwE:G:s&OCID=AID2200258_SEM_CjwKCAjwtcCVBhA0EiwAT1fY71fB2Y4Ii-PkQjHox3Zph1aTBaO5oDSw_7yO-8DsjSAeebg-4svAtRoCgcIQAvD_BwE:G:s&gclid=CjwKCAjwtcCVBhA0EiwAT1fY71fB2Y4Ii-PkQjHox3Zph1aTBaO5oDSw_7yO-8DsjSAeebg-4svAtRoCgcIQAvD_BwE#product-overview)** en este caso):

## ~/Repositories/RepositoryBibliotecas.cs

La defición de los métodos permitidos en esta API. A continuación, los métodos principales (los 3 primeros devuelven listas de objetos de la clase Biblioteca):
~~~
public List<Biblioteca> BuscarLibrosTituloLike(String titulo)
public List<Biblioteca> BuscarLibrosAutorLike(String autor)
public List<Biblioteca> BuscarLibrosTematica(String tematica)
public void InsertarLibro(int num, String titulo, String autor, String tematica, String url, String portada)
public void ModificarLibro(int num, String titulo, String autor, String tematica, String url, String portada)
public void EliminarLibro(int num)

~~~

## ~/appsettings.json

Parámetros de configuración para acceder a la base de datos en Azure (el servidor indicado en *Source* ya no está en funcionamiento). La siguiente línea de programación habría que editarla: 
~~~
 "cadenahospitalazure": "Data Source=srvflutter-antonio.database.windows.net;Initial Catalog=biblioteca;Persist Security Info=True;User ID=adminsql; password=Admin123"
~~~

## ~/Startup.cs

Comienzo de ejecución. Por ejemplo, que tome la configuración realizada en el fichero anterior y la guarde en la variable *cadenaconexion*:
~~~
String cadenaconexion = Configuration.GetConnectionString("cadenahospitalazure");
~~~