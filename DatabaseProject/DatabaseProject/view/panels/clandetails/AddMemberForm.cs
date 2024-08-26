
using DatabaseProject.daos;
using DatabaseProject.mapper;
using DatabaseProject.model.code;

namespace DatabaseProject.view.panels.clandetails
{
    public partial class AddMemberForm : Form
    {
        private List<Account> _accountsWithoutClan = [];
        private List<Account> _selectedAccounts = [];
        private readonly Guid clanGuid;
        public AddMemberForm(Guid clanGuid)
        {
            InitializeComponent();
            this.clanGuid = clanGuid;
        }

        private void AddMemberForm_Load(object sender, EventArgs e)
        {
            _accountsWithoutClan = AccountDao.GetAccountsWithoutAClan()
                .Select(dbAccount => DatabaseToModelMapper.Map(dbAccount))
                .ToList();
            _accountsWithoutClan.ForEach(account => this.membersCheckedListBox.Items.Add(account.Username));
        }

        private void confirmButton_Click(object sender, EventArgs e)
        {
            this._selectedAccounts.ForEach(account => ClanDao.AddMemberToClan(Guid.Parse(account.Id), clanGuid));
            this.DialogResult = DialogResult.OK;
            this.Close();
        }

        private void cancelButton_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
            this.Close();
        }

        private void MembersCheckedListBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            _selectedAccounts.Clear();
            // This method works even with duplicate usernames, as long as the
            // order of items in _accountsWithoutClan does not change.
            for (int i = 0; i < membersCheckedListBox.Items.Count; i++)
            {
                if (membersCheckedListBox.GetItemChecked(i))
                {
                    _selectedAccounts.Add(_accountsWithoutClan[i]);
                }
            }
            Console.WriteLine("Selected accounts:");
            foreach (var account in _selectedAccounts)
            {
                Console.WriteLine(account.Username);
            }
        }
    }
}
