using System;
using System.Collections.Generic;
using System.Text;

namespace StoreLib
{
    public interface IGroceryItem : IItem
    {
        string ItemType { get; set; }
    }
}
