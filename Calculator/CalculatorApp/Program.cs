using System;
using CalculatorLibrary;

namespace CalculatorApp
{
    class Program
    {
        static void Main(string[] args)
        {
            // Display title as the C# console calculator app.
            Console.WriteLine("Консольный калькулятор C#\r");
            Console.WriteLine("------------------------------------------\n");
            Console.WriteLine("Нажмите Esc для выхода, любую клавишу - для продолжения работы\n");

            Calculator calculator = new Calculator();

            while (Console.ReadKey().Key != ConsoleKey.Escape)
            {
                // Declare variables and set to empty.
                string numInput1 = "";
                string numInput2 = "";
                double result = 0;

                // Ask the user to type the first number.
                Console.Write("Введите первое число и нажмите Enter: ");
                numInput1 = Console.ReadLine();

                double cleanNum1 = 0;
                while (!double.TryParse(numInput1, out cleanNum1))
                {
                    Console.Write("Ввод некорректен, введите другое число: ");
                    numInput1 = Console.ReadLine();
                }

                // Ask the user to type the second number.
                Console.Write("Введите второе число и нажмите Enter:  ");
                numInput2 = Console.ReadLine();

                double cleanNum2 = 0;
                while (!double.TryParse(numInput2, out cleanNum2))
                {
                    Console.Write("Ввод некорректен, введите другое число: ");
                    numInput2 = Console.ReadLine();
                }

                // Ask the user to choose an operator.
                Console.WriteLine("Choose an operator from the following list:");
                Console.WriteLine("\tс - Сумма");
                Console.WriteLine("\tр - Разность");
                Console.WriteLine("\tп - Произведение");
                Console.WriteLine("\tд - Деление");
                Console.Write("Введите ваш вариант операции: ");

                string op = Console.ReadLine();

                try
                {
                    result = calculator.DoOperation(cleanNum1, cleanNum2, op);
                    //result = Calculator.DoOperation(cleanNum1, cleanNum2, op);
                    if (double.IsNaN(result))
                    {
                        Console.WriteLine("При попытке произвести вычисления произошла ошибка.\n");
                    }
                    else
                    {
                        Console.WriteLine("Результат: {0:0.##}\n", result);
                    }

                }
                catch (Exception e)
                {
                    Console.WriteLine("При попытке произвести вычисления произошла ошибка.\n - Details: " + e.Message);
                }

                Console.WriteLine("------------------------\n");

                // Wait for the user to respond before closing.
                Console.WriteLine("Нажмите Esc для выхода, любую клавишу - для продолжения работы\n");
            }

            calculator.Finish();
            return;
        }
    }
}