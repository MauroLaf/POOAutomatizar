using System;

namespace ProyectoEj1
{
    public class Marca
    {
        private static int contadorID = 0; // Contador estático para generar IDs automáticamente
        public int ID { get; private set; }
        private string _nombre;

        public string Nombre
        {
            get { return _nombre; }
            set
            {
                if (!string.IsNullOrWhiteSpace(value))
                {
                    _nombre = value;
                }
                else
                {
                    throw new ArgumentException("El nombre no puede estar vacío.");
                }
            }
        }

        // Constructor con asignación de ID automático
        public Marca(string nombre)
        {
            ID = SumarID(); // Asigna un ID único
            Nombre = nombre;
        }

        // Generar IDs únicos
        private static int SumarID()
        {
            return ++contadorID;
        }

        public void MostrarMarca()
        {
            Console.WriteLine($"Marca: {Nombre}, ID: {ID}");
        }
    }
}
