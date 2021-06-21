using Desktop.Infrastructure;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Desktop.Model.Projects
{
    public class Project : СreationGUID
    {
        private string name;
        private int serialNumber;
        private string createdUser;

        private DateTime lastUpdate;
        private string lastUpdateUser;

        public string Name
        {
            get { return name; }
            set
            {
                name = value;
                OnPropertyChanged();
            }
        }
    }
}
