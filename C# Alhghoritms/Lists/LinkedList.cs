using System;

namespace C__Alhghoritms.Lists
{
    internal class LinkedList
    {
        public Node? firstNode;

        /// <summary>
        /// Добавляет элемент в отсортированный односвязный список
        /// </summary>
        /// <param name="value">Данные для добавления</param>
        public void Add(string value)
        {
            // Сложность: O(n), где n - размер списка
            var newNode = new Node(value);

            if (firstNode == null)
            {
                // Если список пустой, добавляем первый элемент
                firstNode = newNode;
            }
            else
            {
                Node? currentNode = firstNode;
                Node? previousNode = null;

                // Поиск позиции для вставки
                while (currentNode != null && string.Compare(currentNode.value, value) < 0)
                {
                    previousNode = currentNode;
                    currentNode = currentNode.nextNode;
                }

                if (previousNode == null)
                {
                    // Вставка в начало списка
                    newNode.nextNode = firstNode;
                    firstNode = newNode;
                }
                else
                {
                    // Вставка между previousNode и currentNode
                    previousNode.nextNode = newNode;
                    newNode.nextNode = currentNode;
                }
            }
        }

        /// <summary>
        /// Выводит элементы списка на консоль
        /// </summary>
        public void PrintList()
        {
            // Сложность: O(n), где n - размер списка
            Node? currentNode = firstNode;
            while (currentNode != null)
            {
                Console.Write(currentNode.value + " ");
                currentNode = currentNode.nextNode;
            }
            Console.WriteLine();
        }

        public class Node
        {
            public string value;
            public Node? nextNode;

            public Node(string value)
            {
                this.value = value;
                nextNode = null;
            }
        }
    }
}
