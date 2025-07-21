using eShift.Utilities;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace eShift.Models
{
    public class Load
    {
        public string LoadNumber { get; set; }
        public string JobNumber { get; set; }
        public string ProductCode { get; set; }
        public int Quantity { get; set; }
        public decimal Weight { get; set; }
        public string SpecialInstructions { get; set; }
        public string TransportUnitId { get; set; }

        public Load() { }

        public Load(string jobNumber, string productCode, int quantity, decimal weight, string specialInstructions)
        {
            LoadNumber = "LOAD" + DateTime.Now.ToString("yyyyMMddHHmmss");
            JobNumber = jobNumber;
            ProductCode = productCode;
            Quantity = quantity;
            Weight = weight;
            SpecialInstructions = specialInstructions;
            TransportUnitId = "";
        }

        public bool AddLoad()
        {
            string query = $"INSERT INTO Loads (LoadNumber, JobNumber, ProductCode, Quantity, Weight, SpecialInstructions, TransportUnitId) " +
                          $"VALUES ('{LoadNumber}', '{JobNumber}', '{ProductCode}', {Quantity}, {Weight}, '{SpecialInstructions}', '{TransportUnitId}')";
            return DatabaseHelper.ExecuteNonQuery(query) > 0;
        }

        public static DataTable GetLoadsByJob(string jobNumber)
        {
            string query = $"SELECT l.*, p.Name AS ProductName FROM Loads l INNER JOIN Products p ON l.ProductCode = p.ProductCode WHERE l.JobNumber = '{jobNumber}'";
            return DatabaseHelper.ExecuteQuery(query);
        }

        public static bool AssignTransportUnit(string loadNumber, string transportUnitId)
        {
            string query = $"UPDATE Loads SET TransportUnitId = '{transportUnitId}' WHERE LoadNumber = '{loadNumber}'";
            return DatabaseHelper.ExecuteNonQuery(query) > 0;
        }
    }
}
