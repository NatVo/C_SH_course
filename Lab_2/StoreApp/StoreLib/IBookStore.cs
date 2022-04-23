using System;
using System.Collections.Generic;
using System.Text;

namespace StoreLib
{
    public interface IBookStore : IStore
    {
        void AddItem(BookItem bookItem);
    }
}
