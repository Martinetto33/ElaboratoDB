using DatabaseProject.model.api;
using DatabaseProject.model.code;
using DatabaseProject.common;

namespace DatabaseProject.view.panels.village
{
    public partial class UpgradingBuildingControl : UserControl
    {
        private static readonly int TIMER_INTERVAL = 1000;
        private static readonly int MAX_PROGRESS = 100;
        private readonly string displayedText;
        private readonly IUpgradeObservable<BaseBuilding> upgradePerformer;
        public UpgradingBuildingControl(string stringToDisplay, IUpgradeObservable<BaseBuilding> upgradePerformer)
        {
            this.displayedText = stringToDisplay;
            this.upgradePerformer = upgradePerformer;
            InitializeComponent();
            this.displayedStringLabel.Text = this.displayedText;
            this.timeLabel.Text = $"Tempo rimanente: {Utils.MapMillisToTime(this.upgradePerformer.GetUpgradeTime())}";
            this.timer1.Interval = TIMER_INTERVAL;
            this.progressBar1.Maximum = MAX_PROGRESS;
            this.timer1.Start();
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            this.progressBar1.Value = MapProgressToPercentage();
            if (this.progressBar1.Value == MAX_PROGRESS)
            {
                this.timer1.Stop();
            }
            this.timeLabel.Text = $"Tempo rimanente: {Utils.MapMillisToTime(this.upgradePerformer.GetRemainingUpgradeTime())}";
        }

        private int MapProgressToPercentage()
        {
            long interval = this.upgradePerformer.GetUpgradeTime();
            long remaining = this.upgradePerformer.GetRemainingUpgradeTime();
            return interval > 0 ? (int)((interval - remaining) * MAX_PROGRESS / interval) : MAX_PROGRESS;
        }

    }
}
