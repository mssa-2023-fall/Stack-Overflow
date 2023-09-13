namespace LeoBinarySearch
{
    public class LeoSearch
    {
        public static int BinarySearch(int[] array, int target)
        {
            if (!IsSortedArray(array)) throw new Exception("Array is not sorted");
            if (array.Length < 1) throw new Exception("Array is empty...");

            int low = 0;
            int high = array.Length - 1;

            while (low <= high)
            {
                int middle = low + (high - low) / 2;
                int value = array[middle];

                if (value < target) low = middle + 1;
                else if (value > target) high = middle - 1;
                else return middle;
            }

            return -1; //never evaluated
        }

        private static bool IsSortedArray(int[] a)
        {
            int j = a.Length - 1;
            if (j < 1) return true;
            int ai = a[0], i = 1;
            while (i <= j && ai <= (ai = a[i])) i++;
            return i > j;
        }

    }

    
}