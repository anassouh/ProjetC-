using static Views.Form1;
namespace Views
{
    partial class FormAddArticle
    {
        private Label lblNom;
        private Label lblPrix;
        private Label lblQuantite;
        private Label lblType;
        private TextBox txtNom;
        private TextBox txtPrix;
        private TextBox txtQuantite;
        private ComboBox cmbType;
        private Button btnSave;
        private Button btnCancel;

        private void InitializeComponent()
        {
            lblNom = new Label();
            lblPrix = new Label();
            lblQuantite = new Label();
            lblType = new Label();
            txtNom = new TextBox();
            txtPrix = new TextBox();
            txtQuantite = new TextBox();
            cmbType = new ComboBox();
            btnSave = new Button();
            btnCancel = new Button();

            SuspendLayout();

            // Nom
            lblNom.AutoSize = true;
            lblNom.Location = new Point(30, 30);
            lblNom.Name = "lblNom";
            lblNom.Size = new Size(40, 15);
            lblNom.Text = "Nom :";

            txtNom.Location = new Point(100, 30);
            txtNom.Name = "txtNom";
            txtNom.Size = new Size(200, 23);

            // Prix
            lblPrix.AutoSize = true;
            lblPrix.Location = new Point(30, 70);
            lblPrix.Name = "lblPrix";
            lblPrix.Size = new Size(30, 15);
            lblPrix.Text = "Prix :";

            txtPrix.Location = new Point(100, 70);
            txtPrix.Name = "txtPrix";
            txtPrix.Size = new Size(200, 23);

            // Quantité
            lblQuantite.AutoSize = true;
            lblQuantite.Location = new Point(30, 110);
            lblQuantite.Name = "lblQuantite";
            lblQuantite.Size = new Size(55, 15);
            lblQuantite.Text = "Quantité :";

            txtQuantite.Location = new Point(100, 110);
            txtQuantite.Name = "txtQuantite";
            txtQuantite.Size = new Size(200, 23);

            // Type
            lblType.AutoSize = true;
            lblType.Location = new Point(30, 150);
            lblType.Name = "lblType";
            lblType.Size = new Size(35, 15);
            lblType.Text = "Type :";

            cmbType.DropDownStyle = ComboBoxStyle.DropDownList;
            cmbType.Location = new Point(100, 150);
            cmbType.Name = "cmbType";
            cmbType.Size = new Size(200, 23);
            cmbType.Items.AddRange(Enum.GetNames(typeof(TypeArticle)));

            // Save button
            btnSave.Location = new Point(100, 200);
            btnSave.Name = "btnSave";
            btnSave.Size = new Size(75, 30);
            btnSave.Text = "Ajouter";
            btnSave.UseVisualStyleBackColor = true;
            btnSave.Click += btnSave_Click;

            // Cancel button
            btnCancel.Location = new Point(225, 200);
            btnCancel.Name = "btnCancel";
            btnCancel.Size = new Size(75, 30);
            btnCancel.Text = "Annuler";
            btnCancel.UseVisualStyleBackColor = true;
            //btnCancel.Click += (s, e) => DialogResult = DialogResult.Cancel;

            // FormAddArticle
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(350, 280);
            Controls.Add(lblNom);
            Controls.Add(txtNom);
            Controls.Add(lblPrix);
            Controls.Add(txtPrix);
            Controls.Add(lblQuantite);
            Controls.Add(txtQuantite);
            Controls.Add(lblType);
            Controls.Add(cmbType);
            Controls.Add(btnSave);
            Controls.Add(btnCancel);
            Name = "FormAddArticle";
            Text = "Ajouter un article";
            ResumeLayout(false);
            PerformLayout();
        }
    }
}