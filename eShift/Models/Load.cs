using eShift.Utilities;
using System;
using System.Data;
using System.Data.SqlClient;

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

        public Load(string jobNumber, string productCode, int quantity, decimal weight,
                   string specialInstructions, string transportUnitId = null)
        {
            LoadNumber = "LOAD" + DateTime.Now.ToString("yyyyMMddHHmmss");
            JobNumber = jobNumber;
            ProductCode = productCode;
            Quantity = quantity;
            Weight = weight;
            SpecialInstructions = specialInstructions;
            TransportUnitId = transportUnitId;
        }

        public bool AddLoad()
        {
            try
            {
                string query = @"INSERT INTO Loads 
                                (LoadNumber, JobNumber, ProductCode, Quantity, 
                                 Weight, SpecialInstructions, TransportUnitId) 
                                VALUES 
                                (@LoadNumber, @JobNumber, @ProductCode, @Quantity, 
                                 @Weight, @SpecialInstructions, @TransportUnitId)";

                SqlParameter[] parameters = new SqlParameter[]
                {
                    new SqlParameter("@LoadNumber", LoadNumber),
                    new SqlParameter("@JobNumber", JobNumber),
                    new SqlParameter("@ProductCode", ProductCode),
                    new SqlParameter("@Quantity", Quantity),
                    new SqlParameter("@Weight", Weight),
                    new SqlParameter("@SpecialInstructions", SpecialInstructions ?? (object)DBNull.Value),
                    new SqlParameter("@TransportUnitId", TransportUnitId ?? (object)DBNull.Value)
                };

                return DatabaseHelper.ExecuteNonQuery(query, parameters) > 0;
            }
            catch (SqlException ex)
            {
                // Handle specific SQL errors
                if (ex.Number == 547) // Foreign key violation
                {
                    throw new Exception("Invalid Transport Unit or Product reference");
                }
                throw;
            }
        }

        public static bool AssignTransportUnit(string loadNumber, string transportUnitId)
        {
            // First verify the transport unit exists
            string checkQuery = "SELECT COUNT(*) FROM TransportUnits WHERE TransportUnitId = @TransportUnitId";
            var checkParam = new SqlParameter("@TransportUnitId", transportUnitId);

            int count = (int)DatabaseHelper.ExecuteScalar(checkQuery, new[] { checkParam });
            if (count == 0)
                return false;

            // Update the load
            string updateQuery = "UPDATE Loads SET TransportUnitId = @TransportUnitId WHERE LoadNumber = @LoadNumber";
            SqlParameter[] parameters = new SqlParameter[]
            {
                new SqlParameter("@TransportUnitId", transportUnitId),
                new SqlParameter("@LoadNumber", loadNumber)
            };

            return DatabaseHelper.ExecuteNonQuery(updateQuery, parameters) > 0;
        }

        public static DataTable GetLoadsByJob(string jobNumber)
        {
            string query = @"SELECT l.*, p.Name AS ProductName 
                           FROM Loads l 
                           INNER JOIN Products p ON l.ProductCode = p.ProductCode 
                           WHERE l.JobNumber = @JobNumber";

            SqlParameter param = new SqlParameter("@JobNumber", jobNumber);
            return DatabaseHelper.ExecuteQuery(query, new[] { param });
        }

        public static DataTable GetLoadsWithTransportDetails(string jobNumber)
        {
            string query = @"SELECT l.LoadNumber, p.Name AS ProductName, l.Quantity, l.Weight,
                           t.LorryNumber, t.DriverName, t.ContainerNumber
                           FROM Loads l
                           INNER JOIN Products p ON l.ProductCode = p.ProductCode
                           LEFT JOIN TransportUnits t ON l.TransportUnitId = t.TransportUnitId
                           WHERE l.JobNumber = @JobNumber";

            SqlParameter param = new SqlParameter("@JobNumber", jobNumber);
            return DatabaseHelper.ExecuteQuery(query, new[] { param });
        }
    }
}