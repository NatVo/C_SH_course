using System;
using System.Collections.Generic;
using System.Text;

namespace StoreLib
{
    public class BookStore : BaseStore, IBookStore
    {
        private TimeSpan timeStart = new TimeSpan(9, 0, 0);
        private TimeSpan timeFinish = new TimeSpan(18, 0, 0);

        private List<BookItem> BookItems = new List<BookItem>();

        public override void OutputStoreInfo()
        {
            Console.WriteLine($"\nКнижный магазин '{Name}' по адресу: {Adress} работает с {timeStart.ToString(@"hh\:mm")} до {timeFinish.ToString(@"hh\:mm")} ");
        }

        public void AddItem(BookItem bookItem)
        {
            BookItems.Add(bookItem);
        }

        public override void DeleteItem(string itemName)
        {
            for (int i = BookItems.Count - 1; i > -1; i--)
            {
                if (BookItems[i].ItemName == itemName)
                {
                    BookItems.RemoveAt(i);
                }
            }

        }
        public override void ItemsOutput()
        {
            
            int counter = 1;

            Console.WriteLine();
            foreach (BookItem bItem in BookItems)
            {
                Console.WriteLine($"{counter}) Название книги: {bItem.ItemName}, Автор: {bItem.Author}, Жанр: {bItem.Genre}, Стоимость: {bItem.GetPrice}, Количество: {bItem.GetAmount}");
                counter += 1;
            }
        }
    }
}
