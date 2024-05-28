using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace C__Alhghoritms.Lists
{

    public class CircularLinkedList
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

        public void PrintList()
        {
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
