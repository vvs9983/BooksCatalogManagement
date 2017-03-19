using BooksCatalogManagement.Api.Models;
using System.Threading.Tasks;

namespace BooksCatalogManagement.Gui
{
    class Logic
    {
        private Api _api;

        public Logic()
        {
            _api = Api.Instance;
        }

        public async Task<Catalog> GetCatalogAsync()
        {
            return await _api.GetCatalogAsync();
        }

        public void SaveCatalog(Catalog catalog)
        {
            _api.SaveCatalogAsync(catalog);
        }
    }
}
