using System;
using StoreLib;

namespace StoreApp
{
    class Program
    {
        static void Main(string[] args)
        {
            BookStore bookStore = new BookStore();
            bookStore.Name = "Дом киниги";
            bookStore.Adress = "ул. Советская, 33";
            bookStore.OutputStoreInfo();
            bookStore.AddEmpolyees(10);
            bookStore.RemoveEmpolyees(2);
            Console.WriteLine($"Количество работников в магазине '{bookStore.Name}' - {bookStore.AmountOfEmployees}");

            BookItem book_1 = new BookItem();
            book_1.ItemName = "Шерлок Холмс";
            book_1.Author = "Артур Конан-Дойль";
            book_1.Genre = "детектив";
            book_1.IncreasePrice(153.5);
            book_1.IncreaseAmount(3);

            BookItem book_2 = new BookItem();
            book_2.ItemName = "Преступление и Наказание";
            book_2.Author = "Федор Достоевский";
            book_2.Genre = "роман";
            book_2.SetPrice(333.0);
            book_2.SetAmount(1);

            BookItem book_3 = new BookItem();
            book_3.ItemName = "Война и мир";
            book_3.Author = "Лев Толстой";
            book_3.Genre = "роман";
            book_3.SetPrice(225.8);
            book_3.SetAmount(5);

            bookStore.AddItem(book_1);
            bookStore.AddItem(book_2);
            bookStore.AddItem(book_3);
            bookStore.ItemsOutput();
            bookStore.DeleteItem("Преступление и Наказание");
            bookStore.ItemsOutput();
            //-----------------------------------------------------------------------------------------------------------------
            GroceryStore groceryStore = new GroceryStore();
            groceryStore.Name = "Продукты 24/7";
            groceryStore.Adress = "ул. Ленина, 5";
            groceryStore.OutputStoreInfo();
            groceryStore.AddEmpolyees(35);
            Console.WriteLine($"Количество работников в магазине '{groceryStore.Name}' - {groceryStore.AmountOfEmployees}");

            GroceryItem grocery_1 = new GroceryItem();
            grocery_1.ItemName = "апельсины";
            grocery_1.ItemType = "фрукты";
            grocery_1.SetPrice(99.99);
            grocery_1.SetAmount(523);

            GroceryItem grocery_2 = new GroceryItem();
            grocery_2.ItemName = "яблоки";
            grocery_2.ItemType = "фрукты";
            grocery_2.SetPrice(123.00);
            grocery_2.SetAmount(1500);

            GroceryItem grocery_3 = new GroceryItem();
            grocery_3.ItemName = "рис";
            grocery_3.ItemType = "крупы";
            grocery_3.SetPrice(150.00);
            grocery_3.SetAmount(220);

            groceryStore.AddItem(grocery_1);
            groceryStore.AddItem(grocery_2);
            groceryStore.AddItem(grocery_3);
            groceryStore.ItemsOutput();
            groceryStore.DeleteItem("яблоки");
            groceryStore.ItemsOutput();

            Console.ReadKey();

        }
    }
}
