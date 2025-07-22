using eShift.Models;
using System;
using System.Windows.Forms;

namespace eShift.Forms.AdminForms
{
    public partial class ProcessJobForm : Form
    {
        private Button btnCancel;
        private Button btnAccept;
        private Button btnDecline;
        private Label lblJobNumber;
        private Label label6;
        private Label lblTitle;
        private RichTextBox txtRemarks;
        private string jobNumber;

        public ProcessJobForm(string jobNumber)
        {
            InitializeComponent();
            this.jobNumber = jobNumber;
            lblJobNumber.Text = "Job Number: " + jobNumber;
        }

        private void btnAccept_Click(object sender, EventArgs e)
        {
            if (Job.UpdateJobStatus(jobNumber, "Accepted", txtRemarks.Text))
            {
                MessageBox.Show("Job accepted successfully");
                this.DialogResult = DialogResult.OK;
                this.Close();
            }
            else
            {
                MessageBox.Show("Failed to accept job");
            }
        }

        private void btnDecline_Click(object sender, EventArgs e)
        {
            if (Job.UpdateJobStatus(jobNumber, "Declined", txtRemarks.Text))
            {
                MessageBox.Show("Job declined successfully");
                this.DialogResult = DialogResult.OK;
                this.Close();
            }
            else
            {
                MessageBox.Show("Failed to decline job");
            }
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
            this.Close();
        }

        private void InitializeComponent()
        {
            this.btnCancel = new System.Windows.Forms.Button();
            this.btnAccept = new System.Windows.Forms.Button();
            this.btnDecline = new System.Windows.Forms.Button();
            this.lblJobNumber = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.lblTitle = new System.Windows.Forms.Label();
            this.txtRemarks = new System.Windows.Forms.RichTextBox();
            this.SuspendLayout();
            // 
            // btnCancel
            // 
            this.btnCancel.BackColor = System.Drawing.Color.Black;
            this.btnCancel.Font = new System.Drawing.Font("Microsoft Sans Serif", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnCancel.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.btnCancel.Location = new System.Drawing.Point(561, 340);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(135, 50);
            this.btnCancel.TabIndex = 58;
            this.btnCancel.Text = "Cancel";
            this.btnCancel.UseVisualStyleBackColor = false;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // btnAccept
            // 
            this.btnAccept.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(13)))), ((int)(((byte)(84)))), ((int)(((byte)(2)))));
            this.btnAccept.Font = new System.Drawing.Font("Microsoft Sans Serif", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnAccept.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.btnAccept.Location = new System.Drawing.Point(241, 340);
            this.btnAccept.Name = "btnAccept";
            this.btnAccept.Size = new System.Drawing.Size(135, 50);
            this.btnAccept.TabIndex = 49;
            this.btnAccept.Text = "Accept";
            this.btnAccept.UseVisualStyleBackColor = false;
            this.btnAccept.Click += new System.EventHandler(this.btnAccept_Click);
            // 
            // btnDecline
            // 
            this.btnDecline.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(221)))), ((int)(((byte)(17)))), ((int)(((byte)(27)))));
            this.btnDecline.Font = new System.Drawing.Font("Microsoft Sans Serif", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnDecline.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.btnDecline.Location = new System.Drawing.Point(399, 340);
            this.btnDecline.Name = "btnDecline";
            this.btnDecline.Size = new System.Drawing.Size(135, 50);
            this.btnDecline.TabIndex = 48;
            this.btnDecline.Text = "Decline";
            this.btnDecline.UseVisualStyleBackColor = false;
            this.btnDecline.Click += new System.EventHandler(this.btnDecline_Click);
            // 
            // lblJobNumber
            // 
            this.lblJobNumber.AutoSize = true;
            this.lblJobNumber.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblJobNumber.Location = new System.Drawing.Point(456, 116);
            this.lblJobNumber.Name = "lblJobNumber";
            this.lblJobNumber.Size = new System.Drawing.Size(0, 29);
            this.lblJobNumber.TabIndex = 47;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.label6.Location = new System.Drawing.Point(235, 163);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(139, 36);
            this.label6.TabIndex = 46;
            this.label6.Text = "Remarks";
            // 
            // lblTitle
            // 
            this.lblTitle.AutoSize = true;
            this.lblTitle.Font = new System.Drawing.Font("Microsoft Sans Serif", 24F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTitle.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.lblTitle.Location = new System.Drawing.Point(188, 65);
            this.lblTitle.Name = "lblTitle";
            this.lblTitle.Size = new System.Drawing.Size(253, 46);
            this.lblTitle.TabIndex = 43;
            this.lblTitle.Text = "Process Job";
            // 
            // txtRemarks
            // 
            this.txtRemarks.BackColor = System.Drawing.SystemColors.MenuBar;
            this.txtRemarks.Location = new System.Drawing.Point(241, 202);
            this.txtRemarks.Name = "txtRemarks";
            this.txtRemarks.Size = new System.Drawing.Size(455, 96);
            this.txtRemarks.TabIndex = 59;
            this.txtRemarks.Text = "";
            // 
            // ProcessJobForm
            // 
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(181)))), ((int)(((byte)(77)))));
            this.ClientSize = new System.Drawing.Size(934, 511);
            this.Controls.Add(this.txtRemarks);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.btnAccept);
            this.Controls.Add(this.btnDecline);
            this.Controls.Add(this.lblJobNumber);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.lblTitle);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.Name = "ProcessJobForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.ResumeLayout(false);
            this.PerformLayout();

        }
    }
}
