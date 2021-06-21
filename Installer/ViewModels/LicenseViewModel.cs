using System;
using System.IO;
using System.Reflection;

namespace Installer.ViewModel
{
    public class LicenseViewModel : BaseModel
    {
        #region Fields
        private MainWindowViewModel main;
        private string license;
        #endregion

        #region Public Properties
        public MainWindowViewModel Main
        {
            get => main;
            set
            {
                main = value;
                OnPropertyChanged();
            }
        }

        public string License
        {
            get => license;
            set
            {
                license = value;
                OnPropertyChanged();
            }
        }
        #endregion

        #region Command

        #endregion

        #region Constructors
        public LicenseViewModel(MainWindowViewModel owner)
        {
            main = owner;

            var assembly = Assembly.GetExecutingAssembly();
            var resourceName = "Installer.Languages.ru_RU.license.txt";
            try
            {
                using (Stream stream = assembly.GetManifestResourceStream(resourceName))
                using (StreamReader reader = new StreamReader(stream))
                {
                    license = reader.ReadToEnd();
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
        }
        #endregion
    }
}
