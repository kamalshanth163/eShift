using eShift.Models;
using System;
using System.Windows.Forms;

namespace eShift.Forms.CustomerForms
{
    public partial class CustomerProfileForm : Form
    {
        private Button btnCancel;
        private Button btnUpdate;
        private Label label8;
        private Label label5;
        private Label label4;
        private Label label3;
        private Label label2;
        private TextBox txtUsername;
        private TextBox txtEmail;
        private TextBox txtPhone;
        private TextBox txtAddress;
        private TextBox txtName;
        private Label label1;
        private Label label6;
        private TextBox txtCustomerNumber;
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

        private void InitializeComponent()
        {
            this.btnCancel = new System.Windows.Forms.Button();
            this.btnUpdate = new System.Windows.Forms.Button();
            this.label8 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.txtUsername = new System.Windows.Forms.TextBox();
            this.txtEmail = new System.Windows.Forms.TextBox();
            this.txtPhone = new System.Windows.Forms.TextBox();
            this.txtAddress = new System.Windows.Forms.TextBox();
            this.txtName = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.txtCustomerNumber = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // btnCancel
            // 
            this.btnCancel.Location = new System.Drawing.Point(496, 417);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(75, 23);
            this.btnCancel.TabIndex = 33;
            this.btnCancel.Text = "Cancel";
            this.btnCancel.UseVisualStyleBackColor = true;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // btnUpdate
            // 
            this.btnUpdate.Location = new System.Drawing.Point(396, 417);
            this.btnUpdate.Name = "btnUpdate";
            this.btnUpdate.Size = new System.Drawing.Size(75, 23);
            this.btnUpdate.TabIndex = 32;
            this.btnUpdate.Text = "Update";
            this.btnUpdate.UseVisualStyleBackColor = true;
            this.btnUpdate.Click += new System.EventHandler(this.btnUpdate_Click);
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(279, 338);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(55, 13);
            this.label8.TabIndex = 31;
            this.label8.Text = "Username";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(279, 301);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(32, 13);
            this.label5.TabIndex = 28;
            this.label5.Text = "Email";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(278, 261);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(38, 13);
            this.label4.TabIndex = 27;
            this.label4.Text = "Phone";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(278, 219);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(45, 13);
            this.label3.TabIndex = 26;
            this.label3.Text = "Address";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(277, 176);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(35, 13);
            this.label2.TabIndex = 25;
            this.label2.Text = "Name";
            // 
            // txtUsername
            // 
            this.txtUsername.Location = new System.Drawing.Point(420, 331);
            this.txtUsername.Name = "txtUsername";
            this.txtUsername.Size = new System.Drawing.Size(238, 20);
            this.txtUsername.TabIndex = 22;
            // 
            // txtEmail
            // 
            this.txtEmail.Location = new System.Drawing.Point(420, 295);
            this.txtEmail.Name = "txtEmail";
            this.txtEmail.Size = new System.Drawing.Size(238, 20);
            this.txtEmail.TabIndex = 21;
            // 
            // txtPhone
            // 
            this.txtPhone.Location = new System.Drawing.Point(420, 254);
            this.txtPhone.Name = "txtPhone";
            this.txtPhone.Size = new System.Drawing.Size(238, 20);
            this.txtPhone.TabIndex = 20;
            // 
            // txtAddress
            // 
            this.txtAddress.Location = new System.Drawing.Point(420, 214);
            this.txtAddress.Multiline = true;
            this.txtAddress.Name = "txtAddress";
            this.txtAddress.Size = new System.Drawing.Size(238, 20);
            this.txtAddress.TabIndex = 19;
            // 
            // txtName
            // 
            this.txtName.Location = new System.Drawing.Point(420, 173);
            this.txtName.Name = "txtName";
            this.txtName.Size = new System.Drawing.Size(238, 20);
            this.txtName.TabIndex = 18;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(392, 50);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(141, 24);
            this.label1.TabIndex = 17;
            this.label1.Text = "Update Profile";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(277, 135);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(91, 13);
            this.label6.TabIndex = 35;
            this.label6.Text = "Customer Number";
            // 
            // txtCustomerNumber
            // 
            this.txtCustomerNumber.Location = new System.Drawing.Point(420, 132);
            this.txtCustomerNumber.Name = "txtCustomerNumber";
            this.txtCustomerNumber.ReadOnly = true;
            this.txtCustomerNumber.Size = new System.Drawing.Size(238, 20);
            this.txtCustomerNumber.TabIndex = 34;
            // 
            // CustomerProfileForm
            // 
            this.ClientSize = new System.Drawing.Size(934, 511);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.txtCustomerNumber);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.btnUpdate);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.txtUsername);
            this.Controls.Add(this.txtEmail);
            this.Controls.Add(this.txtPhone);
            this.Controls.Add(this.txtAddress);
            this.Controls.Add(this.txtName);
            this.Controls.Add(this.label1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.Name = "CustomerProfileForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.ResumeLayout(false);
            this.PerformLayout();

        }
    }
}
