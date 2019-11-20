using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WolframAlphaNet;
using WolframAlphaNet.Objects;


namespace DemoLibrary
{
    public class WolframProcessor
    {
        public static async Task<QueryResult> LoadWolfram(string query)
        {
            string appId = "YV37YU-JL7K87EG5V";
            string url = $"http://api.wolframalpha.com/v2/query?input={query}&appid={appId}";

            //var response = await ApiHelper.ApiClient.GetAsync(url);

            WolframAlpha wolfram = new WolframAlpha(appId);

            QueryResult results = wolfram.Query(query);
            
            return results;

        }

        public static async Task<System.Drawing.Image> DownloadImageFromUrl(string imageUrl)
        {
            System.Drawing.Image image = null;

            try
            {
                System.Net.HttpWebRequest webRequest = (System.Net.HttpWebRequest)System.Net.HttpWebRequest.Create(imageUrl);
                webRequest.AllowWriteStreamBuffering = true;
                webRequest.Timeout = 30000;

                System.Net.WebResponse webResponse = await webRequest.GetResponseAsync();  //            GetResponse();

                System.IO.Stream stream = webResponse.GetResponseStream();

                image = System.Drawing.Image.FromStream(stream);

                webResponse.Close();
            }
            catch (Exception ex)
            {
                return null;
            }

            return image;
        }


    }
}
