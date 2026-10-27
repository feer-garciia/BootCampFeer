using System.Collections.Generic;

public interface IRepositorioTareas
{
    void Guardar(List<Tarea> tareas);
    List<Tarea> Cargar();
}