using CollegeMS.Model.ComponentModel;
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
    public class RegisterDoctor : ICommand
    {
        public event EventHandler CanExecuteChanged;

        StaffViewModel StaffViewModel { get; set; }
        public RegisterDoctor(StaffViewModel staffViewModel)
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
                var doctor = StaffViewModel.doctor;

                // Check for null or empty inputs
                if (doctor == null ||
                    string.IsNullOrWhiteSpace(doctor.Name) ||
                    string.IsNullOrWhiteSpace(doctor.Email) ||
                    string.IsNullOrWhiteSpace(doctor.Password) ||
                    doctor.BirthDate == null)
                {
                    MessageBox.Show("All fields are required and cannot be empty.",
                        "Input Error",
                        MessageBoxButton.OK,
                        MessageBoxImage.Error);
                    return;
                }

                // Validate Name (only letters and spaces)
                if (!Regex.IsMatch(doctor.Name, @"^[a-zA-Z\s]+$"))
                {
                    MessageBox.Show("Name can only contain letters and spaces, no numbers or special characters.",
                        "Invalid Name",
                        MessageBoxButton.OK,
                        MessageBoxImage.Error);
                    return;
                }

                // Validate Email (contains '@' and ends with '.com')
                if (!doctor.Email.Contains("@") || !doctor.Email.EndsWith(".com"))
                {
                    MessageBox.Show("Email must contain '@' and end with '.com'.",
                        "Invalid Email",
                        MessageBoxButton.OK,
                        MessageBoxImage.Error);
                    return;
                }

                // Validate Password (min 8 chars, contains numbers and lowercase)
                if (doctor.Password.Length < 8 ||
                    !doctor.Password.Any(char.IsDigit) ||
                    !doctor.Password.Any(char.IsLower))
                {
                    MessageBox.Show("Password must be at least 8 characters long and include both numbers and lowercase letters.",
                        "Invalid Password",
                        MessageBoxButton.OK,
                        MessageBoxImage.Error);
                    return;
                }
                // Validate BirthDate (must be at least 25 years ago)
                DateTime minBirthDate = DateTime.Today.AddYears(-25);
                if (doctor.BirthDate > minBirthDate)
                {
                    MessageBox.Show("A doctor must be at least 25 years old.",
                        "Invalid Birth Date",
                        MessageBoxButton.OK,
                        MessageBoxImage.Error);
                    return;
                }

                // Proceed with doctor creation
                new CollegeMS.Model.Handlers.DoctorDBHandler().Create(doctor);
                StaffViewModel._doctor = new Model.Data.Doctor();
                StaffViewModel.getDoctors();
                MessageBox.Show("Doctor successfully registered!",
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
                Logger.SaveLogger(ex.Message, "Doctor-Register-Validation");
            }
            catch (DatabaseException ex)
            {
                MessageBox.Show($"Database error: {ex.Message}",
                    "Database Error",
                    MessageBoxButton.OK,
                    MessageBoxImage.Error);
                Logger.SaveLogger(ex.Message, "Doctor-Register-Database");
            }
            catch (Exception ex)
            {
                MessageBox.Show("An unexpected error occurred. Please try again.",
                    "Unexpected Error",
                    MessageBoxButton.OK,
                    MessageBoxImage.Error);
                Logger.SaveLogger(ex.Message, "Doctor-Register-Unexpected");
            }
        }
    }
}
