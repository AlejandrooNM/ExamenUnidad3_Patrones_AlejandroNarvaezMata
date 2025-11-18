using System;

namespace ExamenUnidad3
{
    public class DecoradorColor : IRegistrador
    {
        private readonly IRegistrador _registrador;
        private ConsoleColor _color;

        public DecoradorColor(IRegistrador registrador, ConsoleColor color)
        {
            _registrador = registrador;
            _color = color;
        }

        public void CambiarColor(ConsoleColor nuevoColor)
        {
            _color = nuevoColor;
        }

        public void Registrar(string mensaje)
        {
            Console.ForegroundColor = _color;
            _registrador.Registrar(mensaje);
            Console.ResetColor();
        }
    }
}
