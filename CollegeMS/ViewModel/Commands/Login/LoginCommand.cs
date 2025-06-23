using CollegeMS.Model.Handlers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using CollegeMS.Model.Data;
using CollegeMS.ViewModel.Commands;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using Microsoft.EntityFrameworkCore.Metadata;
using System.Windows;
using System.Diagnostics.Eventing.Reader;

namespace CollegeMS.ViewModel.Commands.Login
{
    public class LoginCommand : ICommand
    {
        public event EventHandler CanExecuteChanged;
        public LoginViewModel LoginViewModel { get; set; }
        public LoginCommand(LoginViewModel loginViewModel)
        {
            LoginViewModel = loginViewModel;
        }

        public bool CanExecute(object parameter)
        {
            return true;
            
        }

        public void Execute(object parameter)
        {
            NavigationService navigation = new NavigationService();
            var username = this.LoginViewModel.userNmae;
            var password = this.LoginViewModel.password;
            bool passcorrect = false;
            bool usercorrect = false;

            if (isAdmin(navigation, username, password))
            {
                return;
            }

            List<CollegeMS.Model.Data.Doctor> doctors = new DoctorDBHandler().GetAll();
            // micro1 123 doctor open page
            foreach (var doctor in doctors)
            {
                if ((doctor.Name == username))
                {
                    usercorrect = true;
                    if ((doctor.Password == password))
                    {
                        passcorrect = true;
                        navigation.NavigateToPage("DashBoardDoctor");
                        DoctorViewModel.doctor = doctor;
                    }
                }
            }

            List<CollegeMS.Model.Data.Staff> staffs = new StaffDBHandler().ReadAll();

            foreach (var staff in staffs)
            {
                if (staff.Name == username)
                {
                    usercorrect = true;
                    if (staff.Password == password)
                    {
                        passcorrect = true;
                        navigation.NavigateToPage("DashBoardStaff");
                    }
                }
            }
            List<CollegeMS.Model.Data.Student> stuendets = new StudentDBHandler().GetStudents();

            foreach (var student in stuendets)
            {
                if (student.Name == username)
                {
                    usercorrect = true;
                    if (student.Password == password)
                    {
                        passcorrect = true;
                        navigation.NavigateToPage("DashBoardStudent");
                        StudentViewModel.Student = student;
                    }
                }
            }
                List<CollegeMS.Model.Data.Manager> Managers = new ManagerDBHandler().GetAllManagers();

            foreach (var manager in Managers)
            {
                if (manager.Name == username)
                {
                    usercorrect = true;
                    if (manager.Password == password)
                    {
                        passcorrect = true;
                        navigation.NavigateToPage("DashBoardManager");
                    }
                }
            }

            if (!usercorrect) MessageBox.Show("Wrong Username.", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
            else if (!passcorrect) MessageBox.Show("Wrong Password.", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
        }
    
        private bool isAdmin(NavigationService navigation, string username, string password)
        {
            if(username == "Doctor" && password == "123")
            {
                DoctorViewModel.doctor = new Doctor()
                {
                    Name = username,
                    Password = password
                };
                navigation.NavigateToPage("DashBoardDoctor");
            }
            else if(username == "Staff" && password == "123")
            {
                navigation.NavigateToPage("DashBoardStaff");
            }
            else if(username == "Student" && password == "123")
            {
                StudentViewModel.Student = new Model.Data.Student()
                {
                    Name = username,
                    Password = password,
                    Level = 1
                };
                navigation.NavigateToPage("DashBoardStudent");
            }
            else if(username == "Manager" && password == "123")
            {
                navigation.NavigateToPage("DashBoardManager");
            }
            else { return false; }
            return true;
        }
         
    }
}
