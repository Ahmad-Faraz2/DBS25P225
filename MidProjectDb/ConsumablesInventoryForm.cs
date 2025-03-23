using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MidProjectDb
{
    public partial class ConsumablesInventoryForm: Form
    {
        public ConsumablesInventoryForm()
        {
            InitializeComponent();
        }

        private void InventoryManagementForm_Load(object sender, EventArgs e)
        {
            
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            string itemName = dgvInventory.CurrentRow.Cells["ItemName"].Value.ToString();
            int quantity = Convert.ToInt32(txtQuantity.Text);

            string query = "UPDATE Inventory SET Quantity = @quantity WHERE ItemName = @itemName";
            // Execute query
        }
    }
}
