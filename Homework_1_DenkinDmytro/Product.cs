using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Homework_1_DenkinDmytro
{
	// TODO: Додати перевірку даних в `set` -- ціна, вага
    public class Product
    {
		// protected -- for future children to inherit
		protected string _name;

		// decimal is used for financial calculations
		private decimal _price;
		private double _weight;

		public double Weight
		{
			get { return _weight; }
			set { _weight = value; }
		}

		public decimal Price
		{
			get { return _price; }
			set { _price = value; }
		}

		public string Name
		{
			get { return _name; }
			set { _name = value; }
		}

		public Product(string name, decimal price, double weight)
		{
			_name = name;
			_price = price;
			_weight = weight;
		}

		public override string ToString()
		{
			return $"Product:\n" +
                $"\tName: {_name},\n" +
                $"\tPrice: {_price},\n" +
                $"\tWeight: {_weight}";
		}
	}
}
