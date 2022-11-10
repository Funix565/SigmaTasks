using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Homework_1_DenkinDmytro
{// Покупка може містити кілька Product. Чому, коли Ви можете міняти будь-коли Product зміна кількості можлива тільки через конструктор?
    public class Buy
    {
		private Product _product;

        // readonly -- assume that we can't change the quantity in Buy
        private readonly int _quantity;

		public int Quantity
        {
			get { return _quantity; }
		}

		public Product Product
		{
			get { return _product; }
			set { _product = value; }
		}

		public decimal TotalPrice()
		{
			return _product.Price * _quantity;
		}

		public Buy(Product product, int quantity)
		{
			_product = product;
			_quantity = quantity;
		}

		public override string ToString()
		{
			return $"Buy:\n" +
				$"\t{_product},\n" +
				$"\tQuantity: {_quantity},\n" +
				$"\tTotal Price: {TotalPrice()}";
        }
	}
}
