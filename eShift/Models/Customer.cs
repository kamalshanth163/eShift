using eShift.Utilities;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace eShift.Models
{
    public class Customer
    {
        public string CustomerNumber { get; set; }
        public string Name { get; set; }
        public string Address { get; set; }
        public string Phone { get; set; }
        public string Email { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }

        public Customer() { }

        public Customer(string name, string address, string phone, string email, string username, string password)
        {
            CustomerNumber = "CUST" + DateTime.Now.ToString("yyyyMMddHHmmss");
            Name = name;
            Address = address;
            Phone = phone;
            Email = email;
            Username = username;
            Password = password;
        }

        public bool Register()
        {
            string query = $"INSERT INTO Customers (CustomerNumber, Name, Address, Phone, Email, Username, Password) " +
                          $"VALUES ('{CustomerNumber}', '{Name}', '{Address}', '{Phone}', '{Email}', '{Username}', '{Password}')";
            return DatabaseHelper.ExecuteNonQuery(query) > 0;
        }

        public static Customer Login(string username, string password)
        {
            string query = $"SELECT * FROM Customers WHERE Username = '{username}' AND Password = '{password}'";
            DataTable dt = DatabaseHelper.ExecuteQuery(query);

            if (dt.Rows.Count > 0)
            {
                DataRow row = dt.Rows[0];
                return new Customer
                {
                    CustomerNumber = row["CustomerNumber"].ToString(),
                    Name = row["Name"].ToString(),
                    Address = row["Address"].ToString(),
                    Phone = row["Phone"].ToString(),
                    Email = row["Email"].ToString(),
                    Username = row["Username"].ToString(),
                    Password = row["Password"].ToString()
                };
            }
            return null;
        }

        public static DataTable GetAllCustomers()
        {
            string query = "SELECT * FROM Customers";
            return DatabaseHelper.ExecuteQuery(query);
        }

        public bool UpdateProfile()
        {
            string query = $"UPDATE Customers SET Name = '{Name}', Address = '{Address}', Phone = '{Phone}', " +
                          $"Email = '{Email}' WHERE CustomerNumber = '{CustomerNumber}'";
            return DatabaseHelper.ExecuteNonQuery(query) > 0;
        }
    }
}
