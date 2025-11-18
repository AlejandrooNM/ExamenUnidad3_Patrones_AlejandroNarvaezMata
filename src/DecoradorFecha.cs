using System;

namespace ExamenUnidad3
{
    public class DecoradorFecha : IRegistrador
    {
        private readonly IRegistrador _registrador;

        public DecoradorFecha(IRegistrador registrador)
        {
            _registrador = registrador;
        }

        public void Registrar(string mensaje)
        {
            string fecha = DateTime.Now.ToString("HH:mm:ss");
            _registrador.Registrar($"[{fecha}] {mensaje}");
        }
    }
}
