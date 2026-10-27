using System;
using System.Collections.Generic;

public class GestorTareas
{
    private List<Tarea> tareas = new List<Tarea>();
    private readonly IRepositorioTareas repositorio;

    // Inyección de Dependencias: Recibimos la abstracción por el constructor
    public GestorTareas(IRepositorioTareas repositorio)
    {
        this.repositorio = repositorio;
        CargarTareas();
    }

    public void AgregarTarea(Tarea tarea)
    {
        int nuevoId = tareas.Count > 0 ? tareas[tareas.Count - 1].Id + 1 : 1;
        tarea.Id = nuevoId;
        tareas.Add(tarea);
        GuardarTareas();
        Console.WriteLine("¡Tarea agregada y guardada con éxito!");
    }

    public void ListarTareas()
    {
        if (tareas.Count == 0)
        {
            Console.WriteLine("No hay tareas registradas.");
            return;
        }

        Console.WriteLine("\n--- Lista de Tareas (Con Interfaces) ---");
        foreach (var tarea in tareas)
        {
            string estado = tarea.EstaCompletada ? "[X]" : "[ ]";
            Console.WriteLine($"{tarea.Id}. {estado} {tarea.ObtenerDetalles()}");
        }
    }

    public void MarcarTareaCompletada(int id)
    {
        var tarea = tareas.Find(t => t.Id == id);
        if (tarea != null)
        {
            tarea.MarcarComoCompletada();
            GuardarTareas();
            Console.WriteLine($"¡Tarea {id} marcada como completada!");
        }
        else
        {
            Console.WriteLine("No se encontró una tarea con ese ID.");
        }
    }

    private void GuardarTareas()
    {
        repositorio.Guardar(tareas);
    }

    private void CargarTareas()
    {
        tareas = repositorio.Cargar();
    }
}