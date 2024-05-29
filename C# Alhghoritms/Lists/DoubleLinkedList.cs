using System;

namespace C__Alhghoritms.Lists
{
    public class DoubleLinkedList
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
        /// Добавляет элемент в отсортированный двусвязный список
        /// </summary>
        /// <param name="data">Данные для добавления</param>
        public void Add(string data)
        {
            // Сложность: O(n), где n - размер списка
            var newNode = new Node(data);

            Node? previous = null;
            if (IsEmpty())
            {
                First = newNode;
                Last = newNode;
            }
            else
            {
                var current = First;

                while (current != null && string.Compare(current.Data, data) < 0)
                {
                    previous = current;
                    current = current.NextNode;
                }

                if (previous == null)
                {
                    // Вставка в начало списка
                    newNode.NextNode = First;
                    First!.PreviousNode = newNode;
                    First = newNode;
                }
                else if (current == null)
                {
                    // Вставка в конец списка
                    previous.NextNode = newNode;
                    newNode.PreviousNode = previous;
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
            var current = First;
            while (current != null)
            {
                Console.Write(current.Data + " ");
                current = current.NextNode;
            }

            Console.WriteLine();
        }
    }
}
