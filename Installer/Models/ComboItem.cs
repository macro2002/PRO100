using Installer.ViewModel;

namespace Installer.Model
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
