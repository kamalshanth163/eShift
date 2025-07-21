using eShift.Utilities;
using System;
using System.Data;
using System.Drawing;
using System.Drawing.Printing;
using System.Windows.Forms;

namespace eShift.Forms.Shared
{
    public partial class ReportsForm : Form
    {
        private DataGridView dgvReport;
        private Button btnPrint;
        private Button btnClose;
        private Button btnGenerate;
        private Label label1;
        private ComboBox cmbReportType;
        private Label lblTitle;

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

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void InitializeComponent()
        {
            this.dgvReport = new System.Windows.Forms.DataGridView();
            this.btnPrint = new System.Windows.Forms.Button();
            this.btnClose = new System.Windows.Forms.Button();
            this.btnGenerate = new System.Windows.Forms.Button();
            this.lblTitle = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.cmbReportType = new System.Windows.Forms.ComboBox();
            ((System.ComponentModel.ISupportInitialize)(this.dgvReport)).BeginInit();
            this.SuspendLayout();
            // 
            // dgvReport
            // 
            this.dgvReport.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dgvReport.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvReport.Location = new System.Drawing.Point(98, 168);
            this.dgvReport.Name = "dgvReport";
            this.dgvReport.ReadOnly = true;
            this.dgvReport.Size = new System.Drawing.Size(750, 246);
            this.dgvReport.TabIndex = 42;
            // 
            // btnPrint
            // 
            this.btnPrint.Location = new System.Drawing.Point(632, 61);
            this.btnPrint.Name = "btnPrint";
            this.btnPrint.Size = new System.Drawing.Size(84, 23);
            this.btnPrint.TabIndex = 41;
            this.btnPrint.Text = "Print";
            this.btnPrint.UseVisualStyleBackColor = true;
            this.btnPrint.Click += new System.EventHandler(this.btnPrint_Click);
            // 
            // btnClose
            // 
            this.btnClose.Location = new System.Drawing.Point(810, 61);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(75, 23);
            this.btnClose.TabIndex = 40;
            this.btnClose.Text = "Close";
            this.btnClose.UseVisualStyleBackColor = true;
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // btnGenerate
            // 
            this.btnGenerate.Location = new System.Drawing.Point(524, 61);
            this.btnGenerate.Name = "btnGenerate";
            this.btnGenerate.Size = new System.Drawing.Size(90, 23);
            this.btnGenerate.TabIndex = 39;
            this.btnGenerate.Text = "Generate";
            this.btnGenerate.UseVisualStyleBackColor = true;
            this.btnGenerate.Click += new System.EventHandler(this.btnGenerate_Click);
            // 
            // lblTitle
            // 
            this.lblTitle.AutoSize = true;
            this.lblTitle.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTitle.Location = new System.Drawing.Point(50, 58);
            this.lblTitle.Name = "lblTitle";
            this.lblTitle.Size = new System.Drawing.Size(174, 24);
            this.lblTitle.TabIndex = 37;
            this.lblTitle.Text = "Generate Reports";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(105, 127);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(66, 13);
            this.label1.TabIndex = 44;
            this.label1.Text = "Report Type";
            // 
            // cmbReportType
            // 
            this.cmbReportType.FormattingEnabled = true;
            this.cmbReportType.Location = new System.Drawing.Point(205, 123);
            this.cmbReportType.Name = "cmbReportType";
            this.cmbReportType.Size = new System.Drawing.Size(216, 21);
            this.cmbReportType.TabIndex = 43;
            // 
            // ReportsForm
            // 
            this.ClientSize = new System.Drawing.Size(934, 511);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.cmbReportType);
            this.Controls.Add(this.dgvReport);
            this.Controls.Add(this.btnPrint);
            this.Controls.Add(this.btnClose);
            this.Controls.Add(this.btnGenerate);
            this.Controls.Add(this.lblTitle);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.Name = "ReportsForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            ((System.ComponentModel.ISupportInitialize)(this.dgvReport)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }
    }
}
