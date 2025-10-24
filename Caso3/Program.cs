// Caso 3: El caso propone que los estudiantes desarrollen en C# un programa que use una lista de
// elementos para representar los programas registrados, con atributos como Id, Nombre
// y Versión. El objetivo es que comprendan cómo las listas permiten manipular
// colecciones de datos de forma flexible, facilitando operaciones de mantenimiento,
// búsqueda y actualización. Este caso vincula la teoría con una aplicación real de
// administración tecnológica dentro de los sistemas informáticos universitarios

using System;
using System.Collections.Generic;

namespace CatalogoSoftware
{
    // Clase que representa un software en el catálogo
    class Software
    {
        public int Id { get; set; }
        public string Nombre { get; set; }
        public string Version { get; set; }

        public Software(int id, string nombre, string version)
        {
            Id = id;
            Nombre = nombre;
            Version = version;
        }

        public override string ToString()
        {
            return $"ID: {Id}, Nombre: {Nombre}, Versión: {Version}";
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            List<Software> catalogo = new List<Software>();
            int opcion;

            do
            {
                Console.Clear();
                Console.WriteLine("=== Catálogo de Software Universitario ===");
                Console.WriteLine("1. Agregar software");
                Console.WriteLine("2. Eliminar software por ID");
                Console.WriteLine("3. Buscar software por nombre");
                Console.WriteLine("4. Mostrar todo el catálogo");
                Console.WriteLine("5. Salir");
                Console.Write("Seleccione una opción: ");

                opcion = int.Parse(Console.ReadLine());
                Console.Clear();

                switch (opcion)
                {
                    case 1:
                        Console.Write("Ingrese el ID del software: ");
                        int id = int.Parse(Console.ReadLine());
                        Console.Write("Ingrese el nombre del software: ");
                        string nombre = Console.ReadLine();
                        Console.Write("Ingrese la versión del software: ");
                        string version = Console.ReadLine();

                        catalogo.Add(new Software(id, nombre, version));
                        Console.WriteLine("Software agregado exitosamente.");
                        break;

                    case 2:
                        Console.Write("Ingrese el ID del software a eliminar: ");
                        int idEliminar = int.Parse(Console.ReadLine());
                        Software softwareEliminar = catalogo.Find(s => s.Id == idEliminar);
                        if (softwareEliminar != null)
                        {
                            catalogo.Remove(softwareEliminar);
                            Console.WriteLine("Software eliminado correctamente.");
                        }
                        else
                        {
                            Console.WriteLine("No se encontró un software con ese ID.");
                        }
                        break;

                    case 3:
                        Console.Write("Ingrese el nombre a buscar: ");
                        string nombreBuscar = Console.ReadLine();
                        List<Software> resultados = catalogo.FindAll(s => s.Nombre.ToLower().Contains(nombreBuscar.ToLower()));

                        if (resultados.Count > 0)
                        {
                            Console.WriteLine("Resultados encontrados:");
                            foreach (var s in resultados)
                                Console.WriteLine(s);
                        }
                        else
                        {
                            Console.WriteLine("No se encontró ningún software con ese nombre.");
                        }
                        break;

                    case 4:
                        Console.WriteLine("=== Catálogo Completo ===");
                        if (catalogo.Count == 0)
                        {
                            Console.WriteLine("No hay software registrado.");
                        }
                        else
                        {
                            foreach (var s in catalogo)
                                Console.WriteLine(s);
                        }
                        break;

                    case 5:
                        Console.WriteLine("Saliendo del programa...");
                        break;

                    default:
                        Console.WriteLine("Opción inválida. Intente nuevamente.");
                        break;
                }

                if (opcion != 5)
                {
                    Console.WriteLine("\nPresione cualquier tecla para continuar...");
                    Console.ReadKey();
                }

            } while (opcion != 5);
        }
        
    }
}
