using BooksCatalogManagement.Api.Models;
using System.Windows.Forms;

namespace BooksCatalogManagement.Gui
{
    public partial class Main : Form
    {
        private Catalog _catalog;
        private Logic _logic;

        public Main()
        {
            InitializeComponent();

            _logic = new Logic();

            SetCatalog();
        }

        private async void SetCatalog()
        {
            _catalog = await _logic.GetCatalogAsync();
            dataGridViewCatalog.DataSource = _catalog.Books;
        }
    }
}
