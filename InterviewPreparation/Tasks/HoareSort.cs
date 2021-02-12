namespace InterviewPreparation.Tasks
{
    public static class HoareSort
    {
        public static void Sort(int[] arr, int start, int end)
        {
            if (start == end)
                return;
            var pivot = arr[end];
            var storeIndex = start;
            for (var i = start; i < end; i++)
            {
                if (arr[i] <= pivot)
                {
                    var t = arr[i];
                    arr[i] = arr[storeIndex];
                    arr[storeIndex] = t;
                    storeIndex++;
                }
            }
            var temp = arr[storeIndex];
            arr[storeIndex] = pivot;
            arr[end] = temp;
            if (storeIndex > start) Sort(arr, start, storeIndex - 1);
            if (storeIndex < end) Sort(arr, storeIndex + 1, end);
        }
    }
}
