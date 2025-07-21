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
        private DataGridViewTextBoxColumn AdminId;
        private DataGridViewTextBoxColumn AdminName;
        private DataGridViewTextBoxColumn Username;
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
            this.AdminId = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.AdminName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Username = new System.Windows.Forms.DataGridViewTextBoxColumn();
            ((System.ComponentModel.ISupportInitialize)(this.dgvAdmins)).BeginInit();
            this.SuspendLayout();
            // 
            // dgvAdmins
            // 
            this.dgvAdmins.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dgvAdmins.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvAdmins.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.AdminId,
            this.AdminName,
            this.Username});
            this.dgvAdmins.Location = new System.Drawing.Point(123, 138);
            this.dgvAdmins.Name = "dgvAdmins";
            this.dgvAdmins.ReadOnly = true;
            this.dgvAdmins.Size = new System.Drawing.Size(718, 316);
            this.dgvAdmins.TabIndex = 48;
            // 
            // btnClose
            // 
            this.btnClose.Location = new System.Drawing.Point(775, 60);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(75, 23);
            this.btnClose.TabIndex = 47;
            this.btnClose.Text = "Close";
            this.btnClose.UseVisualStyleBackColor = true;
            // 
            // btnAddAdmin
            // 
            this.btnAddAdmin.Location = new System.Drawing.Point(509, 60);
            this.btnAddAdmin.Name = "btnAddAdmin";
            this.btnAddAdmin.Size = new System.Drawing.Size(104, 23);
            this.btnAddAdmin.TabIndex = 46;
            this.btnAddAdmin.Text = "Add Admin";
            this.btnAddAdmin.UseVisualStyleBackColor = true;
            // 
            // btnDeleteAdmin
            // 
            this.btnDeleteAdmin.Location = new System.Drawing.Point(638, 60);
            this.btnDeleteAdmin.Name = "btnDeleteAdmin";
            this.btnDeleteAdmin.Size = new System.Drawing.Size(112, 23);
            this.btnDeleteAdmin.TabIndex = 45;
            this.btnDeleteAdmin.Text = "Delete Admin";
            this.btnDeleteAdmin.UseVisualStyleBackColor = true;
            // 
            // lblTitle
            // 
            this.lblTitle.AutoSize = true;
            this.lblTitle.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTitle.Location = new System.Drawing.Point(92, 51);
            this.lblTitle.Name = "lblTitle";
            this.lblTitle.Size = new System.Drawing.Size(161, 24);
            this.lblTitle.TabIndex = 44;
            this.lblTitle.Text = "Manage Admins";
            // 
            // AdminId
            // 
            this.AdminId.HeaderText = "Admin Id";
            this.AdminId.Name = "AdminId";
            this.AdminId.ReadOnly = true;
            // 
            // AdminName
            // 
            this.AdminName.HeaderText = "Admin Name";
            this.AdminName.Name = "AdminName";
            this.AdminName.ReadOnly = true;
            // 
            // Username
            // 
            this.Username.HeaderText = "Username";
            this.Username.Name = "Username";
            this.Username.ReadOnly = true;
            // 
            // ManageAdminsForm
            // 
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
