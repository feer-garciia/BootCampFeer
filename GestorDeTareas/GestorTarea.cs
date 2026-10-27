
using System.Collections.Generic;
public class GestorTarea
{
    private List<Tarea> tareas = new List<Tarea>();
    public void AgregarTarea (string descripcion)
    {
        int nuevoId =tareas.Count +1;
        Tarea nuevaTarea = new Tarea { Id = nuevoId, Descripcion = descripcion };
        tareas.Add(nuevaTarea);
        Console.WriteLine($"Tarea '{descripcion}' agregada con exito");
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
            Console.WriteLine($"Tarea '{id}' marcada como completada.");
        }
        else
        {
            Console.WriteLine($"No se encontró ninguna tarea con el ID {id}.");
        }
    }
}