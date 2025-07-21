using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml.Linq;

namespace eShift.Forms.Customer
{
    public partial class CustomerProfileForm : Form
    {
        private Customer customer;
        public Customer UpdatedCustomer { get; private set; }

        public CustomerProfileForm(Customer customer)
        {
            InitializeComponent();
            this.customer = customer;
            LoadCustomerData();
        }

        private void LoadCustomerData()
        {
            txtCustomerNumber.Text = customer.CustomerNumber;
            txtName.Text = customer.Name;
            txtAddress.Text = customer.Address;
            txtPhone.Text = customer.Phone;
            txtEmail.Text = customer.Email;
            txtUsername.Text = customer.Username;
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            if (ValidateProfile())
            {
                customer.Name = txtName.Text.Trim();
                customer.Address = txtAddress.Text.Trim();
                customer.Phone = txtPhone.Text.Trim();
                customer.Email = txtEmail.Text.Trim();

                if (customer.UpdateProfile())
                {
                    UpdatedCustomer = customer;
                    MessageBox.Show("Profile updated successfully");
                    this.DialogResult = DialogResult.OK;
                    this.Close();
                }
                else
                {
                    MessageBox.Show("Failed to update profile. Please try again.");
                }
            }
        }

        private bool ValidateProfile()
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

            return true;
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
            this.Close();
        }
    }
}
