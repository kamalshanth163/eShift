using eShift.Models;
using System;
using System.Data;
using System.Windows.Forms;

namespace eShift.Forms.AdminForms
{
    public partial class AssignTransportForm : Form
    {
        private string jobNumber;
        private DataTable loads;
        private Button btnClose;
        private Button btnAssign;
        private Label lblJobNumber;
        private Label lblTitle;
        private Label label1;
        private ComboBox cmbTransportUnit;
        private DataGridView dgvLoads;
        private DataGridViewTextBoxColumn LoadNum;
        private DataGridViewTextBoxColumn Product;
        private DataGridViewTextBoxColumn Qty;
        private DataGridViewTextBoxColumn Weight;
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
            loads = Models.Load.GetLoadsByJob(jobNumber);
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

                if (Models.Load.AssignTransportUnit(loadNumber, transportUnitId) &&
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

        private void InitializeComponent()
        {
            this.btnClose = new System.Windows.Forms.Button();
            this.btnAssign = new System.Windows.Forms.Button();
            this.lblJobNumber = new System.Windows.Forms.Label();
            this.lblTitle = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.cmbTransportUnit = new System.Windows.Forms.ComboBox();
            this.dgvLoads = new System.Windows.Forms.DataGridView();
            this.LoadNum = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Product = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Qty = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Weight = new System.Windows.Forms.DataGridViewTextBoxColumn();
            ((System.ComponentModel.ISupportInitialize)(this.dgvLoads)).BeginInit();
            this.SuspendLayout();
            // 
            // btnClose
            // 
            this.btnClose.Location = new System.Drawing.Point(510, 410);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(75, 23);
            this.btnClose.TabIndex = 65;
            this.btnClose.Text = "Close";
            this.btnClose.UseVisualStyleBackColor = true;
            // 
            // btnAssign
            // 
            this.btnAssign.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.btnAssign.Location = new System.Drawing.Point(396, 410);
            this.btnAssign.Name = "btnAssign";
            this.btnAssign.Size = new System.Drawing.Size(75, 23);
            this.btnAssign.TabIndex = 64;
            this.btnAssign.Text = "Assign";
            this.btnAssign.UseVisualStyleBackColor = false;
            // 
            // lblJobNumber
            // 
            this.lblJobNumber.AutoSize = true;
            this.lblJobNumber.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblJobNumber.Location = new System.Drawing.Point(769, 94);
            this.lblJobNumber.Name = "lblJobNumber";
            this.lblJobNumber.Size = new System.Drawing.Size(0, 24);
            this.lblJobNumber.TabIndex = 62;
            // 
            // lblTitle
            // 
            this.lblTitle.AutoSize = true;
            this.lblTitle.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTitle.Location = new System.Drawing.Point(97, 75);
            this.lblTitle.Name = "lblTitle";
            this.lblTitle.Size = new System.Drawing.Size(210, 24);
            this.lblTitle.TabIndex = 60;
            this.lblTitle.Text = "Assign Transport Unit";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(257, 148);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(74, 13);
            this.label1.TabIndex = 68;
            this.label1.Text = "Transport Unit";
            // 
            // cmbTransportUnit
            // 
            this.cmbTransportUnit.FormattingEnabled = true;
            this.cmbTransportUnit.Items.AddRange(new object[] {
            "[\"Customer\", \"Admin\"]"});
            this.cmbTransportUnit.Location = new System.Drawing.Point(396, 145);
            this.cmbTransportUnit.Name = "cmbTransportUnit";
            this.cmbTransportUnit.Size = new System.Drawing.Size(238, 21);
            this.cmbTransportUnit.TabIndex = 67;
            // 
            // dgvLoads
            // 
            this.dgvLoads.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dgvLoads.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvLoads.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.LoadNum,
            this.Product,
            this.Qty,
            this.Weight});
            this.dgvLoads.Location = new System.Drawing.Point(120, 189);
            this.dgvLoads.Name = "dgvLoads";
            this.dgvLoads.ReadOnly = true;
            this.dgvLoads.Size = new System.Drawing.Size(718, 198);
            this.dgvLoads.TabIndex = 69;
            // 
            // LoadNum
            // 
            this.LoadNum.HeaderText = "Load Number";
            this.LoadNum.Name = "LoadNum";
            this.LoadNum.ReadOnly = true;
            // 
            // Product
            // 
            this.Product.HeaderText = "Product";
            this.Product.Name = "Product";
            this.Product.ReadOnly = true;
            // 
            // Qty
            // 
            this.Qty.HeaderText = "Qty";
            this.Qty.Name = "Qty";
            this.Qty.ReadOnly = true;
            // 
            // Weight
            // 
            this.Weight.HeaderText = "Weight";
            this.Weight.Name = "Weight";
            this.Weight.ReadOnly = true;
            // 
            // AssignTransportForm
            // 
            this.ClientSize = new System.Drawing.Size(934, 511);
            this.Controls.Add(this.dgvLoads);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.cmbTransportUnit);
            this.Controls.Add(this.btnClose);
            this.Controls.Add(this.btnAssign);
            this.Controls.Add(this.lblJobNumber);
            this.Controls.Add(this.lblTitle);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.Name = "AssignTransportForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            ((System.ComponentModel.ISupportInitialize)(this.dgvLoads)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }
    }
}
