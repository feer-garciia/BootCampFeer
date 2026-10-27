class Program
{
    static void Main(string[] args)
    {
        GestorTarea gestor = new GestorTarea();
        string? opcion ="";
        while (opcion != "4")
        {
            Console.WriteLine("\n---Gestor de Tareas---");
            Console.WriteLine("1. Agregar Tarea");
            Console.WriteLine("2. Listar Tareas");
            Console.WriteLine("3. Marcar Tarea como Completada");
            Console.WriteLine("4. Salir");
            Console.Write("Seleccione una opción: ");
            opcion = Console.ReadLine();

            switch (opcion)
            {
                case "1":
                    Console.Write("Ingrese la descripción de la tarea: ");
                    string descripcion = Console.ReadLine() ?? "";
                    if(!string.IsNullOrWhiteSpace(descripcion))
                    {
                        gestor.AgregarTarea(descripcion);
                    }
                    else
                    {
                        Console.WriteLine("La descripción de la tarea no puede estar vacía.");
                    }
                    break;
                case "2":
                    gestor.ListarTareas();
                    break;
                case "3":
                    Console.Write("Ingrese el ID de la tarea a marcar como completada: ");
                    if (int.TryParse(Console.ReadLine(), out int id))
                    {
                        gestor.MarcarTareaComoCompletada(id);
                    }
                    else
                    {
                        Console.WriteLine("Error: Por favor, ingrese un número válido para el ID de la tarea.");
                    }
                    break;
                case "4":
                    Console.WriteLine("Saliendo del programa...");
                    break;
                default:
                    Console.WriteLine("Opción inválida. Por favor, seleccione una opción válida.");
                    break;
            }
    }
}
}

