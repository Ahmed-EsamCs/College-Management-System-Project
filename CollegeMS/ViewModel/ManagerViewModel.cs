using CollegeMS.Model;
using CollegeMS.Model.Data;
using CollegeMS.ViewModel.Commands;
using CollegeMS.ViewModel.Commands.Manager;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CollegeMS.ViewModel
{
    public class ManagerViewModel : ObservableObject
    {
    
        public NavigationComand navigationComand { get; set; } = new NavigationComand();

        public ObservableCollection<Staff> Staffs { get; set; }
        public Staff staff { get; set; }
        public RegisterStaff RegisterStaff { get; set; }
        public ManagerViewModel()
        {
            RegisterStaff = new RegisterStaff(this);
            staff = new Staff();
            getStaffs();
        }
        public Staff _staff {
            get
            {
                return staff;
            }
            set
            {
                staff = value;
                OnPropertyChanged(nameof(staff));
            }
        }
        public void getStaffs()
        {
            
            _staffs = new ObservableCollection<Staff>(new CollegeMS.Model.Handlers.StaffDBHandler().ReadAll());
        }

        public ObservableCollection<Staff> _staffs
        {
            get
            {
                return Staffs;
            }
            set
            {
                Staffs = value;
                OnPropertyChanged(nameof(Staffs));
            }
        }
    }
}
