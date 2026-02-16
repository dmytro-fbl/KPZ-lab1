using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimpleClassConlsole
{
    public class InputValidator
    {
        Record record = new Record();
        public virtual int ReadValue(string writeConsoleString, int value)
        {
            bool validValue;

            do
            {
                Console.Write(writeConsoleString);
                validValue = int.TryParse(Console.ReadLine(), out value);

            } while (!validValue || value <= 0);

            return value;
        }

        public double ReadValue(string writeConsoleString, double value)
        {
            bool validValue;

            do
            {
                Console.Write(writeConsoleString);
                validValue = double.TryParse(Console.ReadLine(), out value);

            } while (!validValue || value <= 0);

            return value;
        }

        public string ReadValue(string writeConsoleString, string value)
        {
            do
            {
                Console.Write(writeConsoleString);
                value = Console.ReadLine();

            } while (string.IsNullOrWhiteSpace(value));

            return value;
        }

        public int ReadExpirationDate(int value)
        {
            bool validValue;

            do
            {
                record.WriteMenuExpirationDate();
                validValue = int.TryParse(Console.ReadLine(), out value);

            } while (!validValue || value < 1 || value > 3);

            return value; 
        } 

        public int ReadMenuChoice(int value)
        {
            bool validValue;

            do
            {
                Console.Write("Ваш вибір: ");
                validValue = int.TryParse(Console.ReadLine(), out value);
                if (!validValue || value < 0 || value > 8)
                    Console.WriteLine("Некоректне число. Спробуйте ще раз.");
            } while (!validValue || value < 0 || value > 8);

            return value;
        }
    }
}
