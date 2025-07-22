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
            ((System.ComponentModel.ISupportInitialize)(this.dgvLoads)).BeginInit();
            this.SuspendLayout();
            // 
            // btnClose
            // 
            this.btnClose.BackColor = System.Drawing.Color.Black;
            this.btnClose.Font = new System.Drawing.Font("Microsoft Sans Serif", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnClose.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.btnClose.Location = new System.Drawing.Point(510, 428);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(115, 53);
            this.btnClose.TabIndex = 65;
            this.btnClose.Text = "Close";
            this.btnClose.UseVisualStyleBackColor = false;
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // btnAssign
            // 
            this.btnAssign.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(199)))), ((int)(((byte)(111)))), ((int)(((byte)(28)))));
            this.btnAssign.Font = new System.Drawing.Font("Microsoft Sans Serif", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnAssign.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.btnAssign.Location = new System.Drawing.Point(334, 428);
            this.btnAssign.Name = "btnAssign";
            this.btnAssign.Size = new System.Drawing.Size(129, 53);
            this.btnAssign.TabIndex = 64;
            this.btnAssign.Text = "Assign";
            this.btnAssign.UseVisualStyleBackColor = false;
            this.btnAssign.Click += new System.EventHandler(this.btnAssign_Click);
            // 
            // lblJobNumber
            // 
            this.lblJobNumber.AutoSize = true;
            this.lblJobNumber.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblJobNumber.Location = new System.Drawing.Point(769, 94);
            this.lblJobNumber.Name = "lblJobNumber";
            this.lblJobNumber.Size = new System.Drawing.Size(0, 29);
            this.lblJobNumber.TabIndex = 62;
            // 
            // lblTitle
            // 
            this.lblTitle.AutoSize = true;
            this.lblTitle.Font = new System.Drawing.Font("Microsoft Sans Serif", 24F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTitle.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.lblTitle.Location = new System.Drawing.Point(97, 75);
            this.lblTitle.Name = "lblTitle";
            this.lblTitle.Size = new System.Drawing.Size(424, 46);
            this.lblTitle.TabIndex = 60;
            this.lblTitle.Text = "Assign Transport Unit";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.label1.Location = new System.Drawing.Point(114, 160);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(219, 36);
            this.label1.TabIndex = 68;
            this.label1.Text = "Transport Unit";
            // 
            // cmbTransportUnit
            // 
            this.cmbTransportUnit.FormattingEnabled = true;
            this.cmbTransportUnit.Items.AddRange(new object[] {
            "[\"Customer\", \"Admin\"]"});
            this.cmbTransportUnit.Location = new System.Drawing.Point(353, 172);
            this.cmbTransportUnit.Name = "cmbTransportUnit";
            this.cmbTransportUnit.Size = new System.Drawing.Size(238, 24);
            this.cmbTransportUnit.TabIndex = 67;
            // 
            // dgvLoads
            // 
            this.dgvLoads.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dgvLoads.BackgroundColor = System.Drawing.SystemColors.MenuBar;
            this.dgvLoads.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvLoads.Location = new System.Drawing.Point(120, 206);
            this.dgvLoads.Name = "dgvLoads";
            this.dgvLoads.ReadOnly = true;
            this.dgvLoads.RowHeadersWidth = 51;
            this.dgvLoads.Size = new System.Drawing.Size(718, 198);
            this.dgvLoads.TabIndex = 69;
            // 
            // AssignTransportForm
            // 
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(181)))), ((int)(((byte)(77)))));
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
