using CollegeMS.Model;
using CollegeMS.Model.ComponentModel;
using CollegeMS.Model.Data;
using CollegeMS.Model.Handlers;
using CollegeMS.ViewModel.Commands;
using CollegeMS.ViewModel.Commands.Student;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CollegeMS.ViewModel
{
    public class StudentViewModel : ObservableObject
    {
        public static Student Student { get; set; }
        public ObservableCollection<Course> Courses { get; set; }
        public ObservableCollection<GPATableCalculation> GPATables { get; set; }
        public NavigationComand navigationComand { get; set; } = new NavigationComand();    
        public CalculateGPA CalculateGPA { get; set; }
        public StudentViewModel()
        {
            Student = new Student();
            this.CalculateGPA = new CalculateGPA(this);
            getMyLevelCourses();
        }
        public void getMyLevelCourses()
        {
            _Courses = new ObservableCollection<Course>(new CourseDBHandler().GetByLevel(Student.Level));
            _GPATables = new ObservableCollection<GPATableCalculation>();
            foreach (var item in Courses)
            {
                _GPATables.Add(new GPATableCalculation()
                {
                    Course = item,
                    GradePoints = 0.0,
                    GradePercentage = "0",
                    LetterGrade = "N/A"
                });           
            }
        }
        public ObservableCollection<GPATableCalculation> _GPATables
        {
            get
            {
                return GPATables;
            }
            set
            {
                GPATables = value;
                OnPropertyChanged(nameof(GPATables));
            }
        }
        public ObservableCollection<Course> _Courses
        {
            get { return Courses; }
            set
            {
                Courses = value;
                OnPropertyChanged(nameof(Courses));
            }
        }
    }
}
