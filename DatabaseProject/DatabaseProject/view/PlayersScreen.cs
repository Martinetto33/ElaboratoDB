using DatabaseProject.daos;
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
    public partial class PlayersScreen : Form
    {
        public PlayersScreen()
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

        }
    }
}
