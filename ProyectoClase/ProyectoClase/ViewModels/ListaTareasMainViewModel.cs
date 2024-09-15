using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using ProyectoClase.Models;
using ProyectoClase.Services;
using ProyectoClase.Views;
using System.Collections.ObjectModel;

namespace ProyectoClase.ViewModels
{
    public class ListaTareasMainViewModel : ObservableObject
    {
        [ObservableProperty]
        private ObservableCollection<ListaTareas> productoCollection = new ObservableCollection<ListaTareas>();

        private readonly ListaTareasService ListaTareasService;

        public ListaTareasMainViewModel()
        {
            ListaTareasService = new ListaTareasService();
        }

        /// <summary>
        /// Muestra un mensaje de alerta personalizado
        /// </summary>
        /// <param name="Titulo">Titulo de la alerta, por ejemplo, ERROR, ADVERTENCIA, etc</param>
        /// <param name="Mensaje">Mensaje a mostrar en la alerta</param>
        private void Alerta(string Titulo, string Mensaje)
        {
            MainThread.BeginInvokeOnMainThread(async () => await App.Current!.MainPage!.DisplayAlert(Titulo, Mensaje, "Aceptar"));
        }

        /// <summary>
        /// Muestra el listado de tareas
        /// </summary>
        public void GetAll()
        {
            var GetAll = ListaTareasService.GetAll();

            if (GetAll.Count > 0)
            {
                ListaTareasCollection.Clear();
                foreach (var listaTareas in GetAll)
                {
                    ListaTareasCollection.Add(listaTareas);
                }
            }
        }

        /// <summary>
        /// Redirecciona a la vista de agregar / editar producto
        /// </summary>
        /// <returns>Muestra la vista de agregar / editar producto</returns>
        [RelayCommand]
        private async Task GoToAddProductoForm()
        {
            await App.Current!.MainPage!.Navigation.PushAsync(new ListaTareasFormView());
        }

        /// <summary>
        /// Muestra las opciones para editar o eliminar un prudcto al seleccionarlo
        /// </summary>
        /// <param name="ListaTareas">Objeto seleccionado para actualizar o eliminar el registro</param>
        /// <returns>Proceso de opciones al seleccionar el registro del producto</returns>
        [RelayCommand]
        private async Task SelectListaTareas(ListaTareas ListaTareas)
        {
            try
            {
                const string ACTUALIZAR = "1. Actualizar";
                const string ELIMINAR = "2. Eliminar";

                string res = await App.Current!.MainPage!.DisplayActionSheet("OPCIONES", "Cancelar", null, ACTUALIZAR, ELIMINAR);

                if (res == ACTUALIZAR)
                {
                    await App.Current.MainPage.Navigation.PushAsync(new ListaTareasFormView(ListaTareas));
                }
                else if (res == ELIMINAR)
                {
                    bool respuesta = await App.Current!.MainPage!.DisplayAlert("ELIMINAR TAREA", "¿Desea eliminar el tarea?", "Si", "No");

                    if (respuesta)
                    {
                        int del = ListaTareasService.Delete(ListaTareas);

                        if (del > 0)
                        {
                            ListaTareasCollection.Remove(ListaTareas);
                        }
                    }
                }

            }
            catch (Exception ex)
            {
                Alerta("ERROR", ex.Message);
            }
        }

    }
}

