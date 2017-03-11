using BooksCatalogManagement.Api.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace BooksCatalogManagement.Gui
{
    class Api
    {
        private HttpClient httpClient;

        public Api()
        {
            httpClient = new HttpClient();
            httpClient.BaseAddress = new Uri(@"http://localhost:51556/");
            httpClient.DefaultRequestHeaders.Accept.Clear();
        }

        public async Task<Catalog> GetCatalog()
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
            using (var stringReader = new StringReader(xml))
            {
                var xmlSerializer = new XmlSerializer(typeof(Catalog));

                return xmlSerializer.Deserialize(stringReader) as Catalog;
            }
        }
    }
}
