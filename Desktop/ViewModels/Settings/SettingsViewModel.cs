using Desktop.Infrastructure;
using Desktop.Model;
using Desktop.View.Settings;
using System.Collections.ObjectModel;
using System.Linq;

namespace Desktop.ViewModel.Settings
{
    public class SettingsViewModel : BaseModel
    {
        #region Fields
        private ObservableCollection<ItemMenu> menuItems = new ObservableCollection<ItemMenu>();
        private ItemMenu selectedMenu;
        private MainSettingsViewModel mainSettingsViewModel;

        private AboutSettingsViewModel aboutSettingsViewModel;
        #endregion

        #region Public Properties
        public ObservableCollection<ItemMenu> MenuItems
        {
            get => menuItems;
            set
            {
                menuItems = value;
                OnPropertyChanged();
            }
        }

        public ItemMenu SelectedMenu
        {
            get => selectedMenu;
            set
            {
                if (Equals(selectedMenu, value)) return;
                selectedMenu = value;
                OnPropertyChanged();
            }
        }

        public MainSettingsViewModel MainSettingsViewModel
        {
            get
            {
                if (mainSettingsViewModel == null)
                {
                    mainSettingsViewModel = new MainSettingsViewModel();
                }
                return mainSettingsViewModel;
            }
        }

        public AboutSettingsViewModel AboutSettingsViewModel
        {
            get
            {
                if (aboutSettingsViewModel == null)
                {
                    aboutSettingsViewModel = new AboutSettingsViewModel();
                }
                return aboutSettingsViewModel;
            }
        }
        #endregion

        #region Constructors
        public SettingsViewModel()
        {
            menuItems.Add(new ItemMenu { Name = "Main", Display = new MainSettingsControl { DataContext = MainSettingsViewModel } });
            menuItems.Add(new ItemMenu { Name = "Documents" });
            menuItems.Add(new ItemMenu { Name = "Lists" });
            menuItems.Add(new ItemMenu { Name = "About", Display = new AboutSettingsControl { DataContext = AboutSettingsViewModel } });
            selectedMenu = menuItems.First();
        }
        #endregion

        #region Private Methods

        #endregion
    }
}
