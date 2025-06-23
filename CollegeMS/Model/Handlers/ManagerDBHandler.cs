using CollegeMS.Model.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SQLite;

namespace CollegeMS.Model.Handlers
{
    internal class ManagerDBHandler
    {
        private readonly string _connectionString;
        private string dbPath = "sqlite.db";

        public ManagerDBHandler()
        {
            _connectionString = $"Data Source={dbPath};Version=3;";
            CreateTableIfNotExists();
        }

        private void CreateTableIfNotExists()
        {
            using var conn = new SQLiteConnection(_connectionString);
            conn.Open();

            string query = @"
            CREATE TABLE IF NOT EXISTS Managers (
                id INTEGER PRIMARY KEY AUTOINCREMENT,
                Name TEXT NOT NULL,
                Password TEXT NOT NULL,
                Email TEXT NOT NULL,
                BirthDate TEXT NOT NULL,
                Role TEXT NOT NULL
            );";

            using var cmd = new SQLiteCommand(query, conn);
            cmd.ExecuteNonQuery();
        }

        public void CreateManager(Manager manager)
        {
            using var conn = new SQLiteConnection(_connectionString);
            conn.Open();

            string query = @"
            INSERT INTO Managers (Name , Password , Email, BirthDate, Role)
            VALUES (@Name , @Password , @Email, @BirthDate, @Role);";

            using var cmd = new SQLiteCommand(query, conn);
            cmd.Parameters.AddWithValue("@Name", manager.Name);
            cmd.Parameters.AddWithValue("@Password", manager.Password);
            cmd.Parameters.AddWithValue("@Email", manager.Email);
            cmd.Parameters.AddWithValue("@BirthDate", manager.BirthDate.ToString("yyyy-MM-dd"));
            cmd.Parameters.AddWithValue("@Role", manager.Role);

            cmd.ExecuteNonQuery();
        }

        public Manager GetManagerById(int id)
        {
            using var conn = new SQLiteConnection(_connectionString);
            conn.Open();

            string query = "SELECT * FROM Managers WHERE id = @id;";
            using var cmd = new SQLiteCommand(query, conn);
            cmd.Parameters.AddWithValue("@id", id);

            using var reader = cmd.ExecuteReader();
            if (reader.Read())
            {
                return new Manager
                {
                    id = Convert.ToInt32(reader["id"]),
                    Name = reader["Name"].ToString(),
                    Password = reader["Password"].ToString(),
                    Email = reader["Email"].ToString(),
                    BirthDate = DateTime.Parse(reader["BirthDate"].ToString()),
                    Role = reader["Role"].ToString()
                };
            }

            return null;
        }

        public List<Manager> GetAllManagers()
        {
            var list = new List<Manager>();
            using var conn = new SQLiteConnection(_connectionString);
            conn.Open();

            string query = "SELECT * FROM Managers;";
            using var cmd = new SQLiteCommand(query, conn);
            using var reader = cmd.ExecuteReader();

            while (reader.Read())
            {
                list.Add(new Manager
                {
                    id = Convert.ToInt32(reader["id"]),
                    Name = reader["Name"].ToString(),
                    Password = reader["Password"].ToString(),
                    Email = reader["Email"].ToString(),
                    BirthDate = DateTime.Parse(reader["BirthDate"].ToString()),
                    Role = reader["Role"].ToString()
                });
            }

            return list;
        }

        public void UpdateManager(Manager manager)
        {
            using var conn = new SQLiteConnection(_connectionString);
            conn.Open();

            string query = @"
            UPDATE Managers SET 
                Name = @Name,
                Email = @Email,
                Password = @Password,
                BirthDate = @BirthDate,
                Role = @Role
            WHERE id = @id;";

            using var cmd = new SQLiteCommand(query, conn);
            cmd.Parameters.AddWithValue("@id", manager.id);
            cmd.Parameters.AddWithValue("@Name", manager.Name);
            cmd.Parameters.AddWithValue("@Password", manager.Password);
            cmd.Parameters.AddWithValue("@Email", manager.Email);
            cmd.Parameters.AddWithValue("@BirthDate", manager.BirthDate.ToString("yyyy-MM-dd"));
            cmd.Parameters.AddWithValue("@Role", manager.Role);

            cmd.ExecuteNonQuery();
        }

        public void DeleteManager(int id)
        {
            using var conn = new SQLiteConnection(_connectionString);
            conn.Open();

            string query = "DELETE FROM Managers WHERE id = @id;";
            using var cmd = new SQLiteCommand(query, conn);
            cmd.Parameters.AddWithValue("@id", id);

            cmd.ExecuteNonQuery();
        }
    }
}