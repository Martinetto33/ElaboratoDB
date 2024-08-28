using DatabaseProject.common;
using DatabaseProject.simulator;
using DatabaseProject.view.panels.initialmenu;

namespace DatabaseProject.view.panels.warmenu.warrecap
{
    public partial class WarRecapPanel : UserControl
    {
        public WarRecapPanel(WarRecap recap)
        {
            InitializeComponent();
            clan1Label.Text = recap.Clan1Name;
            clan2Label.Text = recap.Clan2Name;
            clan1StarsLabel.Text = recap.Clan1Stars.ToString();
            clan2StarsLabel.Text = recap.Clan2Stars.ToString();
            clan1AverageLabel.Text = Utils.MapMillisToTime((long)recap.Clan1AverageAttackTime);
            clan2AverageLabel.Text = Utils.MapMillisToTime((long)recap.Clan2AverageAttackTime);
            string victoryString;
            if (recap.Clan1Stars > recap.Clan2Stars)
            {
                victoryString = $"Vincitore: {recap.Clan1Name}";
            }
            else if (recap.Clan1Stars < recap.Clan2Stars)
            {
                victoryString = $"Vincitore: {recap.Clan2Name}";
            }
            else
            {
                victoryString = "Pareggio!";
            }
            victoryLabel.Text = victoryString;
        }
        private void BackButton_Click(object sender, EventArgs e)
        {
            var mainForm = (ClashOfClansDatabaseApplication)this.Parent!;
            mainForm.LoadPanel(new InitialMenuPanel());
        }

    }
}
