using System;
using System.Threading;
using System.Windows.Forms;

namespace USB_Sanitizer
{
    static class Program
    {
        static private Mutex _mutexObject = null;

        /// <summary>
        ///  The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            const string appName = "USB_SANITIZER_APP";
            _mutexObject = new Mutex(true, appName, out bool createdNew);
            if (!createdNew)
            {
                return;
            }

            Application.SetHighDpiMode(HighDpiMode.SystemAware);
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new MainForm());
        }
    }
}
