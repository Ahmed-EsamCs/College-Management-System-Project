# ★ College Management System ★

## 👥 Team Members

- [Belal Hassan (Micro)](https://www.linkedin.com/in/belal-hassan-micro-8565ba191/)
- [Ahmed Essam Kamal](https://www.linkedin.com/in/ahmed-essam-kamal-84112b348/)
- [Abdulrahman Mohammed](https://www.linkedin.com/in/abdullrahman-mohamed-595563322/)
- [Mohammed Ali Mohammed](https://www.linkedin.com/in/%D9%85%D8%AD%D9%85%D8%AF-%D8%B9%D9%84%D9%8A-%D9%85%D8%AD%D9%85%D8%AF-1b45a1371/)
- [Mohammed Mostafa Mohammed](https://www.linkedin.com/in/mohammed-mustafa-7b9321339/)
- [Mostafa Ahmed Kamal](https://www.linkedin.com/in/mostafa-ahmed-986411352/)

---

## 📘 Project Description

🎓 **The College Management System** is a comprehensive WPF desktop application designed to streamline and manage the day-to-day operations of a college. With secure role-based access, it enables students, doctors (instructors), administrative staff, and managers to perform their tasks through personalized dashboards.

---

### 🔐 Login Panel

A secure authentication system that directs users to their appropriate dashboard based on role:

- Student
- Doctor
- Staff
- Manager

---

### 🎓 Student Dashboard

Students can:

- **Display Personal Data**: View personal profile and academic info.
- **View Your Courses**: Access enrolled courses and details.
- **View Student Grades**: Check academic performance in real-time.

---

### ‍⚕️ Doctor Dashboard

Doctors (instructors) can:

- **Display Doctor Data**: Manage their profile.
- **View Student List**: See students enrolled in their courses.

---

### 💼 Staff Dashboard

Administrative staff can:

- **Create New Course**: Add courses to the curriculum.
- **Register New Doctor**: Enroll new doctors into the system.
- **View Doctor List**: List of all registered doctors.
- **View Students List**: View all student profiles.
- **Register New Student**: Add new students to the system.

---

### 👨‍💼 Manager Dashboard

Managers can:

- **View All Staff**: See all staff members.
- **Register New Staff**: Add new administrative staff.

---

### 🎨 UI/UX Design

The application follows modern UI/UX principles for a clean and intuitive experience:

#### ✨ UI (User Interface)

- Built with **WPF + XAML** for a modern Windows desktop appearance.
- Use of **icons and labeled buttons** to enhance clarity.

#### ✅ UX (User Experience)

- **Role-based dashboards** provide users with only the tools they need.
- **Simplified navigation** through organized tabs and sections.
- **Feedback on user actions**: alerts, success messages, and error dialogs.
- **Logical flow of tasks**: registration before viewing profiles or grades.
- **Smooth transition between views** with no clutter or confusion.

## ▶️ How to Run the Project

1. Open the solution file `CollegeMS.sln` using Visual Studio.
2. Build the project.
3. Run the application.
4. On startup, the **Login Panel** will appear.
5. Enter your **username** and **password** You can get username and password from "Login Users File".
6. The system will automatically detect your role and redirect you to your personalized dashboard.

- *`Or you can run the executable File "College Management System"`*

Each dashboard is designed with specific functionalities relevant to the user’s role within the system.

---

## 💻 Project Code

> The full source code is located inside the `CollegeMS/` directory.

---

## 🛠️ Technologies Used

- WPF (Windows Presentation Foundation)
- C#
- .NET Framework
- SQLite (as the local database)
- MVVM Pattern
