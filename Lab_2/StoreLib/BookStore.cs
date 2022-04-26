using System;
using System.Collections.Generic;
using System.Text;

namespace StoreLib
{
    public class BookStore : BaseStore, IBookStore
    {
        public const string cantFindBookItemToDeleteMessage = "Невозможно удалить книжные товары с указанным названием!\n";

        private TimeSpan _timeStart = new TimeSpan(9, 0, 0);
        private TimeSpan _timeFinish = new TimeSpan(18, 0, 0);

        private List<BookItem> _bookItems = new List<BookItem>();

        public override void OutputStoreInfo()
        {
            Console.WriteLine($"\nКнижный магазин '{Name}' по адресу: {Adress} работает с {_timeStart:hh\\:mm} до {_timeFinish:hh\\:mm} ");
        }

        public void AddItem(BookItem bookItem)
        {
            _bookItems.Add(bookItem);
        }

        public override void DeleteItem(string itemName)
        {
            bool flag = false;
            for (int i = _bookItems.Count - 1; i > -1; i--)
            {
                if (_bookItems[i].ItemName == itemName)
                {
                    _bookItems.RemoveAt(i);
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
            foreach (BookItem bItem in _bookItems)
            {
                Console.WriteLine($"{counter}) Название книги: {bItem.ItemName}, Автор: {bItem.Author}, Жанр: {bItem.Genre}, Стоимость: {bItem.GetPrice}, Количество: {bItem.GetAmount}");
                counter += 1;
            }
        }
    }
}
