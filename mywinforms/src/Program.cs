using System;
using System.Text;
using System.Windows.Forms;

namespace MyProduct
{
    static class Program
    {
        /// <summary>
        ///  The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            // To customize application configuration such as set high DPI settings or default font,
            // see https://aka.ms/applicationconfiguration.
            //-:cnd:noEmit
#if NET6_0_OR_GREATER
            Encoding.RegisterProvider(CodePagesEncodingProvider.Instance);
            ApplicationConfiguration.Initialize();
#else
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            //Application.SetCompatibleTextRenderingDefault(true);
            //Application.SetHighDpiMode(HighDpiMode.SystemAware);
#endif
            //+:cnd:noEmit
            Application.Run(new MainForm());
        }
    }
}