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
            string jsonString = File.ReadAllText("articles.json");
            articles = JsonSerializer.Deserialize<List<ArticleType>>(jsonString);

        }

        private void InitializePanier()
        {
            panier = new List<ArticlePanier>();
        }
        private void BtnSaveArticles_Click(object sender, EventArgs e)
        {
            SaveArticlesToFile(articles);
        }


        private void SaveArticlesToFile(List<ArticleType> articles)
        {
            var options = new JsonSerializerOptions
            {
                WriteIndented = true // Pour une sortie lisible
            };

            try
            {
                // Sérialiser la liste des articles en JSON
                string jsonString = JsonSerializer.Serialize(articles, options);
                Console.WriteLine(jsonString);

                // Sauvegarder le JSON dans un fichier
                File.WriteAllText("articles.json", jsonString);


                // afficher un message de succès avec les articles sauvegardés
                MessageBox.Show("Les articles ont été sauvegardés avec succès dans le dossier ", "Succès", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                // Si une erreur se produit, affichez un message d'erreur
                MessageBox.Show($"Erreur lors de la sauvegarde des articles : {ex.Message}", "Erreur", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }



        private void PopulateDataGridView()
        {
            dataGridView1.Rows.Clear();
            MessageBox.Show(articles.Where(a => a == null).Count().ToString());
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

                // Mettre à jour la quantité de l'article dans la liste des articles
                var articleInList = articles.FirstOrDefault(a => a.Nom == nom);
                if (articleInList != null && articleInList.Quantite > 0)
                {
                    articleInList.Quantite--; // Réduire la quantité de l'article dans la liste
                }

                // Mettre à jour l'affichage du DataGridView avec les nouvelles quantités
                PopulateDataGridView();

                MessageBox.Show($"L'article {article.Nom} a été ajouté au panier.");
            }

            if (e.RowIndex >= 0 && e.ColumnIndex == dataGridView1.Columns["ViewColumn"].Index)
            {
                string nom = dataGridView1.Rows[e.RowIndex].Cells["Nom"].Value.ToString();
                var article = articles.FirstOrDefault(a => a.Nom == nom);
                if (article != null)
                {
                    MessageBox.Show(JsonSerializer.Serialize(article));
                }
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
