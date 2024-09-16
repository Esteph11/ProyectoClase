using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using ProyectoClase.Models;
using ProyectoClase.Services;
using ProyectoClase.Views;
using System.Collections.ObjectModel;
using System.Windows.Input;

namespace ProyectoClase.ViewModels
{
    public partial class ListaTareasFormViewModel : BindableObject
    {

       
        public int Id;

        
        public string Tarea;

        
        public string Descripcion;

       
        public string Estado;

        private readonly ListaTareasService ListaTareasService;

        
        private ObservableCollection<ListaTareas> tareas;
        private ListaTareas selectedTask;

        public ObservableCollection<ListaTareas> Tareas
        {
            get { return tareas; }
            set { tareas = value; OnPropertyChanged(); }
        }

        public ListaTareas SelectedTask
        {
            get { return selectedTask; }
            set { selectedTask = value; OnPropertyChanged(); }
        }

        public ICommand AddTaskCommand { get; }
        public ICommand EditTaskCommand { get; }
        public ICommand DeleteTaskCommand { get; }

        public ListaTareasFormViewModel()
        {
            tareas = new ObservableCollection<ListaTareas>();
            AddTaskCommand = new Command(AddTask);
            EditTaskCommand = new Command(EditTask);
            DeleteTaskCommand = new Command(DeleteTask);
        }
        private void AddTask()
        {
            // Crear un nuevo Lista de Tareas y solicitar al usuario que introduzca los detalles de la tarea  
            var newTarea = ShowTaskDialog("Añadir nueva tarea");

            if (newTarea != null) // Verificar si el usuario no canceló el diálogo  
            {
                tareas.Add(newTarea);
            }
        }

        private void EditTask()
        {
            // Verificar si hay una tarea seleccionada  
            if (SelectedTask != null)
            {
                // Solicitar al usuario los detalles de la tarea  
                var editedTask = ShowTaskDialog("Editar tarea", SelectedTask);

                if (editedTask != null) // Verifica si el usuario no cancela el diálogo  
                {
                    // Actualizar la tarea seleccionada  
                    SelectedTask.Tarea = editedTask.Tarea;
                    SelectedTask.Descripcion = editedTask.Descripcion;
                    SelectedTask.Estado = editedTask.Estado;
                    OnPropertyChanged(nameof(SelectedTask));
                }
            }
        }

        // Método ficticio para mostrar un cuadro de diálogo y obtener una nueva Lista de Tareas 
        private ListaTareas ShowTaskDialog(string title, ListaTareas existingTask = null)
        {
            // Aquí deberías implementar algún tipo de diálogo para obtener los datos.  
            // Por simplicidad, aquí solo se devuelve un TaskItem con datos ficticios.  

            // Ejemplo: si usas una biblioteca de UI, podrías mostrar un cuadro de entrada  
            // y esperar la entrada del usuario; aquí se muestra solo un ejemplo simplificado.  


            string tarea = existingTask?.Tarea ?? "Nueva tarea";
            string descripcion = existingTask?.Descripcion ?? "Descripción de la tarea";
            string estado = existingTask?.Estado ?? "Estasdo de la tarea";


            // Imaginar que aquí se abre un cuadro de diálogo que permite al usuario modificar `name` y `description`  
            // En la implementación real, este método debería retornar null si el usuario canceló  

            return new ListaTareas // Crea una nueva tarea con los datos ingresados  
            {
                Tarea = tarea,
                Descripcion = descripcion,
                Estado = estado
            };
        }


        private void DeleteTask()
        {
            if (SelectedTask != null)
            {
                tareas.Remove(SelectedTask);
            }
        }
    }

}
