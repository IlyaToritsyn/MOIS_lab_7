using System;
using System.Collections;
using System.Collections.Generic;

namespace ClassLibrary
{
    /// <summary>
    /// Обобщённый класс для работы с двунаправленным линейным списком.
    /// </summary>
    /// <typeparam name="T">Тип данных</typeparam>
    public class MyList<T> : IEnumerable<T>
    {
        /// <summary>
        /// Класс элементов двунаправленного линейного списка.
        /// </summary>
        private class Element
        {
            /// <summary>
            /// След. элемент.
            /// </summary>
            public Element Next { get; set; }

            /// <summary>
            /// Пред. элемент.
            /// </summary>
            public Element Previous { get; set; }

            /// <summary>
            /// Значение элемента.
            /// </summary>
            public T Val { get; set; }

            public Element()
            {
                Val = default;
                Next = null;
                Previous = null;
            }

            public Element(T a)
            {
                Val = a;
                Next = null;
                Previous = null;
            }
        }

        Element head = null;
        Element last = null;

        /// <summary>
        /// Подсчёт количества элементов в деке.
        /// </summary>
        public int Count
        {
            get
            {
                int count;
                Element t = head;

                for (count = 0; t != null; count++)
                {
                    t = t.Next;
                }

                return count;
            }
        }

        /// <summary>
        /// Перебор элементов двунаправленного линейного списка.
        /// </summary>
        /// <returns>Элементы двунаправленного линейного списка.</returns>
        public IEnumerator<T> GetEnumerator()
        {
            var tmp = head;

            while (tmp != null)
            {
                yield return tmp.Val;

                tmp = tmp.Next;
            }
        }

        /// <summary>
        /// Поддержка интерфейса IEnumerable.
        /// </summary>
        /// <returns>Результат перебора элементов двунаправленного линейного списка.</returns>
        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }

        /// <summary>
        /// Возвращение строкового представления экземпляра класса.
        /// </summary>
        /// <returns>Строковое представление экземпляра класса.</returns>
        public override string ToString()
        {
            string str = "";

            if (head != null)
            {
                Element t = head;

                while (t != null)
                {
                    str += t.Val + "\t";
                    t = t.Next;
                }
            }

            return str;
        }

        /// <summary>
        /// Добавление элемента в начало списка.
        /// </summary>
        /// <param name="a">Значение элемента</param>
        public void AddToBegin(T a)
        {
            if (head == null)
            {
                Element newElement = new Element(a);
                head = newElement;
                last = head;
            }

            else
            {
                Element newElement = new Element(a)
                {
                    Next = head
                };
                head.Previous = newElement;
                head = newElement;
            }
        }

        /// <summary>
        /// Добавление элемента в конец списка
        /// </summary>
        /// <param name="a">Значение элемента</param>
        public void AddToEnd(T a)
        {
            if (head == null)
            {
                Element newElement = new Element(a);
                head = newElement;
                last = head;
            }

            else
            {
                Element newElement = new Element(a)
                {
                    Previous = last
                };
                last.Next = newElement;
                last = newElement;
            }
        }

        /// <summary>
        /// Вывод списка на экран в прямом и обратном порядке.
        /// </summary>
        public void OutputConsoleForwardReverseOrder()
        {
            string reversed = "";

            Console.WriteLine("Прямой порядок:");
            foreach (T element in this)
            {
                Console.Write(element + "\t");
                reversed = element + "\t" + reversed;
            }

            Console.WriteLine("\n\nОбратный порядок:\n" + reversed + "\n");
        }

        /// <summary>
        /// Поиск элемента по его значению (возвращает bool).
        /// </summary>
        /// <param name="a">Значение элемента</param>
        /// <returns>true - есть элемент, false - нет элемента</returns>
        public bool IsElement(T a)
        {
            Element p = head;

            while (p != null)
            {
                if (p.Val.Equals(a))
                {
                    return true;
                }

                p = p.Next;
            }

            return false;
        }

        /// <summary>
        /// Поиск элемента по номеру (возвращает значение).
        /// </summary>
        /// <param name="number">Номер элемента</param>
        /// <returns>Значение элемента</returns>
        public T GetValue(int number)
        {
            if (head != null)
            {
                Element p = head;
                int count = 1;

                while ((p.Next != null) && (count != number))
                {
                    p = p.Next;
                    count++;
                }

                if (count == number)
                {
                    return p.Val;
                }
            }

            throw new IndexOutOfRangeException("Обращение к элементу, находящемуся за пределами списка.");
        }

        /// <summary>
        /// Добавление элемента перед заданным.
        /// </summary>
        /// <param name="setNumber">Номер элемента</param>
        /// <param name="a">Значение добавляемого элемента</param>
        public void AddBefore(int setNumber, T a)
        {
            if (head != null)
            {

                Element newElement = new Element(a);
                Element p = head;
                Element q = head.Previous;

                int count = 1;

                while ((p.Next != null) && (count != setNumber))
                {
                    q = p;
                    p = p.Next;
                    count++;
                }

                if (count == setNumber)
                {
                    newElement.Next = p;

                    if (p != head)
                    {
                        newElement.Previous = q;
                        q.Next = newElement;
                    }

                    else
                    {
                        head = newElement;
                    }

                    p.Previous = newElement;

                    return;
                }
            }

            throw new IndexOutOfRangeException("Обращение к элементу, находящемуся за пределами списка.");
        }

        /// <summary>
        /// Добавление элемента после заданного
        /// </summary>
        /// <param name="setNumber">Номер элемента</param>
        /// <param name="a">Значение добавляемого элемента</param>
        public void AddAfter(int setNumber, T a)
        {
            if (head != null)
            {
                Element newElement = new Element(a);
                Element p = head;

                int count = 1;

                while ((p.Next != null) && (count != setNumber))
                {
                    p = p.Next;
                    count++;
                }

                if (count == setNumber)
                {
                    newElement.Next = p.Next;
                    newElement.Previous = p;
                    p.Next = newElement;

                    if (p == last)
                    {
                        last = newElement;
                    }

                    return;
                }
            }
            
            throw new IndexOutOfRangeException("Обращение к элементу, находящемуся за пределами списка.");
        }

        /// <summary>
        /// Удаление элемента из начала списка.
        /// </summary>
        public void DeleteFromBegin()
        {
            if (head != null)
            {
                if (head == last)
                {
                    head = null;
                    last = null;
                }

                else
                {
                    head.Next.Previous = null;
                    head = head.Next;
                }
            }
        }

        /// <summary>
        /// Удаление элемента из конца списка.
        /// </summary>
        public void DeleteFromEnd()
        {
            if (head != null)
            {
                if (head == last)
                {
                    head = null;
                    last = null;
                }

                else
                {
                    Element p = head;
                    Element q = p;

                    while (p.Next != null)
                    {
                        q = p;
                        p = p.Next;
                    }

                    q.Next = null;
                    last = q;
                }
            }
        }

        /// <summary>
        /// Удаление элемента перед заданным.
        /// </summary>
        /// <param name="setNumber">Номер элемента</param>
        public void DeleteBefore(int setNumber)
        {
            if (head != null)
            {
                Element p = head;

                int count = 1;

                while ((p.Next != null) && (count != setNumber))
                {
                    p = p.Next;

                    count++;
                }

                if (count == setNumber)
                {
                    if (p != head)
                    {
                        p.Previous = p.Previous.Previous;

                        if (p.Previous != null)
                        {
                            p.Previous.Next = p;
                        }

                        else
                        {
                            head = p;
                        }
                    }

                    return;
                }
            }

            throw new IndexOutOfRangeException("Обращение к элементу, находящемуся за пределами списка.");
        }

        /// <summary>
        /// Удаление элемента после заданного.
        /// </summary>
        /// <param name="setNumber">Номер элемента</param>
        public void DeleteAfter(int setNumber)
        {
            if (head != null)
            {
                Element p = head;

                int count = 1;

                while ((p.Next != null) && (count != setNumber))
                {
                    p = p.Next;

                    count++;
                }

                if (count == setNumber)
                {
                    if (p != last)
                    {
                        p.Next = p.Next.Next;
                        
                        if (p.Next != null)
                        {
                            p.Next.Previous = p;
                        }

                        else
                        {
                            last = p;
                        }
                    }

                    return;
                }
            }

            throw new IndexOutOfRangeException("Обращение к элементу, находящемуся за пределами списка.");
        }
    }
}
