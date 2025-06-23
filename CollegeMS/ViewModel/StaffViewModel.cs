using CollegeMS.Model;
using CollegeMS.Model.Data;
using CollegeMS.Model.Handlers;
using CollegeMS.View.Pages.Doctor;
using CollegeMS.ViewModel.Commands;
using CollegeMS.ViewModel.Commands.Staff;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CollegeMS.ViewModel
{
    public class StaffViewModel : ObservableObject
    {
        public ObservableCollection<Doctor> Doctors { get; set; }
        public ObservableCollection<Student> students { get; set; }
        public RegisterDoctor RegisterDoctor { get ; set; }
        public RegisterStudent RegisterStudent  { get ; set; }
        public NavigationComand navigationComand { get; set; } = new NavigationComand();
        public AddCourse AddCourse {  get; set; }
        public Course course {  get; set; }
        public ObservableCollection<Course> courses { get; set; }
        public Doctor doctor { get; set; }
        public Student Student { get; set; }
        public StaffViewModel()
        {
            getDoctors();
            getCourses();
            getStudents();
            RegisterDoctor = new RegisterDoctor(this);
            RegisterStudent = new RegisterStudent(this);
            AddCourse = new AddCourse(this);
            _doctor = new Doctor();
            _Student = new Student();
            _course = new Course();
        }
        public void getCourses()
        {
            _courses = new ObservableCollection<Course>(new CourseDBHandler().GetAll());
        }
        public void getDoctors()
        {
            _Doctors = new ObservableCollection<Doctor>(new CollegeMS.Model.Handlers.DoctorDBHandler().GetAll());
        }
        public void getStudents()
        {
            _Students = new ObservableCollection<Student>(new CollegeMS.Model.Handlers.StudentDBHandler().GetStudents());

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
        public Doctor _doctor {
            get
            {
                return doctor;
            }
            set
            {
                doctor = value;
                OnPropertyChanged(nameof(doctor));
            }
        }
        public Student _Student
        {
            get
            {
                return Student;
            }
            set
            {
                Student = value;
                OnPropertyChanged(nameof(Student));
            }
        }
        public Course _course
        {
            get
            {
                return course;
            }
            set
            {
                course = value;
                OnPropertyChanged(nameof(course));
            }
        }
        public ObservableCollection<Doctor> _Doctors
        {
            get
            {
                return Doctors;
            }
            set
            {
                Doctors = value;
                OnPropertyChanged(nameof(Doctors));
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
