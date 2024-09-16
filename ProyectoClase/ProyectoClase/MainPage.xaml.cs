using System;
using System.Runtime.CompilerServices;
using Microsoft.Maui.Controls; 
using ProyectoClase.ViewModels; 
namespace ProyectoClase
{
    public partial class MainPage : ContentPage
    {
        int count = 0;

        public MainPage()
        {
            throw new NotImplementedException();

        }
        public Button CounterBtn { get; set; }
        private void OnCounterClicked(object sender, EventArgs e)
        {
            count++;

            if (count == 1)
                CounterBtn.Text = $"Clicked {count} time";
            else
                CounterBtn.Text = $"Clicked {count} times";

            SemanticScreenReader.Announce(CounterBtn.Text);
        }

    }

}
