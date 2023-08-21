using HarmonyAssistant.UI.Windows.MainWindow;
using System;
using System.Windows;

namespace HarmonyAssistant
{
    public class Program
    {
        [STAThread]
        static void Main(string[] args)
        {
            MainWindow mainWindow = new MainWindow();
            mainWindow.Show();

            Application application = new Application();
            application.MainWindow = mainWindow;
            application.Run();
        }
    }
}
