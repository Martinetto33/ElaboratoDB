namespace DatabaseProject.view.panels.clandetails
{
    partial class AddMemberForm
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
            membersCheckedListBox = new CheckedListBox();
            titleLabel = new Label();
            cancelButton = new Button();
            confirmButton = new Button();
            SuspendLayout();
            // 
            // membersCheckedListBox
            // 
            membersCheckedListBox.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            membersCheckedListBox.CheckOnClick = true;
            membersCheckedListBox.ColumnWidth = 300;
            membersCheckedListBox.FormattingEnabled = true;
            membersCheckedListBox.Location = new Point(27, 95);
            membersCheckedListBox.MultiColumn = true;
            membersCheckedListBox.Name = "membersCheckedListBox";
            membersCheckedListBox.Size = new Size(746, 292);
            membersCheckedListBox.TabIndex = 0;
            membersCheckedListBox.SelectedIndexChanged += MembersCheckedListBox_SelectedIndexChanged;
            // 
            // titleLabel
            // 
            titleLabel.AutoSize = true;
            titleLabel.Font = new Font("Segoe UI", 20F);
            titleLabel.Location = new Point(22, 13);
            titleLabel.Name = "titleLabel";
            titleLabel.Size = new Size(308, 37);
            titleLabel.TabIndex = 1;
            titleLabel.Text = "Aggiungi membri al clan";
            // 
            // cancelButton
            // 
            cancelButton.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
            cancelButton.BackColor = Color.Salmon;
            cancelButton.Font = new Font("Segoe UI", 12F);
            cancelButton.Image = Properties.Resources.back_arrow_icon;
            cancelButton.ImageAlign = ContentAlignment.MiddleLeft;
            cancelButton.Location = new Point(490, 407);
            cancelButton.Name = "cancelButton";
            cancelButton.Size = new Size(135, 33);
            cancelButton.TabIndex = 4;
            cancelButton.Text = "Annulla";
            cancelButton.UseVisualStyleBackColor = false;
            cancelButton.Click += cancelButton_Click;
            // 
            // confirmButton
            // 
            confirmButton.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
            confirmButton.BackColor = Color.PaleGreen;
            confirmButton.Font = new Font("Segoe UI", 12F);
            confirmButton.Location = new Point(638, 407);
            confirmButton.Name = "confirmButton";
            confirmButton.Size = new Size(135, 33);
            confirmButton.TabIndex = 5;
            confirmButton.Text = "Conferma";
            confirmButton.UseVisualStyleBackColor = false;
            confirmButton.Click += confirmButton_Click;
            // 
            // AddMemberForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 461);
            Controls.Add(confirmButton);
            Controls.Add(cancelButton);
            Controls.Add(titleLabel);
            Controls.Add(membersCheckedListBox);
            MinimumSize = new Size(600, 500);
            Name = "AddMemberForm";
            Text = "AddMemberForm";
            Load += AddMemberForm_Load;
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private CheckedListBox membersCheckedListBox;
        private Label titleLabel;
        private Button cancelButton;
        private Button confirmButton;
    }
}