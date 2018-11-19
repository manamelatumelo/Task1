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
    public static class VerifyBreed
    {
        public static bool CheckBreed(string breedName)
        {
            var breedExists = false;
            using (var httpClient = new HttpClient())
            {
                var result = httpClient.GetStringAsync("https://dog.ceo/api/breeds/list/all");
                var responseObj = JsonConvert.DeserializeObject<dynamic>(result.Result);

                if (responseObj.status == "success")
                {
                    var breeds = responseObj.message;
             
                    foreach (JProperty property in breeds.Properties())
                    {
                        if (property.Name.ToLower() == breedName.ToLower())
                        {
                            breedExists = true;
                            break;
                        }

                    }
                }
            }

            return breedExists;
        }
    }
}
