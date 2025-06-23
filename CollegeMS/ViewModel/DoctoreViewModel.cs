using CollegeMS.Model;
using CollegeMS.Model.Data;
using CollegeMS.Model.Handlers;
using CollegeMS.ViewModel.Commands;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CollegeMS.ViewModel
{
    public class DoctorViewModel : ObservableObject
    {
        public static Doctor doctor { get; set; }
        public NavigationComand navigationComand { get; set; }
        public ObservableCollection<Student> students { get; set; }
        public ObservableCollection<Course> courses { get; set; }
        public DoctorViewModel()
        {
            _Students = new ObservableCollection<Student>(new CollegeMS.Model.Handlers.StudentDBHandler().GetStudents());
            navigationComand = new NavigationComand();
            getCourses();
        }
        public void getCourses()
        {
            _courses = new ObservableCollection<Course>(new CourseDBHandler().GetAll());
        }
        public ObservableCollection<Course> _courses
        {
            get
            {
                return courses;
            }
            set
            {
                courses = value;
                OnPropertyChanged(nameof(courses));
            }
        }
        public ObservableCollection<Student> _Students
        {
            get
            {
                return students;
            }
            set
            {
                students = value;
                OnPropertyChanged(nameof(students));
            }
        }
    }
}
