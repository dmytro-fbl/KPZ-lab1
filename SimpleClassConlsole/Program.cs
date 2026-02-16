using System;
using SimpleClassLibrary;
using System.Collections.Generic;
using System.Text;

namespace SimpleClassConlsole
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Record recordConsole = new Record();
            Console.OutputEncoding = Encoding.UTF8;
            Console.InputEncoding = Encoding.UTF8;
            Console.Title = "Лабораторна робота №5";

            Product[] products = new Product[0];
            Product product = new Product();


            while (true)
            {
                
                recordConsole.WriteMenuToConsole();

                int menu;
                bool good;
                do
                {
                    Console.Write("Ваш вибір: ");
                    good = int.TryParse(Console.ReadLine(), out menu);
                    if (!good || menu < 0 || menu > 8)
                        Console.WriteLine("Некоректне число. Спробуйте ще раз.");
                } while (!good || menu < 0 || menu > 8);

                switch (menu)
                {
                    case 1:
                        Product newProduct = ReadProductsArray();
                        Array.Resize(ref products, products.Length + 1);
                        products[products.Length - 1] = newProduct;
                        break;
                    case 2:
                        if (products.Length > 0)
                            recordConsole.PrintProduct(products[products.Length - 1]);
                        else
                            Console.WriteLine("Товари відсутні.");
                        break;
                    case 3:
                        recordConsole.PrintProducts(products);
                        break;
                    case 4:
                        if (products.Length > 0)
                            GetProductsInfo(products, out _, out _);
                        else
                            Console.WriteLine("Немає товарів для аналізу.");
                        break;
                    case 5:
                        SortProductsByPrice(products);
                        break;
                    case 6:
                        SortProductsByCount(products);
                        break;
                    case 7:
                        Console.WriteLine($"Вага всіх товарів на складі (кг): {product.GetTotalWeight(products)}");
                        break;
                    case 8:
                        if (products.Length == 0)
                        {
                            Console.WriteLine("Товари відсутні.");
                        }
                        else
                        {
                            Console.WriteLine("Термін придатності кожного товару:");
                            foreach (var prod in products)
                            {
                                Console.WriteLine($"{prod.GetName()} — {prod.ExpirationInDays} днів / {prod.ExpirationInMonths} міс. / {prod.ExpirationInYears} рік(років)");
                            }
                        }
                        break;
                    case 0:
                        Console.WriteLine("Завершення роботи...");
                        return;
                }

                Console.WriteLine("\nНатисніть будь-яку клавішу для повернення до меню...");
                Console.ReadKey();
            }
        }

        public static Product ReadProductsArray()
        {
            
            bool good;
            string name, producer, currencyName;
            double price, exRate;
            int quantity, weight;

            do
            {
                Console.Write("Назва товару: ");
                name = Console.ReadLine();
            } while (string.IsNullOrWhiteSpace(name));

            do
            {
                Console.Write("Ціна одиниці (USD): ");
                good = double.TryParse(Console.ReadLine(), out price);
            } while (!good || price <= 0);

            do
            {
                Console.Write("Кількість товару: ");
                good = int.TryParse(Console.ReadLine(), out quantity);
            } while (!good || quantity <= 0);

            do
            {
                Console.Write("Компанія-виробник: ");
                producer = Console.ReadLine();
            } while (string.IsNullOrWhiteSpace(producer));

            do
            {
                Console.Write("Вага товару (кг): ");
                good = int.TryParse(Console.ReadLine(), out weight);
            } while (!good || weight <= 0);

            do
            {
                Console.Write("Назва валюти: ");
                currencyName = Console.ReadLine();
            } while (string.IsNullOrWhiteSpace(currencyName));

            do
            {
                Console.Write("Курс валюти до UAH: ");
                good = double.TryParse(Console.ReadLine(), out exRate);
            } while (!good || exRate <= 0);

            int choice, expirationValue, expirationDays = 0;
            Product prod = new Product();
            do
            {
                Console.WriteLine("Оберіть одиниці терміну придатності:");
                Console.WriteLine("1 — у днях");
                Console.WriteLine("2 — у місяцях");
                Console.WriteLine("3 — у роках");
                good = int.TryParse(Console.ReadLine(), out choice);
            } while (!good || choice < 1 || choice > 3);

            do
            {
                Console.Write("Введіть значення терміну: ");
                good = int.TryParse(Console.ReadLine(), out expirationValue);
            } while (!good || expirationValue <= 0);

            switch (choice)
            {
                case 1:
                    expirationDays = expirationValue;
                    break;
                case 2:
                    expirationDays = expirationValue * 30;
                    break;
                case 3:
                    expirationDays = expirationValue * 365;
                    break;
            }

            Currency currency = new Currency(currencyName, exRate);
            return new Product(name, price, quantity, producer, weight, currency, expirationDays);
        }
        

        public static void GetProductsInfo(Product[] products, out double max, out double min)
        {
            max = min = products[0].GetPrice();
            Product maxP = products[0], minP = products[0];

            foreach (var p in products)
            {
                if (p.GetPrice() > max) { max = p.GetPrice(); maxP = p; }
                if (p.GetPrice() < min) { min = p.GetPrice(); minP = p; }
            }

            Console.WriteLine($"Найдорожчий товар: {maxP.GetName()} - {max}");
            Console.WriteLine($"Найдешевший товар: {minP.GetName()} - {min}");
        }

        public static void SortProductsByPrice(Product[] products)
        {
            Array.Sort(products, (a, b) => a.GetPrice().CompareTo(b.GetPrice()));
            Console.WriteLine("\nСортування за ціною:");
            foreach (var p in products)
                Console.WriteLine($"{p.GetName()} - {p.GetPrice()}");
        }

        public static void SortProductsByCount(Product[] products)
        {
            Array.Sort(products, (a, b) => a.GetQuantity().CompareTo(b.GetQuantity()));
            Console.WriteLine("\nСортування за кількістю:");
            foreach (var p in products)
                Console.WriteLine($"{p.GetName()} - {p.GetQuantity()}");
        }
    }
}
