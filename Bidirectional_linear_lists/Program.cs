using System;
using ClassLibrary;

namespace Bidirectional_linear_lists
{
    //20.Удалить элементы списка, имеющие равных соседей.
    //Под соседями понимаются элементы, находящиеся перед и после текущего элемента.

    //34. Создать метод, передать туда 2 списка.
    //Отсортировать их.
    //Например: входные данные: списки 1 5 12 23 35 и 2 3 10 15, - выходные - список 1 2 3 5 10 12 15 23 35.

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

        /// <summary>
        /// Удаление элементов списка, имеющих равных соседей.
        /// </summary>
        /// <param name="list">Обрабатываемый список.</param>
        public static void DeleteBetweenEquel(MyList<int> list)
        {
            if (list.Count < 3)
            {
                return;
            }

            MyList<int>.Element current = list.Head.Next;
            MyList<int>.Element beforeCurrent = list.Head;

            while (current != null)
            {
                if ((current.Next != null) && (current.Previous.Val == current.Next.Val))
                {
                    beforeCurrent.Next = current.Next;
                }

                else
                {
                    current.Previous = beforeCurrent;
                    beforeCurrent = current;
                }

                current = current.Next;
            }
        }

        /// <summary>
        /// Сортировка малых списков по возрастанию, их объединение и сортировка общего списка.
        /// </summary>
        /// <param name="L1">Малый список № 1.</param>
        /// <param name="L2">Малый список № 2.</param>
        /// <returns>Объединённый отсортированный по возрастанию список.</returns>
        public static MyList<int> SortASCUnited(MyList<int> L1, MyList<int> L2)
        {
            MyList<int> L = new MyList<int>();

            SortASC(L1);
            SortASC(L2);

            for (int i = 1; i <= L1.Count; i++)
            {
                L.AddToEnd(L1.GetValue(i));
            }

            for (int i = 1; i <= L2.Count; i++)
            {
                L.AddToEnd(L2.GetValue(i));
            }

            SortASC(L);

            return L;
        }

        /// <summary>
        /// Сортировка списка по возрастанию.
        /// </summary>
        /// <param name="list">Сортируемый список.</param>
        public static void SortASC(MyList<int> list)
        {
            int draggedValue;

            //Сортировка методом прямой вставки.
            for (int i = 2; i <= list.Count; i++)
            {
                for (int j = i; (j > 1) && (list.GetValue(j - 1) > list.GetValue(j)); j--)
                {
                    draggedValue = list.GetValue(j);

                    list.DeleteAfter(j - 1);

                    list.AddBefore(j - 1, draggedValue);
                }
            }
        }

        static void Main()
        {
            string enterValue = "Введите значение элемента (целое число):";
            string enterNumber = "Введите номер элемента (начиная с 1):";
            string nothingToDelete = "Список пуст - удалять нечего.";
            string mainWorkingList = "Основной рабочий список: ";
            string listL1 = "Список L1: ";
            string listL2 = "Список L2: ";
            string listL = "Список L : ";
            string empty = "[Пуст.]";

            MyList<int> list = new MyList<int>();
            MyList<int> L1 = new MyList<int>();
            MyList<int> L2 = new MyList<int>();
            MyList<int> L = new MyList<int>();

            int commandNumber;
            int countBefore; //Количество элементов в списке до манипуляций (используется в команде 12. Удаление элементов списка, имеющих равных соседей.)
            int elementNumber;
            int amount; //Количество элементов в создаваемых малых списках (используется в команде 13. Создать возрастающий список из 2 др.)
            int N;

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
                Console.WriteLine("11.Удаление элемента после заданного");
                Console.WriteLine("12.Удаление элементов списка, имеющих равных соседей.");
                Console.WriteLine("13.Создать возрастающий список из 2 др.\n");

                if (list.Count == 0)
                {
                    Console.WriteLine(mainWorkingList + empty + "\n");
                }

                else
                {
                    Console.WriteLine(mainWorkingList + list.ToString() + "\n");
                }

                if (L.Count != 0)
                {
                    if (L1.Count == 0)
                    {
                        Console.WriteLine(listL1 + empty + "\n");
                    }

                    else
                    {
                        Console.WriteLine(listL1 + L1.ToString() + "\n");
                    }

                    if (L2.Count == 0)
                    {
                        Console.WriteLine(listL2 + empty + "\n");
                    }

                    else
                    {
                        Console.WriteLine(listL2 + L2.ToString() + "\n");
                    }

                    Console.WriteLine(listL + L.ToString() + "\n");
                }

                commandNumber = InputInteger("Введите номер команды (1 - 13):");

                switch (commandNumber)
                {
                    case 1:
                        N = InputInteger(enterValue);

                        list.AddToBegin(N);

                        Console.WriteLine("Элемент со значением " + N + " добавлен в начало списка.");

                        break;
                    case 2:
                        N = InputInteger(enterValue);

                        list.AddToEnd(N);

                        Console.WriteLine("Элемент со значением " + N + " добавлен в конец списка.");

                        break;
                    case 3:
                        list.OutputConsoleForwardReverseOrder();

                        break;
                    case 4:
                        if (list.Count == 0)
                        {
                            Console.WriteLine("[Список пуст - искать не из чего.]");
                        }

                        else
                        {
                            N = InputInteger(enterValue);
                            bool isElement = list.IsElement(N);

                            if (isElement)
                            {
                                Console.WriteLine("Элемент со значением " + N + " есть.");
                            }

                            else
                            {
                                Console.WriteLine("Нет элемента со значением " + N + ".");
                            }
                        }

                        break;
                    case 5:
                        if (list.Count == 0)
                        {
                            Console.WriteLine("[Список пуст - искать не из чего.]");
                        }

                        else
                        {
                            try
                            {
                                elementNumber = InputInteger(enterNumber);
                                int a = list.GetValue(elementNumber);

                                Console.WriteLine("Значение элемента под номером " + elementNumber + ": " + a);
                            }

                            catch (IndexOutOfRangeException exc)
                            {
                                Console.WriteLine(exc.Message);
                            }
                        }

                        break;
                    case 6:
                        if (list.Count == 0)
                        {
                            Console.WriteLine("[Список пуст - нет элементов, перед которыми можно добавить новый элемент.]");
                        }

                        else
                        {
                            elementNumber = InputInteger(enterNumber);
                            N = InputInteger(enterValue);

                            try
                            {
                                list.AddBefore(elementNumber, N);

                                Console.WriteLine("Элемент со значением " + N + " добавлен перед элементом с номером " + elementNumber + ".");
                            }

                            catch (IndexOutOfRangeException exc)
                            {
                                Console.WriteLine(exc.Message);
                            }
                        }

                        break;
                    case 7:
                        if (list.Count == 0)
                        {
                            Console.WriteLine("[Список пуст - нет элементов, после которых можно добавить новый элемент.]");
                        }

                        else
                        {
                            elementNumber = InputInteger(enterNumber);
                            N = InputInteger(enterValue);

                            try
                            {
                                list.AddAfter(elementNumber, N);

                                Console.WriteLine("Элемент со значением " + N + " добавлен после элемента с номером " + elementNumber + ".");
                            }

                            catch (IndexOutOfRangeException exc)
                            {
                                Console.WriteLine(exc.Message);
                            }
                        }

                        break;
                    case 8:
                        if (list.Count == 0)
                        {
                            Console.WriteLine(nothingToDelete);
                        }

                        else
                        {
                            list.DeleteFromBegin();

                            Console.WriteLine("Элемент удалён из начала списка.");
                        }

                        break;
                    case 9:
                        if (list.Count == 0)
                        {
                            Console.WriteLine(nothingToDelete);
                        }

                        else
                        {
                            list.DeleteFromEnd();

                            Console.WriteLine("Элемент удалён из конца списка.");
                        }

                        break;
                    case 10:
                        if (list.Count == 0)
                        {
                            Console.WriteLine(nothingToDelete);
                        }

                        else
                        {
                            elementNumber = InputInteger(enterNumber);

                            if (elementNumber == 1)
                            {
                                Console.WriteLine("Выбран " + elementNumber + " элемент - перед ним нечего удалять.");
                            }

                            else
                            {
                                try
                                {
                                    list.DeleteBefore(elementNumber);

                                    Console.WriteLine("Элемент, находящийся перед элементом с номером " + elementNumber + ", удалён.");
                                }

                                catch (IndexOutOfRangeException exc)
                                {
                                    Console.WriteLine(exc.Message);
                                }
                            }
                        }

                        break;
                    case 11:
                        if (list.Count == 0)
                        {
                            Console.WriteLine(nothingToDelete);
                        }

                        else
                        {
                            elementNumber = InputInteger(enterNumber);

                            if (elementNumber == list.Count)
                            {
                                Console.WriteLine("Выбран " + elementNumber + " элемент - после него нечего удалять.");
                            }

                            else
                            {
                                try
                                {
                                    list.DeleteAfter(elementNumber);

                                    Console.WriteLine("Элемент, находящийся после элемента с номером " + elementNumber + ", удалён.");
                                }

                                catch (IndexOutOfRangeException exc)
                                {
                                    Console.WriteLine(exc.Message);
                                }
                            }
                        }

                        break;
                    case 12:
                        if (list.Count == 0)
                        {
                            Console.WriteLine(nothingToDelete);
                        }

                        else
                        {
                            countBefore = list.Count;

                            DeleteBetweenEquel(list);

                            if (countBefore == list.Count)
                            {
                                Console.WriteLine("Элементов с равными соседями нет - ничего не удалено.");
                            }

                            else
                            {
                                Console.WriteLine("Элементы списка, имеющие равных соседей, удалены.");
                            }
                        }

                        break;
                    case 13:
                        do
                        {
                            amount = InputInteger("Введите количество элементов 1 малого списка:");
                        }
                        while (amount < 0);

                        while (L1.Count != 0)
                        {
                            L1.DeleteFromEnd();
                        }

                        for (int i = 1; i <= amount; i++)
                        {
                            L1.AddToEnd(InputInteger("Введите значение номер " + i + ": "));
                        }

                        do
                        {
                            amount = InputInteger("Введите количество элементов 2 малого списка:");
                        }
                        while (amount < 0);

                        while (L2.Count != 0)
                        {
                            L2.DeleteFromEnd();
                        }

                        for (int i = 1; i <= amount; i++)
                        {
                            L2.AddToEnd(InputInteger("Введите значение номер " + i + ": "));
                        }

                        if ((L1.Count == 0) && (L2.Count == 0))
                        {
                            while (L.Count != 0)
                            {
                                L.DeleteFromEnd();
                            }

                            Console.WriteLine("Новый список не создан - оба малых списка пусты.");
                        }

                        else
                        {
                            L = SortASCUnited(L1, L2);

                            Console.WriteLine("Создан возрастающий список из 2 др.");
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
