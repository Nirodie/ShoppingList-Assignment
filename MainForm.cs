using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Assignment5_ShoppingList
{
    /// <summary>
    /// MainForm class which is the GUI and where the user gets output and input
    /// </summary>
    public partial class MainForm : Form
    {
        ItemManager itemManager = new ItemManager();
        public MainForm()
        {
            InitializeComponent();
            InitializeGUI();
        }

        private void InitializeGUI()
        {
            //Fills the combobox with the options inside of the UnitTypes enum
            cmbUnits.Items.AddRange(Enum.GetNames(typeof(UnitTypes)));
            //Sets "piece" as the default option
            cmbUnits.SelectedIndex = (int)UnitTypes.piece;
        }
        //Displays an error message box
        private void GiveMessage(string message)
        {
            MessageBox.Show(message,
                "error",
                MessageBoxButtons.OK,
                MessageBoxIcon.Error
                );
        }
        //Reads the amount given from the GUI
        private double ReadAmount (out bool success)
        {
            double amount = 0.0;
            success = false;

            if (!double.TryParse(txtAmount.Text, out amount)) //If no double is given
            {
                GiveMessage("Bad amount given, try again!");

                txtAmount.Focus();
                txtAmount.SelectionStart = 0;
                txtAmount.SelectionLength = txtAmount.TextLength;
            }
            else
                success = true;

            return amount;
        }
        //Reads the unit selected in the combo box
        private UnitTypes ReadUnit (out bool success)
        {
            success = false;
            UnitTypes unit = UnitTypes.lb; //initialization

            if (cmbUnits.SelectedIndex >= 0)
            {
                success = true;
                unit = (UnitTypes)cmbUnits.SelectedIndex;
            }
            else
                GiveMessage("Bad unit given, try again!");

            return unit;
        }
        //Reads and validates the input from the GUI
        private ShoppingItem ReadInput (out bool success)
        {
            success = false;

            ShoppingItem item = new ShoppingItem();

            //Reads the description
            item.Description = ReadDescription(out success);
            if (!success)
                return null;

            //Reads the amount
            item.Amount = ReadAmount(out success);
            if (!success)
                return null;

            //Reads the unit
            item.Unit = ReadUnit(out success);

            return item;
        }
        //Reads the description and trims it
        private string ReadDescription(out bool success)
        {
            success = false;
            string text = txtDescription.Text.Trim();
            if (!string.IsNullOrEmpty(text))
                success = true;
            else
                GiveMessage("Provide a description");

            return text;
        }
        private void UpdateGUI()
        {
            lstItems.Items.Clear();
            string[] itemStrings = itemManager.GetItemsInfoStrings();
            if (itemStrings.Length != null)
                lstItems.Items.AddRange(itemStrings);
        }
        //Adds an item with the button click
        private void btnAdd_Click(object sender, EventArgs e)
        {
            bool success = false;

            ShoppingItem item = ReadInput(out success);
            if(success)
            {
                itemManager.AddItem(item);
                UpdateGUI();
            }
        }

        private void lstItems_SelectedIndexChanged(object sender, EventArgs e)
        {

            if (lstItems.SelectedIndex < 0)
                return;
            //Checks what line is selected
            ShoppingItem item = itemManager.GetItem(lstItems.SelectedIndex);
            txtAmount.Text = item.Amount.ToString();
            txtDescription.Text = item.Description;
            cmbUnits.SelectedIndex = (int)item.Unit;
        }
        //Deletes an item with the button click
        private void btnDelete_Click(object sender, EventArgs e)
        {
            int index = lstItems.SelectedIndex;
            if (index < 0)
                return;

            else
            {
                itemManager.DeleteItem(index);
                UpdateGUI();
            }
        }
        //Changes selected item with button click
        private void btnChange_Click_1(object sender, EventArgs e)
        {
            {
                bool success = true;
                ShoppingItem item = ReadInput(out success);
                int index = lstItems.SelectedIndex;
                if (index < 0)
                    return;

                if (success)
                {
                    itemManager.ChangeItem(item, index);
                    UpdateGUI();
                }
            }
        }
    }
}
