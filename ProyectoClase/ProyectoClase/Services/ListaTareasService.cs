using ProyectoClase.Models;
using SQLite;

namespace ProyectoClase.Services
{
    public class ListaTareasService
    {
    private readonly SQLiteConnection DbConnection;

    public ListaTareasService()
    {
        string DbPath = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData), "ListaTareas.db3");

        DbConnection = new SQLiteConnection(DbPath);
        DbConnection.CreateTable<ListaTareas>();
    }

    /// <summary>
    /// Lista todas las tareas
    /// </summary>
    /// <returns>Listado de tareas</returns>
    public List<ListaTareas> GetAll()
    {
        var res = DbConnection.Table<ListaTareas>().ToList();
        return res;
    }

        /// <summary>
        /// Crea un registro en la base de datos
        /// </summary>
        /// <param name="ListaTareas">Objeto con los datos de la lista de tareas a ingresar</param>
        /// <returns>Cantidad de registros ingresados</returns>
        public int Insert(ListaTareas ListaTareas)
    {
        return DbConnection.Insert(ListaTareas);
    }

        /// <summary>
        /// Actualiza un registro en la base de datos
        /// </summary>
        /// <param name="ListaTareas">Objeto con los datos de la lista de tareas a actualizar</param>
        /// <returns>Cantidad de registros actualizados</returns>
        public int Update(ListaTareas ListaTareas)
    {
        return DbConnection.Update(ListaTareas);
    }

        /// <summary>
        /// Elimina un registro de la base de datos
        /// </summary>
        /// <param name="ListaTareas">Objeto con los datos a eliminar</param>
        /// <returns>Cantidad de registros eliminados</returns>
        public int Delete(ListaTareas ListaTareas)
    {
        return DbConnection.Delete(ListaTareas);
    }

}
}
