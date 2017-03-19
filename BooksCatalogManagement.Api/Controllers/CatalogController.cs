using BooksCatalogManagement.Api.Models;
using BooksCatalogManagement.Api.Repository;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Description;

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
        
        [HttpPost]
        public void SaveCatalog(Catalog catalog)
        {
            BooksXmlRepository.Instance.SaveCatalog(catalog);
        }
    }
}
