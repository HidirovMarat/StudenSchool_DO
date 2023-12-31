﻿using WorkWithUser;

namespace Menu;

public class Menu
{
    private const string OPTIONAL_RERUN_MESSAGE = "1. Остаться (выполнить задачу снова) \n2. Вернуться в главное меню";
    private const int NUMBER_RUN_AGAIN = 1;
    private const int NUMBER_GO_BACK_TO_MAIN_MENU = 2;
    private const int NUMBER_EXIT = 0;

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

            int numberItem = InputCorrector.GetNumberFromUser(choiceNumber => (0 <= choiceNumber) && (choiceNumber < _information.Length + 1));

            if (numberItem == NUMBER_EXIT)
            {
                break;
            }

            SelectingMenuItem(numberItem - 1);
        }
    }

    private void PrintMainMenu()
    {
        DesignedMenu.WriteTextMenu("0. Выход");

        for (int i = 0; i < _information.Length; i++)
        {
            DesignedMenu.WriteTextMenu($"{i + 1}. {_information[i].GetInformation()}");
        }
    }

    private void SelectingMenuItem(int numberItem)
    {
        do
        {
            _information[numberItem].Operate();
        }
        while (Repeat());
    }

    private bool Repeat()
    {
        DesignedMenu.WriteTextMenu(OPTIONAL_RERUN_MESSAGE);

        int answer = InputCorrector.GetNumberFromUser(value => value == NUMBER_RUN_AGAIN || value == NUMBER_GO_BACK_TO_MAIN_MENU);

        return answer == NUMBER_RUN_AGAIN;
    }
}