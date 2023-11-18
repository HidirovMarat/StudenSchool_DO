using Services.Base;

namespace Menu;

public class Menu
{
    private const string OPTIONAL_RERUN_MESSAGE = "1. Остаться (выполнить задачу снова) \n2. Вернуться в главное меню";
    private const int NUMBER_RUN_AGAIN = 1;
    private const int NUMBER_GO_BACK_TO_MAIN_MENU = 2;
    private const int NUMBER_EXIT = 0;

    private IInformation[] _information;
    private IInputNumberService _inputNumberIntService;
    private IOutputService _outputOutputService;

    public Menu(IInputNumberService inputNumberInt, IOutputService outputOutputService, IInformation[] information)
    {
        _inputNumberIntService = inputNumberInt;
        _outputOutputService = outputOutputService;
        _information = information;
    }

    public void MakeMain()
    {
        while(true)
        {
            PrintMainMenu();

            int numberItem = _inputNumberIntService.GetNumberIntByCondition(choiceNumber => (0 <= choiceNumber) && (choiceNumber < _information.Length + 1));

            if (numberItem == NUMBER_EXIT)
            {
                break;
            }

            SelectingMenuItem(numberItem - 1);
        }
    }

    private void PrintMainMenu()
    {
        _outputOutputService.PrintTextMenu("0. Выход");

        for (int i = 0; i < _information.Length; i++)
        {
            _outputOutputService.PrintTextMenu($"{i + 1}. {_information[i].GetInformation()}");
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
        _outputOutputService.PrintTextMenu(OPTIONAL_RERUN_MESSAGE);

        int answer = _inputNumberIntService.GetNumberIntByCondition(value => value == NUMBER_RUN_AGAIN || value == NUMBER_GO_BACK_TO_MAIN_MENU);

        return answer == NUMBER_RUN_AGAIN;
    }
}