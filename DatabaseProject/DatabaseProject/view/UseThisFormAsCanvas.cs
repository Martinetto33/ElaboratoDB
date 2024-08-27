using DatabaseProject.daos;
using DatabaseProject.database;
using DatabaseProject.model.code;
using DatabaseProject.view.images;
using DatabaseProject.view.panels.initialmenu;

namespace DatabaseProject
{
    public partial class UseThisFormAsCanvas : Form
    {
        public UseThisFormAsCanvas()
        {
            InitializeComponent();
        }

        private void BackButton_Click(object sender, EventArgs e)
        {
            var mainForm = (ClashOfClansDatabaseApplication)this.Parent!;
            mainForm.LoadPanel(new InitialMenuPanel());
        }

        private void ConfirmButton_Click(object sender, EventArgs e)
        {

        }
    }
}
