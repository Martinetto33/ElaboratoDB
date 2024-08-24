//using DatabaseProject.daos;
//using DatabaseProject.database;
//using System;
//using System.Collections.Generic;
//using System.ComponentModel;
//using System.Data;
//using System.Drawing;
//using System.Linq;
//using System.Text;
//using System.Threading.Tasks;
//using System.Windows.Forms;

//namespace DatabaseProject.view
//{
//    public partial class AccountInsertionForm : Form
//    {
//        public Giocatore player { get; }
//        public AccountInsertionForm(Giocatore player)
//        {
//            this.player = player;
//            InitializeComponent();
//            this.Shown += new EventHandler(AccountInsertionForm_Shown);
//        }

//        private void AccountInsertionForm_Shown(object? sender, EventArgs e)
//        {
//            this.textBox1.Focus();
//        }

//        private void textBox2_TextChanged(object sender, EventArgs e)
//        {

//        }

//        private void cancelButton_Click(object sender, EventArgs e)
//        {
//            this.DialogResult = DialogResult.Cancel;
//            this.Close();
//        }

//        private void confirmButton_Click(object sender, EventArgs e)
//        {
//            AccountDao.CreateAccount(player, textBox1.Text, textBox2.Text);
//            this.DialogResult = DialogResult.OK;
//            this.Close();
//        }
//    }
//}
