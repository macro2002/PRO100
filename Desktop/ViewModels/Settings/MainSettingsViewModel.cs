using Desktop.Infrastructure;
using Desktop.Model;
using System;
using System.Collections.ObjectModel;
using System.Linq;
using System.Windows;

namespace Desktop.ViewModel.Settings
{
    public class MainSettingsViewModel : BaseModel
    {
        #region Fields
        private string code;
        private ObservableCollection<ComboItem> units = new ObservableCollection<ComboItem>();
        private ComboItem selectedUnit;
        private ObservableCollection<ComboItem> languages = new ObservableCollection<ComboItem>();
        private ComboItem selectedLanguage;
        #endregion

        #region Public Properties
        public string Code
        {
            get => code;
            set
            {
                code = value;
                OnPropertyChanged();
            }
        }

        public ObservableCollection<ComboItem> Units
        {
            get => units;
            set
            {
                units = value;
                OnPropertyChanged();
            }
        }

        public ComboItem SelectedUnit
        {
            get => selectedUnit;
            set
            {
                if (Equals(selectedUnit, value)) return;
                selectedUnit = value;
                OnPropertyChanged();
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

        public ComboItem SelectedLanguage
        {
            get => selectedLanguage;
            set
            {
                if (Equals(selectedLanguage, value)) return;
                selectedLanguage = value;
                OnPropertyChanged();
                ChangeLanguage();
            }
        }
        #endregion

        #region Constructors
        public MainSettingsViewModel()
        {
            code = "AA";
            InitializationUnits();
            InitializationLanguages();
            InitializationSettings();
        }
        #endregion

        #region Private Methods
        private void InitializationUnits()
        {

        }

        private void InitializationLanguages()
        {
            languages.Add(new ComboItem { Name = "ru-RU" });
            languages.Add(new ComboItem { Name = "en-US" });
            languages.Add(new ComboItem { Name = "et-EE" });
        }

        private void InitializationSettings()
        {
            if (string.IsNullOrEmpty(Properties.Settings.Default.Language))
            {
                var language = languages.FirstOrDefault(i => i.Name == System.Globalization.CultureInfo.CurrentCulture.ToString());
                if(language == null)
                {
                    selectedLanguage = languages[1];
                }
            }
            else
            {
                selectedLanguage = languages.FirstOrDefault(i => i.Name == Properties.Settings.Default.Language);
            }

            // Временный метод проверки
            if(selectedLanguage == null)
            {
                selectedLanguage = languages[1];
            }
        }

        private void ChangeLanguage()
        {
            AppSettings.SetLanguage(SelectedLanguage.Name);
        }
        #endregion
    }
}
