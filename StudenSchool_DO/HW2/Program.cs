﻿namespace HW2
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


/*
 * ## Реализовать команды:

1. Вывод на консоль заданного количества строк текста из файла. Файл сохранён локально. текст - любой, минимум на пару страниц. Количество строк для прочтения задаётся с консоли.
2. Вывод на консоль n-ного числа ряда Фибоначчи. n- порядковый номер числа, задаётся с консоли.
3. Запись кода web-страницы в файл. Файл размещается локально. Адрес страницы (URL) задаётся с консоли.

## Реализовать меню:

- Главное меню - появляется в консоли при запуске приложения, включает опции:
    - Чтение
    - Запись
    - Вывод числа Фибоначчи
    - Выход.
    При выборе одного из пунктов происходит переход в меню конкретной задачи. После выполнения конкретной задачи должен быть выбор:
    - Остаться (выполнить задачу снова)
    - Вернуться в главное меню.

    💡 Выбор пунктов меню осуществляется с помощью ввода цифр/символов.
- Цвета в консоли:
    - Текст меню - жёлтого цвета
    - Сообщения об ошибках - красного цвета
    - Служебные сообщения - синего цвета
    - Вывод результатов и всего остального - цвет по умолчанию
 */