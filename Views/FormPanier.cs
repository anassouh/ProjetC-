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
        private void BtnSauvegarderCommande_Click(object sender, EventArgs e)
        {
            if (!panier.Any())
            {
                MessageBox.Show("Le panier est vide. Ajoutez des articles avant de sauvegarder.");
                return;
            }

            // Générer un nom de commande
            string commandeNom = $"Commande_{DateTime.Now:yyyyMMdd_HHmmss}";

            // Calculer le total de la commande
            decimal total = panier.Sum(article => article.Total);

            // Sauvegarder la commande dans la liste des commandes validées
            string commandeDetails = $"{commandeNom} - Total : {total:C}";
            Form1.commandesValidees.Add(commandeDetails);

            // Effacer l'affichage actuel des commandes sauvegardées
            lstCommandesSauvegardees.Items.Clear();

            // Ajouter la liste des commandes mises à jour
            lstCommandesSauvegardees.Items.AddRange(Form1.commandesValidees.ToArray());

            // Vider le panier après sauvegarde
            panier.Clear();
            PopulatePanierDataGridView();

            // Mettre à jour le total du panier (vide)
            lblTotal.Text = "Total : 0,00 €";

            MessageBox.Show($"Commande sauvegardée : {commandeNom} avec un total de {total:C}");
        }

    }
}
