using System;

namespace Desktop.Model
{
    public class Log : СreationGUID
    {
        private int type;
        private Guid organization;
        private int user;
        private string displayRole;
        private string displayName;
        private string action;

        /// <summary>
        /// Type 0 = info, Type 1 = Warning, Type 2 = Error; 
        /// </summary>
        public int Type
        {
            get { return type; }
            set
            {
                type = value;
                OnPropertyChanged();
            }
        }

        public Guid Organization
        {
            get { return organization; }
            set
            {
                organization = value;
                OnPropertyChanged();
            }
        }

        public int User
        {
            get { return user; }
            set
            {
                user = value;
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

        public string Action
        {
            get { return action; }
            set
            {
                action = value;
                OnPropertyChanged();
            }
        }

        public Log() { }

        public Log(int type, string action)
        {
            Type = type;
            Guid = Guid.NewGuid();
            Creation = DateTime.UtcNow;
            Action = action;
        }
    }
}
