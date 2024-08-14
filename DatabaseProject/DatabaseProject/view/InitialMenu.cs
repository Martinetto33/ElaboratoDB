using System.Runtime.InteropServices;

namespace DatabaseProject
{
    public partial class InitialMenu : Form
    {
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
            PlayersScreen playersScreen = new();
            LoadFormIntoPanel(playersScreen);
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

        private void LoadFormIntoPanel(Form form)
        {
            form.TopLevel = false;
            form.FormBorderStyle = FormBorderStyle.None;
            form.Dock = DockStyle.Fill;
            this.panelContainer.Controls.Clear();
            this.panelContainer.Controls.Add(form);
            form.Show();
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
