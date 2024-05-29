namespace C__Algorithms.Sorts
{
    internal class MergeSort
    {
        // Основной метод сортировки, использующий алгоритм MergeSort.
        // Сложность: O(n log n) во всех случаях (средний, лучший и худший).
        public int[] Sort(int[] list)
        {
            // Базовый случай: массив из одного или нуля элементов уже отсортирован.
            if (list.Length <= 1)
            {
                return list;
            }

            // Находим средний индекс для разделения массива на две части.
            int middleIndex = GetMiddleIndex(list);

            // Рекурсивно сортируем левую и правую части.
            // Каждое рекурсивное деление массива в среднем имеет сложность O(log n),
            // а общее число элементов n, что в итоге дает сложность O(n log n).
            int[] leftSide = Sort(list.Take(middleIndex).ToArray());
            int[] rightSide = Sort(list.Skip(middleIndex).ToArray());

            // Сливаем отсортированные части в один массив.
            return Merge(leftSide, rightSide);
        }

        // Метод для получения среднего индекса массива.
        // Сложность: O(1) - постоянное время.
        private int GetMiddleIndex(int[] list)
        {
            return list.Length / 2;
        }

        // Метод для слияния двух отсортированных массивов в один.
        // Сложность: O(n), где n - суммарное количество элементов в двух массивах.
        private int[] Merge(int[] leftSide, int[] rightSide)
        {
            int[] result = new int[leftSide.Length + rightSide.Length];
            int leftIndex = 0, rightIndex = 0, resultIndex = 0;

            // Сливаем массивы, пока не достигнем конца одного из них.
            // В этом цикле каждый элемент добавляется в результирующий массив в отсортированном порядке.
            // Сложность: O(n).
            while (leftIndex < leftSide.Length && rightIndex < rightSide.Length)
            {
                if (leftSide[leftIndex] <= rightSide[rightIndex])
                {
                    result[resultIndex] = leftSide[leftIndex];
                    leftIndex++;
                }
                else
                {
                    result[resultIndex] = rightSide[rightIndex];
                    rightIndex++;
                }
                resultIndex++;
            }

            // Добавляем оставшиеся элементы из левого массива (если есть).
            // Сложность: O(n), но это часть общего процесса слияния.
            while (leftIndex < leftSide.Length)
            {
                result[resultIndex] = leftSide[leftIndex];
                leftIndex++;
                resultIndex++;
            }

            // Добавляем оставшиеся элементы из правого массива (если есть).
            // Сложность: O(n), но это часть общего процесса слияния.
            while (rightIndex < rightSide.Length)
            {
                result[resultIndex] = rightSide[rightIndex];
                rightIndex++;
                resultIndex++;
            }

            return result;
        }
    }
}
