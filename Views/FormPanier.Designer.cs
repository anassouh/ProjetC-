namespace Views
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
            btnSauvegarderCommande.Text = "Sauvegarder la commande";
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
        }

        
    }
}
