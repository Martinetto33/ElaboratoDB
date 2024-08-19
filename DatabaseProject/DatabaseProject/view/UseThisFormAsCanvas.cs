using DatabaseProject.daos;

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
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }
    }
}
