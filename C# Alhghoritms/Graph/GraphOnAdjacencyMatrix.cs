using System;
using System.Collections.Generic;

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

        // Сложность метода: O(1)

        public void AddEdge(int v, int w)
        {
            // Сложность метода: O(1)
            _adjacencyMatrix[v, w] = 1;
            _adjacencyMatrix[w, v] = 1; // Для неориентированного графа
        }

        // Сложность метода: O(V^2), где V - количество вершин

        public void PrintMatrix()
        {
            // Сложность метода: O(V^2), где V - количество вершин
            for (int i = 0; i < _vertices; i++)
            {
                for (int j = 0; j < _vertices; j++)
                {
                    Console.Write(_adjacencyMatrix[i, j] + " ");
                }

                Console.WriteLine();
            }
        }

        // Сложность метода: O(V+E), где V - количество вершин, E - количество рёбер

        /// <summary>
        /// Метод для выполнения обхода в глубину (DFS)
        /// </summary>
        /// <param name="startVertex"></param>
        public void DFS(int startVertex)
        {
            // Сложность метода: O(V+E), где V - количество вершин, E - количество рёбер
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
            // Отметить текущую вершину как посещённую
            visited[vertex] = true;
            Console.Write(vertex + " ");

            // Получить все смежные вершины
            for (int i = 0; i < _vertices; i++)
            {
                if (_adjacencyMatrix[vertex, i] == 1 && !visited[i])
                {
                    DFSUtil(i, visited);
                }
            }
        }

        // Сложность метода: O(V+E), где V - количество вершин, E - количество рёбер

        /// <summary>
        /// Метод для выполнения обхода в ширину (BFS)
        /// </summary>
        /// <param name="startVertex"></param>
        public void BFS(int startVertex)
        {
            // Сложность метода: O(V+E), где V - количество вершин, E - количество рёбер
            bool[] visited = new bool[_vertices];
            Queue<int> queue = new();

            // Отметить начальную вершину как посещённую и добавить её в очередь
            visited[startVertex] = true;
            queue.Enqueue(startVertex);

            while (queue.Count > 0)
            {
                // Извлечь вершину из очереди и вывести её
                int vertex = queue.Dequeue();
                Console.Write(vertex + " ");

                // Получить все смежные вершины
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
