//using DatabaseProject.view;
//using System.Runtime.InteropServices;
//using System.Windows.Forms;

//namespace DatabaseProject
//{
//    public partial class ClashOfClansDatabaseApplication : Form
//    {
//        public ClashOfClansDatabaseApplication()
//        {
//            InitializeComponent();
//        }

//        public void LoadPanel(UserControl panel)
//        {
//            this.Controls.Clear();
//            panel.Dock = DockStyle.Fill;
//            this.Controls.Add(panel);
//        }

//        /**
//         * This method is called when the form is loaded.
//         * It allocates a console window.
//         * Code taken from:
//         * https://stackoverflow.com/questions/4362111/how-do-i-show-a-console-output-window-in-a-forms-application
//         */
//        private void Form1_Load(object sender, EventArgs e)
//        {
//            AllocConsole();
//        }

//        [DllImport("kernel32.dll", SetLastError = true)]
//        [return: MarshalAs(UnmanagedType.Bool)]
//        static extern bool AllocConsole();
//    }
//}
