namespace ExamenUnidad3
{
    public class DecoradorFormato : IRegistrador
    {
        private readonly IRegistrador _registrador;

        public DecoradorFormato(IRegistrador registrador)
        {
            _registrador = registrador;
        }

        public void Registrar(string mensaje)
        {
            _registrador.Registrar($">>> {mensaje}");
        }
    }
}
