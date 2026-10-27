using System;

class Program
{
    static void Main(string[] args)
    {
        // 1. Instanciamos la implementación concreta de la persistencia
        IRepositorioTareas repositorio = new JsonRepositorioTareas();

        // 2. Inyectamos la dependencia en el gestor
        GestorTareas gestor = new GestorTareas(repositorio);
        
        string? opcion = "";

        while (opcion != "4")
        {
            Console.WriteLine("\n=== Gestor de Tareas (Arquitectura SOLID) ===");
            Console.WriteLine("1. Agregar tarea");
            Console.WriteLine("2. Listar tareas");
            Console.WriteLine("3. Marcar tarea como completada");
            Console.WriteLine("4. Salir");
            Console.Write("Elige una opción: ");

            opcion = Console.ReadLine();

            switch (opcion)
            {
                case "1":
                    Console.WriteLine("\n1. Laboral\n2. Personal");
                    Console.Write("Tipo de tarea: ");
                    string? tipo = Console.ReadLine();
                    if (tipo == "1")
                    {
                        Console.Write("Descripción: ");
                        string? desc = Console.ReadLine();
                        Console.Write("Proyecto: ");
                        string? proj = Console.ReadLine();
                        if (!string.IsNullOrWhiteSpace(desc) && !string.IsNullOrWhiteSpace(proj))
                        {
                            gestor.AgregarTarea(new TareaLaboral { Descripcion = desc, Proyecto = proj });
                        }
                    }
                    else if (tipo == "2")
                    {
                        Console.Write("Descripción: ");
                        string? desc = Console.ReadLine();
                        Console.Write("Categoría: ");
                        string? cat = Console.ReadLine();
                        if (!string.IsNullOrWhiteSpace(desc) && !string.IsNullOrWhiteSpace(cat))
                        {
                            gestor.AgregarTarea(new TareaPersonal { Descripcion = desc, Categoria = cat });
                        }
                    }
                    else if (tipo != null)
                    {
                        Console.WriteLine("Tipo de tarea no válido.");
                    }
                    break;

                case "2":
                    gestor.ListarTareas();
                    break;

                case "3":
                    gestor.ListarTareas();
                    Console.Write("Ingresa el ID a completar: ");
                    if (int.TryParse(Console.ReadLine(), out int id))
                    {
                        gestor.MarcarTareaCompletada(id);
                    }
                    break;

                case "4":
                    Console.WriteLine("¡Hasta luego!");
                    break;
            }
        }
    }
}