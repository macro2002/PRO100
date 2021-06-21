using Desktop.Infrastructure;
using System;
using System.Reflection;

namespace Desktop.ViewModel.Settings
{
    public class AboutSettingsViewModel : BaseModel
    {
        #region Fields
        private string currentVersion;
        private string updateVersion;
        private string license;
        #endregion

        #region Public Properties
        public string CurrentVersion
        {
            get => currentVersion;
            set
            {
                currentVersion = value;
                OnPropertyChanged();
            }
        }

        public string UpdateVersion
        {
            get => updateVersion;
            set
            {
                updateVersion = value;
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
        private RelayCommand actionCommand;

        public RelayCommand ActionCommand =>
          actionCommand ?? (actionCommand = new RelayCommand(obj =>
          {
              switch (obj.ToString())
              {
                  case "UpdateApplication":

                      break;
                  case "UpdateLicense":
                      SetLicense();
                      break;
              }
          }));
        #endregion

        #region Constructors
        public AboutSettingsViewModel()
        {
            currentVersion = Assembly.GetExecutingAssembly().GetName().Version.ToString();
            GetLicense();
        }
        #endregion

        #region Private Methods
        private void GetLicense()
        {
            license = Properties.Settings.Default.License.ToString().ToUpper();
        }

        private void SetLicense()
        {
            Properties.Settings.Default.License = Guid.Parse(License);
            //Properties.Settings.Default.License = Guid.Empty;
            Properties.Settings.Default.Save();
        }
        #endregion
    }
}
