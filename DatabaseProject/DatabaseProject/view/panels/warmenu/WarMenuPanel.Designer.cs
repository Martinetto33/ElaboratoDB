using DatabaseProject.Properties;

namespace DatabaseProject.view.panels.warmenu
{
    public partial class WarMenuPanel
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
        private void InitializeComponent()
        {
            BackButton = new Button();
            startWarButton = new Button();
            showWarsButton = new Button();
            SuspendLayout();
            // 
            // BackButton
            // 
            BackButton.Image = Resources.back_arrow;
            BackButton.Location = new Point(18, 12);
            BackButton.Name = "BackButton";
            BackButton.Size = new Size(50, 50);
            BackButton.TabIndex = 1;
            BackButton.UseVisualStyleBackColor = true;
            BackButton.Click += BackButton_Click;
            // 
            // startWarButton
            // 
            startWarButton.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            startWarButton.Font = new Font("Segoe UI", 15F);
            startWarButton.Location = new Point(88, 92);
            startWarButton.Name = "startWarButton";
            startWarButton.Size = new Size(409, 77);
            startWarButton.TabIndex = 2;
            startWarButton.Text = "Scatena una guerra";
            startWarButton.UseVisualStyleBackColor = true;
            startWarButton.Click += StartWar_Click;
            // 
            // showWarsButton
            // 
            showWarsButton.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            showWarsButton.Font = new Font("Segoe UI", 15F);
            showWarsButton.Location = new Point(88, 220);
            showWarsButton.Name = "showWarsButton";
            showWarsButton.Size = new Size(409, 77);
            showWarsButton.TabIndex = 2;
            showWarsButton.Text = "Visualizza guerre";
            showWarsButton.UseVisualStyleBackColor = true;
            showWarsButton.Click += ShowWarsButton_Click;
            // 
            // WarMenuPanel
            // 
            Controls.Add(showWarsButton);
            Controls.Add(startWarButton);
            Controls.Add(BackButton);
            Name = "WarMenuPanel";
            Size = new Size(584, 461);
            ResumeLayout(false);
        }

        private Button BackButton;
        private Button startWarButton;
        private Button showWarsButton;
    }
}
