using System;
using System.Collections.Generic;
using System.Text;

namespace StoreLib
{
    public interface IItem
    {
        string ItemName { get; set; }
        double GetPrice { get; }
        int GetAmount { get; }

        void SetPrice(double setPrice);
        void IncreasePrice(double incrPrice);
        void DecreasePrice(double decrPrice);
        void SetAmount(int setAmount);
        void IncreaseAmount(int incrAmount);
        void DecreaseAmount(int decrAmount);

    }
}
