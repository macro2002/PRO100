using Desktop.Infrastructure;
using System;
using System.ComponentModel.DataAnnotations;

namespace Desktop.Model
{
    public class СreationID : BaseModel
    {
        private int id;
        private DateTime creation;

        [Key]
        public int ID
        {
            get { return id; }
            set
            {
                id = value;
                OnPropertyChanged();
            }
        }

        public DateTime Creation
        {
            get { return creation; }
            set
            {
                creation = value;
                OnPropertyChanged();
            }
        }
    }
}
