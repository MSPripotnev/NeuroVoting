using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace NeuroVoting
{
    static class Program
    {
        static Form form;
        /// <summary>
        /// Главная точка входа для приложения.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Thread.CurrentThread.CurrentUICulture = new System.Globalization.CultureInfo("en");
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            form = new VotingForm();
            Application.Run(form);
        }
    }
}
