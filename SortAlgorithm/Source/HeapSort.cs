public class HeapSort : SortBase
{
    public override string SortName => "堆排序";

    public override void Sort(int[] nums)
    {
        // 初始化堆
        for(int i = nums.Length - 1; i > 0; i--)
        {
            int parentI = (i - 1) / 2;
            if(nums[parentI] < nums[i])
            {
                int tmp = nums[parentI];
                nums[parentI] = nums[i];
                nums[i] = tmp;
            }
        }
        SortTest.PrintNums(nums);
        for(int heapLength = nums.Length;;)
        {
            // 将堆顶的最大元素与当前堆的最后一个元素进行交换，然后再重新调整堆
            int tmp = nums[0];
            nums[0] = nums[heapLength - 1];
            nums[heapLength - 1] = tmp;

            SortTest.PrintNums(nums);

            heapLength--;
            if(heapLength <= 1)
            {
                break;
            }

            int moveNum = nums[0];
            int foundI = 0;
            int leftChildI = foundI * 2 + 1;
            while(leftChildI < heapLength)
            {
                int maxChildI = leftChildI;
                if(leftChildI + 1 < heapLength
                    && nums[leftChildI] < nums[leftChildI + 1])
                {
                    maxChildI = leftChildI + 1;
                }
                if(nums[foundI] < nums[maxChildI])
                {
                    nums[foundI] = nums[maxChildI];
                    foundI = maxChildI;
                    leftChildI = foundI * 2 + 1;
                }else
                {
                    break;
                }
            }
            nums[foundI] = moveNum;
        }
    }
}
