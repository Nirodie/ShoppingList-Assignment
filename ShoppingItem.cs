using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assignment5_ShoppingList
{
    /// <summary>
    /// has fields to contain data
    /// </summary>
    class ShoppingItem
    {
        private string description; //Describes the item
        private double amount; //Does not have a set unit
        private UnitTypes unit; //Picks the unit

        //Constructor of the class to initate the object
        public ShoppingItem (string name, double amount, UnitTypes unit)
        {
            this.description = name;
            this.amount = amount;
            this.unit = unit;
        }
        #region constructors
        //Default constructor for chain-call to set default values
        public ShoppingItem (): this("Unknown", 1.0, UnitTypes.piece )
        {

        }

        //Constructor with only 1 parameter
        public ShoppingItem (string description ) : this ( description, 1.0, UnitTypes.piece)
        {

        }

        //Copy constructor
        public ShoppingItem (ShoppingItem theOther)
        {
            //Object being created at left side and initialized with values on the right
            description = theOther.description;
            amount = theOther.amount;
            unit = theOther.unit;
        }
        #endregion
        #region Properties
        public string Description
        {
            get { return description; }
            set
            {
                if (!string.IsNullOrEmpty(value))
                    description = value;
            }
        }
        public double Amount
        {
            get { return amount; }
            set
            {
                if (value >= 0) //Makes sure value of amount isn't < 0
                    amount = value;
            }
        }
        public UnitTypes Unit
        {
            get { return unit; }
            set
            {
                if (Enum.IsDefined(typeof(UnitTypes), value)) //Makes sure there's a defined value in the enum
                    unit = value;
            }
        }
        #endregion
        //A ToString method to adjust and round off the values when presented to an output
        public override string ToString()
        {
            string textOut = string.Empty;
            textOut = $"{description,-45} {amount,6:f2} {unit,-6}";
            return textOut;
        }
    }
}
