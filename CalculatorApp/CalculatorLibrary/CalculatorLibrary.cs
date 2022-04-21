using System;
using System.IO;
using Newtonsoft.Json;

namespace CalculatorLibrary
{
    public class Calculator
    {
        JsonWriter writer;
        public Calculator()
        {

            StreamWriter logFile = File.CreateText("calculatorlog.json");
            logFile.AutoFlush = true;
            writer = new JsonTextWriter(logFile);
            writer.Formatting = Formatting.Indented;
            writer.WriteStartObject();
            writer.WritePropertyName("Operations");
            writer.WriteStartArray();
        }

        public double DoOperation(double num1, double num2, string op)
        {
            double result = double.NaN;

            writer.WriteStartObject();
            writer.WritePropertyName("Operand1");
            writer.WriteValue(num1);
            writer.WritePropertyName("Operand2");
            writer.WriteValue(num2);
            writer.WritePropertyName("Operation");

            switch (op)
            {
                case "с":
                    result = num1 + num2;
                    writer.WriteValue("Сумма");
                    break;
                case "р":
                    result = num1 - num2;
                    writer.WriteValue("Разность");
                    break;
                case "п":
                    result = num1 * num2;
                    writer.WriteValue("Произведение");
                    break;
                case "д":
                    if (num2 != 0)
                    {
                        result = num1 / num2;
                        writer.WriteValue("Деление");
                    }
                    else
                    {
                        Console.WriteLine("На ноль делить нельзя!");
                        writer.WriteValue("Попытка поделить на ноль");
                    }

                    break;
                default:
                    {
                        Console.WriteLine("Введен некорректный вариант операции калькулятора!");
                        writer.WriteValue("Некорректная операция");
                        break;
                    }
            }

            writer.WritePropertyName("Результат");
            writer.WriteValue(result);
            writer.WriteEndObject();

            return result;
        }

        public void Finish()
        {
            writer.WriteEndArray();
            writer.WriteEndObject();
            writer.Close();
        }
    }

}
