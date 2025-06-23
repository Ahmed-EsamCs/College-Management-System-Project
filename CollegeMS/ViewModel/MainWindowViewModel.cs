using CollegeMS.Model;
using CollegeMS.Views.window;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using CollegeMS.Model.ComponentModel;
using CollegeMS.ViewModel.Commands;

namespace CollegeMS.ViewModel
{
    public class MainWindowViewModel : ObservableObject
    {

        public static MainWindow MainWindow { get; set; }


        public MainWindowViewModel()
        {

        }

        internal void setContext(MainWindow mainWindow)
        {
            MainWindow = mainWindow;
        }
    }
}
