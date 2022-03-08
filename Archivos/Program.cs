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

            Console.WriteLine("1) crear archivo, 2) leer archivo");
            valor = Console.ReadLine();
            opcion = Convert.ToInt32(valor);

            if(opcion == 1)
            {
                // Creamos el objeto Carro
                string modelo = "";
                double costo = 0;

                Console.WriteLine("Dame el modelo");
                modelo = Console.ReadLine();

                Console.WriteLine("Dame el costo");
                valor = Console.ReadLine();
                costo = Convert.ToDouble(valor);

                Carro miCarro = new Carro(modelo, costo);

                // Variables extra
                int numero = 5;
                bool acceso = false;
                byte conteo = 120;

                // Creamos el stream
                FileStream fs = new FileStream("MiArchivo.arc", FileMode.Create, FileAccess.Write, FileShare.None);

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
            }

            if(opcion == 2)
            {
                // Leemos el archivo
                Console.WriteLine("--- Leemos archivo ---");

                // Creamos stream
                FileStream fs = new FileStream("MiArchivo.arc", FileMode.Open, FileAccess.Read, FileShare.None);

                // Creamos el lector
                BinaryReader lector = new BinaryReader(fs);

                // Leemos en el mismo orden que se escribió
                // tomando en cuenta el tipo
                string modelo = "";
                double costo = 0;
                int numero = 0;
                bool acceso = true;
                byte conteo = 0;

                modelo = lector.ReadString();
                costo = lector.ReadDouble();
                Carro miCarro = new Carro(modelo, costo);

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
            }
        }
    }
}
