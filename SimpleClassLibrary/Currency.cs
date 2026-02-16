using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimpleClassLibrary
{
    public class Currency
    {
        protected string Name;
        protected double ExRate;

        public Currency()
        {
            Name = "UAH";
            ExRate = 1.0;
        }
        public Currency(string name, double exRate)
        {
            SetName(name);
            SetExRate(exRate);
        }
        public Currency(string name)
        {
            SetName(name);
            ExRate = 1.0;
        }

        public Currency(Currency other)
        {
            Name = other.Name;
            ExRate = other.ExRate;
        }

        public void SetName(string name)
        {
            if (name == null || name.Length == 0)
                throw new Exception("Назва валюти пуста");
            Name = name;
        }
        public void SetExRate(double exRate)
        {
            if (exRate < 0)
                throw new Exception("Курс не може бути від'ємним");
            ExRate = exRate;
        }
        public string GetName()
        {
            return Name;
        }
        public double GetExRate()
        {
            return ExRate;
        }
    }
}
