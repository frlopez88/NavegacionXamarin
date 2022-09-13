using NavTest.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace NavTest.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class PersonaPost : ContentPage
    {

        private string url = "https://desfrlopez.me/biblioteca2/api/persona";

        public PersonaPost()
        {
            InitializeComponent();
        }

        private async Task crearPersonaAsync()
        {
            using (var httpClient = new HttpClient())
            {

                persona x = new persona()
                {
                    nombre = nombreForm.Text,
                    apellido = apellidoForm.Text,
                    genero = generoForm.Text
                };



                var body = x.toJson();
                HttpContent c = new StringContent(body, Encoding.UTF8, "application/json");
                
                var response = await httpClient.PostAsync(url, c);

                if (response.IsSuccessStatusCode)
                {
                    var content = await response.Content.ReadAsStringAsync();
                    resultado.Text = "Insercion Exitosa";
                }
                else
                {
                    resultado.Text = "Insercion Fallida";
                }

                nombreForm.Text = "";
                apellidoForm.Text = "";
                generoForm.Text = "";

            }
        }

        private void Button_Clicked(object sender, EventArgs e)
        {
            crearPersonaAsync();
        }
    }
}