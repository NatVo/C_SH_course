using System;
using System.Collections.Generic;
using System.Text;

namespace StoreLib
{
    public class BookStore : BaseStore, IBookStore
    {
        public const string CantFindBookItemToDeleteMessage = "Невозможно удалить книжные товары с указанным названием!\n";

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
            BookItem bookItem = _bookItems.Find(x => x.ItemName == itemName);
            if(!_bookItems.Remove(bookItem))
            {
                throw new ArgumentException(CantFindBookItemToDeleteMessage);
            }
        }

        public override void ItemsOutput()
        {
            int counter = 1;

            Console.WriteLine();
            foreach (BookItem bItem in _bookItems)
            {
                Console.WriteLine($"{counter}) Название книги: {bItem.ItemName}, Автор: {bItem.Author}, Жанр: {bItem.Genre}, Стоимость: {bItem.Price}, Количество: {bItem.Amount}");
                counter += 1;
            }
        }
    }
}
