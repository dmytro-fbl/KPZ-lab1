using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace SimpleClassLibrary
{
    public class Currency
    {
        protected string _name;
        protected double _exRate;

        public string Name
        {
            get { return _name; }
            protected set
            {
                if (value == null || value.Length == 0)
                    throw new Exception("Назва валюти пуста");
                _name = value;
            }
        }
        public double ExRate
        {
            get { return _exRate; }
            protected set
            {
                if (value < 0)
                    throw new Exception("Курс не може бути від'ємним");
                _exRate = value;
            }
        }
        public Currency()
        {
            Name = "UAH";
            ExRate = 1.0;
        }
        public Currency(string name, double exRate)
        {
            Name = name;
            ExRate = exRate;
        }
        public Currency(string name)
        {
            Name = name;
            ExRate = 1.0;
        }

        public Currency(Currency other)
        {
            Name = other.Name;
            ExRate = other.ExRate;
        }
    }
}
