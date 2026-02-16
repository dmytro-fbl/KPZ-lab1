using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimpleClassLibrary
{
    public class Product
    {
        protected string Name;
        protected double Price;
        protected int Quantity;
        protected string Produser;
        protected double Weight;
        protected Currency Cost;
        protected int ExpirationDays;

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
            SetName(name);
            SetPrice(price);
            SetQuantity(quantity);
            SetProduser(produser);
            SetWeight(weight);
            SetCost(cost);
            SetExpirationDays(days);
        }

        public Product(string name, double price, int quantity, double weight, Currency cost)
        {
            SetName(name);
            SetPrice(price);
            SetQuantity(quantity);
            SetWeight(weight);
            SetCost(cost);
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
        public void SetName(string name)
        {
            if (name == null || name.Length == 0)
                throw new Exception("Не вказана назва товару");
            Name = name;
        }
        public void SetPrice(double price)
        {
            if (Price < 0)
                throw new Exception("Невірна ціна");
            Price = price;
        }
        public void SetCost(Currency cost)
        {
            if (cost == null) throw new Exception("Валюта не може бути 0");
            Cost = cost;
        }
        public void SetQuantity(int quantity)
        {
            if (quantity < 0) throw new Exception("Невірна кількість товару");
            Quantity = quantity;
        }
        public void SetProduser(string produser)
        {
            if (produser == null || produser.Length == 0)
                throw new Exception("Не вказана назва компанії-розробника");
            Produser = produser;
        }
        public void SetWeight(double weight)
        {
            if (weight < 0) throw new Exception("Невірна вага товару");
            Weight = weight;
        }
        public void SetExpirationDays(int days)
        {
            if (days < 0) throw new Exception("Невірний термін придатності");
            ExpirationDays = days;
        }
        public void SetExpirationMonths(int months)
        {
            if (months < 0) throw new Exception("Невірний термін придатності");
            ExpirationDays = months * 30;
        }
        public void SetExpirationYears(int years)
        {
            if (years < 0) throw new Exception("Невірний термін придатності");
            ExpirationDays = years * 365;
        }


        public int ExpirationInDays => ExpirationDays;
        public int ExpirationInMonths => ExpirationDays / 30;
        public int ExpirationInYears => ExpirationDays / 365;



        public string GetName()
        {
            return Name;
        }
        public double GetPrice()
        {
            return Price;
        }
        public Currency GetCost()
        {
            return Cost;
        }
        public int GetQuantity()
        {
            return Quantity;
        }
        public string GetProducer()
        {
            return Produser;
        }
        public double GetWeight()
        {
            return Weight;
        }
        public double GetPriceInUAH()
        {
            if (Cost == null)
                throw new Exception("Ви не ввели ще валюту");
            return Price * Cost.GetExRate();
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
                double totalPrice = product.Price * product.Quantity * product.Cost.GetExRate();
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
