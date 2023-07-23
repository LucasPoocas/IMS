using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.Button;

namespace IMS
{
    public partial class ModifyPart : Form
    {
        bool isInhouse = true;
        bool isOutsourced = false;
        Inventory MainInventory;
        InventoryScreen InventoryScreen = InventoryScreen.MainScreenInstance;
        int partIndex;

        public ModifyPart()
        {
            partIndex = InventoryScreen.SetPartIndexFromRow();
            MainInventory = InventoryScreen.inventory;
            InitializeComponent();
        }

        void ClearErrors()
        {
            errorProviderID.Clear();
            errorProviderName.Clear();
            errorProviderInventory.Clear();
            errorProviderPrice.Clear();
            errorProviderMin.Clear();
            errorProviderMax.Clear();
            errorProviderMachineID.Clear();
            errorProviderCompanyName.Clear();
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

            //Validate Machine ID
            if (isInhouse)
            {

                if (string.IsNullOrEmpty(textBoxMachine.Text))
                {
                    errorProviderMachineID.SetError(textBoxMachine, "Machine ID is Required.");
                    return false;
                }


                foreach (char c in textBoxMachine.Text.ToCharArray())
                {
                    if (!Char.IsNumber(c))
                    {
                        errorProviderMachineID.SetError(textBoxMachine, "Machine ID must be a number.");
                        return false;
                    }
                }

            }

            else if (isOutsourced)
            {
                if (string.IsNullOrEmpty(textBoxMachine.Text))
                {
                    errorProviderCompanyName.SetError(textBoxMachine, "Company Name is Required.");
                    return false;
                }
            }

            return true;
        }

        private void SavePart()
        {
            if (ValidateData() == false)
            {
                MessageBox.Show("All Fields Must Be Valid.");
                return;
            }
            int partID;
            partID = int.Parse(textBoxID.Text);
            string name = textBoxName.Text;
            decimal price;
            price = decimal.Parse(textBoxPrice.Text);
            int inventory;
            inventory = int.Parse(textBoxInventory.Text);
            int min;
            min = int.Parse(textBoxMin.Text);
            int max;
            max = int.Parse(textBoxMax.Text);

            if (isInhouse)
            {
                int machineID;
                machineID = int.Parse(textBoxMachine.Text);
                Inhouse inhouse = new Inhouse(partID, name, price, inventory, min, max, machineID);
                MessageBox.Show("In-House Part Updated:\n" + inhouse.ToString());
                MainInventory.updatePart(partIndex, inhouse);
                Close();
            }
            else if (isOutsourced)
            {
                string companyName;
                companyName = textBoxMachine.Text;
                Outsourced outsourced = new Outsourced(partID, name, price, inventory, min,
                    max, companyName);
                MessageBox.Show("Outsourced Part Updated:\n" + outsourced.ToString());
                MainInventory.updatePart(partIndex, outsourced);
                Close();
            }
        }

        private void PopulateTextBoxes()
        {
            textBoxID.Text = MainInventory.lookupPart(partIndex).PartID.ToString();
            textBoxName.Text = MainInventory.lookupPart(partIndex).Name.ToString();
            textBoxPrice.Text = MainInventory.lookupPart(partIndex).Price.ToString();
            textBoxInventory.Text = MainInventory.lookupPart(partIndex).InStock.ToString();
            textBoxMin.Text = MainInventory.lookupPart(partIndex).Min.ToString();
            textBoxMax.Text = MainInventory.lookupPart(partIndex).Max.ToString();
            if(MainInventory.lookupPart(partIndex) is Inhouse)
            {
                Inhouse selectedPart = (Inhouse)MainInventory.lookupPart(partIndex);
                isInhouse = true;
                radioButton1.Checked = true;
                textBoxMachine.Text = selectedPart.MachineID.ToString();
            }
            else if (MainInventory.lookupPart(partIndex) is Outsourced)
            {
                Outsourced selectedPart = (Outsourced)MainInventory.lookupPart(partIndex);
                isOutsourced = true;
                radioButton2.Checked = true;
                textBoxMachine.Text = selectedPart.CompanyName.ToString();
            }
        }

        private void buttonCancel_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void ModifyPart_Load(object sender, EventArgs e)
        {
            PopulateTextBoxes();
        }

        private void buttonSave_Click(object sender, EventArgs e)
        {
            ValidateData();
            SavePart();
        }

        private void radioButtonInhouse_CheckedChanged(object sender, EventArgs e)
        {

                if (radioButton1.Checked)
                {
                    isOutsourced = false;
                    isInhouse = true;
                    labelCompany.Hide();
                    labelMachine.Show();
                }
        }

        private void radioButtonOutsourced_CheckedChanged(object sender, EventArgs e)
        {
            if (radioButton2.Checked)
            {
                isInhouse = false;
                isOutsourced = true;
                labelMachine.Hide();
                labelCompany.Show();
            }
        }
    }
}
