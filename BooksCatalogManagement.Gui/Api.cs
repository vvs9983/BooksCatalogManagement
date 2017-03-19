using BooksCatalogManagement.Api.Models;
using Newtonsoft.Json;
using System;
using System.IO;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace BooksCatalogManagement.Gui
{
    class Api
    {
        private static volatile Api _instance;
        private static object _syncRoot = new object();
        private HttpClient httpClient;

        private Api()
        {
            httpClient = new HttpClient();
            httpClient.BaseAddress = new Uri(@"http://localhost:51556/");
            httpClient.DefaultRequestHeaders.Accept.Clear();
        }

        public static Api Instance
        {
            get
            {
                if (_instance == null)
                {
                    lock (_syncRoot)
                    {
                        if (_instance == null)
                        {
                            _instance = new Api();
                        }
                    }
                }

                return _instance;
            }
        }

        public async Task<Catalog> GetCatalogAsync()
        {
            string catalogContent = string.Empty;

            try
            {
                var httpResponseMessage = await httpClient.GetAsync("api/catalog");

                if (httpResponseMessage.IsSuccessStatusCode)
                {
                    catalogContent = await httpResponseMessage.Content.ReadAsStringAsync();
                }
            }
            catch (Exception)
            {

                throw;
            }

            return Deserialize(catalogContent);
        }

        public async void SaveCatalogAsync(Catalog catalog)
        {
            try
            {
                var httpResponseMessage = await httpClient.PostAsJsonAsync("api/catalog", catalog);
            }
            catch (Exception)
            {

                throw;
            }
        }

        private Catalog Deserialize(string json)
        {
            using (TextReader stringReader = new StringReader(json))
            {
                var jsonSerializer = new JsonSerializer();

                var res = jsonSerializer.Deserialize(stringReader, typeof(Catalog)) as Catalog;
                return res;
            }
        }
    }
}
