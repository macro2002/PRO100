using System;
using System.Collections.ObjectModel;
using System.Text;

namespace Desktop.Model.Users
{
    public class User : СreationID
    {
        #region Fields
        private string login;
        private string firstName;
        private string lastName;
        private string middleName;
        private string displayRole;
        private string displayName;
        private string email;
        private string phone;
        private string password;
        private ObservableCollection<Service> services;
        private int organizationID;
        private Organization organization;
        #endregion

        #region Public Properties
        public string Login
        {
            get { return login; }
            set
            {
                login = value;
                OnPropertyChanged();
            }
        }

        public string FirstName
        {
            get { return firstName; }
            set
            {
                firstName = value;
                OnPropertyChanged();
            }
        }

        public string LastName
        {
            get { return lastName; }
            set
            {
                lastName = value;
                OnPropertyChanged();
            }
        }

        public string MiddleName
        {
            get { return middleName; }
            set
            {
                middleName = value;
                OnPropertyChanged();
            }
        }

        public string DisplayRole
        {
            get { return displayRole; }
            set
            {
                displayRole = value;
                OnPropertyChanged();
            }
        }

        public string DisplayName
        {
            get { return displayName; }
            set
            {
                displayName = value;
                OnPropertyChanged();
            }
        }

        public string Email
        {
            get { return email; }
            set
            {
                email = value;
                OnPropertyChanged();
            }
        }

        public string Phone
        {
            get { return phone; }
            set
            {
                phone = value;
                OnPropertyChanged();
            }
        }

        public string Password
        {
            get { return password; }
            set
            {
                password = value;
                OnPropertyChanged();
            }
        }

        public ObservableCollection<Service> Services
        {
            get { return services; }
            set
            {
                services = value;
                OnPropertyChanged();
            }
        }

        public int OrganizationID
        {
            get { return organizationID; }
            set
            {
                organizationID = value;
                OnPropertyChanged();
            }
        }

        public Organization Organization
        {
            get { return organization; }
            set
            {
                organization = value;
                OnPropertyChanged();
            }
        }
        #endregion

        #region Constructors
        public User()
        {
            Creation = DateTime.UtcNow;
            Password = GeneratePassword();
        }
        #endregion

        #region Private Methods
        private string GeneratePassword()
        {
            const string valid = "abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ1234567890";
            StringBuilder res = new StringBuilder();
            Random rnd = new Random();
            while (0 < 8)
            {
                res.Append(valid[rnd.Next(valid.Length)]);
            }
        }
        #endregion
    }
}
