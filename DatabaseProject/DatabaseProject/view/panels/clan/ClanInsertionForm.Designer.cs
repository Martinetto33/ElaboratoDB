namespace DatabaseProject.view
{
    partial class ClanInsertionForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ClanInsertionForm));
            textBox1 = new TextBox();
            label1 = new Label();
            firstNameLabel = new Label();
            lastNameLabel = new Label();
            confirmButton = new Button();
            cancelButton = new Button();
            accountsComboBox = new ComboBox();
            SuspendLayout();
            // 
            // textBox1
            // 
            textBox1.Font = new Font("Segoe UI", 15F);
            textBox1.Location = new Point(79, 111);
            textBox1.Name = "textBox1";
            textBox1.Size = new Size(642, 34);
            textBox1.TabIndex = 0;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI", 18F);
            label1.Location = new Point(252, 22);
            label1.Name = "label1";
            label1.Size = new Size(258, 32);
            label1.TabIndex = 1;
            label1.Text = "Inserisci un nuovo clan";
            label1.Click += label1_Click;
            // 
            // firstNameLabel
            // 
            firstNameLabel.AutoSize = true;
            firstNameLabel.Font = new Font("Segoe UI", 15F);
            firstNameLabel.Location = new Point(79, 67);
            firstNameLabel.Name = "firstNameLabel";
            firstNameLabel.Size = new Size(66, 28);
            firstNameLabel.TabIndex = 2;
            firstNameLabel.Text = "Nome";
            firstNameLabel.Click += firstNameLabel_Click;
            // 
            // lastNameLabel
            // 
            lastNameLabel.AutoSize = true;
            lastNameLabel.Font = new Font("Segoe UI", 15F);
            lastNameLabel.Location = new Point(79, 169);
            lastNameLabel.Name = "lastNameLabel";
            lastNameLabel.Size = new Size(135, 28);
            lastNameLabel.TabIndex = 2;
            lastNameLabel.Text = "Account Capo";
            // 
            // confirmButton
            // 
            confirmButton.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
            confirmButton.BackColor = Color.PaleGreen;
            confirmButton.Font = new Font("Segoe UI", 12F);
            confirmButton.Location = new Point(586, 314);
            confirmButton.Name = "confirmButton";
            confirmButton.Size = new Size(135, 33);
            confirmButton.TabIndex = 3;
            confirmButton.Text = "Conferma";
            confirmButton.UseVisualStyleBackColor = false;
            confirmButton.Click += confirmButton_Click;
            // 
            // cancelButton
            // 
            cancelButton.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
            cancelButton.BackColor = Color.Salmon;
            cancelButton.Font = new Font("Segoe UI", 12F);
            cancelButton.Image = (Image)resources.GetObject("cancelButton.Image");
            cancelButton.ImageAlign = ContentAlignment.MiddleLeft;
            cancelButton.Location = new Point(445, 314);
            cancelButton.Name = "cancelButton";
            cancelButton.Size = new Size(135, 33);
            cancelButton.TabIndex = 3;
            cancelButton.Text = "Annulla";
            cancelButton.UseVisualStyleBackColor = false;
            cancelButton.Click += cancelButton_Click;
            // 
            // accountsComboBox
            // 
            accountsComboBox.FormattingEnabled = true;
            accountsComboBox.Location = new Point(79, 200);
            accountsComboBox.Name = "accountsComboBox";
            accountsComboBox.Size = new Size(642, 23);
            accountsComboBox.TabIndex = 4;
            // 
            // ClanInsertionForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 374);
            Controls.Add(accountsComboBox);
            Controls.Add(cancelButton);
            Controls.Add(confirmButton);
            Controls.Add(lastNameLabel);
            Controls.Add(firstNameLabel);
            Controls.Add(label1);
            Controls.Add(textBox1);
            Name = "ClanInsertionForm";
            Text = "PlayerInsertionForm";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private TextBox textBox1;
        private Label label1;
        private Label firstNameLabel;
        private Label lastNameLabel;
        private Button confirmButton;
        private Button cancelButton;
        private ComboBox accountsComboBox;
    }
}