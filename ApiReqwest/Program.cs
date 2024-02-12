using System;
using System.Net.Http;
using System.Net.Http.Json;
using Newtonsoft.Json;
using ApiShop;
using ApiShop.Model;

internal class Program
{
    private static void Main(string[] args)
    {
        HttpClient httpClient = new HttpClient();
        async Task Main()
        {

            await Task.Delay(7000);
            List<Product>? products = await httpClient.GetFromJsonAsync<List<Product>>("https://localhost:7122/api/Product");
            if (products != null)
            {
                foreach (var product in products)
                {
                    Console.WriteLine(product.ProductName);
                }
            }
        }

         
    }
}