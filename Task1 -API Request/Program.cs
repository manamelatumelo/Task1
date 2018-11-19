using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Task1__API_Request.Services;

namespace Task1__API_Request
{
    public class Program
    {
        public static void Main(string[] args)
        {
            //Get list of all breeds
            BreedList.ListAllBreed();

            //Call the Verify breed class
            string breedName = "retriever";

            Console.WriteLine("Verify if " + breedName + " " + "Exist" +
                "\n" + "------------------------------------------------------");
            var exists = VerifyBreed.CheckBreed(breedName);
            Console.WriteLine(exists ? "Pass " + breedName + " is withinlist"
                : "Failed" + breedName + " is not within the list");


            Console.WriteLine("Perform an API request to produce a list of sub-breeds for “retriever”. (Diagram 3) "+
               "\n" + "------------------------------------------------------");
            SubBreed.SubBreedName(breedName);
            //Console.WriteLine(exists_ ? "Pass " + breedName + " is withinlist"
            //    : "Failed" + breedName + " is not within the list");


            RandomImage.GetRandomImage();

            Console.ReadLine();
        }


    }

}
