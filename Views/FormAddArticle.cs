using System;
using System.Windows.Forms;
using static Views.Form1;

namespace Views
{
    public partial class FormAddArticle : Form
    {
        public ArticleType NewArticle { get; private set; }

        public FormAddArticle()
        {
            InitializeComponent();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            try
            {
                string nom = txtNom.Text;
                decimal prix = decimal.Parse(txtPrix.Text);
                int quantite = int.Parse(txtQuantite.Text);
                TypeArticle type = (TypeArticle)cmbType.SelectedIndex;

                NewArticle = new ArticleType(nom, prix, quantite, type);
                DialogResult = DialogResult.OK;
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Erreur : {ex.Message}", "Erreur", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
