using Xunit;

namespace StoreLib.Tests
{
    public class BookStoreTest
    {
        [Fact]
        public void BookStore_AddEmpolyees_AddZeroOrNegativeAmountOfEmployees_ShouldThrowArgumentException()
        {
            BookStore bookStore = new BookStore();
            bookStore.Name = "Дом киниги";
            bookStore.Adress = "ул. Советская, 33";
            bookStore.SetEmployees(1);

            int employeeAmount = 0; //employeeAmount = -3;

            try
            {
                bookStore.AddEmpolyees(employeeAmount);
            }
            catch (System.ArgumentException e)
            {
                Assert.Equal(e.Message, BookStore.addZeroOrNegativeEmployeesMessage);
                return;
            }

            Assert.True(false, "Ожидаемая ошибка не была выявлена");
        }

        [Fact]
        public void BookStore_RemoveEmpolyees_RemoveZeroOrNegativeAmountOfEmployees_ShouldThrowArgumentException()
        {
            BookStore bookStore = new BookStore();
            bookStore.Name = "Дом киниги";
            bookStore.Adress = "ул. Советская, 33";
            bookStore.SetEmployees(1);

            int employeeAmount = 0; //employeeAmount = -3;

            try
            {
                bookStore.RemoveEmpolyees(employeeAmount);
            }
            catch (System.ArgumentException e)
            {
                Assert.Equal(e.Message, BookStore.removeZeroOrNegativeEmployeesMessage);
                return;
            }

            Assert.True(false, "Ожидаемая ошибка не была выявлена");
        }

        [Fact]
        public void BookStore_RemoveEmpolyees_ZeroOrNegativeTotalAmountOfEmployeesAfterRemoval_ShouldThrowArgumentException()
        {
            BookStore bookStore = new BookStore();
            bookStore.Name = "Дом киниги";
            bookStore.Adress = "ул. Советская, 33";
            bookStore.SetEmployees(1);

            int employeeAmount = 1;

            try
            {
                bookStore.RemoveEmpolyees(employeeAmount);
            }
            catch (System.ArgumentException e)
            {
                Assert.Equal(e.Message, BookStore.zeroOrNegativeTotalAmountOfEmployeesMessage);
                return;
            }

            Assert.True(false, "Ожидаемая ошибка не была выявлена");
        }

        [Fact]
        public void BookStore_DeleteItem_TryToDeleteInexistingBookItem_ShouldThrowArgumentException()
        {
            BookStore bookStore = new BookStore();
            bookStore.Name = "Дом киниги";
            bookStore.Adress = "ул. Советская, 33";
            bookStore.SetEmployees(10);

            BookItem bookOne = new BookItem();
            bookOne.ItemName = "Шерлок Холмс";
            bookOne.Author = "Артур Конан-Дойль";
            bookOne.Genre = "детектив";
            bookOne.SetPrice(153.5);
            bookOne.SetAmount(3);

            bookStore.AddItem(bookOne);

            try
            {
                bookStore.DeleteItem("Преступлени и Наказание"); ;
            }
            catch (System.ArgumentException e)
            {
                Assert.Equal(e.Message, BookStore.cantFindBookItemToDeleteMessage);
                return;
            }

            Assert.True(false, "Ожидаемая ошибка не была выявлена");
        }
    }

    public class BookItemTest
    {
        [Fact]
        public void BookItem_IncreasePrice_IncreaseByNegativePrice_ShouldThrowArgumentException()
        {
            BookItem bookOne = new BookItem();
            bookOne.ItemName = "Шерлок Холмс";
            bookOne.Author = "Артур Конан-Дойль";
            bookOne.Genre = "детектив";

            double increasePrice = -5;

            try
            {
                bookOne.IncreasePrice(increasePrice);
            }
            catch (System.ArgumentException e)
            {
                Assert.Equal(e.Message, BookItem.increaseByNegativePriceMessage);
                return;
            }

            Assert.True(false, "Ожидаемая ошибка не была выявлена");
        }

        [Fact]
        public void BookItem_DecreasePrice_DecreaseByNegativePrice_ShouldThrowArgumentException()
        {
            BookItem bookOne = new BookItem();
            bookOne.ItemName = "Шерлок Холмс";
            bookOne.Author = "Артур Конан-Дойль";
            bookOne.Genre = "детектив";

            double decreasePrice = -5;

            try
            {
                bookOne.DecreasePrice(decreasePrice);
            }
            catch (System.ArgumentException e)
            {
                Assert.Equal(e.Message, BookItem.decreaseByNegativePriceMessage);
                return;
            }

            Assert.True(false, "Ожидаемая ошибка не была выявлена");
        }

        [Fact]
        public void BookItem_DecreasePrice_ZeroOrNegativeTotalPriceAfterDecreasing_ShouldThrowArgumentException()
        {
            BookItem bookOne = new BookItem();
            bookOne.ItemName = "Шерлок Холмс";
            bookOne.Author = "Артур Конан-Дойль";
            bookOne.Genre = "детектив";
            bookOne.IncreasePrice(153.5);

            double decreasePrice = 205.5;

            try
            {
                bookOne.DecreasePrice(decreasePrice);
            }
            catch (System.ArgumentException e)
            {
                Assert.Equal(e.Message, BookItem.negativeTotalPriceMessage);
                return;
            }

            Assert.True(false, "Ожидаемая ошибка не была выявлена");
        }

        [Fact]
        public void BookItem_IncreaseAmount_IncreaseByNegativeAmount_ShouldThrowArgumentException()
        {
            BookItem bookOne = new BookItem();
            bookOne.ItemName = "Шерлок Холмс";
            bookOne.Author = "Артур Конан-Дойль";
            bookOne.Genre = "детектив";

            int increaseAmount = -5;

            try
            {
                bookOne.IncreaseAmount(increaseAmount);
            }
            catch (System.ArgumentException e)
            {
                Assert.Equal(e.Message, BookItem.increaseByNegativeAmountMessage);
                return;
            }

            Assert.True(false, "Ожидаемая ошибка не была выявлена");
        }

        [Fact]
        public void BookItem_DecreaseAmount_DecreaseByNegativeAmount_ShouldThrowArgumentException()
        {
            BookItem bookOne = new BookItem();
            bookOne.ItemName = "Шерлок Холмс";
            bookOne.Author = "Артур Конан-Дойль";
            bookOne.Genre = "детектив";

            int decreaseAmount = -5;

            try
            {
                bookOne.DecreaseAmount(decreaseAmount);
            }
            catch (System.ArgumentException e)
            {
                Assert.Equal(e.Message, BookItem.decreaseByNegativeAmountMessage);
                return;
            }

            Assert.True(false, "Ожидаемая ошибка не была выявлена");
        }

        [Fact]
        public void BookItem_DecreaseAmount_ZeroOrNegativeTotalAmountAfterDecreasing_ShouldThrowArgumentException()
        {
            BookItem bookOne = new BookItem();
            bookOne.ItemName = "Шерлок Холмс";
            bookOne.Author = "Артур Конан-Дойль";
            bookOne.Genre = "детектив";
            bookOne.IncreaseAmount(5);

            int decreaseAmount = 20;

            try
            {
                bookOne.DecreaseAmount(decreaseAmount);
            }
            catch (System.ArgumentException e)
            {
                Assert.Equal(e.Message, BookItem.negativeTotalAmountMessage);
                return;
            }

            Assert.True(false, "Ожидаемая ошибка не была выявлена");
        }
    }
}
