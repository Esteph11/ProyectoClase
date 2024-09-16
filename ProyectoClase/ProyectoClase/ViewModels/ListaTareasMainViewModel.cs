using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using ProyectoClase.Models;
using ProyectoClase.Services;
using ProyectoClase.Views;
using System.Collections.ObjectModel;
using System.Windows.Input;
using Microsoft.Maui.Controls;
using System.Linq;


namespace ProyectoClase.ViewModels
{
    public partial class ListaTareasMainViewModel : ObservableObject
    {
        [ObservableProperty]
        private ObservableCollection<ListaTareas> listaTareas = new ObservableCollection<ListaTareas>();

        private readonly ListaTareasService listaTareasService;

 

        public ListaTareasMainViewModel()
        {
            listaTareasService = new ListaTareasService();
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
            var GetAll = listaTareasService.GetAll();

            if (GetAll.Count > 0)
            {
                listaTareas.Clear();
                foreach (var listaTareas in GetAll)
                {
                    ListaTareas.Add(listaTareas);
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
        /// <param name="listaTareas">Objeto seleccionado para actualizar o eliminar el registro</param>
        /// <returns>Proceso de opciones al seleccionar el registro del producto</returns>
        [RelayCommand]
        private async Task SelectListaTareas(ListaTareas listaTareas)
        {
            try
            {
                const string ACTUALIZAR = "1. Actualizar";
                const string ELIMINAR = "2. Eliminar";

                string res = await App.Current!.MainPage!.DisplayActionSheet("OPCIONES", "Cancelar", null, ACTUALIZAR, ELIMINAR);

                if (res == ACTUALIZAR)
                {
                    await App.Current.MainPage.Navigation.PushAsync(new ListaTareasFormView(listaTareas));
                }
                else if (res == ELIMINAR)
                {
                    bool respuesta = await App.Current!.MainPage!.DisplayAlert("ELIMINAR TAREA", "¿Desea eliminar el tarea?", "Si", "No");

                    if (respuesta)
                    {
                        int del = listaTareasService.Delete(listaTareas);

                        if (del > 0)
                        {
                            listaTareas.Remove(listaTareas);
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

