using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace eShift.Forms.Admin
{
    public partial class ManageAdminsForm : Form
    {
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
    }
}
