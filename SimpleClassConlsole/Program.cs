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
            InputValidator validator = new InputValidator();
            Console.OutputEncoding = Encoding.UTF8;
            Console.InputEncoding = Encoding.UTF8;
            Console.Title = "Лабораторна робота №5";

            Product[] products = new Product[0];
            Product product = new Product();
            


            while (true)
            {
                
                recordConsole.WriteMenuToConsole();

                int menu;

                menu = validator.ReadMenuChoice(1);

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
            InputValidator validator = new InputValidator();
            Product prod = new Product();
            Record record = new Record();
            int choice, expirationValue, expirationDays = 0;
            bool good;
            string name, producer, currencyName;
            double price, exRate;
            int quantity, weight;


            name = validator.ReadValue("Назва товару: ", "");
           
            price = validator.ReadValue("Ціна одиниці (USD): ", 0.0);
            
            quantity = validator.ReadValue("Кількість товару: ", 0);
            
            producer = validator.ReadValue("Компанія-виробник: ", "");
            
            weight = validator.ReadValue("Вага товару (кг): ", 0);

            currencyName = validator.ReadValue("Назва валюти: ", "");
            
            exRate = validator.ReadValue("Курс валюти до UAH: ", 0.0);

            choice = validator.ReadExpirationDate(0);

            expirationValue = validator.ReadValue("Введіть значення терміну: ", 0);
            
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
