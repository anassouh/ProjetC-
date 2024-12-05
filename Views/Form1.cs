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
        public Form1()
        {
            InitializeComponent();
            InitializeArticles();
            PopulateDataGridView();
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

        private void PopulateDataGridView()
        {
            dataGridView1.Rows.Clear();
            foreach (var article in articles)
            {
                dataGridView1.Rows.Add(article.Nom, article.Prix, article.Quantite, article.Type, "Afficher");
            }
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex == dataGridView1.Columns["ViewColumn"].Index && e.RowIndex >= 0)
            {
                string nom = dataGridView1.Rows[e.RowIndex].Cells["Nom"].Value.ToString();
                var article = articles.FirstOrDefault(a => a.Nom == nom);
                if (article.Nom != null)
                {
                    MessageBox.Show(JsonSerializer.Serialize(article));

                }
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

    }
}
