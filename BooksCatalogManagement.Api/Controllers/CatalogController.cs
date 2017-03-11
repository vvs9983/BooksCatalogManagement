using BooksCatalogManagement.Api.Models;
using BooksCatalogManagement.Api.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
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
