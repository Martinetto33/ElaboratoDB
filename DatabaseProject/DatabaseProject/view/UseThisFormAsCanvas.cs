using DatabaseProject.daos;
using DatabaseProject.database;
using DatabaseProject.model.code;
using DatabaseProject.view.images;

namespace DatabaseProject
{
    public partial class UseThisFormAsCanvas : Form
    {
        public Panel PanelContainer { get; set; }

        public UseThisFormAsCanvas()
        {
            InitializeComponent();
        }

        private void BackButton_Click(object sender, EventArgs e)
        {
            //PanelContainer.Controls.Clear();
            //PanelContainer.Controls.Add(new InitialMenuPanel());
        }
    }
}
