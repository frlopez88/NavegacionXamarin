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
    public partial class PersonaPut : ContentPage
    {
        private string url = "https://desfrlopez.me/biblioteca2/api/persona";

        public PersonaPut()
        {
            InitializeComponent();
        }

        private async Task actualizarPersonaAsync()
        {
            using (var httpClient = new HttpClient())
            {

                persona x = new persona()
                {
                    id_persona = int.Parse(idForm.Text) ,
                    nombre = nombreForm.Text,
                    apellido = apellidoForm.Text,
                    genero = generoForm.Text
                };
                url = url + "/" + x.id_persona; // mandamos de parametro de url del id a modificar
                var body = x.toJson();
                HttpContent c = new StringContent(body, Encoding.UTF8, "application/json");
                var response = await httpClient.PutAsync(url, c);

                if (response.IsSuccessStatusCode)
                {
                    var content = await response.Content.ReadAsStringAsync();
                    resultado.Text = "Actulizacion Exitosa";
                }
                else
                {
                    resultado.Text = "Actulizacion Fallida";
                }

                nombreForm.Text = "";
                apellidoForm.Text = "";
                generoForm.Text = "";

            }
        }

        private void Button_Clicked(object sender, EventArgs e)
        {
            actualizarPersonaAsync();
        }

        private void idForm_TextChanged(object sender, TextChangedEventArgs e)
        {

        }
    }
}