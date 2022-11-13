namespace Homework_1_DenkinDmytro
{
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
			set
			{
				if (value > 0)
				{
					_weight = value;
				}
				else
				{
					throw new ArgumentException("A weight cannot be negative");
				}
			}
		}

		public decimal Price
		{
			get { return _price; }
			set
			{
				if (value > 0)
				{
					_price = value;
				}
				else
				{
					throw new ArgumentException("A price cannot be negative");
				}
			}
		}

		public string Name
		{
			get { return _name; }
			set { _name = value; }
		}

		public Product(string name, decimal price, double weight)
		{
			_name = name;
			Price = price;
			Weight = weight;
		}

        // Change the price by a given percent
        public virtual void ChangePrice(decimal percent)
        {
            Price += Price * (percent / 100.0m);
        }

        public override string ToString()
		{
			return $"Product:\n" +
				$"\tName: {_name},\n" +
				$"\tPrice: {_price},\n" +
				$"\tWeight: {_weight}";
		}

		public override bool Equals(object? obj)
		{
			return obj is Product product &&
				   _name == product._name &&
				   _price == product._price &&
				   _weight == product._weight;
		}

		public override int GetHashCode()
		{
			return HashCode.Combine(_name, _price, _weight);
		}
	}
}
