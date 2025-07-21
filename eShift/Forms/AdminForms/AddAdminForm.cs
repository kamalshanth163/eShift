using eShift.Utilities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml.Linq;

namespace eShift.Forms.AdminForms
{
    public partial class AddAdminForm : Form
    {
        public AddAdminForm()
        {
            InitializeComponent();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (ValidateAdmin())
            {
                Admin admin = new Admin(
                    txtName.Text.Trim(),
                    txtUsername.Text.Trim(),
                    txtPassword.Text.Trim()
                );

                if (admin.AddAdmin())
                {
                    MessageBox.Show("Admin added successfully");
                    this.DialogResult = DialogResult.OK;
                    this.Close();
                }
                else
                {
                    MessageBox.Show("Failed to add admin");
                }
            }
        }

        private bool ValidateAdmin()
        {
            if (string.IsNullOrEmpty(txtName.Text))
            {
                MessageBox.Show("Please enter admin name");
                return false;
            }

            if (string.IsNullOrEmpty(txtUsername.Text))
            {
                MessageBox.Show("Please enter username");
                return false;
            }

            if (string.IsNullOrEmpty(txtPassword.Text))
            {
                MessageBox.Show("Please enter password");
                return false;
            }

            // Check if username exists
            string query = $"SELECT COUNT(*) FROM Admins WHERE Username = '{txtUsername.Text.Trim()}'";
            int count = Convert.ToInt32(DatabaseHelper.ExecuteScalar(query));
            if (count > 0)
            {
                MessageBox.Show("Username already exists");
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
