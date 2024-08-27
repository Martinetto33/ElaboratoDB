using DatabaseProject.daos;
using DatabaseProject.mapper;
using DatabaseProject.model.code;

namespace DatabaseProject.view
{
    public partial class ClanInsertionForm : Form
    {
        private List<Account> _accountsWithoutClan = [];

        public ClanInsertionForm()
        {
            InitializeComponent();
            this.Shown += new EventHandler(ClanInsertionForm_Load);
        }

        private void ClanInsertionForm_Load(object sender, EventArgs e)
        {
            textBox1.Focus(); // Set focus to the first name text box
            _accountsWithoutClan = AccountDao.GetAccountsWithoutAClan()
                .Select(dbAccount => DatabaseToModelMapper.Map(dbAccount))
                .ToList();
            accountsComboBox.DataSource = _accountsWithoutClan.Select(account => account.Username).ToList();
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
            ClanDao.CreateClan(textBox1.Text, DatabaseToModelMapper.Unmap(_accountsWithoutClan[accountsComboBox.SelectedIndex]));
            this.DialogResult = DialogResult.OK;
            this.Close();
        }
    }
}
