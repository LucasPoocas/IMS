using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace IMS
{
    public partial class ModifyProduct : Form
    {
        Inventory MainInventory;
        InventoryScreen InventoryScreen = InventoryScreen.MainScreenInstance;
        BindingList<Part> newAssociatedParts = new BindingList<Part>();
        int productIndex;

        public ModifyProduct()
        {
            InitializeComponent();
            MainInventory = InventoryScreen.inventory;
            SetupGridViews();
            PopulateTextBoxes();
        }

        private void SetupGridViews()
        {
            BindingSource Parts = new BindingSource();
            productIndex = InventoryScreen.SetProductIndexFromRow();
            Product prod = MainInventory.lookupProduct(productIndex);

            Parts.DataSource = MainInventory.AllParts;
            PartsGrid.DataSource = Parts;

            foreach (Part part in prod.AssociatedParts)
            {
                newAssociatedParts.Add(part);
            }
            BindingSource AssociatedParts = new BindingSource();
            AssociatedParts.DataSource = newAssociatedParts;
            AssociatedPartsGrid.DataSource = AssociatedParts;
        }

        void ClearErrors()
        {
            errorProviderID.Clear();
            errorProviderName.Clear();
            errorProviderInventory.Clear();
            errorProviderPrice.Clear();
            errorProviderMin.Clear();
            errorProviderMax.Clear();
        }
        
        bool ValidateData()
        {
            ClearErrors();

            //Validate ID
            if (string.IsNullOrEmpty(textBoxID.Text.Trim()))
            {
                errorProviderID.SetError(textBoxID, "ID is Required.");
                return false;
            }

            foreach (char c in textBoxID.Text.ToCharArray())
            {
                if (!Char.IsNumber(c))
                {
                    errorProviderID.SetError(textBoxID, "ID must be a number.");
                    return false;
                }
            }

            //Validate Name
            if (string.IsNullOrEmpty(textBoxName.Text.Trim()))
            {
                errorProviderName.SetError(textBoxName, "Name is Required.");
                return false;
            }

            //Validate Inventory
            if (string.IsNullOrEmpty(textBoxInventory.Text.Trim()))
            {
                errorProviderInventory.SetError(textBoxInventory, "Inventory is Required.");
                return false;
            }
            foreach (char c in textBoxInventory.Text.ToCharArray())
            {
                if (!Char.IsNumber(c))
                {
                    errorProviderInventory.SetError(textBoxInventory, "Inventory must be a number.");
                    return false;
                }
            }

            //Validate Price
            if (string.IsNullOrEmpty(textBoxPrice.Text.Trim()))
            {
                errorProviderID.SetError(textBoxPrice, "Price is Required.");
                return false;
            }
            int numDecimals = 0;
            foreach (char c in textBoxPrice.Text.ToCharArray())
            {

                if (!Char.IsNumber(c) && c != '.')
                {
                    errorProviderPrice.SetError(textBoxPrice, "Price must be a number.");
                    return false;
                }
                if (c == '.')
                {
                    numDecimals++;
                }
                if (numDecimals > 1)
                {
                    errorProviderPrice.SetError(textBoxPrice, "Price may only have 1 decimal.");
                    return false;
                }
            }


            //Validate Min/Max
            if (string.IsNullOrEmpty(textBoxMin.Text.Trim()))
            {
                errorProviderMin.SetError(textBoxMin, "Min is Required.");
                return false;
            }
            foreach (char c in textBoxMin.Text.ToCharArray())
            {
                if (!Char.IsNumber(c))
                {
                    errorProviderMin.SetError(textBoxMin, "Min must be a number.");
                    return false;
                }
            }
            if (string.IsNullOrEmpty(textBoxMax.Text.Trim()))
            {
                errorProviderMax.SetError(textBoxMax, "Max is Required.");
                return false;
            }
            foreach (char c in textBoxMax.Text.ToCharArray())
            {
                if (!Char.IsNumber(c))
                {
                    errorProviderMax.SetError(textBoxMax, "Max must be a number.");
                    return false;
                }
            }
            if (int.Parse(textBoxMin.Text) > int.Parse(textBoxMax.Text))
            {
                errorProviderMax.SetError(textBoxMax, "Min must be less than Max");
                return false;
            }

            //Validate Inventory is between Min and Max
            if (int.Parse(textBoxInventory.Text) < int.Parse(textBoxMin.Text) || int.Parse(textBoxInventory.Text) > int.Parse(textBoxMax.Text))
            {
                errorProviderInventory.SetError(textBoxInventory,
                    "Inventory must be within Min and Max.");
                return false;
            }
            return true;
        }
        
        void SaveProduct()
        {
            if (ValidateData() == true)
            {
                Product prod = MainInventory.lookupProduct(productIndex);
                for (int i = 0; i < prod.AssociatedParts.Count; i++)
                {
                    prod.removeAssociatedPart(i);
                }
                /*
                foreach (Part part in newAssociatedParts)
                {
                    prod.AssociatedParts.Add(part);
                }
                */
                
                
                int productID;
                productID = int.Parse(textBoxID.Text);
                string name = textBoxName.Text;
                decimal price;
                price = decimal.Parse(textBoxPrice.Text);
                int inventory;
                inventory = int.Parse(textBoxInventory.Text);
                int min;
                min = int.Parse(textBoxMin.Text);
                int max;
                max = int.Parse(textBoxMax.Text);
                Product product = new Product(newAssociatedParts, productID, name, price, inventory, min, max);
                MainInventory.updateProduct(productIndex, product);
                
            }
        }

        private void PopulateTextBoxes()
        {
            textBoxID.Text = MainInventory.lookupProduct(productIndex).ProductID.ToString();
            textBoxName.Text = MainInventory.lookupProduct(productIndex).Name.ToString();
            textBoxPrice.Text = MainInventory.lookupProduct(productIndex).Price.ToString();
            textBoxInventory.Text = MainInventory.lookupProduct(productIndex).InStock.ToString();
            textBoxMin.Text = MainInventory.lookupProduct(productIndex).Min.ToString();
            textBoxMax.Text = MainInventory.lookupProduct(productIndex).Max.ToString();
        }

        private void buttonCancel_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void buttonAssociatePart_Click(object sender, EventArgs e)
        {
            
                foreach (DataGridViewRow tableRow in PartsGrid.SelectedRows)
                {
                    Part part = tableRow.DataBoundItem as Part;
                    if (!newAssociatedParts.Contains(part))
                    {
                        newAssociatedParts.Add(part);
                    }
                    else if (newAssociatedParts.Contains(part))
                    {
                        MessageBox.Show("Table already contains " + part.Name + ".");
                        return;
                    }

                }
            
        }

        private void buttonDelete_Click(object sender, EventArgs e)
        {
            foreach (DataGridViewRow tableRow in AssociatedPartsGrid.SelectedRows)
            {
                Part part = tableRow.DataBoundItem as Part;
                DialogResult dialogResult = MessageBox.Show("Are you sure you wish to un-associate " + part.Name
                    , "Delete Confirmation", MessageBoxButtons.YesNo);
                if (dialogResult == DialogResult.Yes)
                {
                    AssociatedPartsGrid.Rows.Remove(tableRow);
                }
                else if (dialogResult == DialogResult.No)
                {
                    return;
                }
            }
        }

        private void buttonSave_Click(object sender, EventArgs e)
        {
            SaveProduct();
        }
    }
}
