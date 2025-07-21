using eShift.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml.Linq;

namespace eShift.Forms.AdminForms
{
    public partial class AddProductForm : Form
    {
        public AddProductForm()
        {
            InitializeComponent();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (ValidateProduct())
            {
                Product product = new Product(
                    txtName.Text.Trim(),
                    txtDescription.Text.Trim(),
                    decimal.Parse(txtHandlingFee.Text)
                );

                if (product.AddProduct())
                {
                    MessageBox.Show("Product added successfully");
                    this.DialogResult = DialogResult.OK;
                    this.Close();
                }
                else
                {
                    MessageBox.Show("Failed to add product");
                }
            }
        }

        private bool ValidateProduct()
        {
            if (string.IsNullOrEmpty(txtName.Text))
            {
                MessageBox.Show("Please enter product name");
                return false;
            }

            if (string.IsNullOrEmpty(txtHandlingFee.Text) || !decimal.TryParse(txtHandlingFee.Text, out _))
            {
                MessageBox.Show("Please enter a valid handling fee");
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
