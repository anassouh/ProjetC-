using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using static Views.Form1;

namespace Views
{
    public partial class FormPanier : Form
    {
        private List<ArticlePanier> panier;
        public enum TypePromotion
        {
            Pourcentage,
            MontantFixe
        }
        private TypePromotion typePromotion;
        private decimal valeurPromotion;
        private decimal totalApresPromotion = 0;


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
        private void BtnAppliquerPromotion_Click(object sender, EventArgs e)
        {
            ComboBox cmbTypePromotion = (ComboBox)Controls["cmbTypePromotion"];
            TextBox txtValeurPromotion = (TextBox)Controls["txtValeurPromotion"];

            if (cmbTypePromotion.SelectedItem == null || string.IsNullOrWhiteSpace(txtValeurPromotion.Text))
            {
                MessageBox.Show("Veuillez sélectionner un type de promotion et entrer une valeur.", "Erreur", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // Récupérer le type et la valeur de la promotion
            typePromotion = (TypePromotion)Enum.Parse(typeof(TypePromotion), cmbTypePromotion.SelectedItem.ToString());
            if (!decimal.TryParse(txtValeurPromotion.Text, out valeurPromotion) || valeurPromotion <= 0)
            {
                MessageBox.Show("Veuillez entrer une valeur valide pour la promotion.", "Erreur", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // Calculer et afficher le total ajusté
            decimal totalAvantPromotion = CalculerTotalPanier();
            totalApresPromotion = AppliquerPromotion(totalAvantPromotion); // Mettre à jour la variable globale
            lblTotal.Text = $"Total après promotion : {totalApresPromotion:C}";

            MessageBox.Show($"Promotion appliquée avec succès ! Nouveau total : {totalApresPromotion:C}");
        }

        private decimal CalculerTotalPanier()
        {
            decimal total = 0;
            foreach (var article in panier)
            {
                total += article.Prix * article.Quantite;
            }
            return total;
        }
        private decimal AppliquerPromotion(decimal total)
        {
            switch (typePromotion)
            {
                case TypePromotion.Pourcentage:
                    return total - (total * (valeurPromotion / 100));
                case TypePromotion.MontantFixe:
                    return Math.Max(total - valeurPromotion, 0); // Total minimum de 0
                default:
                    return total;
            }
        }
        private void BtnSauvegarderCommande_Click(object sender, EventArgs e)
        {
            if (!panier.Any())
            {
                MessageBox.Show("Le panier est vide. Ajoutez des articles avant de sauvegarder.");
                return;
            }

            // Utiliser le total après promotion si disponible, sinon le total normal
            decimal total = totalApresPromotion > 0 ? totalApresPromotion : CalculerTotalPanier();

            // Générer un nom de commande
            string commandeNom = $"Commande_{DateTime.Now:yyyyMMdd_HHmmss}";

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

            // Réinitialiser les totaux et promotions
            lblTotal.Text = "Total : 0,00 €";
            totalApresPromotion = 0;

            MessageBox.Show($"Commande sauvegardée : {commandeNom} avec un total de {total:C}");
        }


    }
}
