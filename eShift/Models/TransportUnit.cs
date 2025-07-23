using eShift.Utilities;
using System;
using System.Data;

namespace eShift.Models
{
    public class TransportUnit
    {
        public string TransportUnitId { get; set; }
        public string LorryNumber { get; set; }
        public string DriverName { get; set; }
        public string DriverLicense { get; set; }
        public string AssistantName { get; set; }
        public string ContainerNumber { get; set; }
        public string Status { get; set; } // Available, Assigned, Maintenance

        public TransportUnit() { }

        public TransportUnit(string lorryNumber, string driverName, string driverLicense, string assistantName, string containerNumber)
        {
            TransportUnitId = "TU" + DateTime.Now.ToString("yyyyMMddHHmmss");
            LorryNumber = lorryNumber;
            DriverName = driverName;
            DriverLicense = driverLicense;
            AssistantName = assistantName;
            ContainerNumber = containerNumber;
            Status = "Available";
        }

        public bool AddTransportUnit()
        {
            string query = $"INSERT INTO TransportUnits (TransportUnitId, LorryNumber, DriverName, DriverLicense, AssistantName, ContainerNumber, Status) " +
                          $"VALUES ('{TransportUnitId}', '{LorryNumber}', '{DriverName}', '{DriverLicense}', '{AssistantName}', '{ContainerNumber}', '{Status}')";
            return DatabaseHelper.ExecuteNonQuery(query) > 0;
        }

        public static DataTable GetAllTransportUnits()
        {
            string query = "SELECT * FROM TransportUnits ORDER BY Status";
            return DatabaseHelper.ExecuteQuery(query);
        }

        public static DataTable GetAvailableTransportUnits()
        {
            string query = "SELECT * FROM TransportUnits WHERE Status = 'Available'";
            return DatabaseHelper.ExecuteQuery(query);
        }

        public static bool UpdateTransportUnitStatus(string transportUnitId, string status)
        {
            string query = $"UPDATE TransportUnits SET Status = '{status}' WHERE TransportUnitId = '{transportUnitId}'";
            return DatabaseHelper.ExecuteNonQuery(query) > 0;
        }
    }
}
