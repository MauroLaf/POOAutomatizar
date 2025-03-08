using System;
using static System.Runtime.InteropServices.JavaScript.JSType;
using System.Text.RegularExpressions;

namespace ProyectoEj1
{
    public class Coches : Marca
    {
        private string _modelo = "";

        public string Modelo
        {
            get { return _modelo; }
            set
            {
                if (!string.IsNullOrWhiteSpace(value))
                {
                    _modelo = value;
                }
                else
                {
                    throw new ArgumentException("El modelo no puede estar vacío.");
                }
            }
        }

        public double Precio { get; set; }

        public Coches(string nombreMarca, string modelo, double precio) : base(nombreMarca)
        {
            Modelo = modelo;
            Precio = precio;
        }

        public void MostrarCoche()
        {
            Console.WriteLine($"Coche: {Nombre} {Modelo}, Precio: {Precio}");
        }
    }
}
