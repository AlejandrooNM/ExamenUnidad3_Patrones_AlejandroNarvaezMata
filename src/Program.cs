using System;
using System.Collections.Generic;

namespace ExamenUnidad3
{
    class Program
    {
        static Dictionary<string, (string password, ConsoleColor color)> usuarios = new Dictionary<string, (string, ConsoleColor)>
        {
            { "Aleeexx", ("alexcool1", ConsoleColor.Cyan) },
            { "Juan", ("juan123", ConsoleColor.Green) },
            { "Maria", ("maria456", ConsoleColor.Yellow) }
        };

        static void Main(string[] args)
        {
            bool salirPrograma = false;

            while (!salirPrograma)
            {
                Console.Clear();
                Console.WriteLine("=== Sistema de Logging ===\n");

                var usuario = Login();
                if (usuario.nombre != null)
                {
                    MostrarMenu(usuario.nombre, usuario.color);
                }
                else
                {
                    salirPrograma = true;
                }
            }

            Console.WriteLine("\nGracias por usar el sistema.");
            Console.ReadKey();
        }

        static (string nombre, ConsoleColor color) Login()
        {
            Console.Write("Usuario: ");
            string username = Console.ReadLine();

            Console.Write("Contraseña: ");
            string password = LeerPassword();

            if (usuarios.ContainsKey(username) && usuarios[username].password == password)
            {
                Console.WriteLine("\n✓ Login exitoso\n");
                return (username, usuarios[username].color);
            }

            Console.WriteLine("\n✗ Usuario o contraseña incorrectos");
            return (null, ConsoleColor.White);
        }

        static string LeerPassword()
        {
            string password = "";
            ConsoleKeyInfo key;

            do
            {
                key = Console.ReadKey(true);

                if (key.Key != ConsoleKey.Backspace && key.Key != ConsoleKey.Enter)
                {
                    password += key.KeyChar;
                    Console.Write("*");
                }
                else if (key.Key == ConsoleKey.Backspace && password.Length > 0)
                {
                    password = password.Substring(0, password.Length - 1);
                    Console.Write("\b \b");
                }
            } while (key.Key != ConsoleKey.Enter);

            Console.WriteLine();
            return password;
        }

        static void MostrarMenu(string nombre, ConsoleColor color)
        {
            DecoradorColor decoradorColor = new DecoradorColor(new LoggerBasico(), color);
            
            IRegistrador registrador = new AdaptadorArchivoLogger(
                new DecoradorFormato(
                    new DecoradorUsuario(
                        new DecoradorFecha(decoradorColor), nombre
                    )
                ), "logs.txt"
            );

            bool salir = false;
            while (!salir)
            {
                Console.ForegroundColor = color;
                Console.WriteLine("\n=== MENÚ ===");
                Console.WriteLine("1. Ver registro");
                Console.WriteLine("2. Cambiar color");
                Console.WriteLine("3. Cerrar sesión");
                Console.ResetColor();
                Console.Write("\nOpción: ");

                string opcion = Console.ReadLine();

                switch (opcion)
                {
                    case "1":
                        registrador.Registrar("Visualizando registro del sistema");
                        break;
                    case "2":
                        color = CambiarColor(color);
                        decoradorColor.CambiarColor(color);
                        usuarios[nombre] = (usuarios[nombre].password, color);
                        registrador.Registrar($"Color cambiado a {color}");
                        break;
                    case "3":
                        registrador.Registrar("Cerrando sesión");
                        salir = true;
                        break;
                }
            }
        }

        static ConsoleColor CambiarColor(ConsoleColor colorActual)
        {
            Console.WriteLine("\n=== Cambiar Color ===");
            Console.WriteLine("1. Rojo");
            Console.WriteLine("2. Verde");
            Console.WriteLine("3. Azul");
            Console.WriteLine("4. Amarillo");
            Console.WriteLine("5. Cian");
            Console.WriteLine("6. Magenta");
            Console.WriteLine("7. Blanco");
            Console.Write("\nElige un color: ");

            string opcion = Console.ReadLine();

            switch (opcion)
            {
                case "1": return ConsoleColor.Red;
                case "2": return ConsoleColor.Green;
                case "3": return ConsoleColor.Blue;
                case "4": return ConsoleColor.Yellow;
                case "5": return ConsoleColor.Cyan;
                case "6": return ConsoleColor.Magenta;
                case "7": return ConsoleColor.White;
                default: return colorActual;
            }
        }
    }
}
