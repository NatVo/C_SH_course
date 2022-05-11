using System;
using System.Collections.Generic;
using System.Text;

namespace StoreLib
{
    public abstract class BaseItem
    {
        public const string IncreaseByNegativePriceMessage = "Добавочная стоимость не может быть отрицательной!\n";
        public const string DecreaseByNegativePriceMessage = "Уменьшающая стоимость не может быть отрицательной!\n";
        public const string NegativeTotalPriceMessage = "Стоимость товара не может быть отрицательной!";

        public const string IncreaseByNegativeAmountMessage = "Величина для увеличения количества товара не может быть отрицательной!\n";
        public const string DecreaseByNegativeAmountMessage = "Величина для уменьшения количества товара не может быть отрицательной!\n";
        public const string NegativeTotalAmountMessage = "Количество товара не может быть отрицательным!";

        private double _price = 0;
        private int _amount = 0;

        public string ItemName { get; set; }
        public double Price { get { return _price; } }
        public int Amount { get { return _amount; } }

        public void SetPrice(double setPrice)
        {
            if (setPrice > 0)
            {
                _price = setPrice;
            }
            else
            {
                throw new ArgumentException(NegativeTotalPriceMessage);
            }
        }

        public void IncreasePrice(double increasePrice)
        {
            if (increasePrice < 0)
            {
                throw new ArgumentException(IncreaseByNegativePriceMessage);
            }
            else
            {
                _price += increasePrice;
            }
        }

        public void DecreasePrice(double decreasePrice)
        {
            if (decreasePrice < 0)
            {
                throw new ArgumentException(DecreaseByNegativePriceMessage);
            }
            else
            {
                if ((_price - decreasePrice) < 0)
                {
                    throw new ArgumentException(NegativeTotalPriceMessage);
                }
                else
                {
                    _price -= decreasePrice;
                }
            }
        }

        public void SetAmount(int setAmount)
        {
            if (setAmount > 0)
            {
                _amount = setAmount;
            }
            else
            {
                throw new ArgumentException(NegativeTotalAmountMessage);
            }
        }

        public void IncreaseAmount(int incrAmount)
        {
            if (incrAmount < 0)
            {
                throw new ArgumentException(IncreaseByNegativeAmountMessage);
            }
            else
            {
                _amount += incrAmount;
            }
        }

        public void DecreaseAmount(int decrAmount)
        {
            if (decrAmount < 0)
            {
                throw new ArgumentException(DecreaseByNegativeAmountMessage);
            }
            else
            {
                if ((_amount - decrAmount) <= 0)
                {
                    throw new ArgumentException(NegativeTotalAmountMessage);
                }
                else
                {
                    _amount -= decrAmount;
                }
            }
        }

    }
}
