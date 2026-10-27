public class TareaPersonal : Tarea
{
    public string Categoria { get; set; } = string.Empty;

    // Polimorfismo: Sobrescribimos el método de la clase base
    public override string ObtenerDetalles()
    {
        return $"[Personal - Categoría: {Categoria}] {Descripcion}";
    }
}