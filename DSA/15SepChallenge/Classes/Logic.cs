namespace Classes
{
    public class Sort
    {
        public int[] RandomNumArr(int arrLen)
        {
            Random r = new Random();
            int[] result = new int[arrLen];
            for (int i = 0; i < arrLen - 1; i++)
            {
                result[i] = r.Next();
            }
            return result;
        }
        public int[] SortArr(int[] arr)
        {
            SortArr(arr, true); return arr;
        }
        public int[] SortArr(int[] arr, bool asc)
        {
            if (asc)
            {
                Array.Sort(arr, (a, b) => a.CompareTo(b));
            }
            else
            {
                Array.Sort(arr, (a, b) => b.CompareTo(a));
            }
            return arr;
        }

        public bool IsPresent(int[] sortedArr, int target)
        {
            return !(BinaryTreeBreathSearch(sortedArr, target) == -1);
        }
        public int BinaryTreeBreathSearch(int[] sortedArr, int target)
        {
            int left = 0, right = sortedArr.Length;

            while ( left <= right)
            {
                int mid = left + (right - left) / 2;

                if (sortedArr[mid] == target) return mid;
                if (sortedArr[mid] < target)
                {
                    left = mid + 1;
                } else
                {
                    right = mid - 1;
                }
            }
            return -1;
        }
    }


}