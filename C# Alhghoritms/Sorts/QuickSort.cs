namespace C__Algorithms.Sorts
{
    public class QuickSort
    {
        private int GetMiddleIndex(int[] array)
        {
            return array.Length / 2;
        }

        public int[] Sort(int[] array)
        {
            if (array.Length <= 1)
                return array;

            int middleIndex = GetMiddleIndex(array);
            int middle = array[middleIndex];

            var leftSide = new List<int>();
            var rightSide = new List<int>();
            var middleSide = new List<int>();

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

            int[] leftSorted = Sort(leftSide.ToArray());
            int[] rightSorted = Sort(rightSide.ToArray());

            var result = new int[array.Length];
            int index = 0;

            foreach (var item in leftSorted)
            {
                result[index++] = item;
            }

            foreach (var item in middleSide)
            {
                result[index++] = item;
            }

            foreach (var item in rightSorted)
            {
                result[index++] = item;
            }

            return result;
        }
    }
}