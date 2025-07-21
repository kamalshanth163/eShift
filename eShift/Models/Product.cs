using eShift.Utilities;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace eShift.Models
{
    public class Product
    {
        public string ProductCode { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public decimal HandlingFee { get; set; }

        public Product() { }

        public Product(string name, string description, decimal handlingFee)
        {
            ProductCode = "PROD" + DateTime.Now.ToString("yyyyMMddHHmmss");
            Name = name;
            Description = description;
            HandlingFee = handlingFee;
        }

        public bool AddProduct()
        {
            string query = $"INSERT INTO Products (ProductCode, Name, Description, HandlingFee) " +
                          $"VALUES ('{ProductCode}', '{Name}', '{Description}', {HandlingFee})";
            return DatabaseHelper.ExecuteNonQuery(query) > 0;
        }

        public static DataTable GetAllProducts()
        {
            string query = "SELECT * FROM Products";
            return DatabaseHelper.ExecuteQuery(query);
        }

        public static bool DeleteProduct(string productCode)
        {
            string query = $"DELETE FROM Products WHERE ProductCode = '{productCode}'";
            return DatabaseHelper.ExecuteNonQuery(query) > 0;
        }
    }
}
