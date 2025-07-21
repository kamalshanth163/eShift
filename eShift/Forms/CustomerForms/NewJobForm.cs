using eShift.Models;
using System;
using System.Data;
using System.Windows.Forms;

namespace eShift.Forms.CustomerForms
{
    public partial class NewJobForm : Form
    {
        private Customer customer;
        private Label label1;
        private ComboBox cmbProduct;
        private Button btnAddLoad;
        private Button btnRemoveLoad;
        private Label lblDestination;
        private Label label6;
        private TextBox txtDestination;
        private TextBox txtStartLocation;
        private Label lblTitle;
        private NumericUpDown numQuantity;
        private NumericUpDown numWeight;
        private Label label2;
        private Label label3;
        private Label label4;
        private TextBox txtSpecialInstructions;
        private Button btnCreateJob;
        private Button Cancel;
        private DataGridView dgvLoads;
        private DataGridViewTextBoxColumn ProductCode;
        private DataGridViewTextBoxColumn ProductName;
        private DataGridViewTextBoxColumn Quantity;
        private DataGridViewTextBoxColumn Weight;
        private DataGridViewTextBoxColumn Instructions;
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

        private void InitializeComponent()
        {
            this.label1 = new System.Windows.Forms.Label();
            this.cmbProduct = new System.Windows.Forms.ComboBox();
            this.btnAddLoad = new System.Windows.Forms.Button();
            this.btnRemoveLoad = new System.Windows.Forms.Button();
            this.lblDestination = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.txtDestination = new System.Windows.Forms.TextBox();
            this.txtStartLocation = new System.Windows.Forms.TextBox();
            this.lblTitle = new System.Windows.Forms.Label();
            this.numQuantity = new System.Windows.Forms.NumericUpDown();
            this.numWeight = new System.Windows.Forms.NumericUpDown();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.txtSpecialInstructions = new System.Windows.Forms.TextBox();
            this.btnCreateJob = new System.Windows.Forms.Button();
            this.Cancel = new System.Windows.Forms.Button();
            this.dgvLoads = new System.Windows.Forms.DataGridView();
            this.ProductCode = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ProductName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Quantity = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Weight = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Instructions = new System.Windows.Forms.DataGridViewTextBoxColumn();
            ((System.ComponentModel.ISupportInitialize)(this.numQuantity)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numWeight)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvLoads)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(449, 112);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(44, 13);
            this.label1.TabIndex = 34;
            this.label1.Text = "Product";
            // 
            // cmbProduct
            // 
            this.cmbProduct.FormattingEnabled = true;
            this.cmbProduct.Items.AddRange(new object[] {
            "[\"Customer\", \"Admin\"]"});
            this.cmbProduct.Location = new System.Drawing.Point(452, 132);
            this.cmbProduct.Name = "cmbProduct";
            this.cmbProduct.Size = new System.Drawing.Size(162, 21);
            this.cmbProduct.TabIndex = 33;
            // 
            // btnAddLoad
            // 
            this.btnAddLoad.Location = new System.Drawing.Point(543, 194);
            this.btnAddLoad.Name = "btnAddLoad";
            this.btnAddLoad.Size = new System.Drawing.Size(75, 23);
            this.btnAddLoad.TabIndex = 32;
            this.btnAddLoad.Text = "Add Load";
            this.btnAddLoad.UseVisualStyleBackColor = true;
            this.btnAddLoad.Click += new System.EventHandler(this.btnAddLoad_Click);
            // 
            // btnRemoveLoad
            // 
            this.btnRemoveLoad.Location = new System.Drawing.Point(634, 194);
            this.btnRemoveLoad.Name = "btnRemoveLoad";
            this.btnRemoveLoad.Size = new System.Drawing.Size(100, 23);
            this.btnRemoveLoad.TabIndex = 31;
            this.btnRemoveLoad.Text = "Remove Load";
            this.btnRemoveLoad.UseVisualStyleBackColor = true;
            this.btnRemoveLoad.Click += new System.EventHandler(this.btnRemoveLoad_Click);
            // 
            // lblDestination
            // 
            this.lblDestination.AutoSize = true;
            this.lblDestination.Location = new System.Drawing.Point(103, 112);
            this.lblDestination.Name = "lblDestination";
            this.lblDestination.Size = new System.Drawing.Size(73, 13);
            this.lblDestination.TabIndex = 30;
            this.lblDestination.Text = "Start Location";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(270, 112);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(60, 13);
            this.label6.TabIndex = 29;
            this.label6.Text = "Destination";
            // 
            // txtDestination
            // 
            this.txtDestination.Location = new System.Drawing.Point(273, 133);
            this.txtDestination.Name = "txtDestination";
            this.txtDestination.PasswordChar = '*';
            this.txtDestination.Size = new System.Drawing.Size(145, 20);
            this.txtDestination.TabIndex = 28;
            // 
            // txtStartLocation
            // 
            this.txtStartLocation.Location = new System.Drawing.Point(105, 133);
            this.txtStartLocation.Name = "txtStartLocation";
            this.txtStartLocation.Size = new System.Drawing.Size(140, 20);
            this.txtStartLocation.TabIndex = 27;
            // 
            // lblTitle
            // 
            this.lblTitle.AutoSize = true;
            this.lblTitle.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTitle.Location = new System.Drawing.Point(76, 46);
            this.lblTitle.Name = "lblTitle";
            this.lblTitle.Size = new System.Drawing.Size(159, 24);
            this.lblTitle.TabIndex = 26;
            this.lblTitle.Text = "Create New Job";
            // 
            // numQuantity
            // 
            this.numQuantity.Location = new System.Drawing.Point(645, 132);
            this.numQuantity.Name = "numQuantity";
            this.numQuantity.Size = new System.Drawing.Size(76, 20);
            this.numQuantity.TabIndex = 35;
            // 
            // numWeight
            // 
            this.numWeight.Location = new System.Drawing.Point(753, 132);
            this.numWeight.Name = "numWeight";
            this.numWeight.Size = new System.Drawing.Size(72, 20);
            this.numWeight.TabIndex = 36;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(751, 112);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(41, 13);
            this.label2.TabIndex = 37;
            this.label2.Text = "Weight";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(643, 112);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(46, 13);
            this.label3.TabIndex = 38;
            this.label3.Text = "Quantity";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(104, 174);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(99, 13);
            this.label4.TabIndex = 40;
            this.label4.Text = "Special Instructions";
            // 
            // txtSpecialInstructions
            // 
            this.txtSpecialInstructions.Location = new System.Drawing.Point(107, 196);
            this.txtSpecialInstructions.Multiline = true;
            this.txtSpecialInstructions.Name = "txtSpecialInstructions";
            this.txtSpecialInstructions.PasswordChar = '*';
            this.txtSpecialInstructions.Size = new System.Drawing.Size(311, 20);
            this.txtSpecialInstructions.TabIndex = 39;
            // 
            // btnCreateJob
            // 
            this.btnCreateJob.Location = new System.Drawing.Point(452, 194);
            this.btnCreateJob.Name = "btnCreateJob";
            this.btnCreateJob.Size = new System.Drawing.Size(75, 23);
            this.btnCreateJob.TabIndex = 42;
            this.btnCreateJob.Text = "Create Job";
            this.btnCreateJob.UseVisualStyleBackColor = true;
            this.btnCreateJob.Click += new System.EventHandler(this.btnCreateJob_Click);
            // 
            // Cancel
            // 
            this.Cancel.Location = new System.Drawing.Point(751, 194);
            this.Cancel.Name = "Cancel";
            this.Cancel.Size = new System.Drawing.Size(75, 23);
            this.Cancel.TabIndex = 41;
            this.Cancel.Text = "Cancel";
            this.Cancel.UseVisualStyleBackColor = true;
            this.Cancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // dgvLoads
            // 
            this.dgvLoads.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dgvLoads.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvLoads.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.ProductCode,
            this.ProductName,
            this.Quantity,
            this.Weight,
            this.Instructions});
            this.dgvLoads.Location = new System.Drawing.Point(107, 253);
            this.dgvLoads.Name = "dgvLoads";
            this.dgvLoads.ReadOnly = true;
            this.dgvLoads.Size = new System.Drawing.Size(718, 201);
            this.dgvLoads.TabIndex = 43;
            // 
            // ProductCode
            // 
            this.ProductCode.HeaderText = "Product Code";
            this.ProductCode.Name = "ProductCode";
            this.ProductCode.ReadOnly = true;
            // 
            // ProductName
            // 
            this.ProductName.HeaderText = "Product Name";
            this.ProductName.Name = "ProductName";
            this.ProductName.ReadOnly = true;
            // 
            // Quantity
            // 
            this.Quantity.HeaderText = "Quantity";
            this.Quantity.Name = "Quantity";
            this.Quantity.ReadOnly = true;
            // 
            // Weight
            // 
            this.Weight.HeaderText = "Weight";
            this.Weight.Name = "Weight";
            this.Weight.ReadOnly = true;
            // 
            // Instructions
            // 
            this.Instructions.HeaderText = "Instructions";
            this.Instructions.Name = "Instructions";
            this.Instructions.ReadOnly = true;
            // 
            // NewJobForm
            // 
            this.ClientSize = new System.Drawing.Size(934, 511);
            this.Controls.Add(this.dgvLoads);
            this.Controls.Add(this.btnCreateJob);
            this.Controls.Add(this.Cancel);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.txtSpecialInstructions);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.numWeight);
            this.Controls.Add(this.numQuantity);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.cmbProduct);
            this.Controls.Add(this.btnAddLoad);
            this.Controls.Add(this.btnRemoveLoad);
            this.Controls.Add(this.lblDestination);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.txtDestination);
            this.Controls.Add(this.txtStartLocation);
            this.Controls.Add(this.lblTitle);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.Name = "NewJobForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            ((System.ComponentModel.ISupportInitialize)(this.numQuantity)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numWeight)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvLoads)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }
    }
}
