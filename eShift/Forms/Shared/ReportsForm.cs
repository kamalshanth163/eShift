using eShift.Utilities;
using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing.Printing;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace eShift.Forms.Shared
{
    public partial class ReportsForm : Form
    {
        public ReportsForm()
        {
            InitializeComponent();
            LoadReportTypes();
        }

        private void LoadReportTypes()
        {
            cmbReportType.Items.AddRange(new object[] {
                "Jobs by Status",
                "Jobs by Customer",
                "Transport Unit Utilization",
                "Revenue by Month",
                "Pending Jobs"
            });
            cmbReportType.SelectedIndex = 0;
        }

        private void btnGenerate_Click(object sender, EventArgs e)
        {
            string reportType = cmbReportType.SelectedItem.ToString();
            DataTable dt = null;

            switch (reportType)
            {
                case "Jobs by Status":
                    dt = DatabaseHelper.ExecuteQuery("SELECT Status, COUNT(*) AS JobCount FROM Jobs GROUP BY Status");
                    break;
                case "Jobs by Customer":
                    dt = DatabaseHelper.ExecuteQuery("SELECT c.Name, COUNT(j.JobNumber) AS JobCount FROM Customers c LEFT JOIN Jobs j ON c.CustomerNumber = j.CustomerNumber GROUP BY c.Name");
                    break;
                case "Transport Unit Utilization":
                    dt = DatabaseHelper.ExecuteQuery("SELECT Status, COUNT(*) AS UnitCount FROM TransportUnits GROUP BY Status");
                    break;
                case "Revenue by Month":
                    dt = DatabaseHelper.ExecuteQuery("SELECT MONTH(RequestDate) AS Month, SUM(TotalFee) AS Revenue FROM Jobs WHERE Status = 'Completed' GROUP BY MONTH(RequestDate)");
                    break;
                case "Pending Jobs":
                    dt = DatabaseHelper.ExecuteQuery("SELECT j.JobNumber, c.Name, j.RequestDate, j.StartLocation, j.Destination FROM Jobs j INNER JOIN Customers c ON j.CustomerNumber = c.CustomerNumber WHERE j.Status = 'Pending'");
                    break;
            }

            dgvReport.DataSource = dt;
        }

        private void btnPrint_Click(object sender, EventArgs e)
        {
            PrintDocument printDoc = new PrintDocument();
            printDoc.PrintPage += new PrintPageEventHandler(PrintReport);

            PrintDialog printDialog = new PrintDialog();
            printDialog.Document = printDoc;

            if (printDialog.ShowDialog() == DialogResult.OK)
            {
                printDoc.Print();
            }
        }

        private void PrintReport(object sender, PrintPageEventArgs e)
        {
            Graphics graphics = e.Graphics;
            Font font = new Font("Arial", 12);
            Font headingFont = new Font("Arial", 14, FontStyle.Bold);
            float yPos = 0;
            float leftMargin = e.MarginBounds.Left;
            float topMargin = e.MarginBounds.Top;

            // Print header
            graphics.DrawString("e-Shift Report", headingFont, Brushes.Black, leftMargin, yPos);
            yPos += headingFont.GetHeight() + 20;
            graphics.DrawString($"Report Type: {cmbReportType.SelectedItem}", font, Brushes.Black, leftMargin, yPos);
            yPos += font.GetHeight() + 20;
            graphics.DrawString($"Date: {DateTime.Now.ToShortDateString()}", font, Brushes.Black, leftMargin, yPos);
            yPos += font.GetHeight() + 30;

            // Print data grid
            DataTable dt = (DataTable)dgvReport.DataSource;
            if (dt != null)
            {
                // Print column headers
                float xPos = leftMargin;
                foreach (DataColumn column in dt.Columns)
                {
                    graphics.DrawString(column.ColumnName, font, Brushes.Black, xPos, yPos);
                    xPos += 150;
                }
                yPos += font.GetHeight() + 10;

                // Print rows
                foreach (DataRow row in dt.Rows)
                {
                    xPos = leftMargin;
                    foreach (object item in row.ItemArray)
                    {
                        graphics.DrawString(item.ToString(), font, Brushes.Black, xPos, yPos);
                        xPos += 150;
                    }
                    yPos += font.GetHeight() + 10;
                }
            }
        }
    }
}
