using DatabaseProject.view.panels.initialmenu;
using DatabaseProject.view.panels.warmenu.clanselection;

namespace DatabaseProject.view.panels.warmenu
{
    public partial class WarMenuPanel : UserControl
    {
        public WarMenuPanel()
        {
            InitializeComponent();
        }

        private void BackButton_Click(object sender, EventArgs e)
        {
            var mainForm = (ClashOfClansDatabaseApplication)this.Parent!;
            mainForm.LoadPanel(new InitialMenuPanel());
        }

        private void StartWar_Click(object sender, EventArgs e)
        {
            var mainForm = (ClashOfClansDatabaseApplication)this.Parent!;
            mainForm.LoadPanel(new ClanSelectionPanel());
        }

        // TODO: maybe in the next patches :)
        private void ShowWarsButton_Click(object sender, EventArgs e)
        {
            var mainForm = (ClashOfClansDatabaseApplication)this.Parent!;
            // mainForm.LoadPanel(new WarsPanel());
        }
    }
}
