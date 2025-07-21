using eShift.Utilities;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace eShift.Models
{
    public class Admin
    {
        public string AdminId { get; set; }
        public string Name { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }

        public Admin() { }

        public Admin(string name, string username, string password)
        {
            AdminId = "ADM" + DateTime.Now.ToString("yyyyMMddHHmmss");
            Name = name;
            Username = username;
            Password = password;
        }

        public static Admin Login(string username, string password)
        {
            string query = $"SELECT * FROM Admins WHERE Username = '{username}' AND Password = '{password}'";
            DataTable dt = DatabaseHelper.ExecuteQuery(query);

            if (dt.Rows.Count > 0)
            {
                DataRow row = dt.Rows[0];
                return new Admin
                {
                    AdminId = row["AdminId"].ToString(),
                    Name = row["Name"].ToString(),
                    Username = row["Username"].ToString(),
                    Password = row["Password"].ToString()
                };
            }
            return null;
        }

        public bool AddAdmin()
        {
            string query = $"INSERT INTO Admins (AdminId, Name, Username, Password) " +
                          $"VALUES ('{AdminId}', '{Name}', '{Username}', '{Password}')";
            return DatabaseHelper.ExecuteNonQuery(query) > 0;
        }

        public static DataTable GetAllAdmins()
        {
            string query = "SELECT * FROM Admins";
            return DatabaseHelper.ExecuteQuery(query);
        }

        public static bool DeleteAdmin(string adminId)
        {
            string query = $"DELETE FROM Admins WHERE AdminId = '{adminId}'";
            return DatabaseHelper.ExecuteNonQuery(query) > 0;
        }
    }
}
