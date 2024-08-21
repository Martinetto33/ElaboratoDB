using DatabaseProject.database;

namespace DatabaseProject.view.panels
{
    public class VillagePanel: UserControl
    {
        public Account Account { get; }
        public Villaggio Village { get { return this.Account.IdVillaggioNavigation; } }
        public VillagePanel(Account account)
        {
            this.Account = account;
            InitializeComponent();
        }

        private void InitializeComponent()
        {

        }
    }
}
