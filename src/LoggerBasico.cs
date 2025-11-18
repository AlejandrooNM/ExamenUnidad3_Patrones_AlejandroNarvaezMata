using System;

namespace ExamenUnidad3
{
    public class LoggerBasico : IRegistrador
    {
        public void Registrar(string mensaje)
        {
            Console.WriteLine(mensaje);
        }
    }
}
