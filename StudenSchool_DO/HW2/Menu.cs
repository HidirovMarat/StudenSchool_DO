namespace HW2
{
    internal class Menu
    {
        private const string UnderMenuMessages = "1. Остаться (выполнить задачу снова) \n2. Вернуться в главное меню";

        private IInformation[] _information;

        public Menu(IInformation[] information)
        {
            _information = information;
        }

        public void MakeMain()
        {
            while(true)
            {
                PrintMainMenu();
                int numberItem = GetChoiceNumber();
                if (numberItem == 0)
                    break;
                SelectingMenuItem(numberItem - 1);
            }
        }

        private void PrintMainMenu()
        {
            DesignMenu.WriteTextMenu("0. Выход");
            for (int i = 0; i < _information.Length; i++)
            {
                DesignMenu.WriteTextMenu($"{i + 1}. {_information[i].GetInformation()}");
            }
        }

        private int GetChoiceNumber()
        {
            int answer;
            while (!TryConvert(Console.ReadLine(), out answer))
            {
                DesignMenu.WriteServiceMessages("Введите правильно. Повторите");
            }

            return answer;
        }

        private void SelectingMenuItem(int numberItem)
        {
            while(true)
            {
                _information[numberItem].Operation();
                if(!DoYouWantToRepeat())
                    break;
            }
        }

        private bool TryConvert(string answerLine, out int answer)
        {
            if (int.TryParse(answerLine, out answer) && IsValid(answer))
                return true;

            return false;
        }

        private bool IsValid(int choiceNumber) => (0 <= choiceNumber) && (choiceNumber < _information.Length + 1);

        private bool DoYouWantToRepeat()
        {
            DesignMenu.WriteTextMenu(UnderMenuMessages);
            while (true)
            {
                string? answer = Console.ReadLine();
                if (answer == "1")
                    return true;
                if (answer == "2")
                    return false;
                DesignMenu.WriteServiceMessages("Такого нет числа. Повторите");
            }
        }
    }
}


//Выбор пунктов меню осуществляется с помощью ввода цифр/символов.
//- Цвета в консоли:
//    - Текст меню - жёлтого цвета
//    - Сообщения об ошибках - красного цвета
//    - Служебные сообщения - синего цвета
//    - Вывод результатов и всего остального - цвет по умолчанию
