using Homework_1_DenkinDmytro;

namespace Homework_3_DenkinDmytro
{
    public class Meat : Product
    {
        // Відсотки, визначені як сталі нормативи складу, відповідно до категорії м'яса
        public enum Category
        {
            High = 10,
            SortOne = 25,
            SortTwo = 75
        }

        public enum Type
        {
            Lamb,
            Veal,
            Pork,
            Chicken
        }

        private Category _meatCategory;
        private Type _meatType;

        public Type MeatType
        {
            get { return _meatType; }
            set { _meatType = value; }
        }

        public Category MeatCategory
        {
            get { return _meatCategory; }
            set { _meatCategory = value; }
        }

        public Meat(string name, decimal price, double weight, Category category, Type type) : base(name, price, weight)
        {
            _meatCategory = category;
            _meatType = type;
        }

        // Change the price by a given percent
        // and 
        public override void ChangePrice(decimal percent)
        {
            base.ChangePrice(percent);

            switch (_meatCategory)
            {
                case Category.High:
                    Price += Price * ((int)Category.High / 100.0m);
                    break;
                case Category.SortOne:
                    Price += Price * ((int)Category.SortOne / 100.0m);
                    break;
                case Category.SortTwo:
                    Price += Price * ((int)Category.SortTwo / 100.0m);
                    break;
            }
        }

        public override string ToString()
        {
            return $"Meat:\n" +
                $"\tName: {_name},\n" +
                $"\tPrice: {Price},\n" +
                $"\tWeight: {Weight},\n" +
                $"\tCategory: {_meatCategory},\n" +
                $"\tType: {_meatType}";
        }

        public override bool Equals(object? obj)
        {
            return obj is Meat meat &&
                   base.Equals(obj) &&
                   _name == meat._name &&
                   _meatCategory == meat._meatCategory &&
                   _meatType == meat._meatType;
        }

        public override int GetHashCode()
        {
            return HashCode.Combine(base.GetHashCode(), _name, _meatCategory, _meatType);
        }
    }
}
