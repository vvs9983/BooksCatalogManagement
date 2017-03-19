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

        private void dataGridViewCatalog_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {
            buttonSave.Enabled = true;
        }

        private void buttonSave_Click(object sender, System.EventArgs e)
        {
            _logic.SaveCatalog(_catalog);
            buttonSave.Enabled = false;
        }
    }
}
