//namespace DatabaseProject.view
//{
//    partial class AccountInsertionForm
//    {
//        /// <summary>
//        /// Required designer variable.
//        /// </summary>
//        private System.ComponentModel.IContainer components = null;

//        /// <summary>
//        /// Clean up any resources being used.
//        /// </summary>
//        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
//        protected override void Dispose(bool disposing)
//        {
//            if (disposing && (components != null))
//            {
//                components.Dispose();
//            }
//            base.Dispose(disposing);
//        }

//        #region Windows Form Designer generated code

//        /// <summary>
//        /// Required method for Designer support - do not modify
//        /// the contents of this method with the code editor.
//        /// </summary>
//        private void InitializeComponent()
//        {
//            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(AccountInsertionForm));
//            label1 = new Label();
//            createAccountLabel = new Label();
//            label2 = new Label();
//            textBox1 = new TextBox();
//            label3 = new Label();
//            textBox2 = new TextBox();
//            cancelButton = new Button();
//            confirmButton = new Button();
//            SuspendLayout();
//            // 
//            // label1
//            // 
//            label1.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
//            label1.AutoEllipsis = true;
//            label1.Font = new Font("Segoe UI", 25F);
//            label1.Location = new Point(59, 22);
//            label1.Name = "label1";
//            label1.Size = new Size(624, 46);
//            label1.TabIndex = 0;
//            label1.Text = $"{this.player.Nome} {this.player.Cognome}";
//            // 
//            // createAccountLabel
//            // 
//            createAccountLabel.AutoSize = true;
//            createAccountLabel.Font = new Font("Segoe UI", 15F);
//            createAccountLabel.Location = new Point(59, 79);
//            createAccountLabel.Name = "createAccountLabel";
//            createAccountLabel.Size = new Size(213, 28);
//            createAccountLabel.TabIndex = 1;
//            createAccountLabel.Text = "Crea un nuovo account";
//            // 
//            // label2
//            // 
//            label2.AutoSize = true;
//            label2.Location = new Point(59, 132);
//            label2.Name = "label2";
//            label2.Size = new Size(60, 15);
//            label2.TabIndex = 2;
//            label2.Text = "Surname";
//            // 
//            // textBox1
//            // 
//            textBox1.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
//            textBox1.Location = new Point(63, 155);
//            textBox1.Name = "textBox1";
//            textBox1.Size = new Size(675, 23);
//            textBox1.TabIndex = 3;
//            // 
//            // label3
//            // 
//            label3.AutoSize = true;
//            label3.Location = new Point(61, 205);
//            label3.Name = "label3";
//            label3.Size = new Size(36, 15);
//            label3.TabIndex = 2;
//            label3.Text = "Email";
//            // 
//            // textBox2
//            // 
//            textBox2.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
//            textBox2.Location = new Point(65, 228);
//            textBox2.Name = "textBox2";
//            textBox2.Size = new Size(673, 23);
//            textBox2.TabIndex = 3;
//            textBox2.TextChanged += textBox2_TextChanged;
//            // 
//            // cancelButton
//            // 
//            cancelButton.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
//            cancelButton.BackColor = Color.Salmon;
//            cancelButton.Font = new Font("Segoe UI", 12F);
//            cancelButton.Image = (Image)resources.GetObject("cancelButton.Image");
//            cancelButton.ImageAlign = ContentAlignment.MiddleLeft;
//            cancelButton.Location = new Point(490, 383);
//            cancelButton.Name = "cancelButton";
//            cancelButton.Size = new Size(135, 33);
//            cancelButton.TabIndex = 4;
//            cancelButton.Text = "Annulla";
//            cancelButton.UseVisualStyleBackColor = false;
//            cancelButton.Click += cancelButton_Click;
//            // 
//            // confirmButton
//            // 
//            confirmButton.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
//            confirmButton.BackColor = Color.PaleGreen;
//            confirmButton.Font = new Font("Segoe UI", 12F);
//            confirmButton.Location = new Point(631, 383);
//            confirmButton.Name = "confirmButton";
//            confirmButton.Size = new Size(135, 33);
//            confirmButton.TabIndex = 5;
//            confirmButton.Text = "Conferma";
//            confirmButton.UseVisualStyleBackColor = false;
//            confirmButton.Click += confirmButton_Click;
//            // 
//            // AccountInsertionForm
//            // 
//            AutoScaleDimensions = new SizeF(7F, 15F);
//            AutoScaleMode = AutoScaleMode.Font;
//            ClientSize = new Size(800, 450);
//            Controls.Add(confirmButton);
//            Controls.Add(cancelButton);
//            Controls.Add(textBox2);
//            Controls.Add(label3);
//            Controls.Add(textBox1);
//            Controls.Add(label2);
//            Controls.Add(createAccountLabel);
//            Controls.Add(label1);
//            Name = "AccountInsertionForm";
//            Text = "AccountInsertion";
//            ResumeLayout(false);
//            PerformLayout();
//        }

//        #endregion

//        private Label label1;
//        private Label createAccountLabel;
//        private Label label2;
//        private TextBox textBox1;
//        private Label label3;
//        private TextBox textBox2;
//        private Button cancelButton;
//        private Button confirmButton;
//    }
//}