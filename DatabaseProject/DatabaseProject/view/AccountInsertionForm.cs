using DatabaseProject.daos;
using DatabaseProject.mapper;
using DatabaseProject.model.code;

namespace DatabaseProject.view
{
    public partial class AccountInsertionForm : Form
    {
        public Player player { get; }
        public AccountInsertionForm(Player player)
        {
            this.player = player;
            InitializeComponent();
            this.Shown += new EventHandler(AccountInsertionForm_Shown);
        }

        private void AccountInsertionForm_Shown(object? sender, EventArgs e)
        {
            this.textBox1.Focus();
        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void cancelButton_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
            this.Close();
        }

        private void confirmButton_Click(object sender, EventArgs e)
        {
            AccountDao.CreateAccount(DatabaseToModelMapper.Unmap(player), textBox1.Text, textBox2.Text);
            this.DialogResult = DialogResult.OK;
            this.Close();
        }
    }
}
