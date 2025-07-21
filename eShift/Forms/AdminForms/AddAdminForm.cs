using eShift.Models;
using eShift.Utilities;
using System;
using System.Windows.Forms;

namespace eShift.Forms.AdminForms
{
    public partial class AddAdminForm : Form
    {
        private Button btnCancel;
        private Button btnSave;
        private Label label8;
        private Label label2;
        private TextBox txtUsername;
        private TextBox txtName;
        private Label label6;
        private TextBox txtPassword;
        private Label label1;

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

        private void InitializeComponent()
        {
            this.btnCancel = new System.Windows.Forms.Button();
            this.btnSave = new System.Windows.Forms.Button();
            this.label8 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.txtUsername = new System.Windows.Forms.TextBox();
            this.txtName = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.txtPassword = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // btnCancel
            // 
            this.btnCancel.Location = new System.Drawing.Point(496, 388);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(75, 23);
            this.btnCancel.TabIndex = 48;
            this.btnCancel.Text = "Cancel";
            this.btnCancel.UseVisualStyleBackColor = true;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // btnSave
            // 
            this.btnSave.Location = new System.Drawing.Point(396, 388);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(75, 23);
            this.btnSave.TabIndex = 47;
            this.btnSave.Text = "Save";
            this.btnSave.UseVisualStyleBackColor = true;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(279, 234);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(55, 13);
            this.label8.TabIndex = 46;
            this.label8.Text = "Username";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(277, 186);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(35, 13);
            this.label2.TabIndex = 42;
            this.label2.Text = "Name";
            // 
            // txtUsername
            // 
            this.txtUsername.Location = new System.Drawing.Point(420, 227);
            this.txtUsername.Name = "txtUsername";
            this.txtUsername.Size = new System.Drawing.Size(238, 20);
            this.txtUsername.TabIndex = 41;
            // 
            // txtName
            // 
            this.txtName.Location = new System.Drawing.Point(420, 183);
            this.txtName.Name = "txtName";
            this.txtName.Size = new System.Drawing.Size(238, 20);
            this.txtName.TabIndex = 37;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(392, 60);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(162, 24);
            this.label1.TabIndex = 36;
            this.label1.Text = "Add New Admin";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(281, 275);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(53, 13);
            this.label6.TabIndex = 50;
            this.label6.Text = "Password";
            // 
            // txtPassword
            // 
            this.txtPassword.Location = new System.Drawing.Point(420, 270);
            this.txtPassword.Name = "txtPassword";
            this.txtPassword.PasswordChar = '*';
            this.txtPassword.Size = new System.Drawing.Size(238, 20);
            this.txtPassword.TabIndex = 49;
            // 
            // AddAdminForm
            // 
            this.ClientSize = new System.Drawing.Size(934, 511);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.txtPassword);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.btnSave);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.txtUsername);
            this.Controls.Add(this.txtName);
            this.Controls.Add(this.label1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.Name = "AddAdminForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.ResumeLayout(false);
            this.PerformLayout();

        }
    }
}
