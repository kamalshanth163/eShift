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
    public partial class ViewLoadsForm : Form
    {
        private string jobNumber;

        public ViewLoadsForm(string jobNumber)
        {
            InitializeComponent();
            this.jobNumber = jobNumber;
            lblJobNumber.Text = "Job Number: " + jobNumber;
            LoadLoads();
        }

        private void LoadLoads()
        {
            DataTable dt = Load.GetLoadsByJob(jobNumber);
            dgvLoads.DataSource = dt;

            // Hide unnecessary columns
            if (dgvLoads.Columns.Count > 0)
            {
                dgvLoads.Columns["LoadNumber"].Visible = false;
                dgvLoads.Columns["JobNumber"].Visible = false;
                dgvLoads.Columns["ProductCode"].Visible = false;
                dgvLoads.Columns["TransportUnitId"].Visible = false;
            }
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
