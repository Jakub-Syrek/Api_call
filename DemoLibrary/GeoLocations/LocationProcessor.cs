using Newtonsoft.Json;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;


namespace DemoLibrary
{
    public class LocationProcessor
    {
        public static async Task<GeoLocation.GeoLocation> LoadLocation(double lat, double lng)
        {


            string url = $"https://api.opencagedata.com/geocode/v1/json?q={lat}+{lng}&key=619f7781f94f4ca3939045d5e84dc7f4";
                       
            
            var response = await ApiHelper.ApiClient.GetAsync(url);            

            if (response.IsSuccessStatusCode)
            {                
                var result = await response.Content.ReadAsStringAsync();
                
                var deserializedProduct = JsonConvert.DeserializeObject<GeoLocation.GeoLocation>(result);

                return deserializedProduct;
            }
            else
                throw new Exception(response.ReasonPhrase);

        }
    }
}
