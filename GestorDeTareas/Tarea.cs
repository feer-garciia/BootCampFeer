using System;
using System.Text.Json.Serialization;

// Atributos para que System.Text.Json sepa manejar la jerarquía de herencia
[JsonDerivedType(typeof(TareaLaboral), typeDiscriminator: "laboral")]
[JsonDerivedType(typeof(TareaPersonal), typeDiscriminator: "personal")]
public abstract class Tarea
{
    public int Id { get; set; }
    public string Descripcion { get; set; } = string.Empty;
    public bool EstaCompletada { get; set; } = false;

    public void MarcarComoCompletada()
    {
        EstaCompletada = true;
    }

    // Método virtual para aplicar Polimorfismo
    public virtual string ObtenerDetalles()
    {
        return $"Descripción: {Descripcion}";
    }
}