using System;
using System.Collections.Generic;
using System.Text;

namespace StoreLib
{
    public class GroceryStore : BaseStore, IGroceryStore
    {
        private TimeSpan timeStart = new TimeSpan(8, 0, 0);
        private TimeSpan timeFinish = new TimeSpan(21, 0, 0);
        private List<GroceryItem> GroceryItems = new List<GroceryItem>();
        public override void OutputStoreInfo()
        {
            Console.WriteLine($"\nПродуктовый магазин '{Name}' по адресу: {Adress} работает с {timeStart.ToString(@"hh\:mm")} до {timeFinish.ToString(@"hh\:mm")} ");
        }

        public void AddItem(GroceryItem groceryItem)
        {
            GroceryItems.Add(groceryItem);
        }

        public override void DeleteItem(string itemName)
        {
            for (int i = GroceryItems.Count - 1; i > -1; i--)
            {
                if (GroceryItems[i].ItemName == itemName)
                {
                    GroceryItems.RemoveAt(i);
                }
            }

        }
        public override void ItemsOutput()
        {

            int counter = 1;

            Console.WriteLine();
            foreach (GroceryItem gItem in GroceryItems)
            {
                Console.WriteLine($"{counter}) Название продукта: {gItem.ItemName}, Тип продукта: {gItem.ItemType}, Стоимость: {gItem.GetPrice}, Количество: {gItem.GetAmount}");
                counter += 1;
            }
        }
    }
}
