

// 快速排序
public class QuickSort : SortBase
{
    public override string SortName => "快速排序";

    public override void Sort(int[] nums)
    {
        Partition(nums, 0, nums.Length);
    }

    // 以数组的第一个元素为基准划分数组，每次排完序，基准元素在其最终位置
    // 左边小于等于基准元素，右边大于等于基准元素
    // 区间[begin, end)
    void Partition(int[] nums, int begin, int end)
    {
        if (begin >= end) return;
        int pivotNum = nums[begin];
        int leftI = begin;
        int rightI = end - 1;
        while(leftI < rightI)
        {
            // 从右边找出小于pivotNum的数
            while (leftI < rightI && nums[rightI] >= pivotNum) rightI--;
            nums[leftI] = nums[rightI];
            // 从左边找出大于privotNum的数
            while (leftI < rightI && nums[leftI] <= pivotNum) leftI++;
            nums[rightI] = nums[leftI];
        }
        nums[leftI] = pivotNum;
        Partition(nums, begin, leftI);
        Partition(nums, leftI + 1, end);
    }
}
