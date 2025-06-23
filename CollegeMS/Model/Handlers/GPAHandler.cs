using CollegeMS.Model.ComponentModel;
using CollegeMS.Model.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CollegeMS.Model.Handlers
{
    
    static class GPAHandler
    {
        // Method to calculate course grade points and letter grade based on course percentage
        public static void CalculateCourseGradePoints(int coursePercentage, out double courseGradePoints, out string courseLetterGrade)
        {
            courseGradePoints = 0.0; // Initialize course grade points
            courseLetterGrade = "N/A"; // Initialize course letter grade
            var gradeMapping = new (int MinPercentage, double GradePoints, string LetterGrade)[]
            {
            (96, 4.0, "A+"),
            (92, 3.7, "A"),
            (88, 3.4, "A-"),
            (84, 3.2, "B+"),
            (80, 3.0, "B"),
            (76, 2.8, "B-"),
            (72, 2.6, "C+"),
            (68, 2.4, "C"),
            (64, 2.2, "C-"),
            (60, 2.0, "D+"),
            (55, 1.5, "D"),
            (50, 1.0, "D-"),
            (0, 0.0, "F")
            };
            // Iterate through the grade mapping to find the appropriate grade points and letter grade
            foreach (var (minPercentage, gradePoints, letterGrade) in gradeMapping)
            {
                if (coursePercentage >= minPercentage)
                {
                    courseGradePoints = gradePoints;
                    courseLetterGrade = letterGrade;
                    break;
                }
            }
        }

        // Method to calculate the Cumulative GPA (CGPA) based on a list of GPAs
        public static double CalculateCGPA(List<float> gpas)
        {
            int gpaCount = gpas.Count();
            double totalGPA = 0.0;
            foreach (float gpa in gpas)
            {
                totalGPA += gpa;
            }
            if (gpaCount > 0)
            {
                totalGPA = Math.Round(totalGPA / gpaCount, 2);
            }
            else
            {
                totalGPA = 0.0; // Avoid division by zero
            }
            return totalGPA;
        }

        // Method to calculate the GPA based on a list of courses (Semester GPA)
        public static double CalculateSemesterGPA(List<GPATableCalculation> courses)
        {
            int totalCreditHours = 0;
            double totalPoints = 0.0;

            foreach (GPATableCalculation course in courses)
            {
                totalCreditHours += course.Course.CreditHour;
                totalPoints += course.GradePoints * course.Course.CreditHour;
            }

            if (totalCreditHours > 0)
            {
                return Math.Round(totalPoints / totalCreditHours, 2);
            }
            else
            {
                return 0.0; // Avoid division by zero
            }
        }
    }
    
}
