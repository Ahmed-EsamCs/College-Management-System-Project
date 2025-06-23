using CollegeMS.Model.Data;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SQLite;
using System.Windows.Controls;


namespace CollegeMS.Model.Handlers
{
    internal class StudentDBHandler
    {
        private readonly string _connectionString;
        private string dbPath = "sqlite.db";
        public StudentDBHandler()
        {
            _connectionString = $"Data Source={dbPath};Version=3;";
            CreateTablesIfNotExists();
        }

        private void CreateTablesIfNotExists()
        {
            using var conn = new SQLiteConnection(_connectionString);
            conn.Open();

            // Students table
            string studentTable = @"
            CREATE TABLE IF NOT EXISTS Students (
                id INTEGER PRIMARY KEY AUTOINCREMENT,
                Name TEXT NOT NULL,
                Level INTEGER NOT NULL,
                Password TEXT NOT NULL,
                Email TEXT NOT NULL,
                BirthDate TEXT NOT NULL,
                Role TEXT NOT NULL,
                ParentPhone TEXT,
                F_GPA REAL
            );";


            using var cmd = new SQLiteCommand(studentTable, conn);
            cmd.ExecuteNonQuery();

        }

        public int CreateStudent(Student student)
        {
            using var conn = new SQLiteConnection(_connectionString);
            conn.Open();

            string query = @"
            INSERT INTO Students (Name , Password , Level , Email, BirthDate, Role, ParentPhone, F_GPA)
            VALUES (@Name , @Password , @Level , @Email, @BirthDate, @Role, @ParentPhone, @F_GPA);
            SELECT last_insert_rowid();";

            using var cmd = new SQLiteCommand(query, conn);
            cmd.Parameters.AddWithValue("@Name", student.Name);
            cmd.Parameters.AddWithValue("@Password", student.Password);
            cmd.Parameters.AddWithValue("@Level", student.Level);
            cmd.Parameters.AddWithValue("@Email", student.Email);
            cmd.Parameters.AddWithValue("@BirthDate", student.BirthDate.ToString("yyyy-MM-dd"));
            cmd.Parameters.AddWithValue("@Role", student.Role);
            cmd.Parameters.AddWithValue("@ParentPhone", student.ParentPhone ?? "");
            cmd.Parameters.AddWithValue("@F_GPA", student.F_GPA);

            long lastId = (long)cmd.ExecuteScalar();
            int studentId = (int)lastId;

            // Insert GPA records


            return studentId;
        }


        public Student GetStudentById(int id)
        {
            using var conn = new SQLiteConnection(_connectionString);
            conn.Open();

            string query = "SELECT * FROM Students WHERE id = @id;";
            using var cmd = new SQLiteCommand(query, conn);
            cmd.Parameters.AddWithValue("@id", id);

            using var reader = cmd.ExecuteReader();

            if (reader.Read())
            {
                var student = new Student
                {
                    id = Convert.ToInt32(reader["id"]),
                    Name = reader["Name"].ToString(),
                    Email = reader["Email"].ToString(),
                    Level = Int32.Parse(reader["Level"].ToString()),
                    Password = reader["Password"].ToString(),
                    BirthDate = DateTime.Parse(reader["BirthDate"].ToString()),
                    Role = reader["Role"].ToString(),
                    ParentPhone = reader["ParentPhone"].ToString(),
                    F_GPA = Convert.ToDouble(reader["F_GPA"]),
                };
                return student;
            }
            return null;
        }

        public List<Student> GetStudents()
        {
            using var conn = new SQLiteConnection(_connectionString);
            conn.Open();

            string query = "SELECT * FROM Students;";
            using var cmd = new SQLiteCommand(query, conn);

            var list = new List<Student>();

            using var reader = cmd.ExecuteReader();

            while (reader.Read())
            {
                list.Add(new Student
                {
                    id = Convert.ToInt32(reader["id"]),
                    Name = reader["Name"].ToString(),
                    Email = reader["Email"].ToString(),
                    Level = Int32.Parse(reader["Level"].ToString()),
                    Password = reader["Password"].ToString(),
                    BirthDate = DateTime.Parse(reader["BirthDate"].ToString()),
                    Role = reader["Role"].ToString(),
                    ParentPhone = reader["ParentPhone"].ToString(),
                    F_GPA = Convert.ToDouble(reader["F_GPA"]),
                });
            }
            return list;
        }

        public void UpdateStudent(Student student)
        {
            using var conn = new SQLiteConnection(_connectionString);
            conn.Open();

            string query = @"
            UPDATE Students SET
                Name = @Name,
                Password = @Password,
                Email = @Email,
                Level = @Level,
                BirthDate = @BirthDate,
                Role = @Role,
                ParentPhone = @ParentPhone,
                F_GPA = @F_GPA
            WHERE id = @id;";

            using var cmd = new SQLiteCommand(query, conn);
            cmd.Parameters.AddWithValue("@Name", student.Name);
            cmd.Parameters.AddWithValue("@Password", student.Password);
            cmd.Parameters.AddWithValue("@Level", student.Level);
            cmd.Parameters.AddWithValue("@Email", student.Email);
            cmd.Parameters.AddWithValue("@BirthDate", student.BirthDate.ToString("yyyy-MM-dd"));
            cmd.Parameters.AddWithValue("@Role", student.Role);
            cmd.Parameters.AddWithValue("@ParentPhone", student.ParentPhone ?? "");
            cmd.Parameters.AddWithValue("@F_GPA", student.F_GPA);
            cmd.Parameters.AddWithValue("@id", student.id);

            cmd.ExecuteNonQuery();


        }

        public void DeleteStudent(int id)
        {
            using var conn = new SQLiteConnection(_connectionString);
            conn.Open();

            string query = "DELETE FROM Students WHERE id = @id;";
            using var cmd = new SQLiteCommand(query, conn);
            cmd.Parameters.AddWithValue("@id", id);
            cmd.ExecuteNonQuery();
        }
    }
}
