using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
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
            Application.ThreadException += new ThreadExceptionEventHandler(Application_ThreadException);
            AppDomain.CurrentDomain.UnhandledException += new UnhandledExceptionEventHandler(CurrentDomain_UnhandledException);

            Application.EnableVisualStyles();
                Application.SetCompatibleTextRenderingDefault(false);
                Application.Run(new MainForm());
  
         
        }

        static void Application_ThreadException(object sender, ThreadExceptionEventArgs e)
        {
            MessageBox.Show("Sorry, an unexpected error occured... the software will close." + Environment.NewLine +
                                "ERROR MESSAGE: " + e.Exception.ToString() + Environment.NewLine +
                                "Please send an email to 'p36software@mail.com' with object 'unexpected error'. In the mail write the error message, and how to recreate it. Thank you!");
            Environment.Exit(1);
        }

        static void CurrentDomain_UnhandledException(object sender, UnhandledExceptionEventArgs e)
        {
            MessageBox.Show("Sorry, an unexpected error occured... the software will close.");
            Environment.Exit(1);
        }
    }
}
