using ProyectoClase.ViewModels;
namespace ProyectoClase.Views;

public partial class ListaTareasView : ContentPage
{
    private ListaTareasMainViewModel ViewModel;

    public ListaTareasView()
    {
        InitializeComponent();
        ViewModel = new ListaTareasMainViewModel();
        this.BindingContext = ViewModel;
    }

    protected override void OnAppearing()
    {
        base.OnAppearing();
        ViewModel.GetAll();
    }

}