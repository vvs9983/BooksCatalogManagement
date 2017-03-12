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

        public async Task<Catalog> GetCatalogAsync() => await _api.GetCatalogAsync();
    }
}
