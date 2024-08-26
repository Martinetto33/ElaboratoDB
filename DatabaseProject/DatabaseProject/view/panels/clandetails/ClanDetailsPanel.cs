using DatabaseProject.daos;
using DatabaseProject.mapper;
using DatabaseProject.model.code;
using DatabaseProject.view.panels.player;

namespace DatabaseProject.view.panels.clandetails
{
    public partial class ClanDetailsPanel : UserControl
    {
        private List<AccountDataRepresentation> _accounts = [];
        private Clan Clan { get; set; }
        public ClanDetailsPanel(Clan clan)
        {
            InitializeComponent();
            this.Clan = clan;
            FetchAccountData();
            UpdateMainLabels();
            AddAccountsToListView();
        }

        private void FetchAccountData()
        {
            List<Guid> parsedIds = this.Clan.Members.Keys.Select(id => Guid.Parse(id)).ToList();
            _accounts = AccountDao
                .GetStarsAndTrophiesFromAccounts(AccountDao.GetAllAccountsFromAccountIds(parsedIds))
                .Select
                (
                    keyValuePair =>
                    new AccountDataRepresentation
                    (
                        account: DatabaseToModelMapper.Map(keyValuePair.Key),
                        accountTrophies: keyValuePair.Value.Key,
                        accountStars: keyValuePair.Value.Value
                    )
                ).ToList();
        }

        private void UpdateMainLabels()
        {
            this.trophiesLabel.Text = $"Trofei totali: {this._accounts.Sum(account => account.AccountTrophies)}";
            this.starsLabel.Text = $"Stelle totali: {this._accounts.Sum(account => account.AccountStars)}";
            this.clanLabel.Text = $"Clan: {this.Clan.Name}";
        }

        private void AddAccountsToListView()
        {
            foreach (var accountData in _accounts)
            {
                var account = accountData.Account;
                var accountItem = new ListViewItem(account.Username);
                accountItem.SubItems.Add(this.Clan.Members[account.Id].ToString());
                accountItem.SubItems.Add(accountData.AccountTrophies.ToString());
                this.membersListView.Items.Add(accountItem);
            }
        }

        private void BackButton_Click(object sender, EventArgs e)
        {
            var mainForm = (ClashOfClansDatabaseApplication)ParentForm!;
            mainForm.LoadPanel(new ClanPanel());
        }
    }

    internal class AccountDataRepresentation(Account account, int accountTrophies, int accountStars)
    {
        public Account Account { get; } = account;
        public int AccountTrophies { get; } = accountTrophies;
        public int AccountStars { get; } = accountStars;
    }
}
