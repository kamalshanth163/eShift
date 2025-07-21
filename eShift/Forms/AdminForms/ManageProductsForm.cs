using eShift.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace eShift.Forms.AdminForms
{
    public partial class ManageProductsForm : Form
    {
        public ManageProductsForm()
        {
            InitializeComponent();
            LoadProducts();
        }

        private void LoadProducts()
        {
            DataTable dt = Product.GetAllProducts();
            dgvProducts.DataSource = dt;
        }

        private void btnAddProduct_Click(object sender, EventArgs e)
        {
            AddProductForm addProductForm = new AddProductForm();
            if (addProductForm.ShowDialog() == DialogResult.OK)
            {
                LoadProducts();
            }
        }

        private void btnDeleteProduct_Click(object sender, EventArgs e)
        {
            if (dgvProducts.SelectedRows.Count > 0)
            {
                string productCode = dgvProducts.SelectedRows[0].Cells["ProductCode"].Value.ToString();

                if (MessageBox.Show("Are you sure you want to delete this product?", "Confirm Delete", MessageBoxButtons.YesNo) == DialogResult.Yes)
                {
                    if (Product.DeleteProduct(productCode))
                    {
                        MessageBox.Show("Product deleted successfully");
                        LoadProducts();
                    }
                    else
                    {
                        MessageBox.Show("Failed to delete product");
                    }
                }
            }
            else
            {
                MessageBox.Show("Please select a product to delete");
            }
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
