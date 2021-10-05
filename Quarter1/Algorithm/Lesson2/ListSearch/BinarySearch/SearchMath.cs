namespace GeekBrains.Learn.BinarySearch
{
    class SearchMath
    {
        public int BinarySearch(int[] inputArray, int searchValue)
        {
            int min = 0; // O(1)
            int max = inputArray.Length - 1; // O(1)
            while (min <= max) // O(N / 2) = O(N)
            {
                int mid = (min + max) / 2; // O(1)
                if (searchValue == inputArray[mid]) // O(1)
                {
                    return mid; // O(1)
                }
                else if (searchValue < inputArray[mid]) // O(1)
                {
                    max = mid - 1; // O(1)
                }
                else
                {
                    min = mid + 1; // O(1)
                }
            }

            return -1; // O(1)
        }
    }
}
