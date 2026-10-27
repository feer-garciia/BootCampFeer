using System.Collections.Generic;
using System.IO;
using System.Text.Json;

public class JsonRepositorioTareas : IRepositorioTareas
{
    private readonly string rutaArchivo = "tareas.json";

    public void Guardar(List<Tarea> tareas)
    {
        var opciones = new JsonSerializerOptions { WriteIndented = true };
        string jsonString = JsonSerializer.Serialize(tareas, opciones);
        File.WriteAllText(rutaArchivo, jsonString);
    }

    public List<Tarea> Cargar()
    {
        if (File.Exists(rutaArchivo))
        {
            string jsonString = File.ReadAllText(rutaArchivo);
            return JsonSerializer.Deserialize<List<Tarea>>(jsonString) ?? new List<Tarea>();
        }
        return new List<Tarea>();
    }
}

/*using System.Collections.Generic;
using Microsoft.Data.Sqlite;

public class SqlRepositorioTareas : IRepositorioTareas
{
    private readonly string connectionString = "Data Source=tareas.db";

    public SqlRepositorioTareas()
    {
        // Creamos la tabla si no existe al iniciar
        using var connection = new SqliteConnection(connectionString);
        connection.Open();

        string createTableCmd = @"
            CREATE TABLE IF NOT EXISTS Tareas (
                Id INTEGER PRIMARY KEY AUTOINCREMENT,
                Descripcion TEXT NOT NULL,
                EstaCompletada INTEGER NOT NULL,
                Tipo TEXT NOT NULL,
                DetalleExtra TEXT
            );";

        using var command = new SqliteCommand(createTableCmd, connection);
        command.ExecuteNonQuery();
    }

    public void Guardar(List<Tarea> tareas)
    {
        // En una BD real, normalmente guardas al agregar/actualizar individualmente,
        // pero para mantener la firma de la interfaz, podemos sincronizar o insertar.
        // Aquí simulamos cómo interactuaría con la base de datos.
    }

    public List<Tarea> Cargar()
    {
        var lista = new List<Tarea>();
        using var connection = new SqliteConnection(connectionString);
        connection.Open();

        string selectCmd = "SELECT Id, Descripcion, EstaCompletada, Tipo, DetalleExtra FROM Tareas;";
        using var command = new SqliteCommand(selectCmd, connection);
        using var reader = command.ExecuteReader();

        while (reader.Read())
        {
            int id = reader.GetInt32(0);
            string desc = reader.GetString(1);
            bool completada = reader.GetInt32(2) == 1;
            string tipo = reader.GetString(3);
            string detalleExtra = reader.GetString(4);

            // Reconstruimos el objeto polimórfico según el tipo guardado en SQL
            if (tipo == "laboral")
            {
                lista.Add(new TareaLaboral { Id = id, Descripcion = desc, EstaCompletada = completada, Proyecto = detalleExtra });
            }
            else
            {
                lista.Add(new TareaPersonal { Id = id, Descripcion = desc, EstaCompletada = completada, Categoria = detalleExtra });
            }
        }

        return lista;
    }
}*/