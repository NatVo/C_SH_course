using System;
using System.IO;
using Newtonsoft.Json;
using System.Diagnostics;

namespace CalculatorLibrary
{
    public class Calculator
    {
        JsonWriter writer;
        public Calculator()
        {
            //StreamWriter logFile = File.CreateText("calculator.log");
            //Trace.Listeners.Add(new TextWriterTraceListener(logFile));
            //Trace.AutoFlush = true;
            //Trace.WriteLine("История операций калькулятора");
            //Trace.WriteLine(String.Format("Started {0}", System.DateTime.Now.ToString()));

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
            double result = double.NaN; // Default value is "not-a-number" which we use if an operation, such as division, could result in an error.

            writer.WriteStartObject();
            writer.WritePropertyName("Operand1");
            writer.WriteValue(num1);
            writer.WritePropertyName("Operand2");
            writer.WriteValue(num2);
            writer.WritePropertyName("Operation");

            // Use a switch statement to do the math.
            switch (op)
            {
                case "с":
                    result = num1 + num2;
                    //Trace.WriteLine(String.Format("{0} + {1} = {2}", num1, num2, result));
                    writer.WriteValue("Сумма");
                    break;
                case "р":
                    result = num1 - num2;
                    //Trace.WriteLine(String.Format("{0} - {1} = {2}", num1, num2, result));
                    writer.WriteValue("Разность");
                    break;
                case "п":
                    result = num1 * num2;
                    //Trace.WriteLine(String.Format("{0} * {1} = {2}", num1, num2, result));
                    writer.WriteValue("Произведение");
                    break;
                case "д":
                    // Ask the user to enter a non-zero divisor.
                    if (num2 != 0)
                    {
                        result = num1 / num2;
                        //Trace.WriteLine(String.Format("{0} / {1} = {2}", num1, num2, result));
                        writer.WriteValue("Деление");
                    }
                    else
                    {
                        Console.WriteLine("На ноль делить нельзя!");
                        writer.WriteValue("Попытка поделить на ноль");
                    }

                    break;
                // Return text for an incorrect option entry.
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
