using System;

namespace Archivos
{
    class Carro
    {
        private double costo;
        private string modelo;

        public double Costo { get => costo; set => costo = value; }
        public string Modelo { get => modelo; set => modelo = value; }

        // Constructor
        public Carro(string modelo, double costo)
        {
            // Inicializamos los datos
            this.costo = costo;
            this.modelo = modelo;
        }

        public void MuestraInformacion()
        {
            // Mostramos la información necesaria
            Console.WriteLine("Tu carro {0}", modelo);
            Console.WriteLine("Costo {0}", costo);
            Console.WriteLine("----------");
        }
    }
}