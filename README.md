# ExamenUnidad3_Patrones_AlejandroNarvaezMata
Repositorio del examen de la unidad 3

El proyecto es un sistema de logging que usa dos patrones de diseño:

Patrón Decorator: Aquí es donde se le da formato a los logs. Básicamente tengo decoradores que se van apilando uno sobre otro. El DecoradorColor pone el color que el usuario eligió, el DecoradorFecha le pone la hora, el DecoradorUsuario agrega quién hizo la acción, y el DecoradorFormato le da un estilo visual. La cosa es que cada decorador envuelve al anterior, entonces puedes ir agregando o quitando cosas sin tocar el código base. Es flexible.

Patrón Adapter: Este es el AdaptadorArchivoLogger que agarra todo lo que se registra en la consola y lo guarda en un archivo de texto (logs.txt). Funciona como un puente entre el sistema de logging y el sistema de archivos. Cada vez que pasa algo (cambiar color, ver registros, cerrar sesión), queda guardado automáticamente. Así tienes un historial permanente de todo lo que hicieron los usuarios.
