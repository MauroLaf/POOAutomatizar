using System;
using System.Collections.Generic;
using System.IO;

namespace ProyectoEj1
{
    public class Consesionaria
    {
        public string Nombre { get; set; }
        private static readonly Consesionaria _instancia = new Consesionaria("Autos Express SA");
        public static Consesionaria Instancia => _instancia;

        private List<(Comprador, Coches)> historialCompras = new List<(Comprador, Coches)>();

        // Constante para la ruta del archivo
        private const string RutaBaseArchivo = @"C:\Users\Mauro\Documents\";

        public Consesionaria(string nombre)
        {
            Nombre = nombre;
        }

        // Agregar una compra al historial
        public void AgregarCompra(Comprador comprador, Coches coche)
        {
            historialCompras.Add((comprador, coche));
        }

        // Mostrar historial de compras
        public void MostrarCompras()
        {
            Console.WriteLine("\nHistorial de Compras:");
            if (historialCompras.Count == 0)
            {
                Console.WriteLine("No se han realizado compras.");
                return;
            }

            foreach (var (comprador, coche) in historialCompras)
            {
                Console.WriteLine($"{comprador.Nombre} {comprador.Apellido} compró un {coche.Nombre} {coche.Modelo} (ID: {coche.ID}) por {coche.Precio}.");
            }
        }

        // Guardar historial de compras en un archivo de texto
        public void GuardarComprasEnArchivo(string archivo)
        {
            string rutaArchivo = RutaBaseArchivo + archivo;  // Usamos la constante RutaBaseArchivo

            using (StreamWriter writer = new StreamWriter(rutaArchivo, true)) // 'true' para agregar al final
            {
                foreach (var (comprador, coche) in historialCompras)
                {
                    writer.WriteLine($"Comprador: {comprador.Nombre} {comprador.Apellido}, Coche: {coche.Nombre} {coche.Modelo} (ID: {coche.ID}), Precio: {coche.Precio}");
                }
            }
            Console.WriteLine($"Historial de compras guardado en el archivo: {rutaArchivo}");
        }

        // Leer compras desde el archivo
        public void LeerComprasDesdeArchivo(string archivo)
        {
            string rutaArchivo = RutaBaseArchivo + archivo;  // Usamos la constante RutaBaseArchivo

            if (!File.Exists(rutaArchivo))
            {
                Console.WriteLine("El archivo de compras no existe.");
                return;
            }

            Console.WriteLine("\nContenido del historial de compras en el archivo:");

            using (StreamReader reader = new StreamReader(rutaArchivo))
            {
                string linea;
                while ((linea = reader.ReadLine()) != null)
                {
                    Console.WriteLine(linea);
                }
            }
        }
    }
}
