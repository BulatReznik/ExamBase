namespace C__Alhghoritms.Sorts
{
    internal class TreeSort
    {
        public List<int> Sort(List<int> list)
        {
            var tree = new BTree();

            // Добавляем все элементы списка в дерево
            foreach (var item in list)
            {
                tree.Add(item);
            }

            var sortedList = new List<int>();
            tree.InOrderTraversal(tree.Root, sortedList);

            return sortedList;
        }

        public class Node
        {
            public int Value { get; set; }
            public Node? LeftNode { get; set; }
            public Node? RightNode { get; set; }

            public Node(int value)
            {
                Value = value;
                LeftNode = null;
                RightNode = null;
            }
        }

        public class BTree
        {
            public Node? Root { get; private set; }

            public void Add(int newValue)
            {
                if (Root == null)
                {
                    Root = new Node(newValue);
                    return;
                }

                var current = Root;
                while (true)
                {
                    if (newValue < current.Value)
                    {
                        if (current.LeftNode == null)
                        {
                            current.LeftNode = new Node(newValue);
                            break;
                        }

                        current = current.LeftNode;
                    }
                    else
                    {
                        if (current.RightNode == null)
                        {
                            current.RightNode = new Node(newValue);
                            break;
                        }

                        current = current.RightNode;
                    }
                }
            }

            public void InOrderTraversal(Node? node, ICollection<int> sortedList)
            {
                if (node == null)
                    return;

                InOrderTraversal(node.LeftNode, sortedList);
                sortedList.Add(node.Value);
                InOrderTraversal(node.RightNode, sortedList);
            }

            public bool Remove(int value)
            {
                Root = Remove(Root, value);
                return Root != null;
            }

            private Node? Remove(Node? node, int value)
            {
                if (node == null) return node;

                if (value < node.Value)
                {
                    node.LeftNode = Remove(node.LeftNode, value);
                }
                else if (value > node.Value)
                {
                    node.RightNode = Remove(node.RightNode, value);
                }
                else
                {
                    if (node.LeftNode == null)
                        return node.RightNode;
                    if (node.RightNode == null)
                        return node.LeftNode;

                    node.Value = MinValue(node.RightNode);
                    node.RightNode = Remove(node.RightNode, node.Value);
                }

                return node;
            }

            private int MinValue(Node node)
            {
                var minValue = node.Value;
                while (node.LeftNode != null)
                {
                    minValue = node.LeftNode.Value;
                    node = node.LeftNode;
                }

                return minValue;
            }

            public void PrintTree(Node? node)
            {
                if (node == null) return;

                PrintTree(node.LeftNode);
                Console.Write(node.Value + " ");
                PrintTree(node.RightNode);
            }
        }
    }
}