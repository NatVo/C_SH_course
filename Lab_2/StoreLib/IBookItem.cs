using System;
using System.Collections.Generic;
using System.Text;

namespace StoreLib
{
    public interface IBookItem : IItem
    {
        string Author { get; set; }
        string Genre { get; set; }
    }
}
