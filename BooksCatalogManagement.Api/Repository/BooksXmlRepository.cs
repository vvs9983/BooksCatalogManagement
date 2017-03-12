using BooksCatalogManagement.Api.Models;
using System.IO;
using System.Xml.Serialization;

namespace BooksCatalogManagement.Api.Repository
{
    public sealed class BooksXmlRepository
    {
        private static volatile BooksXmlRepository _instance;
        private static object _syncRoot = new object();
        private static readonly string _catalogPath = @"Books.xml";

        private BooksXmlRepository() {}

        public static BooksXmlRepository Instance
        {
            get
            {
                if (_instance == null)
                {
                    lock (_syncRoot)
                    {
                        if (_instance == null)
                        {
                            _instance = new BooksXmlRepository();
                        }
                    }
                }

                return _instance;
            }
        }

        public Catalog GetCatalog()
        {
            var catalogXml = File.ReadAllText(_catalogPath);

            using (var stringReader = new StringReader(catalogXml))
            {
                var xmlSerializer = new XmlSerializer(typeof(Catalog));

                return xmlSerializer.Deserialize(stringReader) as Catalog;
            }
        }

        public void SaveCatalog(Catalog catalog)
        {
            using (var streamWriter = File.OpenWrite(_catalogPath))
            {
                var xmlSerializer = new XmlSerializer(typeof(Catalog));

                xmlSerializer.Serialize(streamWriter, catalog);
            }
        }
    }
}