namespace C__Alhghoritms.Graph
{
    public class GraphOnAdjacencyMatrix
    {
        private int[,] _adjacencyMatrix;
        private int _vertices;

        public GraphOnAdjacencyMatrix(int vertices)
        {
            _vertices = vertices;
            _adjacencyMatrix = new int[vertices, vertices];
        }

        public void AddEdge(int v, int w)
        {
            _adjacencyMatrix[v, w] = 1;
            _adjacencyMatrix[w, v] = 1; // Для неориентированного графа
        }

        public void PrintMatrix()
        {
            for (int i = 0; i < _vertices; i++)
            {
                for (int j = 0; j < _vertices; j++)
                {
                    Console.Write(_adjacencyMatrix[i, j] + " ");
                }

                Console.WriteLine();
            }
        }

        /// <summary>
        /// Метод для выполнения обхода в глубину (DFS)
        /// </summary>
        /// <param name="startVertex"></param>
        public void DFS(int startVertex)
        {
            bool[] visited = new bool[_vertices];
            DFSUtil(startVertex, visited);
        }

        /// <summary>
        /// Вспомогательный метод для рекурсивного выполнения обхода в глубину (DFS)
        /// </summary>
        /// <param name="vertex"></param>
        /// <param name="visited"></param>
        private void DFSUtil(int vertex, bool[] visited)
        {
            visited[vertex] = true;
            Console.Write(vertex + " ");

            for (int i = 0; i < _vertices; i++)
            {
                if (_adjacencyMatrix[vertex, i] == 1 && !visited[i])
                {
                    DFSUtil(i, visited);
                }
            }
        }

        /// <summary>
        /// Метод для выполнения обхода в ширину (BFS)
        /// </summary>
        /// <param name="startVertex"></param>
        public void BFS(int startVertex)
        {
            bool[] visited = new bool[_vertices];
            Queue<int> queue = new();

            visited[startVertex] = true;
            queue.Enqueue(startVertex);

            while (queue.Count > 0)
            {
                int vertex = queue.Dequeue();
                Console.Write(vertex + " ");

                for (int i = 0; i < _vertices; i++)
                {
                    if (_adjacencyMatrix[vertex, i] == 1 && !visited[i])
                    {
                        visited[i] = true;
                        queue.Enqueue(i);
                    }
                }
            }
        }
    }
}