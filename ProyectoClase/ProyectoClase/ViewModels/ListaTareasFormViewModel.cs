using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using ProyectoClase.Models;
using ProyectoClase.Services;
using ProyectoClase.Views;

namespace ProyectoClase.ViewModels
{
    public class ListaTareasFormViewModel : ObservableObject
    {
        private ObservableCollection<TaskItem> tasks;
        private TaskItem selectedTask;

        public ObservableCollection<TaskItem> Tasks
        {
            get { return tasks; }
            set { tasks = value; OnPropertyChanged(); }
        }

        public TaskItem SelectedTask
        {
            get { return selectedTask; }
            set { selectedTask = value; OnPropertyChanged(); }
        }

        public ICommand AddTaskCommand { get; }
        public ICommand EditTaskCommand { get; }
        public ICommand DeleteTaskCommand { get; }

        public ListaTareasFormViewModel()
        {
            Tasks = new ObservableCollection<TaskItem>();
            AddTaskCommand = new Command(AddTask);
            EditTaskCommand = new Command(EditTask);
            DeleteTaskCommand = new Command(DeleteTask);
        }

        private void AddTask()
        {
            // Lógica para añadir una tarea (deberías implementar un dialogo para obtener datos)  
        }

        private void EditTask()
        {
            // Lógica para editar la tarea seleccionada  
        }

        private void DeleteTask()
        {
            if (SelectedTask != null)
            {
                Tasks.Remove(SelectedTask);
            }
        }
    }

}
