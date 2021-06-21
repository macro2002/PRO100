using Desktop.Infrastructure;
using Desktop.View.Administrations;
using Desktop.ViewModels.Administrations;
using Desktop.Views.Administrations;
using System.Windows.Controls;

namespace Desktop.ViewModel.Administrations
{
    public class AdministrationViewModel : BaseModel
    {
        #region Fields
        private UserControl displayContent;

        private UserControl displayOrganizations;
        private OrganizationsViewModel organizationsVM;

        private UserControl displayUsers;
        private UsersViewModel usersVM;
        #endregion

        #region Public Properties
        public UserControl DisplayContent
        {
            get => displayContent;
            set
            {
                displayContent = value;
                OnPropertyChanged();
            }
        }

        public UserControl DisplayOrganizations
        {
            get
            {
                if (displayOrganizations == null)
                {
                    displayOrganizations = new OrganizationsControl { DataContext = OrganizationsVM };
                }
                return displayOrganizations;
            }
        }

        public OrganizationsViewModel OrganizationsVM
        {
            get
            {
                if (organizationsVM == null)
                {
                    organizationsVM = new OrganizationsViewModel(this);
                }
                return organizationsVM;
            }
        }

        public UserControl DisplayUsers
        {
            get
            {
                if (displayUsers == null)
                {
                    displayUsers = new UsersControl { DataContext = UsersVM };
                }
                return displayUsers;
            }
        }

        public UsersViewModel UsersVM
        {
            get
            {
                if (usersVM == null)
                {
                    usersVM = new UsersViewModel(this);
                }
                return usersVM;
            }
        }
        #endregion

        #region Constructors
        public AdministrationViewModel()
        {
            if(AppSettings.User != null && AppSettings.User.Organization.ID == 1)
            {

            } else
            {
                //UsersVM.InitializationUsers(AppSettings.User.Organization.ID);
                //DisplayContent = DisplayUsers;
            }
            DisplayContent = DisplayOrganizations;
        }
        #endregion

        #region Public Methods
        public void ChangeDisplay(int display, int id)
        {
            if(display == 1)
            {
                UsersVM.InitializationUsers(id);
                DisplayContent = DisplayUsers;
            }
            else
            {
                DisplayContent = DisplayOrganizations;
            }
        }
        #endregion
    }
}
