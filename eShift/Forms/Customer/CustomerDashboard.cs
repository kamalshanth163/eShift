using eShift.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace eShift.Forms.Customer
{
    public partial class CustomerDashboard : Form
    {
        private Customer customer;

        public CustomerDashboard(Customer customer)
        {
            InitializeComponent();
            this.customer = customer;
            lblWelcome.Text = $"Welcome, {customer.Name}";
            LoadJobs();
        }

        private void LoadJobs()
        {
            DataTable dt = Job.GetJobsByCustomer(customer.CustomerNumber);
            dgvJobs.DataSource = dt;
        }

        private void btnNewJob_Click(object sender, EventArgs e)
        {
            NewJobForm newJobForm = new NewJobForm(customer);
            newJobForm.ShowDialog();
            LoadJobs();
        }

        private void btnViewLoads_Click(object sender, EventArgs e)
        {
            if (dgvJobs.SelectedRows.Count > 0)
            {
                string jobNumber = dgvJobs.SelectedRows[0].Cells["JobNumber"].Value.ToString();
                ViewLoadsForm viewLoadsForm = new ViewLoadsForm(jobNumber);
                viewLoadsForm.ShowDialog();
            }
            else
            {
                MessageBox.Show("Please select a job first");
            }
        }

        private void btnUpdateProfile_Click(object sender, EventArgs e)
        {
            CustomerProfileForm profileForm = new CustomerProfileForm(customer);
            if (profileForm.ShowDialog() == DialogResult.OK)
            {
                customer = profileForm.UpdatedCustomer;
                lblWelcome.Text = $"Welcome, {customer.Name}";
            }
        }

        private void btnLogout_Click(object sender, EventArgs e)
        {
            MainForm mainForm = new MainForm();
            mainForm.Show();
            this.Close();
        }
    }
}
