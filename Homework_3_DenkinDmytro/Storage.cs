using Homework_1_DenkinDmytro;

namespace Homework_3_DenkinDmytro
{
	public class Storage
	{
		// Use List<Product> instead of array[] to avoid maintaining the resizing
		private List<Product> _products;

		public List<Product> Products
		{
			// It is better to get/set a copy of the reference type to avoid nasty side effects
			get
			{
				List<Product> copyList = new List<Product>(_products.Count);
				foreach (Product p in _products)
				{
					Product product = new Product(p.Name, p.Price, p.Weight);
					copyList.Add(product);
				}

				return copyList;
			}
			set
			{
				_products = new List<Product>(value.Count);
				foreach (Product p in value)
				{
					Product product = new Product(p.Name, p.Price, p.Weight);
					_products.Add(product);
				}
			}
		}

		// Indexer
		public Product this[int index]
		{
			get
			{
				if (index < 0 || index >= _products.Count)
				{
                    // Even though List's index property throws Exceptions
                    // It is better to throw my own exception
                    // https://stackoverflow.com/q/2526434
                    throw new ArgumentOutOfRangeException("index", "The value of an index is outside the allowable range of values");
				}

				return _products[index];
			}
		}

		public Storage()
		{
			_products = new List<Product>();
		}

		public void AddProduct(Product p)
		{
			_products.Add(p);
		}

		public void InteractiveMode()
		{
			UserMenu um = new UserMenu(this);
			um.Display();
		}

		public void DataItinialize()
		{
			Product pr1 = new("Biscuits with chocolate", 86.30m, 140.02);
			Product pr2 = new("Cookies with nuts", 123.45m, 2501.03);

			Meat m1 = new("Fresh pork with bones and skin", 60.87m, 300.56, Meat.Category.SortTwo, Meat.Type.Pork);
			Meat m2 = new("Chicken legs and wings", 321.64m, 3478.81, Meat.Category.SortOne, Meat.Type.Chicken);

			DairyProduct dp1 = new("Quark with raisins", 47.65m, 510.03, 4);
			DairyProduct dp2 = new("Oat milk", 117.33m, 900.25, 10);

			_products.Add(pr1);
			_products.Add(pr2);
			_products.Add(m1);
			_products.Add(m2);
			_products.Add(dp1);
			_products.Add(dp2);
		}

		public void PrintProductsInfo()
		{
			foreach (Product p in _products)
			{
				Check.ProductInfo(p);
			}
		}

		public List<Meat> FindMeatProducts()
		{
			List<Meat> meatProducts = new List<Meat>();
			foreach (Product product in _products)
			{
				if (product is Meat)
				{
					meatProducts.Add((Meat)product);
				}
			}

			return meatProducts;
		}

		public void ChangeEveryProductPrice(decimal percent)
		{
			foreach (Product product in _products)
			{
				// This should call overriden implementation
				product.ChangePrice(percent);
			}
		}
	}
}
