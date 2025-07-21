using eShift.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace eShift.Forms.Admin
{
    public partial class ProcessJobForm : Form
    {
        private string jobNumber;

        public ProcessJobForm(string jobNumber)
        {
            InitializeComponent();
            this.jobNumber = jobNumber;
            lblJobNumber.Text = "Job Number: " + jobNumber;
        }

        private void btnAccept_Click(object sender, EventArgs e)
        {
            if (Job.UpdateJobStatus(jobNumber, "Accepted", txtRemarks.Text))
            {
                MessageBox.Show("Job accepted successfully");
                this.DialogResult = DialogResult.OK;
                this.Close();
            }
            else
            {
                MessageBox.Show("Failed to accept job");
            }
        }

        private void btnDecline_Click(object sender, EventArgs e)
        {
            if (Job.UpdateJobStatus(jobNumber, "Declined", txtRemarks.Text))
            {
                MessageBox.Show("Job declined successfully");
                this.DialogResult = DialogResult.OK;
                this.Close();
            }
            else
            {
                MessageBox.Show("Failed to decline job");
            }
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
            this.Close();
        }
    }
}
