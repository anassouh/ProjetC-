using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json;
using System.IO;
using System.Windows.Forms;

namespace Views
{
    public partial class Form1 : Form
    {

        
        private List<ArticleType> articles;
        private List<ArticlePanier> panier = new List<ArticlePanier>();
        public static List<string> commandesValidees { get; set; } = new List<string>();

        public Form1()
        {

            InitializeComponent();
            InitializeArticles();
            PopulateDataGridView();
            InitializePanier();
            //UpdateTotalLabel();
        }

        private void InitializeArticles()
        {
            articles = new List<ArticleType>
            {
                new ArticleType("Pomme", 2.5m, 50, TypeArticle.Alimentaire),
                new ArticleType("Savon", 3.2m, 30, TypeArticle.Droguerie),
                new ArticleType("T-shirt", 15.0m, 20, TypeArticle.Habillement),
                new ArticleType("Jeu vidéo", 60.0m, 10, TypeArticle.Loisir)
            };
        }

        private void InitializePanier()
        {
            panier = new List<ArticlePanier>();
        }
        


        private void PopulateDataGridView()
        {
            dataGridView1.Rows.Clear();
            foreach (var article in articles)
            {
                dataGridView1.Rows.Add(article.Nom, article.Prix, article.Quantite, article.Type, "Afficher");
            }
        }

        private void BtnAddArticle_Click(object sender, EventArgs e)
        {
            using (var formAdd = new FormAddArticle())
            {
                if (formAdd.ShowDialog() == DialogResult.OK)
                {
                    var newArticle = formAdd.NewArticle;
                    articles.Add(newArticle);
                    PopulateDataGridView();
                    MessageBox.Show("Article ajouté avec succès !", "Succès", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
        }

        private void PopulatePanierDataGridView()
        {
            dataGridViewPanier.Rows.Clear();
            foreach (var article in panier)
            {
                dataGridViewPanier.Rows.Add(article.Nom, article.Prix, article.Quantite);
            }
        }


        private void BtnAddToCart_Click(object sender, EventArgs e)
        {
            // Sélectionnez l'article de la DataGridView principale
            var selectedRow = dataGridView1.SelectedRows[0];
            string nom = selectedRow.Cells["Nom"].Value.ToString();
            var article = articles.FirstOrDefault(a => a.Nom == nom);

            if (article.Nom != null)
            {
                // Vérifiez si l'article est déjà dans le panier
                var existingArticle = panier.FirstOrDefault(p => p.Nom == article.Nom);
                if (existingArticle != null) {
                    // Si l'article est déjà dans le panier, augmentez la quantité
                    existingArticle.Quantite++;
                }
                else
                {
                    // Sinon, ajoutez le nouvel article
                    panier.Add(new ArticlePanier(article.Nom, article.Prix, 1));
                }

                PopulatePanierDataGridView(); // Mettez à jour l'affichage du panier
            }
        }

        private void BtnRemoveFromCart_Click(object sender, EventArgs e)
        {
            var selectedRow = dataGridViewPanier.SelectedRows[0];
            string nom = selectedRow.Cells["Nom"].Value.ToString();
            var article = panier.FirstOrDefault(a => a.Nom == nom);

            if (article.Nom != null)
            {
                panier.Remove(article);
                PopulatePanierDataGridView(); // Mettez à jour l'affichage du panier
            }
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


        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex == dataGridView1.Columns["AddToCartColumn"].Index && e.RowIndex >= 0)
            {
                // Récupérer l'article sélectionné
                string nom = dataGridView1.Rows[e.RowIndex].Cells["Nom"].Value.ToString();
                decimal prix = Convert.ToDecimal(dataGridView1.Rows[e.RowIndex].Cells["Prix"].Value);
                var article = new ArticlePanier(nom, prix, 1); // Ajouter avec une quantité de 1

                // Vérifier si l'article est déjà dans le panier
                var existingArticle = panier.FirstOrDefault(p => p.Nom == article.Nom);
                if (existingArticle != null)
                {
                    // Si l'article est déjà dans le panier, augmenter la quantité
                    existingArticle.Quantite++;
                }
                else
                {
                    // Sinon, ajouter le nouvel article
                    panier.Add(article);
                }

                MessageBox.Show($"L'article {article.Nom} a été ajouté au panier.");
            }
        }

        private void btnPanier_Click(object sender, EventArgs e)
        {
            // Ouvrir la fenêtre du panier et passer la liste des articles dans le panier
            using (var formPanier = new FormPanier(panier))
            {
                formPanier.ShowDialog();
            }
        }
    }
}
