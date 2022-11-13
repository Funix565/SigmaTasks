using Homework_1_DenkinDmytro;

namespace Homework_3_DenkinDmytro
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Storage st = new Storage();
            st.InteractiveMode();
            st.PrintProductsInfo();

            st.DataItinialize();

            st.PrintProductsInfo();

            Check.ProductInfo(st[0]);
            Check.ProductInfo(st[1]);
        }
    }
}
