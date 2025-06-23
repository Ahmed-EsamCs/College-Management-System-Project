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
    public class RegisterStudent : ICommand
    {
        public event EventHandler CanExecuteChanged;
        StaffViewModel StaffViewModel { get; set; }
        public RegisterStudent(StaffViewModel staffViewModel)
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
                var student = StaffViewModel.Student;

                // Check for null or empty inputs
                if (student == null ||
                    string.IsNullOrWhiteSpace(student.Name) ||
                    string.IsNullOrWhiteSpace(student.Email) ||
                    string.IsNullOrWhiteSpace(student.ParentPhone) ||
                    string.IsNullOrWhiteSpace(student.Password) ||
                    student.BirthDate == null)
                {
                    MessageBox.Show("All fields are required and cannot be empty.",
                        "Input Error",
                        MessageBoxButton.OK,
                        MessageBoxImage.Error);
                    return;
                }

                // Validate Name (only letters)
                if (!Regex.IsMatch(student.Name, @"^[a-zA-Z\s]+$"))
                {
                    MessageBox.Show("Name can only contain letters and spaces, no numbers or special characters.",
                        "Invalid Name",
                        MessageBoxButton.OK,
                        MessageBoxImage.Error);
                    return;
                }

                // Validate Email (contains '@' and ends with '.com')
                if (!student.Email.Contains("@") || !student.Email.EndsWith(".com"))
                {
                    MessageBox.Show("Email must contain '@' and end with '.com'.",
                        "Invalid Email",
                        MessageBoxButton.OK,
                        MessageBoxImage.Error);
                    return;
                }

                // Validate Password (min 8 chars, contains numbers and lowercase)
                if (student.Password.Length < 8 ||
                    !student.Password.Any(char.IsDigit) ||
                    !student.Password.Any(char.IsLower))
                {
                    MessageBox.Show("Password must be at least 8 characters long and include both numbers and lowercase letters.",
                        "Invalid Password",
                        MessageBoxButton.OK,
                        MessageBoxImage.Error);
                    return;
                }

                // Validate Egyptian Phone Number (e.g., 01104683717)
                if (!Regex.IsMatch(student.ParentPhone, @"^01[0125][0-9]{8}$"))
                {
                    MessageBox.Show("Parent phone number must be a valid Egyptian number (e.g., 01104683717).",
                        "Invalid Phone Number",
                        MessageBoxButton.OK,
                        MessageBoxImage.Error);
                    return;
                }

                // Validate BirthDate (must be at least 17 years ago)
                DateTime minBirthDate = DateTime.Today.AddYears(-17);
                if (student.BirthDate > minBirthDate)
                {
                    MessageBox.Show("A student must be at least 17 years old.",
                        "Invalid Birth Date",
                        MessageBoxButton.OK,
                        MessageBoxImage.Error);
                    return;
                }

                // Proceed with student creation
                new CollegeMS.Model.Handlers.StudentDBHandler().CreateStudent(student);
                StaffViewModel._Student = new Model.Data.Student();
                StaffViewModel.getStudents();
                MessageBox.Show("Student successfully registered!",
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
                Logger.SaveLogger(ex.Message, "Student-Register-Validation");
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
                Logger.SaveLogger(ex.Message, "Student-Register-Unexpected");
            }
        }
    }
}
