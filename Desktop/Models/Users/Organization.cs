using System;
using System.Collections.ObjectModel;

namespace Desktop.Model.Users
{
    public class Organization : СreationID
    {
        #region Fields
        private string name;
        private string director;
        private string phone;
        private string email;
        private string contract;
        private Guid license;
        private DateTime licenseTermination;
        private int count;
        private ObservableCollection<Service> services;
        private ObservableCollection<User> users;
        #endregion

        #region Public Properties
        public string Name
        {
            get { return name; }
            set
            {
                name = value;
                OnPropertyChanged();
            }
        }

        public string Director
        {
            get { return director; }
            set
            {
                director = value;
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

        public string Email
        {
            get { return email; }
            set
            {
                email = value;
                OnPropertyChanged();
            }
        }

        public string Contract
        {
            get { return contract; }
            set
            {
                contract = value;
                OnPropertyChanged();
            }
        }

        public Guid License
        {
            get { return license; }
            set
            {
                license = value;
                OnPropertyChanged();
            }
        }

        public int Count
        {
            get { return count; }
            set
            {
                count = value;
                OnPropertyChanged();
            }
        }

        public DateTime LicenseTermination
        {
            get { return licenseTermination; }
            set
            {
                licenseTermination = value;
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

        public ObservableCollection<User> Users
        {
            get { return users; }
            set
            {
                users = value;
                OnPropertyChanged();
            }
        }
        #endregion

        #region Constructors
        public Organization()
        {
            Creation = DateTime.UtcNow;
            License = Guid.NewGuid();
        }

        public Organization(string guid)
        {
            Creation = DateTime.UtcNow;
            License = Guid.Parse(guid);
        }
        #endregion
    }
}
