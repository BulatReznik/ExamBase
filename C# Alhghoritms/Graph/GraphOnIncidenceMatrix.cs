using System;
using System.Collections.Generic;

namespace C__Alhghoritms.Graph
{
    public class GraphOnIncidenceMatrix
    {
        /// <summary>
        /// Матрица инцидентности
        /// </summary>
        private int[,] _incidenceMatrix;

        /// <summary>
        /// Количество вершин
        /// </summary>
        private int _vertices;

        /// <summary>
        /// Количество рёбер
        /// </summary>
        private int _edges;

        /// <summary>
        /// Текущий индекс добавляемого ребра
        /// </summary>
        private int _currentEdge;

        /// <summary>
        /// Конструктор класса
        /// </summary>
        /// <param name="vertices">Количество вершин в графе</param>
        /// <param name="edges">Количество рёбер в графе</param>
        public GraphOnIncidenceMatrix(int vertices, int edges)
        {
            _vertices = vertices;
            _edges = edges;
            _incidenceMatrix = new int[vertices, edges];
            _currentEdge = 0;
        }

        // Сложность метода: O(1)

        // Метод для добавления ребра в граф
        public void AddEdge(int v, int w)
        {
            // Сложность метода: O(1)
            if (_currentEdge >= _edges) throw new InvalidOperationException("Все рёбра уже добавлены");

            _incidenceMatrix[v, _currentEdge] = 1;
            _incidenceMatrix[w, _currentEdge] = 1;
            _currentEdge++;
        }

        // Сложность метода: O(V*E), где V - количество вершин, E - количество рёбер

        public void PrintMatrix()
        {
            // Сложность метода: O(V*E), где V - количество вершин, E - количество рёбер
            for (int i = 0; i < _vertices; i++)
            {
                for (int j = 0; j < _edges; j++)
                {
                    Console.Write(_incidenceMatrix[i, j] + " ");
                }
                Console.WriteLine();
            }
        }

        /// <summary>
        /// Метод для выполнения обхода в глубину (DFS)
        /// </summary>
        /// <param name="startVertex">Начальная вершина</param>
        public void DFS(int startVertex)
        {
            // Сложность метода: O(V*E), где V - количество вершин, E - количество рёбер
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

            // Найти все смежные вершины через матрицу инцидентности
            for (int i = 0; i < _edges; i++)
            {
                if (_incidenceMatrix[vertex, i] == 1)
                {
                    for (int j = 0; j < _vertices; j++)
                    {
                        if (j != vertex && _incidenceMatrix[j, i] == 1 && !visited[j])
                        {
                            DFSUtil(j, visited);
                        }
                    }
                }
            }
        }

        /// <summary>
        /// Метод для выполнения обхода в ширину (BFS)
        /// </summary>
        /// <param name="startVertex">Начальная вершина</param>
        public void BFS(int startVertex)
        {
            // Сложность метода: O(V*E), где V - количество вершин, E - количество рёбер
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

                // Найти все смежные вершины через матрицу инцидентности
                for (int i = 0; i < _edges; i++)
                {
                    if (_incidenceMatrix[vertex, i] == 1)
                    {
                        for (int j = 0; j < _vertices; j++)
                        {
                            if (j != vertex && _incidenceMatrix[j, i] == 1 && !visited[j])
                            {
                                visited[j] = true;
                                queue.Enqueue(j);
                            }
                        }
                    }
                }
            }
        }
    }
}
