using CollegeMS.Model;
using CollegeMS.ViewModel.Commands.Login;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace CollegeMS.ViewModel
{
    public class LoginViewModel : ObservableObject
    {
        public MainWindowViewModel mainWindowViewModel { get; set; }
        public string userNmae { 
            get; 
            set; 
        }    
        public string password { get; set; }

        public LoginCommand Login { get; set; }
        public LoginViewModel()
        {
            Login = new LoginCommand(this);
        }
    }
}
