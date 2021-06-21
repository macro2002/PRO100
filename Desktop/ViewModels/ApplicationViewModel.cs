using Desktop.Infrastructure;
using Desktop.View.Administrations;
using Desktop.View.Module;
using Desktop.ViewModel.Administrations;
using Desktop.ViewModel.Module;
using Desktop.ViewModel.Settings;
using System.Windows.Controls;

namespace Desktop.ViewModel
{
    public class ApplicationViewModel : BaseModel
    {
        #region Private Properties
        private UserControl menu;
        private UserControl displayContent;
        // ViewContents
        private UserControl calendar;
        private UserControl projects;
        private UserControl administration;
        private SettingsViewModel settingsViewModel;
        #endregion

        #region Public Properties
        public UserControl Menu
        {
            get => menu;
            set
            {
                if (Equals(menu, value)) return;
                menu = value;
                OnPropertyChanged();
            }
        }

        public UserControl DisplayContent
        {
            get => displayContent;
            set
            {
                displayContent = value;
                OnPropertyChanged();
            }
        }

        public UserControl Calendar
        {
            get
            {
                if (calendar == null)
                {
                    //calendar = new CalendarControl { DataContext = new CalendarViewModel() };
                }
                return calendar;
            }
        }

        public UserControl Projects
        {
            get
            {
                if (projects == null)
                {
                    //taskManager = new TaskManagerControl { DataContext = new TaskManagerViewModel() };
                }
                return projects;
            }
        }

        public UserControl Administration
        {
            get
            {
                if (administration == null)
                {
                    administration = new AdministrationControl { DataContext = new AdministrationViewModel() };
                }
                return administration;
            }
        }

        public SettingsViewModel SettingsViewModel
        {
            get
            {
                if (settingsViewModel == null)
                {
                    settingsViewModel = new SettingsViewModel();
                }
                return settingsViewModel;
            }
        }
        #endregion

        #region Constructors
        public ApplicationViewModel()
        {
            menu = new SideMenuControl { DataContext = new SideMenuViewModel(this) };
        }
        #endregion
    }
}
