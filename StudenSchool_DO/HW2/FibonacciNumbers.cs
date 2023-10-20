namespace HW2
{
    internal class FibonacciNumbers : IInformation
    {
        private const string Information = "Вывод числа Фибоначчи";
        private const string MessagesOperation = "Введите порядковый номер числа Фибоначчи:";

        public FibonacciNumbers()
        {
        }

        public string GetInformation()
        {
            return Information;
        }

        public uint GetFibonacciNumbers(uint ordinalNumberOfNumber)
        {
            uint firstFibonacci = 1;
            uint secondFibonacci = 1;
            if (ordinalNumberOfNumber == 1)
                return firstFibonacci;

            if (ordinalNumberOfNumber == 2)
                return secondFibonacci;

            uint resultFibonacci = 0;
            for (uint i = 3; i < ordinalNumberOfNumber + 1; i++)
            {
                try
                {
                    resultFibonacci = checked(firstFibonacci + secondFibonacci);
                }
                catch(OverflowException overEx)
                {
                    throw overEx;
                }

                (firstFibonacci, secondFibonacci) = (secondFibonacci, resultFibonacci);
            }

            return resultFibonacci;
        }

        public void Operation()
        {
            DesignMenu.WriteTextMenu(MessagesOperation);
            uint ordinalNumberOfNumber = uint.Parse(Console.ReadLine());
            DesignMenu.WriteTextMenu(GetFibonacciNumbers(ordinalNumberOfNumber).ToString());
        }
    }
}