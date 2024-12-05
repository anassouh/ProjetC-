using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;

namespace Views
{
    public partial class FormPanier : Form
    {
        private List<ArticlePanier> panier;

        public FormPanier(List<ArticlePanier> panier)
        {
            InitializeComponent();
            this.panier = panier;
            PopulatePanierDataGridView();
        }

        private void PopulatePanierDataGridView()
        {
            dataGridViewPanier.Rows.Clear();
            foreach (var article in panier)
            {
                dataGridViewPanier.Rows.Add(article.Nom, article.Prix, article.Quantite, article.Total);
            }
            UpdateTotalPanier();
        }

        private void UpdateTotalPanier()
        {
            decimal total = panier.Sum(article => article.Total);
            lblTotal.Text = $"Total : {total:C}"; // Format monétaire
        }

        private void btnRetirer_Click(object sender, EventArgs e)
        {
            if (dataGridViewPanier.SelectedRows.Count > 0)
            {
                var selectedRow = dataGridViewPanier.SelectedRows[0];
                string nom = selectedRow.Cells[0].Value.ToString();

                // Trouver l'article dans le panier et le retirer
                var article = panier.FirstOrDefault(a => a.Nom == nom);
                if (article != null)
                {
                    panier.Remove(article);
                }

                PopulatePanierDataGridView(); // Rafraîchir le panier après suppression
            }
            else
            {
                MessageBox.Show("Veuillez sélectionner un article à retirer.");
            }
        }

        private void btnFermer_Click(object sender, EventArgs e)
        {
            this.Close(); // Fermer la fenêtre du panier
        }
    }
}
