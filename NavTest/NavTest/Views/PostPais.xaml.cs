using NavTest.Models;
using Newtonsoft.Json;
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
    public partial class PostPais : ContentPage
    {
        private string url = "https://desfrlopez.me/asosa/api/pais";

        public PostPais()
        {
            InitializeComponent();
        }

        private async Task postPais()
        {
            using (var httpClient = new HttpClient())
            {

                pais x = new pais()
                {
                    nombre_pais = nombreForm.Text,
                    codigo_de_area = codigoAreaForm.Text
                };


                var body = x.toJson();
                HttpContent c = new StringContent(body, Encoding.UTF8, "application/json");

                var response = await httpClient.PostAsync(url, c);

                if (response.IsSuccessStatusCode)
                {
                    var content = await response.Content.ReadAsStringAsync();
                    pais contenido = JsonConvert.DeserializeObject<pais>(content);
                    resultado.Text = "Pais Creado: id = " + contenido.idPais + " nombre = " + contenido.nombre_pais;
                }
                else
                {
                    resultado.Text = "Insercion Fallida";
                }

                nombreForm.Text = "";
                codigoAreaForm.Text = "";


            }
        }

        private void Button_Clicked(object sender, EventArgs e)
        {
            postPais();
        }
    }
}