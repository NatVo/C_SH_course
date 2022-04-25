using System;
using System.Collections.Generic;
using System.Text;

namespace StoreLib
{
    public abstract class BaseItem
    {
        public const string increaseByNegativePriceMessage = "Добавочная стоимость не может быть отрицательной!\n";
        public const string decreaseByNegativePriceMessage = "Уменьшающая стоимость не может быть отрицательной!\n";
        public const string negativeTotalPriceMessage = "Стоимость товара не может быть отрицательной!";

        public const string increaseByNegativeAmountMessage = "Величина для увеличения количества товара не может быть отрицательной!\n";
        public const string decreaseByNegativeAmountMessage = "Величина для уменьшения количества товара не может быть отрицательной!\n";
        public const string negativeTotalAmountMessage = "Количество товара не может быть отрицательным!";

        private double _price = 0;
        private int _amount = 0;

        public string ItemName { get; set; }
        public double GetPrice { get { return _price; } }
        public int GetAmount { get { return _amount; } }

        public void SetPrice(double setPrice) 
        { 
            if (setPrice > 0)
            {
                _price = setPrice;
            }   
            else
            {
                throw new ArgumentException(negativeTotalPriceMessage);
            }
        }

        public void IncreasePrice(double increasePrice)
        {
            if (increasePrice < 0)
            {
                throw new ArgumentException(increaseByNegativePriceMessage);
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
                throw new ArgumentException(decreaseByNegativePriceMessage);
            }
            else
            {
                if ((_price - decreasePrice) < 0)
                {
                    throw new ArgumentException(negativeTotalPriceMessage);
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
                throw new ArgumentException(negativeTotalAmountMessage);
            }
        }

        public void IncreaseAmount(int incrAmount)
        {
            if (incrAmount < 0)
            {
                throw new ArgumentException(increaseByNegativeAmountMessage);
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
                throw new ArgumentException(decreaseByNegativeAmountMessage);
            }
            else
            {
                if ((_amount - decrAmount) <= 0)
                {
                    throw new ArgumentException(negativeTotalAmountMessage);
                }                    
                else
                {
                    _amount -= decrAmount;
                }
            }
        }

    }
}
