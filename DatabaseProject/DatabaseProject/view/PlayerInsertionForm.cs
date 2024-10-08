﻿using DatabaseProject.daos;

namespace DatabaseProject.view
{
    public partial class PlayerInsertionForm : Form
    {
        public PlayerInsertionForm()
        {
            InitializeComponent();
            this.Shown += new EventHandler(PlayerInsertionForm_Load);
        }

        private void PlayerInsertionForm_Load(object sender, EventArgs e)
        {
            textBox1.Focus(); // Set focus to the first name text box
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void firstNameLabel_Click(object sender, EventArgs e)
        {

        }

        private void cancelButton_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
            this.Close();
        }

        private void confirmButton_Click(object sender, EventArgs e)
        {
            PlayerDao.CreatePlayer(textBox1.Text, textBox2.Text);
            this.DialogResult = DialogResult.OK;
            this.Close();
        }
    }
}
