using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;

namespace DoomModLoader2
{
    static class Program
    {
        /// <summary>
        /// Punto di ingresso principale dell'applicazione.
        /// </summary>
        [STAThread]
        static void Main()
        {
            //try
            //{
                Application.EnableVisualStyles();
                Application.SetCompatibleTextRenderingDefault(false);
                Application.Run(new MainForm());

            //}
            //catch (Exception ex)
            //{
            //    MessageBox.Show("Sorry, an unexpected error occured..." + Environment.NewLine + "ERROR: " + ex.Message);
            //    Application.Exit();
            //}
        }
    }
}
