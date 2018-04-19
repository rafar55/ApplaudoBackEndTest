# Applaudo Studio Back-End Test

 Api que maneja un listado de personas en memoria. Se puede insertar (POST), actualizar (PUT), borrar (DELETE) y consultar (GET) dicho listado.
 
 Para poder correr este proyecto se necesita descargar .NET Core https://www.microsoft.com/net/download/Windows/build. Si tiene Visual Studio 2017 actualizado podran abrir la solución sin problema.

#Estructura de la Solución .Net

Generalmente en los sistemas que no son demasiado pequeños, siempre los trabajo con Dependency Injection y los divido en varias Class library. Antes de .net Core Utilizaba Ninject para manejar las Dependencia. Ahora Asp.net core ya tiene integrado un DI en en el framework.

Entonces la estructura me gusta dividirla en:

 - Una Class Library que la llamo CORE, esta librería tiene los modelos del sistema en cuestión que generalmente son tablas en la base que se generan con CODE FIRST en Entity Framework. Ahi mismo en esa librería pongo las Interfaces que definen las apis de los repositorios, servicios para la lógica de negocios, Provider u otras apis que el sistema utilizara para interactuar con el data store, lógica de negocios, Logging, enviar emails, cobros, etc.  La ventaja de separarlo de esta manera que se pueden reutilizar en otros proyectos ya sea un Windows Form, Xamarin o cualquier tipo de proyecto que se pueda realizaer con la plataforma .Net.
 
 - luego está el proyecto web api en sí, que tiene una referencia al Core y utiliza las implementaciones de las interfaces que son inyectadas con Dependency Injection en los Controllers u otros lugares que se necesiten.
 
 En el caso de este proyecto solo tenemos un repositorio y una implementación del repositorio que trabaja con datos en memoria del modelo Personas.  En otros proyectos ya reales hubieran más interfaces e implementaciones quizás con Entity framework para los repositorios por ejemplo

# Información Swagger del Api
 
 Implemente un Swagger en el proyecto para que puedan tener mejor información de api en y puedan hacer pruebas fácilmente.
 Cuando corran el proyecto pueden ingresar a http://localhost:49475/swagger/ para ver el UI de Swagger
 
# Ejemplo con Postman

También hice una Collection de Postman para que pueden probar el api Fácilmente. Pueden verla aquí
https://www.getpostman.com/collections/39d8cb43e5f57b2a0563 

# Probar en Azure

HE publicado el Api en Azure para que también la puedan probar de ahí. El Url es 
http://applaudoapitest.azurewebsites.net



