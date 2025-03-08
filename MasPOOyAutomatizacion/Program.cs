using System;

namespace ProyectoEj1
{
    public class Program
    {
        public static void Main(string[] args)
        {
            Console.WriteLine("Programa iniciado");

            // Obtener la instancia única de la concesionaria (Singleton)
            Consesionaria concesionaria = Consesionaria.Instancia;

            bool continuar = true;

            while (continuar)
            {
                Console.WriteLine("\nElija una opción:");
                Console.WriteLine("1. Agregar un coche a la concesionaria.");
                Console.WriteLine("2. Mostrar coches comprados en la concesionaria.");
                Console.WriteLine("G. Guardar historial de compras en archivo.");
                Console.WriteLine("L. Leer historial de compras desde archivo.");
                Console.WriteLine("0. Salir.");

                string opcion = Console.ReadLine().ToUpper();  // Convertir la opción a mayúsculas

                switch (opcion)
                {
                    case "1":
                        Console.Write("Indique nombre de comprador: ");
                        string nombre = Console.ReadLine();

                        Console.Write("Indique apellido del comprador: ");
                        string apellido = Console.ReadLine();

                        Console.Write("Indique el presupuesto: ");
                        double presupuesto;
                        while (!double.TryParse(Console.ReadLine(), out presupuesto))
                        {
                            Console.Write("Ingrese un valor numérico para el presupuesto: ");
                        }

                        Console.WriteLine("\nCargue el coche que desea comprar");

                        Console.Write("Indique la marca: ");
                        string marca = Console.ReadLine();

                        Console.Write("Indique el modelo: ");
                        string modelo = Console.ReadLine();

                        Console.Write("Indique el precio: ");
                        double precio;
                        while (!double.TryParse(Console.ReadLine(), out precio))
                        {
                            Console.Write("Ingrese un valor numérico para el precio: ");
                        }

                        Comprador cliente1 = new Comprador(nombre, apellido, presupuesto);
                        Coches coche1 = new Coches(marca, modelo, precio);

                        Console.WriteLine("\nDatos ingresados:");
                        cliente1.MostrarComprador();
                        coche1.MostrarCoche();

                        if (cliente1.Comprar(coche1, concesionaria))
                        {
                            Console.WriteLine("Compra registrada con éxito.");
                        }
                        else
                        {
                            Console.WriteLine("El comprador no tiene suficiente presupuesto.");
                        }

                        break;

                    case "2":
                        concesionaria.MostrarCompras();
                        break;

                    case "G":
                        concesionaria.GuardarComprasEnArchivo("compras.txt");
                        break;

                    case "L":
                        concesionaria.LeerComprasDesdeArchivo("compras.txt");
                        break;

                    case "0":
                        continuar = false;
                        Console.WriteLine("Saliendo del programa...");
                        break;

                    default:
                        Console.WriteLine("Opción no válida. Intente nuevamente.");
                        break;
                }
            }
        }
    }
}
