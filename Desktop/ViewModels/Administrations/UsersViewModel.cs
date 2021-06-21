using Desktop.Infrastructure;
using Desktop.Model.Users;
using Desktop.ViewModel.Administrations;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Desktop.ViewModels.Administrations
{
    public class UsersViewModel : BaseModel
    {
        #region Fields
        private ObservableCollection<User> users = new ObservableCollection<User>();
        private User selectedUser;
        private User user;
        #endregion

        #region Public Properties
        public AdministrationViewModel Owner;

        public ObservableCollection<User> Users
        {
            get => users;
            set
            {
                users = value;
                OnPropertyChanged();
            }
        }

        public User SelectedUser
        {
            get => selectedUser;
            set
            {
                selectedUser = value;
                OnPropertyChanged();
            }
        }

        public User User
        {
            get => user;
            set
            {
                user = value;
                OnPropertyChanged();
            }
        }
        #endregion

        #region Command

        #endregion

        #region Constructors
        public UsersViewModel(AdministrationViewModel owner)
        {
            Owner = owner;
        }
        #endregion

        #region Public Methods
        public void InitializationUsers(int id)
        {

        }
        #endregion

        #region Private Methods

        #endregion
    }
}
