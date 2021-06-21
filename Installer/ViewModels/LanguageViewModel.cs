namespace Installer.ViewModel
{
    public class LanguageViewModel : BaseModel
    {
        #region Fields
        private MainWindowViewModel main;
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
        #endregion

        #region Constructors
        public LanguageViewModel(MainWindowViewModel owner)
        {
            main = owner;
        }
        #endregion
    }
}
