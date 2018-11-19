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
    public static class SubBreed
    {
        public static bool SubBreedName(string breedName)
        {

            var SubBreedExists = false;
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
                            SubBreedExists = true;
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
                                //if(property.Any())
                                // {
                                //     Console.WriteLine()
                                // }
                            }

                        }
                    }
                }

                return SubBreedExists;
            }

        }
    }
    }