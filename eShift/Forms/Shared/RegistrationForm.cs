using eShift.Utilities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml.Linq;

namespace eShift.Forms.Shared
{
    public partial class RegistrationForm : Form
    {
        public RegistrationForm()
        {
            InitializeComponent();
        }

        private void btnRegister_Click(object sender, EventArgs e)
        {
            if (ValidateRegistration())
            {
                Customer customer = new Customer(
                    txtName.Text.Trim(),
                    txtAddress.Text.Trim(),
                    txtPhone.Text.Trim(),
                    txtEmail.Text.Trim(),
                    txtUsername.Text.Trim(),
                    txtPassword.Text.Trim()
                );

                if (customer.Register())
                {
                    MessageBox.Show("Registration successful! Your customer number is: " + customer.CustomerNumber);
                    this.DialogResult = DialogResult.OK;
                    this.Close();
                }
                else
                {
                    MessageBox.Show("Registration failed. Please try again.");
                }
            }
        }

        private bool ValidateRegistration()
        {
            if (string.IsNullOrEmpty(txtName.Text))
            {
                MessageBox.Show("Please enter your name");
                return false;
            }

            if (string.IsNullOrEmpty(txtAddress.Text))
            {
                MessageBox.Show("Please enter your address");
                return false;
            }

            if (string.IsNullOrEmpty(txtPhone.Text))
            {
                MessageBox.Show("Please enter your phone number");
                return false;
            }

            if (string.IsNullOrEmpty(txtEmail.Text))
            {
                MessageBox.Show("Please enter your email");
                return false;
            }

            if (string.IsNullOrEmpty(txtUsername.Text))
            {
                MessageBox.Show("Please enter a username");
                return false;
            }

            if (string.IsNullOrEmpty(txtPassword.Text))
            {
                MessageBox.Show("Please enter a password");
                return false;
            }

            if (txtPassword.Text != txtConfirmPassword.Text)
            {
                MessageBox.Show("Passwords do not match");
                return false;
            }

            // Check if username already exists
            string query = $"SELECT COUNT(*) FROM Customers WHERE Username = '{txtUsername.Text.Trim()}'";
            int count = Convert.ToInt32(DatabaseHelper.ExecuteScalar(query));
            if (count > 0)
            {
                MessageBox.Show("Username already exists. Please choose another one.");
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
            this.SuspendLayout();
            // 
            // RegistrationForm
            // 
            this.ClientSize = new System.Drawing.Size(988, 503);
            this.Name = "RegistrationForm";
            this.ResumeLayout(false);

        }
    }
}
