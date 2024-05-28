namespace C__Algorithms.Sorts
{
    internal class MergeSort
    {
        public int[] Sort(int[] list)
        {
            if (list.Length <= 1)
            {
                return list;
            }

            int middleIndex = GetMiddleIndex(list);
            int[] leftSide = Sort(list.Take(middleIndex).ToArray());
            int[] rightSide = Sort(list.Skip(middleIndex).ToArray());

            return Merge(leftSide, rightSide);
        }

        private int GetMiddleIndex(int[] list)
        {
            return list.Length / 2;
        }

        private int[] Merge(int[] leftSide, int[] rightSide)
        {
            int[] result = new int[leftSide.Length + rightSide.Length];
            int leftIndex = 0, rightIndex = 0, resultIndex = 0;

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

            while (leftIndex < leftSide.Length)
            {
                result[resultIndex] = leftSide[leftIndex];
                leftIndex++;
                resultIndex++;
            }

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