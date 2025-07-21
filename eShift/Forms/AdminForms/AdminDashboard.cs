using eShift.Forms.Shared;
using eShift.Models;
using eShift.Utilities;
using System;
using System.Data;
using System.Windows.Forms;

namespace eShift.Forms.AdminForms
{
    public partial class AdminDashboard : Form
    {
        private Label lblWelcome;
        private Button btnManageAdmins;
        private Button btnLogout;
        private Button btnProcessJob;
        private Button btnAssignTransport;
        private Label lblTitle;
        private Button btnManageProducts;
        private Button btnGenerateReports;
        private TabControl tabControl1;
        private TabPage tabPage1;
        private TabPage tabPage2;
        private TabPage tabPage3;
        private DataGridView dgvPendingJobs;
        private DataGridView dgvAllJobs;
        private DataGridView dgvTransportUnits;
        private Admin admin;

        public AdminDashboard(Admin admin)
        {
            InitializeComponent();
            this.admin = admin;
            lblWelcome.Text = $"Welcome, Admin {admin.Name}";
            LoadPendingJobs();
            LoadAllJobs();
            LoadTransportUnits();
        }

        private void LoadPendingJobs()
        {
            DataTable dt = DatabaseHelper.ExecuteQuery("SELECT j.*, c.Name AS CustomerName FROM Jobs j INNER JOIN Customers c ON j.CustomerNumber = c.CustomerNumber WHERE j.Status = 'Pending'");
            dgvPendingJobs.DataSource = dt;
        }

        private void LoadAllJobs()
        {
            DataTable dt = Job.GetAllJobs();
            dgvAllJobs.DataSource = dt;
        }

        private void LoadTransportUnits()
        {
            DataTable dt = TransportUnit.GetAllTransportUnits();
            dgvTransportUnits.DataSource = dt;
        }

        private void btnManageAdmins_Click(object sender, EventArgs e)
        {
            ManageAdminsForm manageAdminsForm = new ManageAdminsForm();
            manageAdminsForm.ShowDialog();
        }

        private void btnManageProducts_Click(object sender, EventArgs e)
        {
            ManageProductsForm manageProductsForm = new ManageProductsForm();
            manageProductsForm.ShowDialog();
        }

        private void btnProcessJob_Click(object sender, EventArgs e)
        {
            if (dgvPendingJobs.SelectedRows.Count > 0)
            {
                string jobNumber = dgvPendingJobs.SelectedRows[0].Cells["JobNumber"].Value.ToString();
                ProcessJobForm processJobForm = new ProcessJobForm(jobNumber);
                if (processJobForm.ShowDialog() == DialogResult.OK)
                {
                    LoadPendingJobs();
                    LoadAllJobs();
                }
            }
            else
            {
                MessageBox.Show("Please select a pending job first");
            }
        }

        private void btnAssignTransport_Click(object sender, EventArgs e)
        {
            if (dgvAllJobs.SelectedRows.Count > 0)
            {
                string jobNumber = dgvAllJobs.SelectedRows[0].Cells["JobNumber"].Value.ToString();
                AssignTransportForm assignTransportForm = new AssignTransportForm(jobNumber);
                assignTransportForm.ShowDialog();
                LoadAllJobs();
                LoadTransportUnits();
            }
            else
            {
                MessageBox.Show("Please select a job first");
            }
        }

        private void btnGenerateReports_Click(object sender, EventArgs e)
        {
            ReportsForm reportsForm = new ReportsForm();
            reportsForm.ShowDialog();
        }

        private void btnLogout_Click(object sender, EventArgs e)
        {
            MainForm mainForm = new MainForm();
            mainForm.Show();
            this.Close();
        }

        private void InitializeComponent()
        {
            this.lblWelcome = new System.Windows.Forms.Label();
            this.btnManageAdmins = new System.Windows.Forms.Button();
            this.btnLogout = new System.Windows.Forms.Button();
            this.btnProcessJob = new System.Windows.Forms.Button();
            this.btnAssignTransport = new System.Windows.Forms.Button();
            this.lblTitle = new System.Windows.Forms.Label();
            this.btnManageProducts = new System.Windows.Forms.Button();
            this.btnGenerateReports = new System.Windows.Forms.Button();
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.tabPage3 = new System.Windows.Forms.TabPage();
            this.dgvPendingJobs = new System.Windows.Forms.DataGridView();
            this.dgvAllJobs = new System.Windows.Forms.DataGridView();
            this.dgvTransportUnits = new System.Windows.Forms.DataGridView();
            this.tabControl1.SuspendLayout();
            this.tabPage1.SuspendLayout();
            this.tabPage2.SuspendLayout();
            this.tabPage3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvPendingJobs)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvAllJobs)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvTransportUnits)).BeginInit();
            this.SuspendLayout();
            // 
            // lblWelcome
            // 
            this.lblWelcome.AutoSize = true;
            this.lblWelcome.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblWelcome.Location = new System.Drawing.Point(78, 126);
            this.lblWelcome.Name = "lblWelcome";
            this.lblWelcome.Size = new System.Drawing.Size(0, 24);
            this.lblWelcome.TabIndex = 43;
            // 
            // btnManageAdmins
            // 
            this.btnManageAdmins.Location = new System.Drawing.Point(454, 61);
            this.btnManageAdmins.Name = "btnManageAdmins";
            this.btnManageAdmins.Size = new System.Drawing.Size(101, 23);
            this.btnManageAdmins.TabIndex = 41;
            this.btnManageAdmins.Text = "Manage Admins";
            this.btnManageAdmins.UseVisualStyleBackColor = true;
            // 
            // btnLogout
            // 
            this.btnLogout.Location = new System.Drawing.Point(805, 61);
            this.btnLogout.Name = "btnLogout";
            this.btnLogout.Size = new System.Drawing.Size(75, 23);
            this.btnLogout.TabIndex = 40;
            this.btnLogout.Text = "Logout";
            this.btnLogout.UseVisualStyleBackColor = true;
            // 
            // btnProcessJob
            // 
            this.btnProcessJob.Location = new System.Drawing.Point(274, 61);
            this.btnProcessJob.Name = "btnProcessJob";
            this.btnProcessJob.Size = new System.Drawing.Size(75, 23);
            this.btnProcessJob.TabIndex = 39;
            this.btnProcessJob.Text = "Process Job";
            this.btnProcessJob.UseVisualStyleBackColor = true;
            // 
            // btnAssignTransport
            // 
            this.btnAssignTransport.Location = new System.Drawing.Point(363, 61);
            this.btnAssignTransport.Name = "btnAssignTransport";
            this.btnAssignTransport.Size = new System.Drawing.Size(75, 23);
            this.btnAssignTransport.TabIndex = 38;
            this.btnAssignTransport.Text = "Assign Transport";
            this.btnAssignTransport.UseVisualStyleBackColor = true;
            // 
            // lblTitle
            // 
            this.lblTitle.AutoSize = true;
            this.lblTitle.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTitle.Location = new System.Drawing.Point(50, 58);
            this.lblTitle.Name = "lblTitle";
            this.lblTitle.Size = new System.Drawing.Size(177, 24);
            this.lblTitle.TabIndex = 37;
            this.lblTitle.Text = "Admin Dashboard";
            // 
            // btnManageProducts
            // 
            this.btnManageProducts.Location = new System.Drawing.Point(561, 61);
            this.btnManageProducts.Name = "btnManageProducts";
            this.btnManageProducts.Size = new System.Drawing.Size(101, 23);
            this.btnManageProducts.TabIndex = 44;
            this.btnManageProducts.Text = "Manage Products";
            this.btnManageProducts.UseVisualStyleBackColor = true;
            // 
            // btnGenerateReports
            // 
            this.btnGenerateReports.Location = new System.Drawing.Point(668, 61);
            this.btnGenerateReports.Name = "btnGenerateReports";
            this.btnGenerateReports.Size = new System.Drawing.Size(124, 23);
            this.btnGenerateReports.TabIndex = 45;
            this.btnGenerateReports.Text = "Generate Reports";
            this.btnGenerateReports.UseVisualStyleBackColor = true;
            // 
            // tabControl1
            // 
            this.tabControl1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tabControl1.Controls.Add(this.tabPage1);
            this.tabControl1.Controls.Add(this.tabPage2);
            this.tabControl1.Controls.Add(this.tabPage3);
            this.tabControl1.Location = new System.Drawing.Point(54, 126);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(826, 328);
            this.tabControl1.TabIndex = 46;
            // 
            // tabPage1
            // 
            this.tabPage1.Controls.Add(this.dgvPendingJobs);
            this.tabPage1.Location = new System.Drawing.Point(4, 22);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(818, 302);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "Pending Jobs";
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // tabPage2
            // 
            this.tabPage2.Controls.Add(this.dgvAllJobs);
            this.tabPage2.Location = new System.Drawing.Point(4, 22);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage2.Size = new System.Drawing.Size(818, 302);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "All Jobs";
            this.tabPage2.UseVisualStyleBackColor = true;
            // 
            // tabPage3
            // 
            this.tabPage3.Controls.Add(this.dgvTransportUnits);
            this.tabPage3.Location = new System.Drawing.Point(4, 22);
            this.tabPage3.Name = "tabPage3";
            this.tabPage3.Size = new System.Drawing.Size(818, 302);
            this.tabPage3.TabIndex = 2;
            this.tabPage3.Text = "Transport Units";
            this.tabPage3.UseVisualStyleBackColor = true;
            // 
            // dgvPendingJobs
            // 
            this.dgvPendingJobs.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvPendingJobs.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvPendingJobs.Location = new System.Drawing.Point(3, 3);
            this.dgvPendingJobs.Name = "dgvPendingJobs";
            this.dgvPendingJobs.ReadOnly = true;
            this.dgvPendingJobs.Size = new System.Drawing.Size(812, 296);
            this.dgvPendingJobs.TabIndex = 36;
            // 
            // dgvAllJobs
            // 
            this.dgvAllJobs.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvAllJobs.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvAllJobs.Location = new System.Drawing.Point(3, 3);
            this.dgvAllJobs.Name = "dgvAllJobs";
            this.dgvAllJobs.ReadOnly = true;
            this.dgvAllJobs.Size = new System.Drawing.Size(812, 296);
            this.dgvAllJobs.TabIndex = 37;
            // 
            // dgvTransportUnits
            // 
            this.dgvTransportUnits.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvTransportUnits.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvTransportUnits.Location = new System.Drawing.Point(0, 0);
            this.dgvTransportUnits.Name = "dgvTransportUnits";
            this.dgvTransportUnits.ReadOnly = true;
            this.dgvTransportUnits.Size = new System.Drawing.Size(818, 302);
            this.dgvTransportUnits.TabIndex = 37;
            // 
            // AdminDashboard
            // 
            this.ClientSize = new System.Drawing.Size(934, 511);
            this.Controls.Add(this.tabControl1);
            this.Controls.Add(this.btnGenerateReports);
            this.Controls.Add(this.btnManageProducts);
            this.Controls.Add(this.lblWelcome);
            this.Controls.Add(this.btnManageAdmins);
            this.Controls.Add(this.btnLogout);
            this.Controls.Add(this.btnProcessJob);
            this.Controls.Add(this.btnAssignTransport);
            this.Controls.Add(this.lblTitle);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MinimizeBox = false;
            this.Name = "AdminDashboard";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.tabControl1.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            this.tabPage2.ResumeLayout(false);
            this.tabPage3.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvPendingJobs)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvAllJobs)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvTransportUnits)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }
    }
}
