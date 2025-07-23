using System;
using System.Data;
using System.Windows.Forms;

namespace eShift.Forms.CustomerForms
{
    public partial class ViewLoadsForm : Form
    {
        private DataGridView dgvLoads;
        private Button btnClose;
        private Label lblTitle;
        private Label lblJobNumber;
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
            DataTable dt = Models.Load.GetLoadsByJob(jobNumber);
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

        private void InitializeComponent()
        {
            this.dgvLoads = new System.Windows.Forms.DataGridView();
            this.btnClose = new System.Windows.Forms.Button();
            this.lblTitle = new System.Windows.Forms.Label();
            this.lblJobNumber = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.dgvLoads)).BeginInit();
            this.SuspendLayout();
            // 
            // dgvLoads
            // 
            this.dgvLoads.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dgvLoads.BackgroundColor = System.Drawing.SystemColors.MenuBar;
            this.dgvLoads.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvLoads.Location = new System.Drawing.Point(123, 180);
            this.dgvLoads.Name = "dgvLoads";
            this.dgvLoads.ReadOnly = true;
            this.dgvLoads.RowHeadersWidth = 51;
            this.dgvLoads.Size = new System.Drawing.Size(718, 269);
            this.dgvLoads.TabIndex = 46;
            this.dgvLoads.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvLoads_CellContentClick);
            // 
            // btnClose
            // 
            this.btnClose.BackColor = System.Drawing.Color.Black;
            this.btnClose.Font = new System.Drawing.Font("Microsoft Sans Serif", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnClose.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.btnClose.Location = new System.Drawing.Point(706, 64);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(135, 50);
            this.btnClose.TabIndex = 45;
            this.btnClose.Text = "Close";
            this.btnClose.UseVisualStyleBackColor = false;
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // lblTitle
            // 
            this.lblTitle.AutoSize = true;
            this.lblTitle.Font = new System.Drawing.Font("Microsoft Sans Serif", 24F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTitle.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.lblTitle.Location = new System.Drawing.Point(61, 43);
            this.lblTitle.Name = "lblTitle";
            this.lblTitle.Size = new System.Drawing.Size(193, 37);
            this.lblTitle.TabIndex = 44;
            this.lblTitle.Text = "View Loads";
            // 
            // lblJobNumber
            // 
            this.lblJobNumber.AutoSize = true;
            this.lblJobNumber.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblJobNumber.Location = new System.Drawing.Point(89, 104);
            this.lblJobNumber.Name = "lblJobNumber";
            this.lblJobNumber.Size = new System.Drawing.Size(0, 24);
            this.lblJobNumber.TabIndex = 47;
            // 
            // ViewLoadsForm
            // 
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(181)))), ((int)(((byte)(77)))));
            this.ClientSize = new System.Drawing.Size(934, 511);
            this.Controls.Add(this.lblJobNumber);
            this.Controls.Add(this.dgvLoads);
            this.Controls.Add(this.btnClose);
            this.Controls.Add(this.lblTitle);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.Name = "ViewLoadsForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            ((System.ComponentModel.ISupportInitialize)(this.dgvLoads)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        private void dgvLoads_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
    }
}
