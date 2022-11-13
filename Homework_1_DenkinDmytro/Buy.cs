using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Homework_1_DenkinDmytro
{// Покупка може містити кілька Product. Чому, коли Ви можете міняти будь-коли Product зміна кількості можлива тільки через конструктор?
	// >> Ок. Дозволив зміну кількості. Заборонив змінювати Product будь-коли, тільки у конструкторі.
    public class Buy
    {
		private readonly Product _product;

        private uint _quantity;

		public uint Quantity
        {
			get { return _quantity; }
			set { _quantity = value; }
		}

        // TODO: Щоб не порушувати інкапусуляцію, бажано повертати копію посилальних типів
		// It is better to return a copy of the reference type to avoid nasty side effects
        public Product Product
		{
			get
			{
				return new Product(_product.Name, _product.Price, _product.Weight);
			}
		}

		// TODO: Якщо конструктор приймає клас, використовувати копіювання?
		public Buy(Product product, uint quantity)
		{
			_product = product;
			_quantity = quantity;
		}

        public decimal TotalPrice()
        {
            return _product.Price * _quantity;
        }

        public override string ToString()
		{
			return $"Buy:\n" +
				$"\t{_product},\n" +
				$"\tQuantity: {_quantity},\n" +
				$"\tTotal Price: {TotalPrice()}";
        }

		public override bool Equals(object? obj)
		{
			return obj is Buy buy &&
				   EqualityComparer<Product>.Default.Equals(_product, buy._product) &&
				   _quantity == buy._quantity;
		}

		public override int GetHashCode()
		{
			return HashCode.Combine(_product, _quantity);
		}
	}
}
