using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;

namespace CollegeMS.ViewModel.Commands
{
    public class NavigationService
    {
        public void NavigateToPage(string pageKey)
        {
            switch (pageKey)
            {
                case "DashBoardManager":
                    var dashBoardManagerPage = new CollegeMS.View.Pages.Manager.Dashboard();
                    MainWindowViewModel.MainWindow.Frame.NavigationService.Navigate(dashBoardManagerPage);
                    break;

                case "DashBoardStudent":
                    var dashBoardStudentPage = new CollegeMS.View.Pages.Student.Dashboard();
                    MainWindowViewModel.MainWindow.Frame.NavigationService.Navigate(dashBoardStudentPage);
                    break;

                case "DashBoardStaff":
                    var dashBoardStaffPage = new CollegeMS.View.Pages.Staff.Dashboard();
                    MainWindowViewModel.MainWindow.Frame.NavigationService.Navigate(dashBoardStaffPage);
                    break;

                case "DashBoardDoctor":
                    var dashboardDoctor = new CollegeMS.View.Pages.Doctor.Dashboard();
                    MainWindowViewModel.MainWindow.Frame.NavigationService.Navigate(dashboardDoctor);
                    break;

                case "AddDoctor":
                    var addDoctorPage = new CollegeMS.View.Pages.Staff.DoctoreRegister();
                    MainWindowViewModel.MainWindow.Frame.NavigationService.Navigate(addDoctorPage);
                    break;

                case "AddStaff":
                    var addStaffPage = new CollegeMS.View.Pages.Manager.StaffRegister();
                    MainWindowViewModel.MainWindow.Frame.NavigationService.Navigate(addStaffPage);
                    break;

                case "AddStudent":
                    var addStudentPage = new CollegeMS.View.Pages.Staff.StudentRegister();
                    MainWindowViewModel.MainWindow.Frame.NavigationService.Navigate(addStudentPage);
                    break;

                case "AllStudents":
                    var allStudentsPage = new CollegeMS.View.Pages.Staff.StudentList();
                    MainWindowViewModel.MainWindow.Frame.NavigationService.Navigate(allStudentsPage);
                    break;

                case "AllDoctors":
                    var allDoctorsPage = new CollegeMS.View.Pages.Staff.DoctorList();
                    MainWindowViewModel.MainWindow.Frame.NavigationService.Navigate(allDoctorsPage);
                    break;

                case "AllStaffs":
                    var allStaffsPage = new CollegeMS.View.Pages.Manager.AllStaff();
                    MainWindowViewModel.MainWindow.Frame.NavigationService.Navigate(allStaffsPage);
                    break;

                case "DoctorData":
                    var doctorDataPage = new CollegeMS.View.Pages.Doctor.MyData();
                    MainWindowViewModel.MainWindow.Frame.NavigationService.Navigate(doctorDataPage);
                    break;
                case "StudentsDataDoctor":
                    var studentListPageDoctore = new CollegeMS.View.Pages.Doctor.StudentList();
                    MainWindowViewModel.MainWindow.Frame.NavigationService.Navigate(studentListPageDoctore);
                    break;
                case "StudentData":
                    var studentDataPage = new CollegeMS.View.Pages.Student.MyData();
                    MainWindowViewModel.MainWindow.Frame.NavigationService.Navigate(studentDataPage);
                    break;

                case "AllCoursesDoctor":
                    var allCoursesPageDoctor = new CollegeMS.View.Pages.Doctor.Courses();
                    MainWindowViewModel.MainWindow.Frame.NavigationService.Navigate(allCoursesPageDoctor);
                    break;


                case "AllCoursesStaff":
                    var allCoursesPageStaff = new CollegeMS.View.Pages.Staff.CourseList();
                    MainWindowViewModel.MainWindow.Frame.NavigationService.Navigate(allCoursesPageStaff);
                    break;

                case "CreateCourseStaff":
                    var createCourseStaff = new CollegeMS.View.Pages.Staff.CreateCourse();
                    MainWindowViewModel.MainWindow.Frame.NavigationService.Navigate(createCourseStaff);
                    break;


                case "AllCoursesStundet":
                    var allCoursesPage = new CollegeMS.View.Pages.Student.MyCourse();
                    MainWindowViewModel.MainWindow.Frame.NavigationService.Navigate(allCoursesPage);
                    break;
                
                case "LogIn":
                    var login = new CollegeMS.View.Pages.Login();
                    MainWindowViewModel.MainWindow.Frame.NavigationService.Navigate(login);
                    break;

                case "GPACalculate":
                    var gpaCalc = new CollegeMS.View.Pages.Student.GPACalculation();
                    MainWindowViewModel.MainWindow.Frame.NavigationService.Navigate(gpaCalc);
                    break;

                default:
                    // Optionally handle unknown keys
                    MessageBox.Show("Page not found: " + pageKey);
                    break;
            }
        }

    }
}
