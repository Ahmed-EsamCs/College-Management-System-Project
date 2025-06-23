using CollegeMS.Model.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SQLite;

namespace CollegeMS.Model.Handlers
{
    internal class StaffDBHandler
    {
        private readonly string _connectionString;
        private string databasePath = "sqlite.db";

            public StaffDBHandler()
            {
                _connectionString = $"Data Source={databasePath};Version=3;";
                InitializeDatabase();
            }

            private void InitializeDatabase()
            {
                using var conn = new SQLiteConnection(_connectionString);
                conn.Open();

                string createTable = @"
                CREATE TABLE IF NOT EXISTS Staff (
                    id INTEGER PRIMARY KEY AUTOINCREMENT,
                    Name TEXT NOT NULL,
                    Password TEXT NOT NULL,
                    Email TEXT NOT NULL,
                    BirthDate TEXT NOT NULL,
                    Role TEXT NOT NULL
                );";

                using var cmd = new SQLiteCommand(createTable, conn);
                cmd.ExecuteNonQuery();
            }

            public void Create(Staff staff)
            {
                using var conn = new SQLiteConnection(_connectionString);
                conn.Open();

                string insertQuery = @"
                INSERT INTO Staff (Name , Password , Email, BirthDate, Role)
                VALUES (@Name , @Password , @Email, @BirthDate, @Role);";

                using var cmd = new SQLiteCommand(insertQuery, conn);
                cmd.Parameters.AddWithValue("@Name", staff.Name);
                cmd.Parameters.AddWithValue("@Email", staff.Email);
                cmd.Parameters.AddWithValue("@Password", staff.Password);
                cmd.Parameters.AddWithValue("@BirthDate", staff.BirthDate.ToString("yyyy-MM-dd"));
                cmd.Parameters.AddWithValue("@Role", staff.Role);
                cmd.ExecuteNonQuery();
            }

            public Staff Read(int id)
            {
                using var conn = new SQLiteConnection(_connectionString);
                conn.Open();

                string selectQuery = "SELECT * FROM Staff WHERE id = @id;";
                using var cmd = new SQLiteCommand(selectQuery, conn);
                cmd.Parameters.AddWithValue("@id", id);

                using var reader = cmd.ExecuteReader();
                if (reader.Read())
                {
                    return new Staff
                    {
                        id = Convert.ToInt32(reader["id"]),
                        Name = reader["Name"].ToString(),
                        Email = reader["Email"].ToString(),
                        Password = reader["Password"].ToString(),
                        BirthDate = DateTime.Parse(reader["BirthDate"].ToString()),
                        Role = reader["Role"].ToString()
                    };
                }
                return null;
            }

            public List<Staff> ReadAll()
            {
                var list = new List<Staff>();

                using var conn = new SQLiteConnection(_connectionString);
                conn.Open();

                string selectQuery = "SELECT * FROM Staff;";
                using var cmd = new SQLiteCommand(selectQuery, conn);
                using var reader = cmd.ExecuteReader();

                while (reader.Read())
                {
                    list.Add(new Staff
                    {
                        id = Convert.ToInt32(reader["id"]),
                        Name = reader["Name"].ToString(),
                        Email = reader["Email"].ToString(),
                        Password = reader["Password"].ToString(),
                        BirthDate = DateTime.Parse(reader["BirthDate"].ToString()),
                        Role = reader["Role"].ToString()
                    });
                }

                return list;
            }

            public void Update(Staff staff)
            {
                using var conn = new SQLiteConnection(_connectionString);
                conn.Open();

                string updateQuery = @"
                UPDATE Staff SET
                    Name = @Name,
                    Email = @Email,
                    Password = @Password,
                    BirthDate = @BirthDate,
                    Role = @Role
                WHERE id = @id;";

                using var cmd = new SQLiteCommand(updateQuery, conn);
                cmd.Parameters.AddWithValue("@Name", staff.Name);
                cmd.Parameters.AddWithValue("@Password", staff.Password);
                cmd.Parameters.AddWithValue("@Email", staff.Email);
                cmd.Parameters.AddWithValue("@BirthDate", staff.BirthDate.ToString("yyyy-MM-dd"));
                cmd.Parameters.AddWithValue("@Role", staff.Role);
                cmd.Parameters.AddWithValue("@id", staff.id);
                cmd.ExecuteNonQuery();
            }

            public void Delete(int id)
            {
                using var conn = new SQLiteConnection(_connectionString);
                conn.Open();

                string deleteQuery = "DELETE FROM Staff WHERE id = @id;";
                using var cmd = new SQLiteCommand(deleteQuery, conn);
                cmd.Parameters.AddWithValue("@id", id);
                cmd.ExecuteNonQuery();
            }
        

    }
}
