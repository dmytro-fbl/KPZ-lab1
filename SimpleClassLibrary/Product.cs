using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace SimpleClassLibrary
{
    public class Product
    {
        protected string _name;
        protected double _price;
        protected int _quantity;
        protected string _produser;
        protected double _weight;
        protected Currency _cost;
        protected int _expirationDays;

        public int ExpirationInDays => ExpirationDays;
        public int ExpirationInMonths => ExpirationDays / 30;
        public int ExpirationInYears => ExpirationDays / 365;


        public string Name
        {
            get { return _name; }
            set
            {
                if (value == null || value.Length == 0)
                    throw new Exception("Не вказана назва товару");
                _name = value;
            }
        }
        public double Price
        {
            get { return _price; }
            set
            {
                if (value < 0)
                    throw new Exception("Невірна ціна");
                _price = value;
            }
        }
        public int Quantity
        {
            get { return _quantity; }
            set
            {
                if (value < 0) 
                    throw new Exception("Невірна кількість товару");
                _quantity = value;
            }
        }
        public string Produser
        {
            get { return _produser; }
            set
            {
                if (value == null || value.Length == 0)
                    throw new Exception("Не вказана назва компанії-розробника");
                _produser = value;
            }
        }
        public double Weight
        {
            get { return _weight; }
            set
            {
                if (value < 0)
                    throw new Exception("Невірна вага товару");
                _weight = value;
            }
        }

        public Currency Cost
        {
            get { return _cost; }
            set
            {
                if (value == null) 
                    throw new Exception("Валюта не може бути 0");
                _cost = value;
            }
        }

        public int ExpirationDays
        {
            get { return _expirationDays; }
            set
            {
                if (value < 0) 
                    throw new Exception("Невірний термін придатності");

                _expirationDays = value;
            }
        }
        public int ExpirationMonths
        {
            get { return _expirationDays; }
            set
            {
                if (value < 0) throw new Exception("Невірний термін придатності");
                _expirationDays = value * 30;
            }
        }

        public int ExpirationYears
        {
            get{ return _expirationDays; }

            set
            {
                if (value < 0) throw new Exception("Невірний термін придатності");
                    _expirationDays = value * 365;
            }
        }




        public Product()
        {
            Name = " ";
            Price = 0;
            Produser = "Unknown";
            Weight = 0;
            Cost = new Currency();
            ExpirationDays = 1;
        }

        public Product(string name, double price, int quantity, string produser, double weight, Currency cost, int days)
        {
            Name = name;
            Price = price;
            Quantity = quantity;
            Produser = produser;
            Weight = weight;
            Cost = cost;
            ExpirationDays = days;
        }

        public Product(string name, double price, int quantity, double weight, Currency cost)
        {
            Name = name;
            Price = price;
            Quantity = quantity;
            Weight = weight;
            Cost = cost;
        }
        public Product(Product other)
        {
            Name = other.Name;
            Price = other.Price;
            Quantity = other.Quantity;
            Produser = other.Produser;
            Weight = other.Weight;
            Cost = other.Cost;
            ExpirationDays = other.ExpirationDays;
        }
        
        public double GetPriceInUAH()
        {
            if (Cost == null)
                throw new Exception("Ви не ввели ще валюту");
            return Price * Cost.ExRate;
        }
        public double GetTotalPriceInUAH(Product[] products)
        {
            double totalSumInUAH = 0;
            if (Cost == null)
                throw new Exception("Ви не ввели ще валюту");
            foreach (var product in products)
            {
                if (product.Cost == null)
                    throw new Exception("Ви не ввели ще валюту");
                double totalPrice = product.Price * product.Quantity * product.Cost.ExRate;
                totalSumInUAH += totalPrice;
            }
            return totalSumInUAH;
        }
        public double GetTotalWeight(Product[] weights)
        {
            double allWeights = 0;
            foreach (var weight in weights)
            {
                double totalWeight = weight.Weight * weight.Quantity;
                allWeights += totalWeight;
            }
            return allWeights;
        }
        
    }
}
