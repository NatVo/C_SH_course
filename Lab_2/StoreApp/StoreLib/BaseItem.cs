using System;
using System.Collections.Generic;
using System.Text;

namespace StoreLib
{
    public abstract class BaseItem
    {
        public string ItemName { get; set; }
        protected double Price = 0;
        protected int Amount = 0;
        public double GetPrice { get { return Price; } }
        public int GetAmount { get { return Amount; } }

        public void SetPrice(double setPrice) 
        { 
            if (setPrice > 0)
                Price = setPrice; 
        }
        public void IncreasePrice(double incrPrice)
        {
            if (incrPrice < 0)
                throw new ArgumentException("Добавочная стоимость не может быть отрицательной!\n");           
            else
                Price += incrPrice;

        }
        public void DecreasePrice(double decrPrice)
        {
            if (decrPrice < 0)
            {
                Console.WriteLine("Уменьшающая стоимость не может быть отрицательной!\n");
            }
            else
            {
                if ((Price - decrPrice) <= 0)
                    throw new ArgumentException("Стоимость товара не может быть отрицательной!");
                else
                    Price -= decrPrice;

            }

        }

        public void SetAmount(int setAmount)
        {
            if (setAmount > 0)
                Amount = setAmount;
        }
        public void IncreaseAmount(int incrAmount)
        {
            if (incrAmount < 0)
                throw new ArgumentException("Величина для увеличения количества товара не может быть отрицательной!\n");
            else
                Amount += incrAmount;

        }
        public void DecreaseAmount(int decrAmount)
        {
            if (decrAmount < 0)
            {
                Console.WriteLine("Величина для уменьшения количества товара не может быть отрицательной!\n");
            }
            else
            {
                if ((Amount - decrAmount) <= 0)
                    throw new ArgumentException("Количество товара не может быть отрицательным!");
                else
                    Amount -= decrAmount;

            }

        }

    }
}
