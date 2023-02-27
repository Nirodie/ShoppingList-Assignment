using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assignment5_ShoppingList
{
    /// <summary>
    /// The container class for ShoppingItem and adds items to the list
    /// </summary>
    class ItemManager
    {
        //Declares a list object to hold ShoppingItems
        private List<ShoppingItem> itemList;

        //Constructor of the class
        public ItemManager()
        {
            //Creates the list object
            itemList = new List<ShoppingItem>();
        }

        //Makes sure the given index isn't out of range, for example if list contains 4 elements index = 5 is out of range.
        private bool CheckIndex (int index)
        {
            return (index >= 0) && (index < itemList.Count);
        }

        //Property returning # of items in the list
        public int Count
        {
            get { return itemList.Count; }
        }

        public ShoppingItem GetItem (int index)
        {
            if (!CheckIndex(index))
                return null;

            return itemList[index];

        }

        //The method for adding an item to the list
        public bool AddItem (ShoppingItem itemIn)
        {
            bool ok = false;
            if (itemIn != null)
            {
                itemList.Add(itemIn);
                ok = true;
            }
            return ok;
        }

        //Replaces an item within the list and releases the current one
        public bool ChangeItem ( ShoppingItem itemIn, int index)
        {
            bool ok = false;

            if (CheckIndex(index))
            {
                ok = true;
                itemList[index] = itemIn;
            }
            return ok;
        }

        //Removes an item within the list
        public bool DeleteItem (int index)
        {
            bool ok = false;

            if(CheckIndex(index))
            {
                itemList.RemoveAt(index);
                ok = true;
            }
            return ok;
        }
        
        //Prepares a list of strings of all items within of the list
        public string[] GetItemsInfoStrings ()
        {
            string[] stringInfoStrings = new string[itemList.Count];

            int i = 0;
            foreach (ShoppingItem Itemobj in itemList)
            {
                stringInfoStrings[i++] = Itemobj.ToString();
            }

            return stringInfoStrings;
        }
    }
}
