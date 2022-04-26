using System;
using StoreLib;

namespace StoreApp
{
    class Program
    {
        static void Main()
        {
            BookStore bookStore = new BookStore();
            bookStore.Name = "Дом киниги";
            bookStore.Adress = "ул. Советская, 33";
            bookStore.OutputStoreInfo();
            bookStore.SetEmployees(10);
            bookStore.RemoveEmpolyees(2);
            Console.WriteLine($"Количество работников в магазине '{bookStore.Name}' - {bookStore.AmountOfEmployees}");

            BookItem bookOne = new BookItem();
            bookOne.ItemName = "Шерлок Холмс";
            bookOne.Author = "Артур Конан-Дойль";
            bookOne.Genre = "детектив";
            bookOne.SetPrice(153.5);
            bookOne.SetAmount(3);

            BookItem bookTwo = new BookItem();
            bookTwo.ItemName = "Преступление и Наказание";
            bookTwo.Author = "Федор Достоевский";
            bookTwo.Genre = "роман";
            bookTwo.SetPrice(333.0);
            bookTwo.SetAmount(1);

            BookItem bookThree = new BookItem();
            bookThree.ItemName = "Война и мир";
            bookThree.Author = "Лев Толстой";
            bookThree.Genre = "роман";
            bookThree.SetPrice(225.8);
            bookThree.SetAmount(5);
            bookThree.IncreasePrice(12.5);

            bookStore.AddItem(bookOne);
            bookStore.AddItem(bookTwo);
            bookStore.AddItem(bookThree);
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

            GroceryItem groceryOne = new GroceryItem();
            groceryOne.ItemName = "апельсины";
            groceryOne.ItemType = "фрукты";
            groceryOne.SetPrice(99.99);
            groceryOne.SetAmount(523);

            GroceryItem groceryTwo = new GroceryItem();
            groceryTwo.ItemName = "яблоки";
            groceryTwo.ItemType = "фрукты";
            groceryTwo.SetPrice(123.00);
            groceryTwo.SetAmount(1500);

            GroceryItem groceryThree = new GroceryItem();
            groceryThree.ItemName = "рис";
            groceryThree.ItemType = "крупы";
            groceryThree.SetPrice(150.00);
            groceryThree.SetAmount(220);

            groceryStore.AddItem(groceryOne);
            groceryStore.AddItem(groceryTwo);
            groceryStore.AddItem(groceryThree);
            groceryStore.ItemsOutput();
            groceryStore.DeleteItem("яблоки");
            groceryStore.ItemsOutput();

            Console.ReadKey();

        }
    }
}
