using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace winFormsClassChat
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            //remove classChat form from Application.Run() to allow for it to close when home.cs is opened
            classChat frm1 = new classChat();
            frm1.Show();
            Application.Run();
        }
    }
}
