using IMS;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace IMS
{
    public partial class InventoryScreen : Form
    {

        public static InventoryScreen MainScreenInstance;
        static BindingList<Part> AllParts = new BindingList<Part>();
        static BindingList<Product> AllProducts = new BindingList<Product>();
        BindingSource PartSource = new BindingSource();
        BindingSource ProductSource = new BindingSource();
        public static Inventory inventory;


        public InventoryScreen()
        {
            InitializeComponent();
            MainScreenInstance = this;
            inventory = new Inventory(AllProducts, AllParts);
            SetupDataGridView();
            //PartSource = new BindingSource(AllParts, null);
            //ProductSource = new BindingSource(AllProducts, null);

        }

        private void Form1_Load(object sender, EventArgs e)
        {
            InstantiateSampleData();
            SetupDataGridView();
            ClearSelections();
        }

        void InstantiateSampleData()
        {
            Inhouse wheel = new Inhouse(0, "Wheel", 3.22M, 12, 2, 20, 221);
            Inhouse handleBar = new Inhouse(1, "Handle Bar", 13.22M, 8, 2, 20, 221);
            Outsourced seat = new Outsourced(2, "Seat", 5.44M, 6, 1, 25, "Bike Supply Co.");
            Outsourced bell = new Outsourced(3, "Bell", 3.44M, 4, 2, 30, "Novelty Bike Parts");
            BindingList<Part> purpleBikeParts = new BindingList<Part>();
            purpleBikeParts.Add(wheel);
            BindingList<Part> blueBikeParts = new BindingList<Part>();
            Product purpleBike = new Product(purpleBikeParts, 0, "Purple Bike", 56.77M, 13, 1, 20);
            Product blueBike = new Product(blueBikeParts, 1, "Blue Bike", 43.66M, 12, 1, 20);
            inventory.addPart(wheel);
            inventory.addPart(handleBar);
            inventory.addPart(seat);
            inventory.addPart(bell);
            inventory.addProduct(purpleBike);
            inventory.addProduct(blueBike);
        }

        void SetupDataGridView()
        {
            PartSource.DataSource = inventory.AllParts;
            ProductSource.DataSource = inventory.Products;
            PartsTable.DataSource = PartSource;
            ProductsTable.DataSource = ProductSource;
        }

        public int SetPartIndexFromRow()
        {
            return PartsTable.CurrentCell.RowIndex;
        }

        public int SetProductIndexFromRow()
        {
            return ProductsTable.CurrentCell.RowIndex;
        }

        private void ClearSelections()
        {
            for (int i = 0; i < PartsTable.RowCount; i++)
            {
                PartsTable.Rows[i].Selected = false;
            }
            for (int i = 0; i < ProductsTable.RowCount; i++)
            {
                ProductsTable.Rows[i].Selected = false;
            }
        }

        private void buttonModifyPart_Click(object sender, EventArgs e)
        {
            if (PartsTable.SelectedRows.Count > 1)
            {
                MessageBox.Show("Cannot Modify multiple parts at a time.");
                return;
            }
            if (PartsTable.SelectedRows.Count < 1)
            {
                MessageBox.Show("You must select a part to modify.");
                return;
            }
            ModifyPart ModifyParts = new ModifyPart();
            ModifyParts.Show();
        }

        private void buttonExit_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void buttonAddPart_Click(object sender, EventArgs e)
        {
            AddPart AddParts = new AddPart();
            AddParts.Show();
        }

        private void buttonAddProduct_Click(object sender, EventArgs e)
        {
            AddProduct AddProducts = new AddProduct();
            AddProducts.Show();
        }

        private void buttonModifyProduct_Click(object sender, EventArgs e)
        {
            if (ProductsTable.SelectedRows.Count > 1)
            {
                MessageBox.Show("Cannot Modify multiple products at a time.");
                return;
            }
            if (ProductsTable.SelectedRows.Count < 1)
            {
                MessageBox.Show("You must select a product to modify.");
                return;
            }
            ModifyProduct ModifyProducts = new ModifyProduct();
            ModifyProducts.Show();
        }

        private void buttonDeletePart_Click(object sender, EventArgs e)
        {
            //condition of part associated with product
            foreach (DataGridViewRow tableRow in PartsTable.SelectedRows)
            {
                foreach (Product product in inventory.Products)
                {
                    if (product.AssociatedParts.Contains(inventory.lookupPart(tableRow.Index)))
                    {
                        MessageBox.Show($"Cannot delete {inventory.lookupPart(tableRow.Index).Name}, " +
                            $"as it is associated with {product.Name}");
                        return;
                    }
                }
                //inventory.lookupPart(tableRow.Index).Name;
                DialogResult dialogResult = MessageBox.Show("Are you sure you wish to delete " + inventory.lookupPart(tableRow.Index).Name
                    , "Delete Confirmation", MessageBoxButtons.YesNo);
                if (dialogResult == DialogResult.Yes)
                {
                    PartsTable.Rows.Remove(tableRow);
                }
                else if (dialogResult == DialogResult.No)
                {
                    return;
                }
                
                
            }


        }

        private void buttonDeleteProduct_Click(object sender, EventArgs e)
        {
            foreach (DataGridViewRow tableRow in ProductsTable.SelectedRows)
            {
                DialogResult dialogResult = MessageBox.Show("Are you sure you wish to delete " + inventory.lookupProduct(tableRow.Index).Name
                    , "Delete Confirmation", MessageBoxButtons.YesNo);
                if (dialogResult == DialogResult.Yes)
                {
                    ProductsTable.Rows.Remove(tableRow);
                }
                else if (dialogResult == DialogResult.No)
                {
                    return;
                }


            }
        }

        private void buttonSearchParts_Click(object sender, EventArgs e)
        {
            for (int i = 0; i < PartsTable.RowCount; i++)
            {
                PartsTable.Rows[i].Selected = false;
            }
            for (int i = 0; i < PartsTable.RowCount; i++)
            {
                if (inventory.lookupPart(i).Name.ToLower().Contains(textBoxSearchParts.Text.ToLower()))
                {
                    PartsTable.Rows[i].Selected = true;
                }
            }
        }

        private void buttonSearchProducts_Click(object sender, EventArgs e)
        {
            for (int i = 0; i < ProductsTable.RowCount; i++)
            {
                ProductsTable.Rows[i].Selected = false;
            }
            for (int i = 0; i < ProductsTable.RowCount; i++)
            {
                if (inventory.lookupProduct(i).Name.ToLower().Contains(textBoxSearchProducts.Text.ToLower()))
                {
                    ProductsTable.Rows[i].Selected = true;
                }
            }
        }
    }
}
