using System;
using System.IO;

namespace Flujos
{
    class Program
    {
        static void Main(string[] args)
        {
            long cantidad = 0, n = 0;
            int valor = 0;

            FileStream fs = new FileStream("datos.txt", FileMode.Open, FileAccess.Read, FileShare.None);

            // Obtenemos la cantidad
            cantidad = fs.Length;
            Console.WriteLine("El archivo mide {0}", cantidad);

            // Leemos byte por byte
            for (n = 0; n < cantidad; n++)
            {
                // Ponemos la posición
                fs.Seek(n, SeekOrigin.Begin);
                valor = fs.ReadByte();
                Console.WriteLine(" {0}", (char)valor);
            }
        }
    }
}
