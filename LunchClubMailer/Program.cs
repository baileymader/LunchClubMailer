using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace LunchClubMailer
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
            
            // quick hack to run wpf window
            LunchClubMailerWPF window = new LunchClubMailerWPF(new LunchClubModel());
            window.ShowDialog();
        }
    }
}
