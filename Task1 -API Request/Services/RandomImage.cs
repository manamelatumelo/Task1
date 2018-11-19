using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace Task1__API_Request.Services
{
    public static class RandomImage
    {
        public static bool GetRandomImage()
        {
            bool exist = false;
            string breedName = "golden";
            using (var httpClient = new HttpClient())
            {
               
                Console.WriteLine("Perform an API request to produce a random image / link for the sub-breed “golden”(Diagram 4)");
                Console.WriteLine("------------------------------------------------------");

                var result = httpClient.GetStringAsync("https://dog.ceo/api/breeds/image/random");
                var responseObj = JsonConvert.DeserializeObject<dynamic>(result.Result);
                if (responseObj.status == "success")
                {
                    var image = responseObj.message;

                    Console.WriteLine("\t -" + image.Value);

                }
            }

            return exist;
        }

    }
}
