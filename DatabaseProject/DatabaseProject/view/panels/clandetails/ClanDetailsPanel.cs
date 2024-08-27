using DatabaseProject.common;
using DatabaseProject.daos;
using DatabaseProject.mapper;
using DatabaseProject.model.code;
using DatabaseProject.view.panels.player;

namespace DatabaseProject.view.panels.clandetails
{
    public partial class ClanDetailsPanel : UserControl
    {
        private List<AccountDataRepresentation> _accounts = [];
        private string? _selectedAccountId = null;
        private Clan Clan { get; set; }
        public ClanDetailsPanel(Clan clan)
        {
            InitializeComponent();
            this.Clan = clan;
            FetchAccountData();
            UpdateMainLabels();
            AddAccountsToListView();
        }

        /****** VIEW ELEMENTS *******/
        private void RefreshPanel()
        {
            _accounts.Clear();
            this.membersListView.Items.Clear();
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

        private void ListView1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (this.membersListView.SelectedItems.Count > 0)
            {
                var selectedAccount = _accounts
                    .First(accountData => accountData.Account.Username == membersListView.SelectedItems[0].Text).Account;
                this._selectedAccountId = selectedAccount.Id;
                Console.WriteLine($"Selected account id: {this._selectedAccountId}, username: {selectedAccount.Username}");
            }
            else if (this.membersListView.SelectedItems.Count == 0)
            {
                this._selectedAccountId = null;
                Console.WriteLine("No account selected");
            }
        }

        /****** BUTTONS LOGIC *******/
        private void AddMemberButton_Click(object sender, EventArgs e)
        {
            using var AddMemberForm = new AddMemberForm(Guid.Parse(this.Clan.ClanId));
            var result = AddMemberForm.ShowDialog();
            if (result == DialogResult.OK)
            {
                this.RefreshPanel();
            }
        }

        private void RemoveMemberButton_Click(object sender, EventArgs e)
        {
            if (this._selectedAccountId != null)
            {
                if (this.Clan.RemoveMember(this._selectedAccountId))
                {
                    ClanDao.RemoveMemberFromClan(Guid.Parse(this._selectedAccountId), Guid.Parse(this.Clan.ClanId));
                    this.RefreshPanel();
                }
                else
                {
                    if (this.Clan.Members.Count() > 1)
                    {
                        MessageBox.Show("Prima di rimuovere il Capo, promuovi uno degli altri membri a Capo");
                    }
                    else
                    {
                        DialogResult result = MessageBox.Show("Stai per rimuovere l'ultimo membro del clan, " +
                            "che rimarrà senza un Capo. Vuoi davvero procedere?",
                            null,
                            MessageBoxButtons.OKCancel,
                            MessageBoxIcon.Warning);
                        if (result == DialogResult.OK)
                        {
                            this.Clan.ForceLeaderRemoval();
                            ClanDao.RemoveMemberFromClan(Guid.Parse(this._selectedAccountId), Guid.Parse(this.Clan.ClanId));
                            this.RefreshPanel();
                        }
                    }
                }
            }
            else
            {
                MessageBox.Show("Seleziona un membro da rimuovere.", "Errore", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void PromoteMemberButton_Click(object sender, EventArgs e)
        {
            if (this._selectedAccountId != null)
            {
                Console.WriteLine($"Promoting account {_selectedAccountId}");
                Enums.ClanOperationResult opRes = Clan.PromoteMember(this._selectedAccountId);
                if (opRes != Enums.ClanOperationResult.Success)
                {
                    ShowMessageBoxWithClanOperationResult(opRes);
                }
                switch (opRes)
                {
                    case Enums.ClanOperationResult.Success:
                        var newRole = this.Clan.Members[this._selectedAccountId];
                        ClanDao.ChangeClanMemberRole(Guid.Parse(this._selectedAccountId), Guid.Parse(this.Clan.ClanId), newRole);
                        this.RefreshPanel();
                        break;
                    case Enums.ClanOperationResult.CoLeaderPromotion:
                        string previousLeaderId = this.Clan.GetAndConsumeDemotedLeaderId()!;
                        ClanDao.ChangeClanMemberRole(Guid.Parse(previousLeaderId), Guid.Parse(this.Clan.ClanId), Enums.ClanRole.CoLeader);
                        ClanDao.ChangeClanMemberRole(Guid.Parse(this._selectedAccountId), Guid.Parse(this.Clan.ClanId), Enums.ClanRole.Leader);
                        this.RefreshPanel();
                        break;
                    default:
                        break;
                }
            }
            else
            {
                MessageBox.Show("Seleziona un membro da promuovere.", "Errore", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void DemoteMemberButton_Click(object sender, EventArgs e)
        {
            if (this._selectedAccountId != null)
            {
                Console.WriteLine($"Demoting account {_selectedAccountId}");
                Enums.ClanOperationResult opRes = Clan.DemoteMember(this._selectedAccountId);
                if (opRes != Enums.ClanOperationResult.Success)
                {
                    ShowMessageBoxWithClanOperationResult(opRes);
                }
                switch (opRes)
                {
                    case Enums.ClanOperationResult.Success:
                        var newRole = this.Clan.Members[this._selectedAccountId];
                        ClanDao.ChangeClanMemberRole(Guid.Parse(this._selectedAccountId), Guid.Parse(this.Clan.ClanId), newRole);
                        this.RefreshPanel();
                        break;
                    default:
                        break;
                }
            }
            else
            {
                MessageBox.Show("Seleziona un membro da retrocedere.", "Errore", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private static void ShowMessageBoxWithClanOperationResult(Enums.ClanOperationResult opRes)
        {
            if (opRes != Enums.ClanOperationResult.Success)
            {
                string stringToShow = opRes switch
                {
                    Enums.ClanOperationResult.Success => "Operazione completata con successo.",
                    Enums.ClanOperationResult.CoLeaderPromotion => "Un Co-Capo è stato promosso a Capo. Il Capo precedente sarà retrocesso a Co-Capo.",
                    Enums.ClanOperationResult.LeaderPromotionAttempt => "Impossibile promuovere un Capo.",
                    Enums.ClanOperationResult.NoSuchMember => "Membro non trovato nel clan.",
                    Enums.ClanOperationResult.LeaderDemotionAttempt => "Impossibile retrocedere un Capo.",
                    Enums.ClanOperationResult.MemberDemotionAttempt => "Impossibile retrocedere un Membro.",
                    Enums.ClanOperationResult.UnknownError => "Errore sconosciuto.",
                    _ => "Errore sconosciuto."
                };
                MessageBox.Show(stringToShow, "Errore", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        // Navigation button
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
