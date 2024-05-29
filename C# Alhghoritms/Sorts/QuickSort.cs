namespace C__Algorithms.Sorts
{
    public class QuickSort
    {
        // Получает индекс среднего элемента массива.
        // Сложность: O(1) - постоянное время.
        private int GetMiddleIndex(int[] array)
        {
            return array.Length / 2;
        }

        // Основной метод сортировки, использующий алгоритм QuickSort.
        // Сложность:
        // - Средний случай: O(n log n)
        // - Худший случай: O(n^2) (происходит при неудачном выборе опорного элемента)
        public int[] Sort(int[] array)
        {
            // Базовый случай: массив из одного или нуля элементов уже отсортирован.
            if (array.Length <= 1)
                return array;

            // Выбираем опорный элемент.
            int middleIndex = GetMiddleIndex(array);
            int middle = array[middleIndex];

            // Разделяем массив на три части: элементы меньше опорного, равные и больше опорного.
            var leftSide = new List<int>();
            var rightSide = new List<int>();
            var middleSide = new List<int>();

            // Распределяем элементы по соответствующим спискам.
            // Сложность: O(n)
            foreach (var item in array)
            {
                if (item < middle)
                {
                    leftSide.Add(item);
                }
                else if (item > middle)
                {
                    rightSide.Add(item);
                }
                else
                {
                    middleSide.Add(item);
                }
            }

            // Рекурсивно сортируем левую и правую части.
            // Сложность: в среднем O(n log n), в худшем случае O(n^2)
            int[] leftSorted = Sort(leftSide.ToArray());
            int[] rightSorted = Sort(rightSide.ToArray());

            // Объединяем отсортированные части в итоговый массив.
            var result = new int[array.Length];
            int index = 0;

            // Добавляем отсортированные левые элементы.
            // Сложность: O(n)
            foreach (var item in leftSorted)
            {
                result[index++] = item;
            }

            // Добавляем элементы, равные опорному.
            // Сложность: O(n)
            foreach (var item in middleSide)
            {
                result[index++] = item;
            }

            // Добавляем отсортированные правые элементы.
            // Сложность: O(n)
            foreach (var item in rightSorted)
            {
                result[index++] = item;
            }

            return result;
        }
    }
}
