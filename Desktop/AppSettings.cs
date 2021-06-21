using Desktop.Infrastructure;
using Desktop.Model.Users;
using Desktop.Properties;
using System;
using System.Windows;

namespace Desktop
{
    public class AppSettings : BaseModel
    {
        #region Public Properties

        public static User User;

        #endregion

        #region Public Methods
        public static void InitializationSettings()
        {
            // иницализация языковых настроек
            InitializationLanguage();
        }

        public static void SetLanguage(string language)
        {
            ResourceDictionary dictionary = new ResourceDictionary();
            switch (language)
            {
                case "ru-RU":
                    dictionary.Source = new Uri("Infrastructure/Languages/ru-RU.xaml", UriKind.Relative);
                    break;
                case "et-EE":
                    dictionary.Source = new Uri("Infrastructure/Languages/et-EE.xaml", UriKind.Relative);
                    break;
                default:
                    dictionary.Source = new Uri("Infrastructure/Languages/en-US.xaml", UriKind.Relative);
                    break;
            }
            Application.Current.Resources.MergedDictionaries[0] = dictionary;
        }

        #endregion

        #region Private Methods
        private static void InitializationLanguage()
        {
            if (string.IsNullOrEmpty(Settings.Default.Language))
            {
                SetLanguage(System.Globalization.CultureInfo.CurrentCulture.ToString());
            }
            else
            {
                SetLanguage(Settings.Default.Language);
            }
        }
        #endregion
    }
}
