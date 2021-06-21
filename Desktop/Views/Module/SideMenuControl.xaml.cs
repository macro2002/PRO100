using System.Windows.Controls;
using System.Windows.Input;

namespace Desktop.View.Module
{
    /// <summary>
    /// Логика взаимодействия для SideMenuControl.xaml
    /// </summary>
    public partial class SideMenuControl : UserControl
    {
        public SideMenuControl()
        {
            InitializeComponent();
        }

        private void Menu_MouseMove(object sender, MouseEventArgs e)
        {
            var control = sender as Grid;
            control.Width = 240;
        }

        private void Menu_MouseLeave(object sender, MouseEventArgs e)
        {
            var control = sender as Grid;
            control.Width = 48;
        }
    }
}
