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
    public partial class GetPais : ContentPage
    {
        private string url = "https://desfrlopez.me/asosa/api/pais";


        public GetPais()
        {
            InitializeComponent();
            getPais();
        }

        protected override async void OnAppearing()
        {
            base.OnAppearing();
            getPais();
        }

        private async Task getPais()
        {
            using (var httpClient = new HttpClient())
            {

                var response = await httpClient.GetAsync(url);

                if (response.IsSuccessStatusCode)
                {
                    var content = await response.Content.ReadAsStringAsync();
                    List<pais> contenido = JsonConvert.DeserializeObject<List<pais>>(content);

                    string tempRes = "";

                    for (int i =0; i < contenido.Count ; i++){

                        tempRes = tempRes + "idPais: " + contenido[i].idPais + " nombre_pais: " + contenido[i].nombre_pais + "\n";

                    }

                    resultado.Text = tempRes;
                }
                else
                {
                    resultado.Text = "Carga Fallida de Paises";
                }




            }
        }

    }
}