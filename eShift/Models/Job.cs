using eShift.Utilities;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace eShift.Models
{
    public class Job
    {
        public string JobNumber { get; set; }
        public string CustomerNumber { get; set; }
        public DateTime RequestDate { get; set; }
        public string StartLocation { get; set; }
        public string Destination { get; set; }
        public string Status { get; set; } // Pending, Accepted, Declined, Completed
        public string AdminRemarks { get; set; }

        public Job() { }

        public Job(string customerNumber, string startLocation, string destination)
        {
            JobNumber = "JOB" + DateTime.Now.ToString("yyyyMMddHHmmss");
            CustomerNumber = customerNumber;
            RequestDate = DateTime.Now;
            StartLocation = startLocation;
            Destination = destination;
            Status = "Pending";
            AdminRemarks = "";
        }

        public bool CreateJob()
        {
            string query = $"INSERT INTO Jobs (JobNumber, CustomerNumber, RequestDate, StartLocation, Destination, Status, AdminRemarks) " +
                          $"VALUES ('{JobNumber}', '{CustomerNumber}', '{RequestDate}', '{StartLocation}', '{Destination}', '{Status}', '{AdminRemarks}')";
            return DatabaseHelper.ExecuteNonQuery(query) > 0;
        }

        public static DataTable GetJobsByCustomer(string customerNumber)
        {
            string query = $"SELECT * FROM Jobs WHERE CustomerNumber = '{customerNumber}' ORDER BY RequestDate DESC";
            return DatabaseHelper.ExecuteQuery(query);
        }

        public static DataTable GetAllJobs()
        {
            string query = "SELECT j.*, c.Name AS CustomerName FROM Jobs j INNER JOIN Customers c ON j.CustomerNumber = c.CustomerNumber ORDER BY j.RequestDate DESC";
            return DatabaseHelper.ExecuteQuery(query);
        }

        public static bool UpdateJobStatus(string jobNumber, string status, string remarks)
        {
            string query = $"UPDATE Jobs SET Status = '{status}', AdminRemarks = '{remarks}' WHERE JobNumber = '{jobNumber}'";
            return DatabaseHelper.ExecuteNonQuery(query) > 0;
        }
    }
}
