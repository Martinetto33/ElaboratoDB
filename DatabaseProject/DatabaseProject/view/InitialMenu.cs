using DatabaseProject.view;
using System.Runtime.InteropServices;
using System.Windows.Forms;

namespace DatabaseProject
{
    public partial class InitialMenu : Form
    {
        public Panel? PanelContainer { get; set; }
        public InitialMenu()
        {
            InitializeComponent();
        }

        // The Exit button
        private void exitButton_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void playersButton_Click(object sender, EventArgs e)
        {
            PlayersScreen playersScreen = new()
            {
                PanelContainer = this.PanelContainer!
            };
            ViewLoader.LoadPanel(playersScreen, this.PanelContainer!);
            Console.WriteLine("Players button clicked");
        }

        private void clansButton_Click(object sender, EventArgs e)
        {
            /*ClansMenu clansMenu = new ClansMenu();
            clansMenu.Show();*/
            Console.WriteLine("Clans button clicked");
        }

        private void warsButton_Click(object sender, EventArgs e)
        {
            /*WarsMenu warsMenu = new WarsMenu();
            warsMenu.Show();*/
            Console.WriteLine("Wars button clicked");
        }

        /**
         * This method is called when the form is loaded.
         * It allocates a console window.
         * Code taken from:
         * https://stackoverflow.com/questions/4362111/how-do-i-show-a-console-output-window-in-a-forms-application
         */
        private void Form1_Load(object sender, EventArgs e)
        {
            AllocConsole();
        }

        [DllImport("kernel32.dll", SetLastError = true)]
        [return: MarshalAs(UnmanagedType.Bool)]
        static extern bool AllocConsole();
    }
}
