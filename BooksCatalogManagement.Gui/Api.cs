using BooksCatalogManagement.Api.Models;
using Newtonsoft.Json;
using System;
using System.IO;
using System.Net.Http;
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
                HttpResponseMessage httpResponseMessage = await httpClient.GetAsync("api/catalog");

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

        private Catalog Deserialize(string xml)
        {
            using (TextReader stringReader = new StringReader(xml))
            {
                var jsonSerializer = new JsonSerializer();

                var res = jsonSerializer.Deserialize(stringReader, typeof(Catalog)) as Catalog;
                return res;
            }
        }
    }
}
