namespace ShopDb
{
    internal class Program
    {
        static void Main(string[] args)
        {
            ShopDbContex contex = new ShopDbContex();


            foreach (var f in contex.Products)
            {
                Console.WriteLine($"Name : {f.Name}");
            }
        }
    }
}