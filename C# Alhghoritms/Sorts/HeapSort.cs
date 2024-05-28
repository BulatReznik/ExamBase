using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace C__Alhghoritms.Sorts
{
    public class HeapSort
    {
        public void Sort(int[] list)
        {
            var count = list.Length;

            // Построение кучи (перегруппировка списка)
            for (var i = count / 2 - 1; i >= 0; i--)
                Heapify(list, count, i);

            // Один за другим извлекаем элементы из кучи
            for (int i = count - 1; i >= 0; i--)
            {
                // Перемещаем текущий корень в конец
                int temp = list[0];
                list[0] = list[i];
                list[i] = temp;

                // Вызываем Heapify на уменьшенной куче
                Heapify(list, i, 0);
            }
        }

        private void Heapify(int[] list, int n, int i)
        {
            var largest = i; // Инициализируем наибольший как корень
            var left = 2 * i + 1; // левый = 2*i + 1
            var right = 2 * i + 2; // правый = 2*i + 2

            // Если левый дочерний элемент больше корня
            if (left < n && list[left] > list[largest])
                largest = left;

            // Если правый дочерний элемент больше, чем самый большой элемент на данный момент
            if (right < n && list[right] > list[largest])
                largest = right;

            // Если самый большой элемент не корень
            if (largest != i)
            {
                int swap = list[i];
                list[i] = list[largest];
                list[largest] = swap;

                // Рекурсивно преобразуем в кучу затронутое поддерево
                Heapify(list, n, largest);
            }
        }
    }
}
