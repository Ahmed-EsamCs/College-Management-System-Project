using CollegeMS.Model.ComponentModel;
using CollegeMS.Model.Data;
using CollegeMS.Model.Handlers;
using CollegeMS.ViewModel.Commands.Staff;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;

namespace CollegeMS.ViewModel.Commands.Manager
{
    public class RegisterStaff : ICommand
    {
        public event EventHandler CanExecuteChanged;

        ManagerViewModel ManagerViewModel { get; set; }
        public RegisterStaff(ManagerViewModel managerViewModel)
        {
            ManagerViewModel = managerViewModel;
        }


        public bool CanExecute(object parameter)
        {
            return true;
        }

        public void Execute(object parameter)
        {
            try
            {
                var staff = ManagerViewModel.staff;

                // Check for null or empty inputs
                if (staff == null ||
                    string.IsNullOrWhiteSpace(staff.Name) ||
                    string.IsNullOrWhiteSpace(staff.Email) ||
                    string.IsNullOrWhiteSpace(staff.Password) ||
                    staff.BirthDate == null)
                {
                    MessageBox.Show("All fields are required and cannot be empty.",
                        "Input Error",
                        MessageBoxButton.OK,
                        MessageBoxImage.Error);
                    return;
                }

                // Validate Name (only letters and spaces)
                if (!Regex.IsMatch(staff.Name, @"^[a-zA-Z\s]+$"))
                {
                    MessageBox.Show("Name can only contain letters and spaces, no numbers or special characters.",
                        "Invalid Name",
                        MessageBoxButton.OK,
                        MessageBoxImage.Error);
                    return;
                }

                // Validate Email (contains '@' and ends with '.com')
                if (!staff.Email.Contains("@") || !staff.Email.EndsWith(".com"))
                {
                    MessageBox.Show("Email must contain '@' and end with '.com'.",
                        "Invalid Email",
                        MessageBoxButton.OK,
                        MessageBoxImage.Error);
                    return;
                }

                // Validate Password (min 8 chars, contains numbers and lowercase)
                if (staff.Password.Length < 8 ||
                    !staff.Password.Any(char.IsDigit) ||
                    !staff.Password.Any(char.IsLower))
                {
                    MessageBox.Show("Password must be at least 8 characters long and include both numbers and lowercase letters.",
                        "Invalid Password",
                        MessageBoxButton.OK,
                        MessageBoxImage.Error);
                    return;
                }
                // Validate BirthDate (must be at least 25 years ago)
                DateTime minBirthDate = DateTime.Today.AddYears(-25);
                if (staff.BirthDate > minBirthDate)
                {
                    MessageBox.Show("A staff must be at least 25 years old.",
                        "Invalid Birth Date",
                        MessageBoxButton.OK,
                        MessageBoxImage.Error);
                    return;
                }

                // Proceed with staff creation
                new CollegeMS.Model.Handlers.StaffDBHandler().Create(staff);
                ManagerViewModel._staff = new Model.Data.Staff();
                ManagerViewModel.getStaffs();
                MessageBox.Show("Staff successfully created!",
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
                Logger.SaveLogger(ex.Message, "Staff-Register-Validation");
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
                Logger.SaveLogger(ex.Message, "Staff-Register-Unexpected");
            }
        }
    }
}
