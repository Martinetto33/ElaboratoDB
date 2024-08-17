using DatabaseProject.daos;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DatabaseProject.view
{
    public partial class PlayerInsertionForm : Form
    {
        public PlayerInsertionForm()
        {
            InitializeComponent();
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
