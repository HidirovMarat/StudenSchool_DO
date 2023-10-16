namespace Practice_1410
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello, World!");
        }

        public static string FooBar(int num)
        {
            if (num % 3 == 0 && num % 5 == 0)
                return "FooBar";
            if (num % 3 == 0)
                return "Foo";
            if (num % 5 == 0)
                return "Bar";
            return "";
        }
    }
}