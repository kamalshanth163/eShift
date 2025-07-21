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
    public partial class NewJobForm : Form
    {
        private Customer customer;
        private DataTable products;

        public NewJobForm(Customer customer)
        {
            InitializeComponent();
            this.customer = customer;
            LoadProducts();
        }

        private void LoadProducts()
        {
            products = Product.GetAllProducts();
            cmbProduct.DataSource = products;
            cmbProduct.DisplayMember = "Name";
            cmbProduct.ValueMember = "ProductCode";
        }

        private void btnAddLoad_Click(object sender, EventArgs e)
        {
            if (ValidateLoad())
            {
                DataRowView selectedProduct = (DataRowView)cmbProduct.SelectedItem;

                DataGridViewRow row = new DataGridViewRow();
                row.CreateCells(dgvLoads);
                row.Cells[0].Value = selectedProduct["ProductCode"];
                row.Cells[1].Value = selectedProduct["Name"];
                row.Cells[2].Value = numQuantity.Value;
                row.Cells[3].Value = numWeight.Value;
                row.Cells[4].Value = txtSpecialInstructions.Text;
                dgvLoads.Rows.Add(row);

                // Clear fields
                numQuantity.Value = 1;
                numWeight.Value = 0;
                txtSpecialInstructions.Clear();
            }
        }

        private bool ValidateLoad()
        {
            if (cmbProduct.SelectedIndex < 0)
            {
                MessageBox.Show("Please select a product");
                return false;
            }

            if (numQuantity.Value <= 0)
            {
                MessageBox.Show("Please enter a valid quantity");
                return false;
            }

            if (numWeight.Value <= 0)
            {
                MessageBox.Show("Please enter a valid weight");
                return false;
            }

            return true;
        }

        private void btnRemoveLoad_Click(object sender, EventArgs e)
        {
            if (dgvLoads.SelectedRows.Count > 0)
            {
                dgvLoads.Rows.RemoveAt(dgvLoads.SelectedRows[0].Index);
            }
            else
            {
                MessageBox.Show("Please select a load to remove");
            }
        }

        private void btnCreateJob_Click(object sender, EventArgs e)
        {
            if (ValidateJob())
            {
                Job job = new Job(customer.CustomerNumber, txtStartLocation.Text.Trim(), txtDestination.Text.Trim());

                if (job.CreateJob())
                {
                    foreach (DataGridViewRow row in dgvLoads.Rows)
                    {
                        Load load = new Load(
                            job.JobNumber,
                            row.Cells[0].Value.ToString(),
                            Convert.ToInt32(row.Cells[2].Value),
                            Convert.ToDecimal(row.Cells[3].Value),
                            row.Cells[4].Value.ToString()
                        );
                        load.AddLoad();
                    }

                    MessageBox.Show("Job created successfully! Job Number: " + job.JobNumber);
                    this.DialogResult = DialogResult.OK;
                    this.Close();
                }
                else
                {
                    MessageBox.Show("Failed to create job. Please try again.");
                }
            }
        }

        private bool ValidateJob()
        {
            if (string.IsNullOrEmpty(txtStartLocation.Text))
            {
                MessageBox.Show("Please enter start location");
                return false;
            }

            if (string.IsNullOrEmpty(txtDestination.Text))
            {
                MessageBox.Show("Please enter destination");
                return false;
            }

            if (dgvLoads.Rows.Count == 0)
            {
                MessageBox.Show("Please add at least one load");
                return false;
            }

            return true;
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
            this.Close();
        }
    }
}
