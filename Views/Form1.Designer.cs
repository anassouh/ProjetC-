﻿using static System.Net.Mime.MediaTypeNames;
using System.Windows.Forms;
using System.Xml.Linq;

namespace Views
{
    partial class Form1
    {
        private System.ComponentModel.IContainer components = null;
        private DataGridView dataGridView1;
        private DataGridViewTextBoxColumn Nom;
        private DataGridViewTextBoxColumn Prix;
        private DataGridViewTextBoxColumn Quantite;
        private DataGridViewTextBoxColumn Categorie;
        private DataGridViewButtonColumn ViewColumn;
        private Label label1;
        private Button btnAddArticle;

        // Dans la méthode InitializeComponent() :
        


        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            dataGridView1 = new DataGridView();
            Nom = new DataGridViewTextBoxColumn();
            Prix = new DataGridViewTextBoxColumn();
            Quantite = new DataGridViewTextBoxColumn();
            Categorie = new DataGridViewTextBoxColumn();
            ViewColumn = new DataGridViewButtonColumn();
            label1 = new Label();
            ((System.ComponentModel.ISupportInitialize)dataGridView1).BeginInit();
            SuspendLayout();

            // 
            // dataGridView1
            // 
            dataGridView1.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridView1.Columns.AddRange(new DataGridViewColumn[] { Nom, Prix, Quantite, Categorie, ViewColumn });
            dataGridView1.Location = new Point(32, 114);
            dataGridView1.Name = "dataGridView1";
            dataGridView1.RowTemplate.Height = 25;
            dataGridView1.Size = new Size(714, 150);
            dataGridView1.TabIndex = 0;
            dataGridView1.CellContentClick += dataGridView1_CellContentClick;

            // 
            // Nom
            // 
            Nom.HeaderText = "Nom";
            Nom.Name = "Nom";

            // 
            // Prix
            // 
            Prix.HeaderText = "Prix";
            Prix.Name = "Prix";

            // 
            // Quantite
            // 
            Quantite.HeaderText = "Quantite";
            Quantite.Name = "Quantite";

            // 
            // Categorie
            // 
            Categorie.HeaderText = "Categorie";
            Categorie.Name = "Categorie";

            // 
            // ViewColumn
            // 
            ViewColumn.HeaderText = "Action";
            ViewColumn.Name = "ViewColumn";
            ViewColumn.Text = "Afficher";
            ViewColumn.UseColumnTextForButtonValue = true;

            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI", 12F, FontStyle.Bold, GraphicsUnit.Point);
            label1.Location = new Point(32, 69);
            label1.Name = "label1";
            label1.Size = new Size(96, 21);
            label1.TabIndex = 1;
            label1.Text = "Vos articles";

            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(label1);
            Controls.Add(dataGridView1);
            Name = "Form1";
            Text = "Gestionnaire du magasin";
            ((System.ComponentModel.ISupportInitialize)dataGridView1).EndInit();
            ResumeLayout(false);
            PerformLayout();



            btnAddArticle = new Button();
            btnAddArticle.Location = new Point(32, 300);
            btnAddArticle.Name = "btnAddArticle";
            btnAddArticle.Size = new Size(150, 30);
            btnAddArticle.Text = "Ajouter un article";
            btnAddArticle.UseVisualStyleBackColor = true;
            btnAddArticle.Click += BtnAddArticle_Click;

            Controls.Add(btnAddArticle);
        }
    }
}
