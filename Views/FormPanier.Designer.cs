﻿namespace Views
{
    partial class FormPanier
    {
        private System.ComponentModel.IContainer components = null;
        private DataGridView dataGridViewPanier;
        private Button btnRetirer;
        private Button btnSauvegarderCommande;
        private Button btnFermer;
        private Label lblTotal;
        private ListBox lstCommandesSauvegardees;
        private Button btnValiderCommande;
        private Button btnAnnulerCommande;
        private Label lblEtatCommande;



        private void InitializeComponent()
        {
            dataGridViewPanier = new DataGridView();
            btnRetirer = new Button();
            btnFermer = new Button();
            lblTotal = new Label();
            

            // dataGridViewPanier
            dataGridViewPanier.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewPanier.Columns.AddRange(new DataGridViewColumn[] {
                new DataGridViewTextBoxColumn { HeaderText = "Nom", Name = "Nom" },
                new DataGridViewTextBoxColumn { HeaderText = "Prix", Name = "Prix" },
                new DataGridViewTextBoxColumn { HeaderText = "Quantité", Name = "Quantite" },
                new DataGridViewTextBoxColumn { HeaderText = "Total", Name = "Total" }
            });
            dataGridViewPanier.Location = new Point(30, 30);
            dataGridViewPanier.Size = new Size(500, 150);

            // btnRetirer
            btnRetirer.Location = new Point(30, 200);
            btnRetirer.Size = new Size(100, 30);
            btnRetirer.Text = "Retirer";
            btnRetirer.Click += btnRetirer_Click;

            // btnSauvegarderCommande
            btnSauvegarderCommande = new Button();
            btnSauvegarderCommande.Location = new Point(140, 200);
            btnSauvegarderCommande.Name = "btnSauvegarderCommande";
            btnSauvegarderCommande.Size = new Size(200, 30);
            btnSauvegarderCommande.Text = "Passer la commande";
            btnSauvegarderCommande.UseVisualStyleBackColor = true;
            btnSauvegarderCommande.Click += BtnSauvegarderCommande_Click;

            // btnFermer
            btnFermer.Location = new Point(450, 200);
            btnFermer.Size = new Size(100, 30);
            btnFermer.Text = "Fermer";
            btnFermer.Click += btnFermer_Click;

            // lblTotal
            lblTotal.Location = new Point(400, 180);
            lblTotal.Size = new Size(150, 30);
            lblTotal.Text = "Total : 0,00 €";

            // lstCommandesSauvegardees
            lstCommandesSauvegardees = new ListBox();
            lstCommandesSauvegardees.Location = new Point(30, 250); // Position sous les boutons
            lstCommandesSauvegardees.Size = new Size(520, 100);
            lstCommandesSauvegardees.Name = "lstCommandesSauvegardees";
            lstCommandesSauvegardees.Items.Add("Commandes enregistrées :"); // Titre initial
            lstCommandesSauvegardees.Items.AddRange(Form1.commandesValidees.ToArray());
            // FormPanier
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(600, 400); // Augmenté pour inclure le ListBox
            Controls.Add(dataGridViewPanier);
            Controls.Add(btnRetirer);
            Controls.Add(btnFermer);
            Controls.Add(btnSauvegarderCommande);
            Controls.Add(lblTotal);
            Controls.Add(lstCommandesSauvegardees);
            Text = "Panier";

            ComboBox cmbTypePromotion = new ComboBox
            {
                Location = new Point(30, 350),
                Size = new Size(150, 30),
                Name = "cmbTypePromotion",
                DropDownStyle = ComboBoxStyle.DropDownList
            };
            cmbTypePromotion.Items.AddRange(new[] { "Pourcentage", "MontantFixe" });
            Controls.Add(cmbTypePromotion);

            TextBox txtValeurPromotion = new TextBox
            {
                Location = new Point(200, 350),
                Size = new Size(100, 30),
                Name = "txtValeurPromotion",
                PlaceholderText = "Valeur"
            };
            Controls.Add(txtValeurPromotion);

            Button btnAppliquerPromotion = new Button
            {
                Location = new Point(320, 350),
                Size = new Size(150, 30),
                Text = "Appliquer Promotion",
                Name = "btnAppliquerPromotion"
            };
            btnAppliquerPromotion.Click += BtnAppliquerPromotion_Click;
            Controls.Add(btnAppliquerPromotion);

            lblEtatCommande = new Label
            {
                Location = new Point(400, 180),
                Size = new Size(150, 30),
                Text = "Etat : En Attente"
            };
            Controls.Add(lblEtatCommande);

            // Ajouter le bouton Valider Commande
            btnValiderCommande = new Button
            {
                Location = new Point(140, 250),
                Size = new Size(150, 30),
                Text = "Valider Commande"
            };
            btnValiderCommande.Click += BtnValiderCommande_Click;
            Controls.Add(btnValiderCommande);

            // Ajouter le bouton Annuler Commande
            btnAnnulerCommande = new Button
            {
                Location = new Point(320, 250),
                Size = new Size(150, 30),
                Text = "Annuler Commande"
            };
            btnAnnulerCommande.Click += BtnAnnulerCommande_Click;
            Controls.Add(btnAnnulerCommande);

        }
    }
}
