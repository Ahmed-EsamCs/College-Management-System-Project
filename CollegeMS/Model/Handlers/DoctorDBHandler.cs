using CollegeMS.Model.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SQLite;

namespace CollegeMS.Model.Handlers
{
    public class DoctorDBHandler
    {
        private readonly string _connectionString;
        private string databasePath = "sqlite.db";
        private readonly CourseDBHandler _courseHandler;

        public DoctorDBHandler()
        {
            _connectionString = $"Data Source={databasePath};Version=3;";
            _courseHandler = new CourseDBHandler();
            Initialize();
        }

        private void Initialize()
        {
            using var con = new SQLiteConnection(_connectionString);
            con.Open();

            string sql = @"
            CREATE TABLE IF NOT EXISTS Doctor (
                id INTEGER PRIMARY KEY AUTOINCREMENT,
                Name TEXT NOT NULL,
                Password TEXT NOT NULL,
                Email TEXT,
                BirthDate TEXT,
                Role TEXT,
                CourseName TEXT,
                FOREIGN KEY (CourseName) REFERENCES Course(Name)
            );";

            using var cmd = new SQLiteCommand(sql, con);
            cmd.ExecuteNonQuery();
        }

        public void Create(Doctor doctor)
        {
            // Make sure course exists (optional)
            if (doctor.Course != null)
            {
                var courseExists = _courseHandler.Get(doctor.Course.Name);
                if (courseExists == null)
                {
                    _courseHandler.Create(doctor.Course);
                }
            }

            using var con = new SQLiteConnection(_connectionString);
            con.Open();

            string sql = @"
            INSERT INTO Doctor 
            (Name, Password, Email, BirthDate, Role, CourseName) 
            VALUES (@Name, @Password, @Email, @BirthDate, @Role, @CourseName);";

            using var cmd = new SQLiteCommand(sql, con);
            cmd.Parameters.AddWithValue("@Name", doctor.Name);
            cmd.Parameters.AddWithValue("@Password", doctor.Password);
            cmd.Parameters.AddWithValue("@Email", doctor.Email ?? "");
            cmd.Parameters.AddWithValue("@BirthDate", doctor.BirthDate.ToString("o")); // ISO 8601 format
            cmd.Parameters.AddWithValue("@Role", doctor.Role ?? "");
            if (doctor.Course != null && doctor.Course.Name != null)
            {
                cmd.Parameters.AddWithValue("@CourseName", doctor.Course.Name);
            }
            else
            {
                cmd.Parameters.AddWithValue("@CourseName", DBNull.Value);
            }

            cmd.ExecuteNonQuery();

            // Optional: get last inserted id and assign to doctor.id
            doctor.id = (int)con.LastInsertRowId;
        }

        public Doctor Get(int id)
        {
            using var con = new SQLiteConnection(_connectionString);
            con.Open();

            string sql = @"
            SELECT id, Name, Password, Email, BirthDate, Role, CourseName
            FROM Doctor WHERE id = @id;";

            using var cmd = new SQLiteCommand(sql, con);
            cmd.Parameters.AddWithValue("@id", id);

            using var reader = cmd.ExecuteReader();
            if (reader.Read())
            {
                string courseName = reader.IsDBNull(6) ? null : reader.GetString(6);
                Course course = null;
                if (!string.IsNullOrEmpty(courseName))
                    course = _courseHandler.Get(courseName);

                return new Doctor
                {
                    id = reader.GetInt32(0),
                    Name = reader.GetString(1),
                    Password = reader.GetString(2),
                    Email = reader.GetString(3),
                    BirthDate = DateTime.Parse(reader.GetString(4)),
                    Role = reader.GetString(5),
                    Course = course
                };
            }
            return null;
        }

        public List<Doctor> GetAll()
        {
            var doctors = new List<Doctor>();
            using var con = new SQLiteConnection(_connectionString);
            con.Open();

            string sql = @"
            SELECT id, Name, Password, Email, BirthDate, Role, CourseName FROM Doctor;";

            using var cmd = new SQLiteCommand(sql, con);
            using var reader = cmd.ExecuteReader();
            while (reader.Read())
            {
                string courseName = reader.IsDBNull(6) ? null : reader.GetString(6);
                Course course = null;
                if (!string.IsNullOrEmpty(courseName))
                    course = _courseHandler.Get(courseName);

                doctors.Add(new Doctor
                {
                    id = reader.GetInt32(0),
                    Name = reader.GetString(1),
                    Password = reader.GetString(2),
                    Email = reader.GetString(3),
                    BirthDate = DateTime.Parse(reader.GetString(4)),
                    Role = reader.GetString(5),
                    Course = course
                });
            }
            return doctors;
        }

        public void Update(Doctor doctor)
        {
            if (doctor.Course != null)
            {
                var courseExists = _courseHandler.Get(doctor.Course.Name);
                if (courseExists == null)
                {
                    _courseHandler.Create(doctor.Course);
                }
                else
                {
                    _courseHandler.Update(doctor.Course);
                }
            }

            using var con = new SQLiteConnection(_connectionString);
            con.Open();

            string sql = @"
            UPDATE Doctor SET
                Name = @Name,
                Password = @Password,
                Email = @Email,
                BirthDate = @BirthDate,
                Role = @Role,
                CourseName = @CourseName
            WHERE id = @id;";

            using var cmd = new SQLiteCommand(sql, con);
            cmd.Parameters.AddWithValue("@Name", doctor.Name);
            cmd.Parameters.AddWithValue("@Password", doctor.Password);
            cmd.Parameters.AddWithValue("@Email", doctor.Email ?? "");
            cmd.Parameters.AddWithValue("@BirthDate", doctor.BirthDate.ToString("o"));
            cmd.Parameters.AddWithValue("@Role", doctor.Role ?? "");
            if (doctor.Course != null && doctor.Course.Name != null)
            {
                cmd.Parameters.AddWithValue("@CourseName", doctor.Course.Name);
            }
            else
            {
                cmd.Parameters.AddWithValue("@CourseName", DBNull.Value);
            }

            cmd.Parameters.AddWithValue("@id", doctor.id);

            cmd.ExecuteNonQuery();
        }

        public void Delete(int id)
        {
            using var con = new SQLiteConnection(_connectionString);
            con.Open();

            string sql = "DELETE FROM Doctor WHERE id = @id;";
            using var cmd = new SQLiteCommand(sql, con);
            cmd.Parameters.AddWithValue("@id", id);
            cmd.ExecuteNonQuery();
        }
    }

}