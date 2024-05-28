using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace C__Alhghoritms.Graph
{
    public class GraphOnEdgeList
    {
        // Список рёбер графа
        private List<Tuple<int, int>> _edgeList;

        // Количество вершин в графе
        private int _vertices;

        // Конструктор для инициализации графа
        public GraphOnEdgeList(int vertices)
        {
            _vertices = vertices;
            _edgeList = new List<Tuple<int, int>>();
        }

        // Метод для добавления ребра в граф
        public void AddEdge(int v, int w)
        {
            _edgeList.Add(new Tuple<int, int>(v, w));
            _edgeList.Add(new Tuple<int, int>(w, v)); // Добавляем и обратное ребро для неориентированного графа
        }

        // Метод для печати всех рёбер
        public void PrintEdges()
        {
            foreach (var edge in _edgeList)
            {
                Console.WriteLine($"({edge.Item1}, {edge.Item2})");
            }
        }

        // Метод для выполнения обхода в глубину (DFS)
        public void DFS(int startVertex)
        {
            bool[] visited = new bool[_vertices];
            DFSUtil(startVertex, visited);
        }

        // Вспомогательный метод для рекурсивного выполнения обхода в глубину (DFS)
        private void DFSUtil(int vertex, bool[] visited)
        {
            // Отметить текущую вершину как посещённую
            visited[vertex] = true;
            Console.Write(vertex + " ");

            // Получить все смежные вершины
            foreach (var edge in _edgeList)
            {
                if (edge.Item1 == vertex && !visited[edge.Item2])
                {
                    DFSUtil(edge.Item2, visited);
                }
            }
        }

        // Метод для выполнения обхода в ширину (BFS)
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

                // Получить все смежные вершины
                foreach (var edge in _edgeList)
                {
                    if (edge.Item1 == vertex && !visited[edge.Item2])
                    {
                        visited[edge.Item2] = true;
                        queue.Enqueue(edge.Item2);
                    }
                }
            }
        }
    }
}