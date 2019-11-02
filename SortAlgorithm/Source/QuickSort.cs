public class QuickSort : SortBase
{
    public override string SortName => "快速排序";

    public override void Sort(int[] nums)
    {
        Partition(nums, 0, nums.Length);
    }

    // 以数组的第一个元素为基准划分数组
    // 左边小于等于基准元素，右边大于等于基准元素
    // 区间[begin, end)
    void Partition(int[] nums, int begin, int end)
    {
        if (begin >= end) return;
        int pivotNum = nums[begin];
        int leftI = begin + 1;
        int rightI = end - 1;
        while(leftI <= rightI)
        {
            // 从右边找出小于pivotNum的数
            while (leftI <= rightI && nums[rightI] >= pivotNum) rightI--;
            if (leftI > rightI) break;
            int tmp = nums[rightI];
            nums[rightI] = nums[leftI];
            nums[leftI] = tmp;
            // 从左边找出大于privotNum的数
            while (leftI <= rightI && nums[leftI] <= pivotNum) leftI++;
        }
    }
}
