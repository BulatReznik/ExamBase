using System;

namespace C__Alhghoritms.Lists
{
    public class DoubleLinkedList
    {
        public Node? First { get; private set; }
        public Node? Last { get; private set; }

        public bool IsEmpty()
        {
            return First == null;
        }

        public void Add(string data)
        {
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

        public void PrintList()
        {
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