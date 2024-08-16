using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DatabaseProject.view
{
    internal static class ViewLoader
    {
        public static void LoadPanel(Form form, Panel parentPanel)
        {
            //form.TopLevel = false;
            form.FormBorderStyle = FormBorderStyle.None;
            form.Dock = DockStyle.Fill;
            //parentPanel.Controls.Clear();
            Console.Write("Controls contained in form: ");
            foreach (var control in form.Controls)
            {
                Console.Write(control.ToString() + " ");
            }
            //parentPanel.Controls.Add(form);
            form.Show();
        }
    }
}
