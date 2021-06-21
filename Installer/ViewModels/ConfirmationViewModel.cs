using Installer.View;
using System.Linq;
using System.Windows;

namespace Installer.ViewModel
{
    public class ConfirmationViewModel : BaseModel
    {
        #region Public Properties
        public bool Continue;
        #endregion

        #region Command
        private RelayCommand actionCommand;

        public RelayCommand ActionCommand =>
          actionCommand ?? (actionCommand = new RelayCommand(obj =>
          {
              switch (obj.ToString())
              {
                  case "Yes":
                      Continue = false;
                      break;
                  case "No":
                      Continue = true;
                      break;
              }
              Application.Current.Windows.OfType<ConfirmationWindow>().FirstOrDefault().Close();
          }));
        #endregion
    }
}
