# dds-orm

Pasos para poder correr este ejemplo: 

Abrir la consola de Nuget. 
Correr los siguientes comandos: 
Enable-Migrations -ContextTypeName UniversidadContext
Add-Migration InitialCreate
Update-Database

Darle a F5 o el boton de ejecutar. 
Para interactuar con las vistas, ir directo a la URL y poner
http://localhost:52562/Carreras
http://localhost:52562/Alumnos .... y asi para cada una de las vistas generales existentes 
(el puertova a depender de la configuracion de su IIS express) 
