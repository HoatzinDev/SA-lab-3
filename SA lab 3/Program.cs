using SA_lab_3.BLL;

namespace SA_lab_3
{
    internal static class Program
    {
        /// <summary>
        ///  The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            // To customize application configuration such as set high DPI settings or default font,
            // see https://aka.ms/applicationconfiguration.
            ApplicationConfiguration.Initialize();
            AppService globalService = new AppService(); 
            Application.Run(new enter(globalService));   
        }
    }
}