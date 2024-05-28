namespace C__Alhghoritms.Graph
{
    public class GraphOnAdjacencyList
    {
        /// <summary>
        /// Количество вершин в графе
        /// </summary>
        private int _vertices;

        /// <summary>
        /// Список смежности для хранения рёбер графа
        /// </summary>
        private List<int>[] _adjacencyList;

        /// <summary>
        /// Конструктор для инициализации графа
        /// </summary>
        /// <param name="vertices">Количество вершин</param>
        public GraphOnAdjacencyList(int vertices)
        {
            _vertices = vertices;
            _adjacencyList = new List<int>[vertices];
            for (var i = 0; i < vertices; i++)
            {
                _adjacencyList[i] = new List<int>();
            }
        }

        /// <summary>
        /// Метод для добавления ребра в граф
        /// </summary>
        /// <param name="v">Начальная вершина</param>
        /// <param name="w">Конечная вершина</param>
        public void AddEdge(int v, int w)
        {
            _adjacencyList[v].Add(w);
        }

        /// <summary>
        /// Метод для выполнения обхода в глубину (DFS)
        /// </summary>
        /// <param name="startVertex">Начальная вершина</param>
        public void DFS(int startVertex)
        {
            bool[] visited = new bool[_vertices];
            DFSUtil(startVertex, visited);
        }

        /// <summary>
        /// Вспомогательный метод для рекурсивного выполнения обхода в глубину (DFS)
        /// </summary>
        /// <param name="vertex">Текущая вершина</param>
        /// <param name="visited">Массив посещённых вершин</param>
        private void DFSUtil(int vertex, bool[] visited)
        {
            // Отметить текущую вершину как посещённую
            visited[vertex] = true;
            Console.Write(vertex + " ");

            // Повторить для всех смежных вершин
            foreach (var adjacent in _adjacencyList[vertex])
            {
                if (!visited[adjacent])
                {
                    DFSUtil(adjacent, visited);
                }
            }
        }

        /// <summary>
        /// Метод для выполнения обхода в ширину (BFS)
        /// </summary>
        /// <param name="startVertex">Начальная вершина</param>
        public void BFS(int startVertex)
        {
            bool[] visited = new bool[_vertices];
            Queue<int> queue = new Queue<int>();

            // Отметить начальную вершину как посещённую и добавить её в очередь
            visited[startVertex] = true;
            queue.Enqueue(startVertex);

            while (queue.Count > 0)
            {
                // Извлечь вершину из очереди и вывести её
                int vertex = queue.Dequeue();
                Console.Write(vertex + " ");

                // Получить все смежные вершины, которые ещё не были посещены
                foreach (var adjacent in _adjacencyList[vertex])
                {
                    if (!visited[adjacent])
                    {
                        visited[adjacent] = true;
                        queue.Enqueue(adjacent);
                    }
                }
            }
        }
    }
}
