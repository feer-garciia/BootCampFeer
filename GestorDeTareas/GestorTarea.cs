using System.Text.Json;

public class GestorTarea
{
    private List<Tarea> tareas = new List<Tarea>();
    public readonly string rutaArchivo = "tareas.json";

    public GestorTarea()
    {
        CargarTareas();
    }
    public void AgregarTarea (string descripcion)
    {
        int nuevoId =tareas.Count > 0 ? tareas[tareas.Count - 1].Id + 1 : 1;
        Tarea nuevaTarea = new Tarea { Id = nuevoId, Descripcion = descripcion };
        tareas.Add(nuevaTarea);
        GuardarTareas();
        Console.WriteLine($"Tarea '{descripcion}' agregada y guardada con éxito");
    }

    public void ListarTareas()
    {
        if (tareas.Count == 0)
        {
            Console.WriteLine("No hay tareas registradas.");
            return;
        }

        Console.WriteLine("\n---Lista de Tareas---");
        foreach (var tarea in tareas)
        {
            string estado = tarea.EstaCompletada ? "[X] Completada" : "[ ] Pendiente";
            Console.WriteLine($"{tarea.Id}. {tarea.Descripcion} - {estado}");
        }
    }

    public void MarcarTareaComoCompletada(int id)
    {
        var tarea = tareas.Find(t => t.Id == id);
        if (tarea != null)
        {
            tarea.MarcarComoCompletada();
            GuardarTareas();
            Console.WriteLine($"Tarea '{id}' marcada como completada y guardada.");
        }
        else
        {
            Console.WriteLine("No se encontró ninguna tarea con ese ID");
        }
    }

    private void GuardarTareas()
    {
        var opciones = new JsonSerializerOptions { WriteIndented = true };
        string jsonString = JsonSerializer.Serialize(tareas, opciones);
        File.WriteAllText(rutaArchivo, jsonString);
    }

    private void CargarTareas()
    {
        if (File.Exists(rutaArchivo))
        {
            string jsonString = File.ReadAllText(rutaArchivo);
            tareas = JsonSerializer.Deserialize<List<Tarea>>(jsonString) ?? new List<Tarea>();
        }
    }
}