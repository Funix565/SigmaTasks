using Homework_1_DenkinDmytro;

namespace Homework_3_DenkinDmytro
{
    public class UserMenu
    {
        private readonly Storage _storage;

        public UserMenu(Storage storage)
        {
            _storage = storage;
        }

        public void Display()
        {
            while (true)
            {
                Console.WriteLine("Interactive Mode");
                Console.WriteLine("1. Create Product");
                Console.WriteLine("2. Create Meat");
                Console.WriteLine("3. Create Diary Product");
                Console.WriteLine("4. Exit Interactive Mode");

                int option = 0;
                try
                {
                    option = Convert.ToInt32(Console.ReadLine());
                }
                catch (FormatException fe)
                {
                    throw fe;
                }

                if (option == 1)
                {
                    CreateProduct();
                }
                else if (option == 2)
                {
                    CreateMeat();
                }
                else if (option == 3)
                {
                    CreateDairyProduct();
                }
                else if (option == 4)
                {
                    return;
                }
            }
        }

        private void CreateProduct()
        {
            Console.WriteLine("Creating Product. Please, enter <Name; Price (decimal); Weight (double)");
            string input = Console.ReadLine() ?? "nothing";
            int expected = 3;

            if (!input.Equals("nothing"))
            {
                string[] tokens = input.Split(';', StringSplitOptions.TrimEntries | StringSplitOptions.RemoveEmptyEntries);
                if (tokens.Length != expected)
                {
                    throw new ArgumentException("Wrong input");
                }

                string pName = tokens[0];
                try
                {
                    decimal pPrice = Convert.ToDecimal(tokens[1]);
                    double pWeight = Convert.ToDouble(tokens[2]);

                    Product p = new Product(pName, pPrice, pWeight);

                    _storage.AddProduct(p);

                    Console.WriteLine("Successfully added to the storage");

                }
                catch (FormatException fe)
                {
                    throw fe;
                }
            }
        }

        private void CreateMeat()
        {
            Console.WriteLine("Creating Meat. Please, enter <Name; Price (decimal); Weight (double); " +
                "Category (High | SortOne | SortTwo); " +
                "Type (Lamb | Veal | Pork | Chicken)");
            string input = Console.ReadLine() ?? "nothing";
            int expected = 5;

            if (!input.Equals("nothing"))
            {
                string[] tokens = input.Split(';', StringSplitOptions.TrimEntries | StringSplitOptions.RemoveEmptyEntries);
                if (tokens.Length != expected)
                {
                    throw new ArgumentException("Wrong input");
                }

                string mName = tokens[0];
                try
                {
                    decimal mPrice = Convert.ToDecimal(tokens[1]);
                    double mWeight = Convert.ToDouble(tokens[2]);
                    string mCategory = tokens[3];
                    string mType = tokens[4];

                    // https://youtu.be/lBUFlJbNq-Q?t=1040
                    Meat.Category category = (Meat.Category)Enum.Parse(typeof(Meat.Category), mCategory, ignoreCase: false);
                    Meat.Type type = (Meat.Type)Enum.Parse(typeof(Meat.Type), mType, ignoreCase: false);

                    Meat m = new Meat(mName, mPrice, mWeight, category, type);

                    _storage.AddProduct(m);

                    Console.WriteLine("Successfully added to the storage");
                }
                catch (FormatException fe)
                {
                    throw fe;
                }
                catch (ArgumentException ae)
                {
                    throw ae;
                }
            }
        }

        private void CreateDairyProduct()
        {
            Console.WriteLine("Creating DairyProduct. Please, enter <Name; Price (decimal); Weight (double); Days (uint)");
            string input = Console.ReadLine() ?? "nothing";
            int expected = 4;

            if (!input.Equals("nothing"))
            {
                string[] tokens = input.Split(';', StringSplitOptions.TrimEntries | StringSplitOptions.RemoveEmptyEntries);
                if (tokens.Length != expected)
                {
                    throw new ArgumentException("Wrong input");
                }

                string dName = tokens[0];
                try
                {
                    decimal dPrice = Convert.ToDecimal(tokens[1]);
                    double dWeight = Convert.ToDouble(tokens[2]);
                    uint dBestDays = Convert.ToUInt32(tokens[3]);

                    DairyProduct dp = new DairyProduct(dName, dPrice, dWeight, dBestDays);

                    _storage.AddProduct(dp);

                    Console.WriteLine("Successfully added to the storage");
                }
                catch (FormatException fe)
                {
                    throw fe;
                }
            }
        }
    }
}
