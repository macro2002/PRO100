using Desktop.Infrastructure;
using System.Windows.Controls;

namespace Desktop.Model
{
    public class ItemMenu : BaseModel
    {
        private string name;
        private string content;
        private string image;
        private UserControl display;
        private int status;

        public string Name
        {
            get => name;
            set
            {
                name = value;
                OnPropertyChanged();
            }
        }

        public string Content
        {
            get => content;
            set
            {
                content = value;
                OnPropertyChanged();
            }
        }

        public string Image
        {
            get => image;
            set
            {
                image = value;
                OnPropertyChanged();
            }
        }

        public UserControl Display
        {
            get => display;
            set
            {
                display = value;
                OnPropertyChanged();
            }
        }

        public int Status
        {
            get => status;
            set
            {
                status = value;
                OnPropertyChanged();
            }
        }
    }
}
