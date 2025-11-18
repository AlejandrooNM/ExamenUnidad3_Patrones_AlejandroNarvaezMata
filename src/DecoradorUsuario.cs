namespace ExamenUnidad3
{
    public class DecoradorUsuario : IRegistrador
    {
        private readonly IRegistrador _registrador;
        private readonly string _nombreUsuario;

        public DecoradorUsuario(IRegistrador registrador, string nombreUsuario)
        {
            _registrador = registrador;
            _nombreUsuario = nombreUsuario;
        }

        public void Registrar(string mensaje)
        {
            _registrador.Registrar($"[{_nombreUsuario}] {mensaje}");
        }
    }
}
