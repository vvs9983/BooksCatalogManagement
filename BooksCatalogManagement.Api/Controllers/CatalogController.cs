using BooksCatalogManagement.Api.Models;
using BooksCatalogManagement.Api.Repository;
using System.Net;
using System.Web.Http;

namespace BooksCatalogManagement.Api.Controllers
{
    public class CatalogController : ApiController
    {
        private Catalog _catalog;

        public CatalogController()
        {
            _catalog = BooksXmlRepository.Instance.GetCatalog();
        }
        
        public Catalog GetCatalog()
        {
            return _catalog;
        }
    }
}
