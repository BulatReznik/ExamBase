using System;

namespace C__Algorithms.Sorts
{
    public class HeapSort
    {
        // Основной метод сортировки, использующий алгоритм HeapSort.
        // Сложность: O(n log n) во всех случаях (средний, лучший и худший).
        public void Sort(int[] list)
        {
            var count = list.Length;

            // Построение кучи (перегруппировка списка).
            // Сложность: O(n), так как мы строим кучу.
            for (var i = count / 2 - 1; i >= 0; i--)
                Heapify(list, count, i);

            // Один за другим извлекаем элементы из кучи.
            // Каждый вызов Heapify имеет сложность O(log n).
            // Выполняется n раз, поэтому общая сложность этого цикла: O(n log n).
            for (int i = count - 1; i >= 0; i--)
            {
                // Перемещаем текущий корень в конец.
                int temp = list[0];
                list[0] = list[i];
                list[i] = temp;

                // Вызываем Heapify на уменьшенной куче.
                Heapify(list, i, 0);
            }
        }

        // Метод для преобразования поддерева с корневым узлом i в кучу.
        // n - размер кучи.
        // Сложность: O(log n), так как в худшем случае нужно пройти по высоте дерева.
        private void Heapify(int[] list, int n, int i)
        {
            var largest = i; // Инициализируем наибольший как корень.
            var left = 2 * i + 1; // левый дочерний элемент = 2*i + 1.
            var right = 2 * i + 2; // правый дочерний элемент = 2*i + 2.

            // Если левый дочерний элемент больше корня.
            if (left < n && list[left] > list[largest])
                largest = left;

            // Если правый дочерний элемент больше, чем самый большой элемент на данный момент.
            if (right < n && list[right] > list[largest])
                largest = right;

            // Если самый большой элемент не корень.
            if (largest != i)
            {
                // Меняем местами элементы.
                int swap = list[i];
                list[i] = list[largest];
                list[largest] = swap;

                // Рекурсивно преобразуем в кучу затронутое поддерево.
                Heapify(list, n, largest);
            }
        }
    }
}
