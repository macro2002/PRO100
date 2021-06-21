using Desktop.Infrastructure;

namespace Desktop.Model
{
    public class ComboItem : BaseModel
    {
        private string name;

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
