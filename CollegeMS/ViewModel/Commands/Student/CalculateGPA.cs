using CollegeMS.Model.ComponentModel;
using CollegeMS.Model.Handlers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace CollegeMS.ViewModel.Commands.Student
{
    public class CalculateGPA : ICommand
    {
        public event EventHandler CanExecuteChanged;
        StudentViewModel StudentViewModel { get; set; }
        public CalculateGPA(StudentViewModel studentViewModel)
        {
            StudentViewModel = studentViewModel;
        }
        public bool CanExecute(object parameter)
        {
            return true;
        }

        public void Execute(object parameter)
        {
            try
            {
                foreach (var student in StudentViewModel._GPATables)
                {
                    GPAHandler.CalculateCourseGradePoints(int.Parse(student.GradePercentage), out double courseGradePoints, out string courseLetterGrade);
                    student.LetterGrade = courseLetterGrade;
                    student.GradePoints = courseGradePoints;
                }
                double gpa = GPAHandler.CalculateSemesterGPA(StudentViewModel.GPATables.ToList());
                MessageBoxShow.show("Your GPA : " + gpa.ToString());
            }
            catch (Exception ex)
            {
                MessageBoxShow.show("Error");
                Logger.SaveLogger(ex.Message, "GPA-Calculation");
            }
        }
    }
}
