using System;
using ClassLibrary;

namespace Bidirectional_linear_lists
{
    class Program
    {
        /// <summary>
        /// Ввод целого числа с клавиатуры.
        /// </summary>
        /// <param name="message">Сообщение для ввода</param>
        /// <returns>Целое число, введённое с клавиатуры</returns>
        public static int InputInteger(string message)
        {
            bool isParsed = false;

            int N = 0;

            while (!isParsed)
            {
                Console.WriteLine(message);

                isParsed = int.TryParse(Console.ReadLine(), out N);

                Console.WriteLine();
            }

            return N;
        }
        static void Main()
        {
            MyList<int> list = new MyList<int>();
            int commandNumber;

            do
            {
                Console.Clear();

                Console.WriteLine("1. Добавление элемента в начало списка");
                Console.WriteLine("2. Добавление элемента в конец списка");
                Console.WriteLine("3. Вывод списка на экран в прямом и обратном порядке");
                Console.WriteLine("4. Поиск элемента по его значению (возвращает bool)");
                Console.WriteLine("5. Поиск элемента по номеру (возвращает значение)");
                Console.WriteLine("6. Добавление элемента перед заданным");
                Console.WriteLine("7. Добавление элемента после заданного");
                Console.WriteLine("8. Удаление элемента из начала списка");
                Console.WriteLine("9. Удаление элемента из конца списка");
                Console.WriteLine("10.Удаление элемента перед заданным");
                Console.WriteLine("11.Удаление элемента после заданного\n");

                commandNumber = InputInteger("Введите номер команды (1 - 11):");

                switch (commandNumber)
                {
                    case 1:
                        list.AddToBegin(InputInteger("Введите значение элемента:"));

                        break;
                    case 2:
                        list.AddToEnd(InputInteger("Введите значение элемента:"));

                        break;
                    case 3:
                        list.OutputConsoleForwardReverseOrder();

                        break;
                    case 4:
                        bool isElement = list.IsElement(InputInteger("Введите значение элемента:"));

                        if (isElement)
                        {
                            Console.WriteLine("Такой элемент есть.");
                        }

                        else
                        {
                            Console.WriteLine("Нет такого элемента.");
                        }

                        break;
                    case 5:
                        try
                        {
                            int a = list.GetValue(InputInteger("Введите номер элемента (начиная с 1):"));

                            Console.WriteLine("Значение элемента: " + a);
                        }

                        catch (IndexOutOfRangeException exc)
                        {
                            Console.WriteLine(exc.Message);
                        }

                        break;
                    case 6:
                        try
                        {
                            list.AddBefore(InputInteger("Введите номер элемента (начиная с 1):"), InputInteger("Введите значение элемента:"));
                        }

                        catch (IndexOutOfRangeException exc)
                        {
                            Console.WriteLine(exc.Message);
                        }

                        break;
                    case 7:
                        try
                        {
                            list.AddAfter(InputInteger("Введите номер элемента (начиная с 1):"), InputInteger("Введите значение элемента:"));
                        }

                        catch (IndexOutOfRangeException exc)
                        {
                            Console.WriteLine(exc.Message);
                        }

                        break;
                    case 8:
                        list.DeleteFromBegin();

                        break;
                    case 9:
                        list.DeleteFromEnd();

                        break;
                    case 10:
                        try
                        {
                            list.DeleteBefore(InputInteger("Введите номер элемента (начиная с 1):"));
                        }

                        catch (IndexOutOfRangeException exc)
                        {
                            Console.WriteLine(exc.Message);
                        }

                        break;
                    case 11:
                        try
                        {
                            list.DeleteAfter(InputInteger("Введите номер элемента (начиная с 1):"));
                        }

                        catch (IndexOutOfRangeException exc)
                        {
                            Console.WriteLine(exc.Message);
                        }

                        break;
                    default:
                        Console.WriteLine("Нет такой команды.");

                        break;
                }

                System.Threading.Thread.Sleep(2000);
            }
            while (true);
        }
    }
}
