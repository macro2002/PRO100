using Desktop.Infrastructure;
using System;
using System.ComponentModel.DataAnnotations;

namespace Desktop.Model
{
    public class СreationGUID : BaseModel
    {
        private Guid guid;
        private DateTime creation;

        [Key]
        public Guid Guid
        {
            get { return guid; }
            set
            {
                guid = value;
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
