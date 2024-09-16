using ProyectoClase.Models;
using ProyectoClase.ViewModels;

namespace ProyectoClase.Views;

public partial class ListaTareasFormViewModel : ContentPage
{

    private ListaTareasFormViewModel ViewModel;

    private void InitializeComponent()
    {
       throw ( new NotImplementedException() ); 
		
	}

    public ListaTareasFormViewModel(ListaTareas listaTareas)
    {
        InitializeComponent();
        ViewModel = new ListaTareasFormViewModel(listaTareas);
        BindingContext = ViewModel;
    }
}
