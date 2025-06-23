using CollegeMS.Model.ComponentModel;
using CollegeMS.Model.Data;
using CollegeMS.Model.Handlers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;

namespace CollegeMS.ViewModel.Commands.Staff
{
    public class AddCourse : ICommand
    {
        public event EventHandler CanExecuteChanged;

        StaffViewModel StaffViewModel { get; set; }
        public AddCourse(StaffViewModel staffViewModel)
        {
            StaffViewModel = staffViewModel;
        }


        public bool CanExecute(object parameter)
        {
            return true;
        }

        public void Execute(object parameter)
        {
            try
            {
                var course = StaffViewModel.course;

                // Check for null or empty course name
                if (course == null || string.IsNullOrWhiteSpace(course.Name))
                {
                    MessageBox.Show("Course name is required and cannot be empty.",
                        "Input Error",
                        MessageBoxButton.OK,
                        MessageBoxImage.Error);
                    return;
                }

                // Validate Course Name (letters, numbers, spaces underscores, dashes; no special characters)
                if (!Regex.IsMatch(course.Name, @"^[a-zA-Z0-9\s_-]+$"))
                {
                    MessageBox.Show("Course name can only contain letters, numbers, and spaces, no special characters.",
                        "Invalid Course Name",
                        MessageBoxButton.OK,
                        MessageBoxImage.Error);
                    return;
                }
                if (Regex.IsMatch(course.Name.Trim(), @"^[0-9\s_-]+$"))
                {
                    MessageBox.Show("Course name must contain words.",
                        "Invalid Course Name",
                        MessageBoxButton.OK,
                        MessageBoxImage.Error);
                    return;
                }

                // Validate Credit Hours (must be a non-negative integer)
                if (course.CreditHour < 0)
                {
                    MessageBox.Show("Credit hours cannot be negative.",
                        "Invalid Credit Hours",
                        MessageBoxButton.OK,
                        MessageBoxImage.Error);
                    return;
                }

                // Proceed with course creation
                new CollegeMS.Model.Handlers.CourseDBHandler().Create(course);
                StaffViewModel._course = new Model.Data.Course();
                StaffViewModel.getCourses();
                MessageBox.Show("Course successfully created!",
                    "Success",
                    MessageBoxButton.OK,
                    MessageBoxImage.Information);
            }
            catch (ArgumentException ex)
            {
                MessageBox.Show($"Invalid input: {ex.Message}",
                    "Validation Error",
                    MessageBoxButton.OK,
                    MessageBoxImage.Error);
                Logger.SaveLogger(ex.Message, "Course-Register-Validation");
            }
            catch (DatabaseException ex)
            {
                MessageBox.Show($"Database error: {ex.Message}",
                    "Database Error",
                    MessageBoxButton.OK,
                    MessageBoxImage.Error);
                Logger.SaveLogger(ex.Message, "Course-Register-Database");
            }
            catch (Exception ex)
            {
                MessageBox.Show("An unexpected error occurred. Please try again.",
                    "Unexpected Error",
                    MessageBoxButton.OK,
                    MessageBoxImage.Error);
                Logger.SaveLogger(ex.Message, "Course-Register-Unexpected");
            }
        }
    }
    // Custom exception for database-related errors
    public class DatabaseException : Exception
    {
        public DatabaseException(string message) : base(message) { }
    }
}
