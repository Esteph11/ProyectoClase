using SQLite;

namespace ProyectoClase.Models
{
    public class ListaTareas
    {
        [PrimaryKey, AutoIncrement]
        public int Id { get; set; }

        [NotNull]
        public string Tarea { get; set; }
        
        [NotNull]
        public string Descripcion { get; set; }
        
        [NotNull]
        public string Estado { get; set; } 
    }

}
