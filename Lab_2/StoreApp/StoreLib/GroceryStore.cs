using System;
using System.Collections.Generic;
using System.Text;

namespace StoreLib
{
    public class GroceryStore : BaseStore, IGroceryStore
    {
        public const string cantFindBookItemToDeleteMessage = "Невозможно удалить продовольственные товары с указанным названием!\n";

        private TimeSpan _timeStart = new TimeSpan(8, 0, 0);
        private TimeSpan _timeFinish = new TimeSpan(21, 0, 0);
        private List<GroceryItem> _groceryItems = new List<GroceryItem>();

        public override void OutputStoreInfo()
        {
            Console.WriteLine($"\nПродуктовый магазин '{Name}' по адресу: {Adress} работает с {_timeStart:hh\\:mm} до {_timeFinish:hh\\:mm} ");
        }

        public void AddItem(GroceryItem groceryItem)
        {
            _groceryItems.Add(groceryItem);
        }

        public override void DeleteItem(string itemName)
        {
            bool flag = false;
            for (int i = _groceryItems.Count - 1; i > -1; i--)
            {
                if (_groceryItems[i].ItemName == itemName)
                {
                    _groceryItems.RemoveAt(i);
                    flag = true;
                }
            }

            if (!flag)
            {
                throw new ArgumentException(cantFindBookItemToDeleteMessage);
            }
        }

        public override void ItemsOutput()
        {
            int counter = 1;

            Console.WriteLine();
            foreach (GroceryItem gItem in _groceryItems)
            {
                Console.WriteLine($"{counter}) Название продукта: {gItem.ItemName}, Тип продукта: {gItem.ItemType}, Стоимость: {gItem.GetPrice}, Количество: {gItem.GetAmount}");
                counter += 1;
            }
        }
    }
}
