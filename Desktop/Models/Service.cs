using Desktop.Infrastructure;

namespace Desktop.Model
{
    public class Service : BaseModel
    {
        private int id;
        private string name;

        public int ID
        {
            get => id;
            set
            {
                id = value;
                OnPropertyChanged();
            }
        }

        public string Name
        {
            get => name;
            set
            {
                name = value;
                OnPropertyChanged();
            }
        }
    }
}
