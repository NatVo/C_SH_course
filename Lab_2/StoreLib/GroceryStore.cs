using System;
using System.Collections.Generic;
using System.Text;

namespace StoreLib
{
    public class GroceryStore : BaseStore, IGroceryStore
    {
        public const string CantFindGroceryItemToDeleteMessage = "Невозможно удалить продовольственные товары с указанным названием!\n";

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
            GroceryItem groceryItem = _groceryItems.Find(x => x.ItemName == itemName);
            if (!_groceryItems.Remove(groceryItem))
            {
                throw new ArgumentException(CantFindGroceryItemToDeleteMessage);
            }
        }

        public override void ItemsOutput()
        {
            int counter = 1;

            Console.WriteLine();
            foreach (GroceryItem gItem in _groceryItems)
            {
                Console.WriteLine($"{counter}) Название продукта: {gItem.ItemName}, Тип продукта: {gItem.ItemType}, Стоимость: {gItem.Price}, Количество: {gItem.Amount}");
                counter += 1;
            }
        }
    }
}
