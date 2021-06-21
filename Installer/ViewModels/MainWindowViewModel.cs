using Installer.Model;
using Installer.Properties;
using Installer.View;
using IWshRuntimeLibrary;
using Microsoft.Win32;
using System;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.IO;
using System.IO.Compression;
using System.Windows;
using System.Windows.Controls;

namespace Installer.ViewModel
{
    public class MainWindowViewModel : BaseModel
    {
        #region Fields
        private int step;
        private string path;
        private UserControl view;

        private ObservableCollection<ComboItem> languages = new ObservableCollection<ComboItem>();
        private ComboItem selectedLanguage;

        private bool isAccept;
        private bool isInstall;
        private bool isOpen = true;
        #endregion

        #region Public Properties
        public static Window Window;

        public int Step
        {
            get => step;
            set
            {
                step = value;
                OnPropertyChanged();
            }
        }

        public UserControl View
        {
            get => view;
            set
            {
                view = value;
                OnPropertyChanged();
            }
        }

        public ComboItem SelectedLanguage
        {
            get => selectedLanguage;
            set
            {
                if (Equals(selectedLanguage, value)) return;
                selectedLanguage = value;
                OnPropertyChanged();
                ChangeLanguage(SelectedLanguage.Name);
            }
        }

        public ObservableCollection<ComboItem> Languages
        {
            get => languages;
            set
            {
                languages = value;
                OnPropertyChanged();
            }
        }

        public bool IsAccept
        {
            get => isAccept;
            set
            {
                isAccept = value;
                OnPropertyChanged();
            }
        }

        public bool IsInstall
        {
            get => isInstall;
            set
            {
                isInstall = value;
                OnPropertyChanged();
            }
        }

        public bool IsOpen
        {
            get => isOpen;
            set
            {
                isOpen = value;
                OnPropertyChanged();
            }
        }
        #endregion

        #region Command
        private RelayCommand actionCommand;

        public RelayCommand ActionCommand =>
          actionCommand ?? (actionCommand = new RelayCommand(obj =>
          {
              switch(obj.ToString())
              {
                  case "Back":
                      Step--;
                      ViewChange();
                      break;
                  case "Next":
                      Step++;
                      ViewChange();
                      break;
                  case "Cancel":
                      Close();
                      break;
              }
          }));
        #endregion

        #region Constructors
        public MainWindowViewModel(Window window)
        {
            Window = window;
            Window.Closing += Window_Closing;
            InitializationLanguage();
            ViewChange();
        }

        // Тихая установка
        public MainWindowViewModel() { }

        #endregion

        #region Public Methods
        public void ViewChange()
        {
            switch (Step)
            {
                case 0:
                    View = new LanguageControl { DataContext = new LanguageViewModel(this) };
                    break;
                case 1:
                    View = new LicenseControl { DataContext = new LicenseViewModel(this) };
                    break;
                case 2:
                    View = new ApplicationControl { DataContext = new ApplicationViewModel(this) };
                    Install();
                    Step++;
                    break;
                case 4:
                    ApplicationStart();
                    Close();
                    break;
            }
        }

        public void ChangeLanguage(string language)
        {
            ResourceDictionary dictionary = new ResourceDictionary();
            switch (language)
            {
                case "ru-RU":
                    dictionary.Source = new Uri("Languages/ru-RU.xaml", UriKind.Relative);
                    break;
                default:
                    dictionary.Source = new Uri("Languages/en-US.xaml", UriKind.Relative);
                    break;
            }
            Application.Current.Resources.MergedDictionaries[0] = dictionary;
        }

        public void Install()
        {
            path = ProgramFiles();
            Directory.CreateDirectory($@"{path}\PRO100");
            System.IO.File.WriteAllBytes($@"{path}\PRO100\release.zip", Resources.release);

            try
            {
                ZipFile.ExtractToDirectory($@"{path}\PRO100\release.zip", $@"{path}\PRO100");
            }
            catch
            {

                using (ZipArchive archive = ZipFile.OpenRead($@"{path}\PRO100\release.zip"))
                {
                    foreach (var archiveEntry in archive.Entries)
                    {
                        string filePath = Path.Combine($@"{path}\PRO100", archiveEntry.FullName);

                        FileInfo fileInfo = new FileInfo(filePath);
                        fileInfo.Directory.Create();

                        archiveEntry.ExtractToFile(filePath, true);
                    }
                }
            }

            if (System.IO.File.Exists($@"{path}\PRO100\release.zip"))
            {
                System.IO.File.Delete($@"{path}\PRO100\release.zip");
            }

            CreateShortcut();
            RegistrationApplication();
        }

        public void ApplicationStart()
        {
            if(IsOpen)
            {
                Process.Start($@"{path}\PRO100\PRO100.exe", $"-Installed -Start {SelectedLanguage.Name}");
            }
            else
            {
                Process.Start($@"{path}\PRO100\PRO100.exe", $"-Installed -Set {SelectedLanguage.Name}");
            }
        }
        #endregion

        #region Private Methods
        private void InitializationLanguage()
        {
            var language = System.Globalization.CultureInfo.CurrentCulture.ToString();
            ChangeLanguage(language);

            languages.Add(new ComboItem { Name = "ru-RU" });
            languages.Add(new ComboItem { Name = "en-US" });
            switch (language)
            {
                case "ru-RU":
                    SelectedLanguage = Languages[0];
                    break;
                default:
                    SelectedLanguage = Languages[1];
                    break;
            }
        }

        private void CreateShortcut()
        {
            string link = Environment.GetFolderPath(Environment.SpecialFolder.Desktop)
               + Path.DirectorySeparatorChar + "PRO100.lnk";
            var shell = new WshShell();
            var shortcut = shell.CreateShortcut(link) as IWshShortcut;
            shortcut.TargetPath = $@"{path}\PRO100\PRO100.exe";
            shortcut.WorkingDirectory = $@"{path}\PRO100";
            shortcut.Save();
        }

        private string ProgramFiles()
        {
            if (8 == IntPtr.Size
                || (!String.IsNullOrEmpty(Environment.GetEnvironmentVariable("PROCESSOR_ARCHITEW6432"))))
            {
                return Environment.GetEnvironmentVariable("ProgramFiles(x86)");
            }

            return Environment.GetEnvironmentVariable("ProgramFiles");
        }

        private void RegistrationApplication()
        {
            var uninstallKey = Registry.LocalMachine.OpenSubKey("SOFTWARE\\WOW6432Node\\Microsoft\\Windows\\CurrentVersion\\Uninstall", true);
            var programKey = uninstallKey?.CreateSubKey("PRO100");
            programKey?.SetValue("DisplayName", "PRO100");
            programKey?.SetValue("Publisher", "Мебельные Технологии");
            programKey?.SetValue("DisplayVersionr", "1.0.0.0");
            programKey?.SetValue("DisplayIcon", $@"{path}\PRO100\icon002.ico");
            programKey?.SetValue("UninstallString", $@"{path}\PRO100\PRO100.exe -Uninstall");
            programKey?.Close();

            FileAssociation.Associate($@"{path}\PRO100\PRO100.exe", "Files PRO100", $@"{path}\PRO100\project.ico");
        }

        private void Close()
        {
            Window.Close();
        }
        #endregion

        private void Window_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            if (Step == 4)
            {
                return;
            }
            var confirmation = new ConfirmationViewModel();
            new ConfirmationWindow { DataContext = confirmation }.ShowDialog();
            if (confirmation.Continue == false)
            {
                return;
            }
            e.Cancel = true;
        }
    }
}
