using eShift.Models;
using System;
using System.Data;
using System.Windows.Forms;

namespace eShift.Forms.CustomerForms
{
    public partial class CustomerDashboard : Form
    {
        private Button btnNewJob;
        private Button btnViewLoads;
        private Label lblTitle;
        private Button btnUpdateProfile;
        private Button btnLogout;
        private DataGridView dgvJobs;
        private Label lblWelcome;
        private Customer customer;

        public CustomerDashboard(Customer customer)
        {
            InitializeComponent();
            this.customer = customer;
            lblWelcome.Text = $"Welcome, {customer.Name}";
            LoadJobs();
        }

        private void LoadJobs()
        {
            DataTable dt = Job.GetJobsByCustomer(customer.CustomerNumber);
            dgvJobs.DataSource = dt;
        }

        private void btnNewJob_Click(object sender, EventArgs e)
        {
            NewJobForm newJobForm = new NewJobForm(customer);
            newJobForm.ShowDialog();
            LoadJobs();
        }

        private void btnViewLoads_Click(object sender, EventArgs e)
        {
            if (dgvJobs.SelectedRows.Count > 0)
            {
                string jobNumber = dgvJobs.SelectedRows[0].Cells["JobNumber"].Value.ToString();
                ViewLoadsForm viewLoadsForm = new ViewLoadsForm(jobNumber);
                viewLoadsForm.ShowDialog();
            }
            else
            {
                MessageBox.Show("Please select a job first");
            }
        }

        private void btnUpdateProfile_Click(object sender, EventArgs e)
        {
            CustomerProfileForm profileForm = new CustomerProfileForm(customer);
            if (profileForm.ShowDialog() == DialogResult.OK)
            {
                customer = profileForm.UpdatedCustomer;
                lblWelcome.Text = $"Welcome, {customer.Name}";
            }
        }

        private void btnLogout_Click(object sender, EventArgs e)
        {
            MainForm mainForm = new MainForm();
            mainForm.Show();
            this.Close();
        }

        private void InitializeComponent()
        {
            this.btnNewJob = new System.Windows.Forms.Button();
            this.btnViewLoads = new System.Windows.Forms.Button();
            this.lblTitle = new System.Windows.Forms.Label();
            this.btnUpdateProfile = new System.Windows.Forms.Button();
            this.btnLogout = new System.Windows.Forms.Button();
            this.dgvJobs = new System.Windows.Forms.DataGridView();
            this.lblWelcome = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.dgvJobs)).BeginInit();
            this.SuspendLayout();
            // 
            // btnNewJob
            // 
            this.btnNewJob.Location = new System.Drawing.Point(469, 47);
            this.btnNewJob.Name = "btnNewJob";
            this.btnNewJob.Size = new System.Drawing.Size(75, 23);
            this.btnNewJob.TabIndex = 32;
            this.btnNewJob.Text = "New Job";
            this.btnNewJob.UseVisualStyleBackColor = true;
            this.btnNewJob.Click += new System.EventHandler(this.btnNewJob_Click);
            // 
            // btnViewLoads
            // 
            this.btnViewLoads.Location = new System.Drawing.Point(568, 47);
            this.btnViewLoads.Name = "btnViewLoads";
            this.btnViewLoads.Size = new System.Drawing.Size(75, 23);
            this.btnViewLoads.TabIndex = 31;
            this.btnViewLoads.Text = "View Loads";
            this.btnViewLoads.UseVisualStyleBackColor = true;
            this.btnViewLoads.Click += new System.EventHandler(this.btnViewLoads_Click);
            // 
            // lblTitle
            // 
            this.lblTitle.AutoSize = true;
            this.lblTitle.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTitle.Location = new System.Drawing.Point(61, 44);
            this.lblTitle.Name = "lblTitle";
            this.lblTitle.Size = new System.Drawing.Size(206, 24);
            this.lblTitle.TabIndex = 26;
            this.lblTitle.Text = "Customer Dashboard";
            // 
            // btnUpdateProfile
            // 
            this.btnUpdateProfile.Location = new System.Drawing.Point(667, 47);
            this.btnUpdateProfile.Name = "btnUpdateProfile";
            this.btnUpdateProfile.Size = new System.Drawing.Size(124, 23);
            this.btnUpdateProfile.TabIndex = 34;
            this.btnUpdateProfile.Text = "Update Profile";
            this.btnUpdateProfile.UseVisualStyleBackColor = true;
            this.btnUpdateProfile.Click += new System.EventHandler(this.btnUpdateProfile_Click);
            // 
            // btnLogout
            // 
            this.btnLogout.Location = new System.Drawing.Point(821, 47);
            this.btnLogout.Name = "btnLogout";
            this.btnLogout.Size = new System.Drawing.Size(75, 23);
            this.btnLogout.TabIndex = 33;
            this.btnLogout.Text = "Logout";
            this.btnLogout.UseVisualStyleBackColor = true;
            this.btnLogout.Click += new System.EventHandler(this.btnLogout_Click);
            // 
            // dgvJobs
            // 
            this.dgvJobs.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dgvJobs.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvJobs.Location = new System.Drawing.Point(93, 169);
            this.dgvJobs.Name = "dgvJobs";
            this.dgvJobs.ReadOnly = true;
            this.dgvJobs.Size = new System.Drawing.Size(750, 270);
            this.dgvJobs.TabIndex = 35;
            // 
            // lblWelcome
            // 
            this.lblWelcome.AutoSize = true;
            this.lblWelcome.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblWelcome.Location = new System.Drawing.Point(89, 112);
            this.lblWelcome.Name = "lblWelcome";
            this.lblWelcome.Size = new System.Drawing.Size(0, 24);
            this.lblWelcome.TabIndex = 36;
            // 
            // CustomerDashboard
            // 
            this.ClientSize = new System.Drawing.Size(934, 511);
            this.Controls.Add(this.lblWelcome);
            this.Controls.Add(this.dgvJobs);
            this.Controls.Add(this.btnUpdateProfile);
            this.Controls.Add(this.btnLogout);
            this.Controls.Add(this.btnNewJob);
            this.Controls.Add(this.btnViewLoads);
            this.Controls.Add(this.lblTitle);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MinimizeBox = false;
            this.Name = "CustomerDashboard";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            ((System.ComponentModel.ISupportInitialize)(this.dgvJobs)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }
    }
}
