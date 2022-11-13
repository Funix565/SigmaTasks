namespace Homework_1_DenkinDmytro
{
    internal class Program
    {// Вітаю Вас. Поки що бачу тільки 1 завдання.
        // Не бачу використання класу Check.
        static void Main(string[] args)
        {
            Product p1 = new Product("Milk from brown cow", 70.99m, 900);
            Product p2 = new Product("Black bread", 20.99m, 500);
            Product p3 = new Product("Roshen biscuits", 35.50m, 777);

            Buy b1 = new Buy(p1, 20);
            Buy b2 = new Buy(p2, 100);
            Buy b3 = new Buy(p3, 15);

            Console.WriteLine(b1.TotalPrice());
            Console.WriteLine(b2.TotalPrice());
            Console.WriteLine(b3.TotalPrice());

            Console.WriteLine(p1);
            Console.WriteLine(p2);
            Console.WriteLine(p3);

            Console.WriteLine(b1);
            Console.WriteLine(b2);
            Console.WriteLine(b3);

            // Check class using
            Check.ProductInfo(p1);
            Check.BuyInfo(b1);

        }
    }
}
