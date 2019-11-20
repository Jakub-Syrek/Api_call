using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DemoLibrary
{
    public class WeatherProcessor
    {
        public static async Task<Weathers> LoadWeather()
        {
            string url = @"https://fcc-weather-api.glitch.me/api/current?lat=35&lon=139";

            var response = await ApiHelper.ApiClient.GetAsync(url);

            if (response.IsSuccessStatusCode)
            {

                var result = await response.Content.ReadAsStringAsync();
                var deserializedProduct = JsonConvert.DeserializeObject<Weathers>(result);

                return deserializedProduct;

            }
            else
                throw new Exception(response.ReasonPhrase);
        }
    }
}
