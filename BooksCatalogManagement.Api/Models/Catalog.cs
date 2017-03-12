using System.Collections.Generic;
using System.Xml.Serialization;

namespace BooksCatalogManagement.Api.Models
{
    [XmlRoot("catalog")]
    public class Catalog
    {
        [XmlElement("book")]
        public List<Book> Books { get; set; } = new List<Book>();
    }
}