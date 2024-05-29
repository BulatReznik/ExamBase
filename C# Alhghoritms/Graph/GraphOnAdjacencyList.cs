using System;
using System.Collections.Generic;

namespace C__Alhghoritms.Graph
{
    public class GraphOnAdjacencyList
    {
        private int _vertices;
        private List<int>[] _adjacencyList;

        public GraphOnAdjacencyList(int vertices)
        {
            _vertices = vertices;
            _adjacencyList = new List<int>[vertices];
            for (var i = 0; i < vertices; i++)
            {
                _adjacencyList[i] = new List<int>();
            }
        }

        // Сложность метода: O(1)

        public void AddEdge(int v, int w)
        {
            // Сложность метода: O(1)
            _adjacencyList[v].Add(w);
        }

        // Сложность метода: O(V+E), где V - количество вершин, E - количество рёбер

        public void DFS(int startVertex)
        {
            // Сложность метода: O(V+E), где V - количество вершин, E - количество рёбер
            bool[] visited = new bool[_vertices];
            DFSUtil(startVertex, visited);
        }

        // Вспомогательный метод для рекурсивного выполнения обхода в глубину (DFS)

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

        // Сложность метода: O(V+E), где V - количество вершин, E - количество рёбер

        public void BFS(int startVertex)
        {
            // Сложность метода: O(V+E), где V - количество вершин, E - количество рёбер
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
