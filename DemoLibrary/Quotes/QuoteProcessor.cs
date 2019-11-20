using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using WPFApp;

namespace DemoLibrary
{
    public class QuoteProcessor
    {
        public static async Task<Quotes> LoadQuote()
        {
            string url = @"http://quotes.rest/qod.json";

            var response = await ApiHelper.ApiClient.GetAsync(url);

            if (response.IsSuccessStatusCode)
            {                
                var result = await response.Content.ReadAsStringAsync();
                var deserializedProduct = JsonConvert.DeserializeObject<Quotes>(result);               
                return deserializedProduct;                
            }
            else
                throw new Exception(response.ReasonPhrase);
        }
    }
}
