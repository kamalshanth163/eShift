using eShift.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace eShift.Forms.Admin
{
    public partial class AssignTransportForm : Form
    {
        private string jobNumber;
        private DataTable loads;
        private DataTable transportUnits;

        public AssignTransportForm(string jobNumber)
        {
            InitializeComponent();
            this.jobNumber = jobNumber;
            lblJobNumber.Text = "Job Number: " + jobNumber;
            LoadData();
        }

        private void LoadData()
        {
            loads = Load.GetLoadsByJob(jobNumber);
            dgvLoads.DataSource = loads;

            transportUnits = TransportUnit.GetAvailableTransportUnits();
            cmbTransportUnit.DataSource = transportUnits;
            cmbTransportUnit.DisplayMember = "LorryNumber";
            cmbTransportUnit.ValueMember = "TransportUnitId";
        }

        private void btnAssign_Click(object sender, EventArgs e)
        {
            if (dgvLoads.SelectedRows.Count > 0 && cmbTransportUnit.SelectedIndex >= 0)
            {
                string loadNumber = dgvLoads.SelectedRows[0].Cells["LoadNumber"].Value.ToString();
                string transportUnitId = cmbTransportUnit.SelectedValue.ToString();

                if (Load.AssignTransportUnit(loadNumber, transportUnitId) &&
                    TransportUnit.UpdateTransportUnitStatus(transportUnitId, "Assigned"))
                {
                    MessageBox.Show("Transport unit assigned successfully");
                    LoadData();
                }
                else
                {
                    MessageBox.Show("Failed to assign transport unit");
                }
            }
            else
            {
                MessageBox.Show("Please select a load and transport unit");
            }
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
