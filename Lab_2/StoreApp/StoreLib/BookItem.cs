using System;
using System.Collections.Generic;
using System.Text;

namespace StoreLib
{
    public class BookItem : BaseItem, IBookItem
    {
        public string Author { get; set; }
        public string Genre { get; set; }

    }
}
