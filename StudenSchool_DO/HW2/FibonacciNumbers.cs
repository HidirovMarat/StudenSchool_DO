namespace HW2
{
    internal class FibonacciNumbers : IInformation
    {
        private const string InformationMessage = "Вывод числа Фибоначчи";
        private const string MessagesOperation = "Введите порядковый номер числа Фибоначчи:";

        public string GetInformation()
        {
            return InformationMessage;
        }

        public uint GetFibonacciNumbers(uint ordinalNumber)
        {
            uint firstFibonacci = 1;
            uint secondFibonacci = 1;
            if (ordinalNumber == 1)
            {
                return firstFibonacci;
            }

            if (ordinalNumber == 2)
            {
                return secondFibonacci;
            }

            uint resultFibonacci = 0;
            for (uint i = 3; i < ordinalNumber + 1; i++)
            {
                if (uint.MaxValue - firstFibonacci < secondFibonacci)
                {
                    throw new Exception("Выход за uint.MaxValue");
                }

                resultFibonacci = firstFibonacci + secondFibonacci;
                (firstFibonacci, secondFibonacci) = (secondFibonacci, resultFibonacci);
            }

            return resultFibonacci;
        }

        public void Operation()
        {
            DesignedMenu.WriteTextMenu(MessagesOperation);
            uint ordinalNumberOfNumber = uint.Parse(Console.ReadLine());
            DesignedMenu.WriteTextMenu(GetFibonacciNumbers(ordinalNumberOfNumber).ToString());
        }
    }
}