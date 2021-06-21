using Desktop.Infrastructure;
using Desktop.Infrastructure.Service;
using Desktop.Model.Users;
using Microsoft.EntityFrameworkCore;
using System.Collections.ObjectModel;
using System.Linq;

namespace Desktop.ViewModel.Administrations
{
    public class OrganizationsViewModel : BaseModel
    {
        #region Fields
        private AdministrationViewModel Owner;

        private ObservableCollection<Organization> organizations;
        private Organization selectedOrganization;
        private Organization organization;
        #endregion

        #region Public Properties
        public ObservableCollection<Organization> Organizations
        {
            get => organizations;
            set
            {
                organizations = value;
                OnPropertyChanged();
            }
        }

        public Organization SelectedOrganization
        {
            get => selectedOrganization;
            set
            {
                selectedOrganization = value;
                OnPropertyChanged();
            }
        }

        public Organization Organization
        {
            get => organization;
            set
            {
                organization = value;
                OnPropertyChanged();
            }
        }
        #endregion

        #region Command
        private RelayCommand actionCommand;
        private RelayCommand openUsersCommand;

        public RelayCommand ActionCommand =>
          actionCommand ?? (actionCommand = new RelayCommand(obj =>
          {
              switch (obj.ToString())
              {
                  case "Add":
                      Add();
                      break;
                  case "Save":
                      Save();
                      break;
                  case "Cansel":
                      Cansel();
                      break;
                  case "Open":

                      break;
                  case "Remove":

                      break;
              }
          }));

        public RelayCommand OpenUsersCommand =>
         openUsersCommand ?? (openUsersCommand = new RelayCommand(obj =>
         {
             OpenDisplay((int)obj);
         }));
        #endregion

        #region Constructors
        public OrganizationsViewModel(AdministrationViewModel owner)
        {
            Owner = owner;
            InitializationOrganizations();
        }
        #endregion

        #region Public Methods

        #endregion

        #region Private Methods
        private void InitializationOrganizations()
        {
            using (ApplicationContext db = new ApplicationContext())
            {
                if(db.Organizations.Count() == 0)
                {

                }
                organizations = new ObservableCollection<Organization>(db.Organizations.Include(o => o.Users).ToList());
            }
        }

        private void AddManagerOrganization()
        {
            using (ApplicationContext db = new ApplicationContext())
            {
                var org = new Organization("f72ac278-7723-4082-8ad6-dd5958c549ef");
                org.Name = "Мебельные Технологии";
                org.Users.Add(new User{
                    Login = "admin",

                });
            }
        }

        private void Add()
        {
            Organization = new Organization();
        }

        private void Save()
        {
            organizations.Add(Organization);
            using (ApplicationContext db = new ApplicationContext())
            {
                db.Organizations.Add(Organization);
                db.SaveChanges();
                ActionLog.Set($"Добавлена организация: {Organization.Name}, создан лицензионный ключ: {Organization.License}");
                Cansel();
            }
        }

        private void Cansel()
        {
            Organization = null;
        }

        private void OpenDisplay(int id)
        {
            Owner.ChangeDisplay(1, id);
        }
        #endregion
    }
}
