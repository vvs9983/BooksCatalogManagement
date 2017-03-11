using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Xml.Serialization;

namespace BooksCatalogManagement.Api.Models
{
    [XmlRoot("catalog")]
    public class Catalog
    {
        [XmlArray("book")]
        public List<Book> BooksCatalog { get; set; }
    }
}