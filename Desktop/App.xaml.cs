using Desktop.Infrastructure.Service;
using Desktop.Properties;
using System;
using System.Reflection;
using System.Threading;
using System.Windows;

namespace Desktop
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        #region Fields
        private const string UniqueEventName = "{273D0564-F896-4A28-950C-934A5B0F8CA2}";
        private const string UniqueMutexName = "{A96B29E2-FE5D-4995-AEAC-976E5DABC63B}";
        private EventWaitHandle eventWaitHandle;
        private Mutex mutex;
        #endregion

        public App()
        {
            bool isOwned;
            mutex = new Mutex(true, UniqueMutexName, out isOwned);
            eventWaitHandle = new EventWaitHandle(false, EventResetMode.AutoReset, UniqueEventName);

            GC.KeepAlive(this.mutex);
            if (isOwned)
            {
                var thread = new Thread(
                    () =>
                    {
                        while (this.eventWaitHandle.WaitOne())
                        {
                            var test = "s";
                            Current.Dispatcher.BeginInvoke(
                                (Action)(() =>
                                (

                                (MainWindow)Current.MainWindow).WindowState = WindowState.Maximized)
                                );
                        }
                    });
                thread.IsBackground = true;
                thread.Start();
                return;
            }
            eventWaitHandle.Set();
            Shutdown();
        }

        private void Application_Startup(object sender, StartupEventArgs e)
        {
            Diagnostic.Start();
            if (e.Args.Length > 0)
            {
                if (e.Args.Length == 3)
                {
                    if(e.Args[0] == "-Installed")
                    {
                        Settings.Default.Language = e.Args[2];
                        Settings.Default.Save();

                        if (e.Args[1] == "-Set")
                        {
                            return;
                        }
                    }
                }
            }
            MainWindow window = new MainWindow();
            window.Show();
            ActionLog.Set($"Запуск приложения, версия: {Assembly.GetExecutingAssembly().GetName().Version}");
        }
    }
}
