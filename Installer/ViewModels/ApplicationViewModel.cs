namespace Installer.ViewModel
{
    public class ApplicationViewModel : BaseModel
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
        public ApplicationViewModel(MainWindowViewModel owner)
        {
            main = owner;
        }
        #endregion
    }
}
