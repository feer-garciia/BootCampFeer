public class TareaLaboral : Tarea
{
    public string Proyecto { get; set; } = string.Empty;

    // Polimorfismo: Sobrescribimos el método de la clase base
    public override string ObtenerDetalles()
    {
        return $"[Laboral - Proyecto: {Proyecto}] {Descripcion}";
    }
}