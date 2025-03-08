using System;

namespace ProyectoEj1
{
    public class Comprador
    {
        public string Nombre { get; set; }
        public string Apellido { get; set; }
        public double Presupuesto { get; set; }

        public Comprador(string nombre, string apellido, double presupuesto)
        {
            Nombre = nombre;
            Apellido = apellido;
            Presupuesto = presupuesto;
        }

        public void MostrarComprador()
        {
            Console.WriteLine($"Comprador: {Nombre} {Apellido}, Presupuesto: {Presupuesto}");
        }

        // Método para realizar una compra
        public bool Comprar(Coches coche, Consesionaria concesionaria)
        {
            if (Presupuesto >= coche.Precio)
            {
                Presupuesto -= coche.Precio;
                concesionaria.AgregarCompra(this, coche);
                return true;
            }
            return false;
        }
    }
}

