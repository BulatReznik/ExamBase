using System;

namespace C__Alhghoritms.Lists
{
    public class CircularLinkedList
    {
        public Node? First { get; private set; }
        public Node? Last { get; private set; }

        /// <summary>
        /// Проверяет, пуст ли список
        /// </summary>
        /// <returns>true, если список пуст, иначе false</returns>
        public bool IsEmpty()
        {
            // Сложность: O(1)
            return First == null;
        }

        /// <summary>
        /// Добавляет элемент в отсортированный циклический список
        /// </summary>
        /// <param name="data">Данные для добавления</param>
        public void Add(string data)
        {
            // Сложность: O(n), где n - размер списка
            var newNode = new Node(data);

            if (IsEmpty())
            {
                First = newNode;
                Last = newNode;
                First.NextNode = First;
                First.PreviousNode = First;
            }
            else
            {
                var current = First;
                Node? previous = null;

                do
                {
                    if (string.Compare(current!.Data, data) > 0)
                    {
                        break;
                    }
                    previous = current;
                    current = current.NextNode;
                }
                while (current != First);

                if (previous == null)
                {
                    // Вставка в начало списка
                    newNode.NextNode = First;
                    newNode.PreviousNode = Last;
                    First!.PreviousNode = newNode;
                    Last!.NextNode = newNode;
                    First = newNode;
                }
                else if (current == First)
                {
                    // Вставка в конец списка
                    previous.NextNode = newNode;
                    newNode.PreviousNode = previous;
                    newNode.NextNode = First;
                    First!.PreviousNode = newNode;
                    Last = newNode;
                }
                else
                {
                    // Вставка в середину списка
                    previous.NextNode = newNode;
                    newNode.PreviousNode = previous;
                    newNode.NextNode = current;
                    current.PreviousNode = newNode;
                }
            }
        }

        /// <summary>
        /// Выводит элементы списка на консоль
        /// </summary>
        public void PrintList()
        {
            // Сложность: O(n), где n - размер списка
            if (IsEmpty())
            {
                Console.WriteLine("List is empty.");
                return;
            }

            var current = First;
            do
            {
                Console.Write(current!.Data + " ");
                current = current.NextNode;
            }
            while (current != First);

            Console.WriteLine();
        }
    }
}
