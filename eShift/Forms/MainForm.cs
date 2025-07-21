using eShift.Forms.Admin;
using eShift.Forms.Customer;
using eShift.Forms.Shared;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace eShift.Forms
{
    public partial class MainForm : Form
    {
        public MainForm()
        {
            InitializeComponent();
        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            string username = txtUsername.Text.Trim();
            string password = txtPassword.Text.Trim();
            string userType = cmbUserType.SelectedItem.ToString();

            if (string.IsNullOrEmpty(username) || string.IsNullOrEmpty(password))
            {
                MessageBox.Show("Please enter username and password");
                return;
            }

            if (userType == "Customer")
            {
                Customer customer = Customer.Login(username, password);
                if (customer != null)
                {
                    CustomerDashboard customerDashboard = new CustomerDashboard(customer);
                    customerDashboard.Show();
                    this.Hide();
                }
                else
                {
                    MessageBox.Show("Invalid username or password");
                }
            }
            else if (userType == "Admin")
            {
                Admin admin = Admin.Login(username, password);
                if (admin != null)
                {
                    AdminDashboard adminDashboard = new AdminDashboard(admin);
                    adminDashboard.Show();
                    this.Hide();
                }
                else
                {
                    MessageBox.Show("Invalid username or password");
                }
            }
        }

        private void btnRegister_Click(object sender, EventArgs e)
        {
            RegistrationForm registrationForm = new RegistrationForm();
            registrationForm.ShowDialog();
        }

        private void MainForm_Load(object sender, EventArgs e)
        {
            cmbUserType.SelectedIndex = 0;
        }
    }
}
