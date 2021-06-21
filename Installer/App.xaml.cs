using Installer.ViewModel;
using System.ComponentModel;
using System.Diagnostics;
using System.Linq;
using System.Reflection;
using System.Security.Principal;
using System.Windows;

namespace Installer
{
    /// <summary>
    /// Логика взаимодействия для App.xaml
    /// </summary>
    public partial class App : Application
    {
        private void Application_Startup(object sender, StartupEventArgs e)
        {
            WindowsPrincipal pricipal = new WindowsPrincipal(WindowsIdentity.GetCurrent());
            bool hasAdministrativeRight = pricipal.IsInRole(WindowsBuiltInRole.Administrator);

            if (hasAdministrativeRight == false)
            {
                ProcessStartInfo processInfo = new ProcessStartInfo();
                processInfo.Verb = "runas";
                processInfo.FileName = Assembly.GetExecutingAssembly().Location;

                var arguments = "";
                for (int i = 0; i < e.Args.Count(); i++)
                {
                    arguments = $"{arguments} {e.Args[i]}";
                }
                processInfo.Arguments = arguments;
                try
                {
                    Process.Start(processInfo);
                }
                catch (Win32Exception)
                {

                }
                Application.Current.Shutdown();
            }
            else
            {
                if (e.Args.Length == 0)
                {
                    MainWindow window = new MainWindow();
                    window.DataContext = new MainWindowViewModel(window);
                    window.Show();
                }
                else
                {
                    foreach (string s in e.Args)
                    {

                    }
                }
            }
        }
    }
}
