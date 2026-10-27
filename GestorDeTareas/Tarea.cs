public class Tarea
{
    public int Id {get; set;}
    public string Descripcion {get; set;} = string.Empty;
    public bool EstaCompletada {get; set;} = false;

    public void MarcarComoCompletada()
    {
        EstaCompletada = true;
    }
}