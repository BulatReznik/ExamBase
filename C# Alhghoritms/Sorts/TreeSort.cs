namespace C__Algorithms.Sorts
{
    internal class TreeSort
    {
        // Сортирует массив, используя алгоритм TreeSort.
        // Сложность: O(n log n) в среднем случае, O(n^2) в худшем случае.
        public int[] Sort(int[] array)
        {
            var tree = new BTree();

            // Добавляем все элементы массива в дерево.
            // Вставка каждого элемента в среднем занимает O(log n), поэтому для всех элементов O(n log n).
            foreach (var item in array)
            {
                tree.Add(item);
            }

            var sortedList = new List<int>();
            // Обход дерева (InOrder Traversal) для получения отсортированного списка.
            // Сложность: O(n), так как каждый элемент посещается один раз.
            tree.InOrderTraversal(tree.Root, sortedList);

            // Преобразование списка в массив.
            // Сложность: O(n).
            return sortedList.ToArray();
        }

        // Класс, представляющий узел двоичного дерева поиска (BST).
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

        // Класс, представляющий само двоичное дерево поиска (BST).
        public class BTree
        {
            public Node? Root { get; private set; }

            // Добавляет новое значение в дерево.
            // Сложность: O(log n) в среднем случае, O(n) в худшем случае (если дерево вырождено).
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

            // Выполняет обход дерева в порядке возрастания (InOrder Traversal).
            // Сложность: O(n), так как каждый узел посещается один раз.
            public void InOrderTraversal(Node? node, ICollection<int> sortedList)
            {
                if (node == null)
                    return;

                InOrderTraversal(node.LeftNode, sortedList);
                sortedList.Add(node.Value);
                InOrderTraversal(node.RightNode, sortedList);
            }

            // Удаляет значение из дерева.
            // Сложность: O(log n) в среднем случае, O(n) в худшем случае.
            public bool Remove(int value)
            {
                Root = Remove(Root, value);
                return Root != null;
            }

            // Рекурсивный метод для удаления узла.
            // Сложность: O(log n) в среднем случае, O(n) в худшем случае.
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

            // Находит минимальное значение в дереве.
            // Сложность: O(log n) в среднем случае, O(n) в худшем случае.
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

            // Выводит значения дерева в порядке возрастания.
            // Сложность: O(n), так как каждый узел посещается один раз.
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
