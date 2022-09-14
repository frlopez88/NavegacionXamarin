using NavTest.Views;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace NavTest
{
    public partial class MainPage : ContentPage
    {
        public MainPage()
        {
            InitializeComponent();
        }

        private async void enviarPersona(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new PersonaMenu());
        }

        private async void enviarPais(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new MenuPais());
        }
    }
}
