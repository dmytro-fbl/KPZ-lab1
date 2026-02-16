using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SimpleClassLibrary;

namespace SimpleClassConlsole
{
    public class Record
    {

        Product product = new Product();
        Product[] products = new Product[0];
        public void WriteMenuToConsole()
        {
            Console.BackgroundColor = ConsoleColor.White;
            Console.ForegroundColor = ConsoleColor.DarkBlue;
            Console.Clear();
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("Лабораторна робота №5");
            Console.WriteLine("Виконав: Руденко Д.Р.");
            Console.WriteLine("Завдання №1");
            Console.ForegroundColor = ConsoleColor.DarkBlue;

            Console.WriteLine("\nМЕНЮ");
            Console.WriteLine("1 - Ввести продукт");
            Console.WriteLine("2 - Вивести поточний продукт");
            Console.WriteLine("3 - Вивести всі продукти на складі");
            Console.WriteLine("4 - Вивести найдешевший і найдорожчий товар");
            Console.WriteLine("5 - Сортувати всі товари за зростанням ціни");
            Console.WriteLine("6 - Сортувати всі товари за кількістю");
            Console.WriteLine("7 - Вивести загальну вагу товарів");
            Console.WriteLine("8 - Вивести термін придатності");
            Console.WriteLine("0 - Вихід");
        }

        public void WriteMenuExpirationDate()
        {
            Console.WriteLine("Оберіть одиниці терміну придатності:");
            Console.WriteLine("1 — у днях");
            Console.WriteLine("2 — у місяцях");
            Console.WriteLine("3 — у роках");
        }

        public void PrintProduct(Product product)
        {
            Console.WriteLine("\nІнформація про товар:");
            Console.WriteLine($"Назва: {product.Name}");
            Console.WriteLine($"Ціна: {product.Price}");
            Console.WriteLine($"Валюта: {product.Cost.Name}");
            Console.WriteLine($"Курс: {product.Cost.ExRate}");
            Console.WriteLine($"Кількість: {product.Quantity}");
            Console.WriteLine($"Виробник: {product.Produser}");
            Console.WriteLine($"Вага (кг): {product.Weight}");
            Console.WriteLine($"Ціна в UAH: {product.GetPriceInUAH()}");
            Console.WriteLine($"Термін придатності: {product.ExpirationInDays} днів / {product.ExpirationInMonths} міс. / {product.ExpirationInYears} рік(років)\n");

        }

        public void PrintProducts(Product[] products)
        {
            Console.WriteLine("\nІнформація про всі товари:");
            foreach (var product in products)
                PrintProduct(product);

            Product sample = new Product();
            Console.WriteLine($"Загальна вартість товарів (UAH): {sample.GetTotalPriceInUAH(products)}");
        }

        
    }
}
