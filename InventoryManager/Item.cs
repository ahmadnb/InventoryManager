using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InventoryManager
{
    class Item
    {
        // Private members of the Item class
        private string name;
        private int sellin;
        private int quality;

        // Constructors
        public Item() { }

        public  Item(Item i)
        {
            this.name = i.name;
            this.sellin = i.sellin;
            this.quality = i.quality;
        }

        public Item(string n, int s, int q)
        {
            this.name = n;
            this.sellin = s;
            this.quality = q;
        }

        /***********************************************************************
         * GetName
         * 
         * Public method used to retrieve the item's name
         ***********************************************************************
         * Input Parameters:
         * 
         * None
         ***********************************************************************
         * Output:
         * 
         * Item Name
         ***********************************************************************
         * Change history:
         * 
         * Date                Username               Changes made
         * 
         * 08/02/2018          Nabil Ahmad            Initial Creation
         **********************************************************************/
        public string GetName()
        {
            return this.name;
        }

        /***********************************************************************
         * GetSellin
         * 
         * Public method used to retrieve the item's sellin value
         ***********************************************************************
         * Input Parameters:
         * 
         * None
         ***********************************************************************
         * Output:
         * 
         * Item Sell-in value
         ***********************************************************************
         * Change history:
         * 
         * Date                Username               Changes made
         * 
         * 08/02/2018          Nabil Ahmad            Initial Creation
         **********************************************************************/
        public int GetSellin()
        {
            return this.sellin;
        }

        /***********************************************************************
         * GetQuality
         * 
         * Public method used to retrieve the item's quality value
         ***********************************************************************
         * Input Parameters:
         * 
         * None
         ***********************************************************************
         * Output:
         * 
         * Item Quality value
         ***********************************************************************
         * Change history:
         * 
         * Date                Username               Changes made
         * 
         * 08/02/2018          Nabil Ahmad            Initial Creation
         **********************************************************************/
        public int GetQuality()
        {
            return this.quality;
        }

        /***********************************************************************
         * ValidateName
         * 
         * Private method used to check to see if the name entered by the user is 
         * a valid name
         ***********************************************************************
         * Input Parameters:
         * 
         * Item name
         ***********************************************************************
         * Output:
         * 
         * If the input item name is valid, it is left unchanged.
         * Otherwise it will be changed to "NO SUCH ITEM".
         ***********************************************************************
         * Change history:
         * 
         * Date                Username               Changes made
         * 
         * 08/02/2018          Nabil Ahmad            Initial Creation
         **********************************************************************/
        public string ValidateName(string n)
        {
            n = n.Trim();

            if (!((n.ToLower() == "aged brie")
                || (n.ToLower() == "backstage passes")
                || (n.ToLower() == "conjured")
                || (n.ToLower() == "normal item")
                || (n.ToLower() == "sulfuras")))
            {
                n = "NO SUCH ITEM";
            }

            return n;
        }

        /***********************************************************************
         * ProcessItem
         * 
         * Public method used to update the item sellin and quality values after 
         * 1 day
         ***********************************************************************
         * Input Parameters:
         * 
         * None
         ***********************************************************************
         * Output:
         * 
         * None
         ***********************************************************************
         * Change history:
         * 
         * Date                Username               Changes made
         * 
         * 08/02/2018          Nabil Ahmad            Initial Creation
         **********************************************************************/
        public void ProcessItem()
        {
            // The item "Sulfaras" has no expiry date and does not decrease in quality
            if (this.name.ToLower() != "sulfuras")
            {
                this.sellin--;
            }

            // All other items will experience changes to quality one way or another
            if (this.name.ToLower() == "aged brie")
            {
                UpdateQualityAgedBrie();
            }
            else if (this.name.ToLower() == "backstage passes")
            {
                UpdateQualityBackstagePasses();
            }
            else if (this.name.ToLower() == "conjured")
            {
                UpdateQualityConjured();
            }
            else if (this.name.ToLower() == "normal item")
            {
                UpdateQualityNormalItem();
            }
                        
            if (this.quality > 50)
            { // Item quality cannot be greater than 50
                this.quality = 50;
            }
            else if (this.quality < 0)
            { // Item quality cannot be less than 0
                this.quality = 0;
            }
        }

        /***********************************************************************
         * UpdateQualityAgedBrie
         * 
         * Private method used to update the quality of a backstage pass item
         ***********************************************************************
         * Input Parameters:
         * 
         * None
         ***********************************************************************
         * Output:
         * 
         * None
         ***********************************************************************
         * Change history:
         * 
         * Date                Username               Changes made
         * 
         * 08/02/2018          Nabil Ahmad            Initial Creation
         **********************************************************************/
        private void UpdateQualityAgedBrie()
        {
            // Item quality improves with time
            this.quality++;
        }


        /***********************************************************************
         * UpdateQualityBackstagePasses
         * 
         * Private method used to update the quality of a backstage pass item
         ***********************************************************************
         * Input Parameters:
         * 
         * None
         ***********************************************************************
         * Output:
         * 
         * None
         ***********************************************************************
         * Change history:
         * 
         * Date                Username               Changes made
         * 
         * 08/02/2018          Nabil Ahmad            Initial Creation
         **********************************************************************/
        private void UpdateQualityBackstagePasses()
        {
            if (this.sellin > 10)
            { // Item quality increases when sell-in value is greater than 10
                this.quality++;
            }
            else if ((this.sellin <= 10) && (this.sellin > 5))
            { // Item quality increases at double the normal rate when sell-in value is less than or equal to 10 but greater than 5
                this.quality += 2;
            }
            else if ((this.sellin <= 5) && (this.sellin >= 0))
            { // Item quality increases at triple the normal rate when sell-in value is less than or equal to 5 but not expired
                this.quality += 3;
            }
            else if (this.sellin < 0)
            { // Item quality goes to 0 when this item has expired
                this.quality = 0;
            }
        }

        /***********************************************************************
         * UpdateQualityConjured
         * 
         * Private method used to update the quality of a conjured item
         ***********************************************************************
         * Input Parameters:
         * 
         * None
         ***********************************************************************
         * Output:
         * 
         * None
         ***********************************************************************
         * Change history:
         * 
         * Date                Username               Changes made
         * 
         * 08/02/2018          Nabil Ahmad            Initial Creation
         **********************************************************************/
        private void UpdateQualityConjured()
        {
            // Item quality decrements at twice the normal rate
            this.quality -= 2;

            if (this.sellin < 0)
            { // Item quality decrements at twice its usual rate if item has expired
                this.quality -= 2;
            }
        }

        /***********************************************************************
         * UpdateQualityNormalItem
         * 
         * Private method used to update the quality of a normal item
         ***********************************************************************
         * Input Parameters:
         * 
         * None
         ***********************************************************************
         * Output:
         * 
         * None
         ***********************************************************************
         * Change history:
         * 
         * Date                Username               Changes made
         * 
         * 08/02/2018          Nabil Ahmad            Initial Creation
         **********************************************************************/
        private void UpdateQualityNormalItem()
        {
            this.quality--;

            if (this.sellin < 0)
            { // Item quality decrements at twice the normal rate if item has expired
                this.quality--;
            }
        }
    }
}
