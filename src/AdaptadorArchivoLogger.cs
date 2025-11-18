using System;
using System.IO;

namespace ExamenUnidad3
{
    public class AdaptadorArchivoLogger : IRegistrador
    {
        private readonly IRegistrador _registrador;
        private readonly string _rutaArchivo;

        public AdaptadorArchivoLogger(IRegistrador registrador, string rutaArchivo)
        {
            _registrador = registrador;
            _rutaArchivo = rutaArchivo;
        }

        public void Registrar(string mensaje)
        {
            _registrador.Registrar(mensaje);

            string entrada = $"[{DateTime.Now:yyyy-MM-dd HH:mm:ss}] {mensaje}";
            File.AppendAllText(_rutaArchivo, entrada + Environment.NewLine);
        }
    }
}
