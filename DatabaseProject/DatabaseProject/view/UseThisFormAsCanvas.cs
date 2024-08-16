using DatabaseProject.daos;
using DatabaseProject.view;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DatabaseProject
{
    public partial class UseThisFormAsCanvas : Form
    {
        public Panel PanelContainer { get; set; }

        public UseThisFormAsCanvas()
        {
            InitializeComponent();
        }

        private void PlayersScreen_Load(object sender, EventArgs e)
        {
        }

        private void AddPlayerTestButton_Click(object sender, EventArgs e)
        {
            PlayerDao.CreatePlayer("Alin", "Bordeianu");
            Console.WriteLine("Player added");
        }

        private void BackButton_Click(object sender, EventArgs e)
        {
            ClashOfClansDatabaseApplication initialMenu = new()
            {
                PanelContainer = this.PanelContainer
            };
            ViewLoader.LoadPanel(initialMenu, this.panelContainer);
        }
    }
}
