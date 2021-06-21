using Desktop.Infrastructure;
using Desktop.View;
using Desktop.View.Users;
using System;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;

namespace Desktop.ViewModel
{
    public class MainWindowViewModel : BaseModel
    {
        #region Fields
        private int status;
        private UserControl view;

        #endregion

        #region Public Properties
        public static Window Window;

        /// <summary>
        /// Статус окна: 0 - авторизация, 1 - приложение
        /// </summary>
        public int Status
        {
            get => status;
            set
            {
                status = value;
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
        #endregion

        private RelayCommand actionCommand;

        public RelayCommand ActionCommand =>
          actionCommand ?? (actionCommand = new RelayCommand(obj =>
          {
              ResourceDictionary dictionary = new ResourceDictionary();
              dictionary.Source = new Uri("Infrastructure/Languages/et-EE.xaml", UriKind.Relative);
              Application.Current.Resources.MergedDictionaries[0] = dictionary;

          }));

        #region Constructor
        public MainWindowViewModel(Window window)
        {
            VM.Window = this;
            Window = window;
            AppSettings.InitializationSettings();
            AccesCheck();
        }
        #endregion

        #region Private Methods
        

        /// <summary>
        /// Проверка доступа
        /// </summary>
        private void AccesCheck()
        {
            bool autorization = true;
            if (autorization)
            {
                ViewChange(1);
            }
            else
            {
                ViewChange(0);
            }
        }
        #endregion

        #region Public Methods
        public void ViewChange(int selected)
        {
            switch (selected)
            {
                case 0:
                    Status = selected;
                    View = new AuthorizationControl();
                    break;
                case 1:
                    Status = selected;
                    View = new ApplicationControl { DataContext = new ApplicationViewModel() };
                    break;
            }
        }

        public void KeyDown(Key key)
        {
            switch (status)
            {
                case 0:
                    if (key == Key.Enter)
                    {
                        //var control = view as AuthorizationControl;
                        //(control.DataContext as AuthorizationViewModel).Authorization(control.Passowrd.Password);
                    }
                    break;
            }
        }
        #endregion
    }
}
