using Microsoft.Owin.Hosting;
using System;
using System.Net.Http;

namespace UCServidor
{
    public class Program
    {
        static void Main(string[] args)
        {
            string baseAddress = "http://localhost:44331/";

            // Start OWIN host 
            using (WebApp.Start<StartUp>(url: baseAddress))
            {
                // Create HttpClient and make a request to api/values 
                HttpClient client = new HttpClient();

                var response = client.GetAsync(baseAddress + "api/values").Result;

                Console.WriteLine(response);
                Console.WriteLine(response.Content.ReadAsStringAsync().Result);
                Console.ReadLine();
            }
        }
    }
}
