using System;
using System.Collections.Generic;
using System.Text;

namespace StoreLib
{
    public class GroceryItem : BaseItem, IItem
    {
        public string ItemType { get; set; }
    }
}
