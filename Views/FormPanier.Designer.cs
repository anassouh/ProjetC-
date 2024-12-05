namespace Views
{
    partial class FormPanier
    {
        private System.ComponentModel.IContainer components = null;
        private DataGridView dataGridViewPanier;
        private Button btnRetirer;
        private Button btnFermer;
        private Label lblTotal;

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

            // btnFermer
            btnFermer.Location = new Point(450, 200);
            btnFermer.Size = new Size(100, 30);
            btnFermer.Text = "Fermer";
            btnFermer.Click += btnFermer_Click;

            // lblTotal
            lblTotal.Location = new Point(400, 180);
            lblTotal.Size = new Size(150, 30);
            lblTotal.Text = "Total : 0,00 €";

            // FormPanier
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(600, 250);
            Controls.Add(dataGridViewPanier);
            Controls.Add(btnRetirer);
            Controls.Add(btnFermer);
            Controls.Add(lblTotal);
            Text = "Panier";
        }
    }
}
