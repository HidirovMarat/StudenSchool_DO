namespace HW2
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello, World!");
            try
            {
                IInformation[] information = { new FibonacciNumbers(), new FileToRead(), new WebsiteSave() };
                Menu menu = new(information);
                menu.MakeMain();
            }
            catch (Exception ex)
            {
                DesignMenu.WriteErrorMessages(ex.ToString());
            }
        }
    }
}