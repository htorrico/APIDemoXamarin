using APIDemoXamarin.Model;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace APIDemoXamarin
{
    public partial class MainPage : ContentPage
    {
        public   MainPage()
        {
            InitializeComponent();
            
        }



        //private const string BaseUrl = "https://enviodocumentos.wicpr.net/WICAPI2B/API/FoodClassification/GetWithSubClassification";
        private const string BaseUrl = "https://enviodocumentos.wicpr.net";

        public async Task<T> GetAsync<T>(string endpoint)
        {
            using (HttpClient client = new HttpClient())
            {
                client.BaseAddress = new Uri(BaseUrl);

                // Realizar la solicitud GET al servidor
                HttpResponseMessage response = await client.GetAsync(endpoint);

                // Verificar si la solicitud fue exitosa (código de estado 200)
                if (response.IsSuccessStatusCode)
                {
                    // Leer y deserializar la respuesta JSON
                    string json = await response.Content.ReadAsStringAsync();
                    T result = JsonConvert.DeserializeObject<T>(json);
                    return result;
                }
                else
                {
                    // Manejar errores
                    throw new Exception($"Error en la solicitud: {response.StatusCode}");
                }
            }
        }

        private async void Button_Clicked(object sender, EventArgs e)
        {
           

            try
            {
                var result = await GetAsync<ResponseBase>("/WICAPI2B/API/FoodClassification/GetWithSubClassification");
                // Procesar el resultado
            }
            catch (Exception ex)
            {
                throw ex;
                // Manejar errores
            }
        }
    }
}
