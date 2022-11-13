using Homework_1_DenkinDmytro;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Homework_3_DenkinDmytro
{
    public class DairyProduct : Product
    {
        private enum Discount
        {
            Small = 20,
            Medium = 50,
            High = 75
        }

        private uint _bestDays;

        public uint BestDays
        {
            get { return _bestDays; }
            set { _bestDays = value; }
        }

        public DairyProduct(string name, decimal price, double weight, uint bestDays) : base(name, price, weight)
        {
            _bestDays = bestDays;
        }

        public override void ChangePrice(decimal percent)
        {
            base.ChangePrice(percent);

            // Perishable goods
            if (_bestDays <= 2)
            {
                Price += Price * ((int)Discount.High / 100.0m);
            }
            else if (_bestDays <= 5)
            {
                Price += Price * ((int)Discount.Medium / 100.0m);
            }
            else
            {
                Price += Price * ((int)Discount.Small / 100.0m);
            }
        }

        public override string ToString()
        {
            return $"Product:\n" +
                $"\tName: {_name},\n" +
                $"\tPrice: {Price},\n" +
                $"\tWeight: {Weight} ,\n" +
                $"\tConsume for: {_bestDays} days";
        }

        public override bool Equals(object? obj)
        {
            return obj is DairyProduct product &&
                   base.Equals(obj) &&
                   _name == product._name &&
                   _bestDays == product._bestDays;
        }

        public override int GetHashCode()
        {
            return HashCode.Combine(base.GetHashCode(), _name, _bestDays);
        }
    }
}
