using System;
using System.IO;

namespace Archivos
{
    class Program
    {
        static void Main(string[] args)
        {
            int opcion = 0;
            string valor = "";

            string modelo = "";
            double costo = 0;
            Carro miCarro;

            FileStream fs;

            // Variables extra
            int numero = 5;
            bool acceso = false;
            byte conteo = 120;

            Console.WriteLine("1) crear archivo\n2) leer archivo");
            valor = Console.ReadLine();
            opcion = Convert.ToInt32(valor);

            switch (opcion)
            {
                case 1:
                    // Creamos el objeto Carro
                    Console.WriteLine("Dame el modelo");
                    modelo = Console.ReadLine();

                    Console.WriteLine("Dame el costo");
                    valor = Console.ReadLine();
                    costo = Convert.ToDouble(valor);

                    miCarro = new Carro(modelo, costo);

                    // Creamos el stream
                    fs = new FileStream("MiArchivo.arc", FileMode.Create, FileAccess.Write, FileShare.None);

                    // Creamos el escritor
                    BinaryWriter writer = new BinaryWriter(fs);

                    writer.Write(miCarro.Modelo);
                    writer.Write(miCarro.Costo);

                    // Escribimos las variables
                    writer.Write(numero);
                    writer.Write(acceso);
                    writer.Write(conteo);

                    // Cerramos el stream
                    fs.Close();
                    break;

                case 2:
                    // Leemos el archivo
                    Console.WriteLine("--- Leemos archivo ---");

                    // Creamos stream
                    fs = new FileStream("MiArchivo.arc", FileMode.Open, FileAccess.Read, FileShare.None);

                    // Creamos el lector
                    BinaryReader lector = new BinaryReader(fs);

                    // Leemos en el mismo orden que se escribió
                    // tomando en cuenta el tipo
                    modelo = "";
                    costo = 0;
                    numero = 0;
                    acceso = true;
                    conteo = 0;

                    modelo = lector.ReadString();
                    costo = lector.ReadDouble();
                    miCarro = new Carro(modelo, costo);

                    numero = lector.ReadInt32();
                    acceso = lector.ReadBoolean();
                    conteo = lector.ReadByte();

                    // Cerramos el stream
                    fs.Close();

                    // Imprimimos
                    miCarro.MuestraInformacion();
                    Console.WriteLine("número {0}", numero);
                    Console.WriteLine("acceso {0}", acceso);
                    Console.WriteLine("conteo {0}", conteo);
                    break;
                default:
                    Console.WriteLine("Opción inválida");
                    break;
            }
        }
    }
}
