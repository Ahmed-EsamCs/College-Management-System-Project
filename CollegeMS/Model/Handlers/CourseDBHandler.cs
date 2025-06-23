using CollegeMS.Model.Data;
using System;
using System.Collections.Generic;
using System.Data.SQLite;

namespace CollegeMS.Model.Handlers
{
    public class CourseDBHandler
    {
        private readonly string _connectionString;
        private string databasePath = "sqlite.db";
        public CourseDBHandler()
        {
            _connectionString = $"Data Source={databasePath};Version=3;";
            Initialize();
        }

        private void Initialize()
        {
            using var con = new SQLiteConnection(_connectionString);
            con.Open();

            string sql = @"
            CREATE TABLE IF NOT EXISTS Course (
                Name TEXT PRIMARY KEY,
                CreditHour INTEGER NOT NULL,
                Level INTEGER NOT NULL
            );";

            using var cmd = new SQLiteCommand(sql, con);
            cmd.ExecuteNonQuery();
        }

        public void Create(Course course)
        {
            using var con = new SQLiteConnection(_connectionString);
            con.Open();

            string sql = "INSERT INTO Course (Name, CreditHour , Level) VALUES (@Name, @CreditHour, @Level);";
            using var cmd = new SQLiteCommand(sql, con);
            cmd.Parameters.AddWithValue("@Name", course.Name);
            cmd.Parameters.AddWithValue("@Level", course.Level);
            cmd.Parameters.AddWithValue("@CreditHour", course.CreditHour);
            cmd.ExecuteNonQuery();
        }

        public Course Get(string name)
        {
            using var con = new SQLiteConnection(_connectionString);
            con.Open();

            string sql = "SELECT Name, CreditHour , Level FROM Course WHERE Name = @Name;";
            using var cmd = new SQLiteCommand(sql, con);
            cmd.Parameters.AddWithValue("@Name", name);
            using var reader = cmd.ExecuteReader();
            if (reader.Read())
            {
                return new Course
                {
                    Name = reader.GetString(0),
                    CreditHour = reader.GetInt32(1),
                    Level = reader.GetInt32(2)
                };
            }
            return null;
        }
        public List<Course> GetByLevel(int level)
        {
            var courses = new List<Course>();
            using var con = new SQLiteConnection(_connectionString);
            con.Open();

            string sql = "SELECT Name, CreditHour , Level FROM Course WHERE Level = @Level;";
            using var cmd = new SQLiteCommand(sql, con);
            cmd.Parameters.AddWithValue("@Level", level);
            using var reader = cmd.ExecuteReader();
            while (reader.Read())
            {
                courses.Add(new Course
                {
                    Name = reader.GetString(0),
                    CreditHour = reader.GetInt32(1),
                    Level = reader.GetInt32(2),
                });
            }
            return courses;
        }
        public List<Course> GetAll()
        {
            var courses = new List<Course>();
            using var con = new SQLiteConnection(_connectionString);
            con.Open();

            string sql = "SELECT Name, CreditHour , Level FROM Course;";
            using var cmd = new SQLiteCommand(sql, con);
            using var reader = cmd.ExecuteReader();
            while (reader.Read())
            {
                courses.Add(new Course
                {
                    Name = reader.GetString(0),
                    CreditHour = reader.GetInt32(1),
                    Level = reader.GetInt32(2),
                });
            }
            return courses;
        }

        // Not used in real world
        public void Update(Course course)
        {
            using var con = new SQLiteConnection(_connectionString);
            con.Open();

            string sql = "UPDATE Course SET CreditHour = @CreditHour WHERE Name = @Name;";
            using var cmd = new SQLiteCommand(sql, con);
            cmd.Parameters.AddWithValue("@CreditHour", course.CreditHour);
            cmd.Parameters.AddWithValue("@Name", course.Name);
            cmd.ExecuteNonQuery();
        }
        // also this doesnt used
        public void Delete(string name)
        {
            using var con = new SQLiteConnection(_connectionString);
            con.Open();

            string sql = "DELETE FROM Course WHERE Name = @Name;";
            using var cmd = new SQLiteCommand(sql, con);
            cmd.Parameters.AddWithValue("@Name", name);
            cmd.ExecuteNonQuery();
        }
    }

}
