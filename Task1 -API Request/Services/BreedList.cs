using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace Task1__API_Request
{
    public static class BreedList
    {
        public static void ListAllBreed()
        {
            using (var httpClient = new HttpClient())
            {
                Console.WriteLine("Perform an API request to produce a list of all dog breeds. (Diagram 1)");
                Console.WriteLine("------------------------------------------------------");

                var result = httpClient.GetStringAsync("https://dog.ceo/api/breeds/list/all");
                var responseObj = JsonConvert.DeserializeObject<dynamic>(result.Result);
                if (responseObj.status == "success")
                {
                    var breeds = responseObj.message;

                    foreach (JProperty property in breeds.Properties())
                    {
                        Console.WriteLine(property.Name);
                        if (property.Value is JArray propValue)
                        {
                            if (propValue.Any())
                            {
                                foreach (var val in propValue)
                                {
                                    Console.WriteLine("\t -" + val);
                                }
                            }
                        }
                        Console.WriteLine();
                    }

                }
            }
        }
    }
}
