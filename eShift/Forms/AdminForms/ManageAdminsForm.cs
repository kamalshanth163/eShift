using eShift.Models;
using System;
using System.Data;
using System.Windows.Forms;

namespace eShift.Forms.AdminForms
{
    public partial class ManageAdminsForm : Form
    {
        private DataGridView dgvAdmins;
        private Button btnClose;
        private Button btnAddAdmin;
        private Button btnDeleteAdmin;
        private Label lblTitle;

        public ManageAdminsForm()
        {
            InitializeComponent();
            LoadAdmins();
        }

        private void LoadAdmins()
        {
            DataTable dt = Admin.GetAllAdmins();
            dgvAdmins.DataSource = dt;
        }

        private void btnAddAdmin_Click(object sender, EventArgs e)
        {
            AddAdminForm addAdminForm = new AddAdminForm();
            if (addAdminForm.ShowDialog() == DialogResult.OK)
            {
                LoadAdmins();
            }
        }

        private void btnDeleteAdmin_Click(object sender, EventArgs e)
        {
            if (dgvAdmins.SelectedRows.Count > 0)
            {
                string adminId = dgvAdmins.SelectedRows[0].Cells["AdminId"].Value.ToString();

                if (MessageBox.Show("Are you sure you want to delete this admin?", "Confirm Delete", MessageBoxButtons.YesNo) == DialogResult.Yes)
                {
                    if (Admin.DeleteAdmin(adminId))
                    {
                        MessageBox.Show("Admin deleted successfully");
                        LoadAdmins();
                    }
                    else
                    {
                        MessageBox.Show("Failed to delete admin");
                    }
                }
            }
            else
            {
                MessageBox.Show("Please select an admin to delete");
            }
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void InitializeComponent()
        {
            this.dgvAdmins = new System.Windows.Forms.DataGridView();
            this.btnClose = new System.Windows.Forms.Button();
            this.btnAddAdmin = new System.Windows.Forms.Button();
            this.btnDeleteAdmin = new System.Windows.Forms.Button();
            this.lblTitle = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.dgvAdmins)).BeginInit();
            this.SuspendLayout();
            // 
            // dgvAdmins
            // 
            this.dgvAdmins.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dgvAdmins.BackgroundColor = System.Drawing.SystemColors.MenuBar;
            this.dgvAdmins.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvAdmins.Location = new System.Drawing.Point(100, 184);
            this.dgvAdmins.Name = "dgvAdmins";
            this.dgvAdmins.ReadOnly = true;
            this.dgvAdmins.RowHeadersWidth = 51;
            this.dgvAdmins.Size = new System.Drawing.Size(718, 280);
            this.dgvAdmins.TabIndex = 48;
            // 
            // btnClose
            // 
            this.btnClose.BackColor = System.Drawing.Color.Black;
            this.btnClose.Font = new System.Drawing.Font("Microsoft Sans Serif", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnClose.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.btnClose.Location = new System.Drawing.Point(534, 116);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(135, 46);
            this.btnClose.TabIndex = 47;
            this.btnClose.Text = "Close";
            this.btnClose.UseVisualStyleBackColor = false;
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // btnAddAdmin
            // 
            this.btnAddAdmin.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(199)))), ((int)(((byte)(111)))), ((int)(((byte)(28)))));
            this.btnAddAdmin.Font = new System.Drawing.Font("Microsoft Sans Serif", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnAddAdmin.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.btnAddAdmin.Location = new System.Drawing.Point(100, 116);
            this.btnAddAdmin.Name = "btnAddAdmin";
            this.btnAddAdmin.Size = new System.Drawing.Size(170, 46);
            this.btnAddAdmin.TabIndex = 46;
            this.btnAddAdmin.Text = "Add Admin";
            this.btnAddAdmin.UseVisualStyleBackColor = false;
            this.btnAddAdmin.Click += new System.EventHandler(this.btnAddAdmin_Click);
            // 
            // btnDeleteAdmin
            // 
            this.btnDeleteAdmin.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(221)))), ((int)(((byte)(17)))), ((int)(((byte)(27)))));
            this.btnDeleteAdmin.Font = new System.Drawing.Font("Microsoft Sans Serif", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnDeleteAdmin.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.btnDeleteAdmin.Location = new System.Drawing.Point(300, 116);
            this.btnDeleteAdmin.Name = "btnDeleteAdmin";
            this.btnDeleteAdmin.Size = new System.Drawing.Size(206, 46);
            this.btnDeleteAdmin.TabIndex = 45;
            this.btnDeleteAdmin.Text = "Delete Admin";
            this.btnDeleteAdmin.UseVisualStyleBackColor = false;
            this.btnDeleteAdmin.Click += new System.EventHandler(this.btnDeleteAdmin_Click);
            // 
            // lblTitle
            // 
            this.lblTitle.AutoSize = true;
            this.lblTitle.Font = new System.Drawing.Font("Microsoft Sans Serif", 24F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTitle.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.lblTitle.Location = new System.Drawing.Point(92, 51);
            this.lblTitle.Name = "lblTitle";
            this.lblTitle.Size = new System.Drawing.Size(320, 46);
            this.lblTitle.TabIndex = 44;
            this.lblTitle.Text = "Manage Admins";
            // 
            // ManageAdminsForm
            // 
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(181)))), ((int)(((byte)(77)))));
            this.ClientSize = new System.Drawing.Size(934, 511);
            this.Controls.Add(this.dgvAdmins);
            this.Controls.Add(this.btnClose);
            this.Controls.Add(this.btnAddAdmin);
            this.Controls.Add(this.btnDeleteAdmin);
            this.Controls.Add(this.lblTitle);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MinimizeBox = false;
            this.Name = "ManageAdminsForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            ((System.ComponentModel.ISupportInitialize)(this.dgvAdmins)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }
    }
}
