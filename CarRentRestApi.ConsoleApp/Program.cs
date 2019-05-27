using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CarRentRestApi.BLL;
using CarRentRestApi.Models;
using System.IO;
using System.IO.Compression;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Xml;
using System.Xml.Serialization;
using Newtonsoft.Json;
using System.Net;

namespace CarRentRestApi.ConsoleApp
{
        class Program
        {
            /*static void Main(string[] args)
      {
          KiralikBilgiBusiness kiralikBusiness = new KiralikBilgiBusiness();
          List<KiralikBilgi> kiralikBilgi = kiralikBusiness.ListAll();
          foreach(var item in kiralikBilgi)
          {
              Console.WriteLine(item.KiralikID);
          }
          Console.Read();     
      }*/
            static HttpClient client = new HttpClient();

            static void ShowProduct(KiralikBilgi kiralik)
            {
                Console.WriteLine($"KiralikID: {kiralik.KiralikID}\tAracID: " +
                    $"{kiralik.AracID}\tAlınanUcret: {kiralik.AlinanUcret}");
            }

            static async Task<Uri> CreateProductAsync(KiralikBilgi kiralik)
            {

                HttpResponseMessage response = await client.PostAsJsonAsync(
                    "api/KiralikBilgi", kiralik);
                response.EnsureSuccessStatusCode();

                // return URI of the created resource.
                return response.Headers.Location;
            }

            static async Task<KiralikBilgi> GetProductAsync(string path)
            {
                KiralikBilgi kiralik = null;
                HttpResponseMessage response = await client.GetAsync(path);
                if (response.IsSuccessStatusCode)
                {
                    kiralik = await response.Content.ReadAsAsync<KiralikBilgi>();
                }
                return kiralik;
            }

            static async Task<KiralikBilgi> UpdateProductAsync(KiralikBilgi kiralik)
            {
                HttpResponseMessage response = await client.PutAsJsonAsync(
                    $"api/KiralikBilgi/{kiralik.AracID}", kiralik);
                response.EnsureSuccessStatusCode();

                // Deserialize the updated product from the response body.
                kiralik = await response.Content.ReadAsAsync<KiralikBilgi>();
                return kiralik;
            }

            static async Task<HttpStatusCode> DeleteProductAsync(int id)
            {
                HttpResponseMessage response = await client.DeleteAsync(
                    $"api/KiralikBilgi/{id}");
                return response.StatusCode;
            }

            static void Main()
            {
                RunAsync().GetAwaiter().GetResult();
            }

        /*public static class HttpResponseMessageExtensions
        {
            public static async Task EnsureSuccessStatusCodeAsync(this HttpResponseMessage response)
            {
                if (response.IsSuccessStatusCode)
                {
                    return;
                }

                var content = await response.Content.ReadAsStringAsync();

                if (response.Content != null)
                    response.Content.Dispose();

                throw new SimpleHttpResponseException(response.StatusCode, content);
            }
        }

        public class SimpleHttpResponseException : Exception
        {
            public HttpStatusCode StatusCode { get; private set; }

            public SimpleHttpResponseException(HttpStatusCode statusCode, string content) : base(content)
            {
                StatusCode = statusCode;
            }
        }
        public static void EnsureSuccessStatusCode(this HttpResponseMessage response)
        {
            if (response.IsSuccessStatusCode)
            {
                return;
            }

            var content = response.Content.ReadAsStringAsync().GetAwaiter().GetResult();

            if (response.Content != null)
                response.Content.Dispose();

            throw new SimpleHttpResponseException(response.StatusCode, content);
        }*/

        static async Task RunAsync()
            {
                // Update port # in the following line.
                client.BaseAddress = new Uri("http://localhost:52009/");
                client.DefaultRequestHeaders.Accept.Clear();
                client.DefaultRequestHeaders.Accept.Add(
                    new MediaTypeWithQualityHeaderValue("application/problem+json"));

                try
                {
                    // Create a new product
                    KiralikBilgi kiralik = new KiralikBilgi
                    {
                        KiralikID = 6,
                        AracID = 6,
                        AlinanUcret = 500
                    };

                    var url = await CreateProductAsync(kiralik);
                    Console.WriteLine($"Created at {url}");

                    // Get the product
                    kiralik = await GetProductAsync(url.PathAndQuery);
                    ShowProduct(kiralik);

                    // Update the product
                    Console.WriteLine("Updating price...");
                    kiralik.AracID = 8;
                    await UpdateProductAsync(kiralik);

                    // Get the updated product
                    kiralik = await GetProductAsync(url.PathAndQuery);
                    ShowProduct(kiralik);

                    // Delete the product
                    var statusCode = await DeleteProductAsync(kiralik.KiralikID);
                    Console.WriteLine($"Deleted (HTTP Status = {(int)statusCode})");

                }
                catch (Exception e)
                {
                    Console.WriteLine(e.Message);
                }

                Console.ReadLine();
            }
        }
    }
