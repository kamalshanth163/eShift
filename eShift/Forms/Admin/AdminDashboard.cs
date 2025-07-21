using eShift.Forms.Shared;
using eShift.Models;
using eShift.Utilities;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace eShift.Forms.Admin
{
    public partial class AdminDashboard : Form
    {
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
    }
}
