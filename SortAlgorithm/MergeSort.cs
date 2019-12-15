using System;

// 归并排序
// 算法复杂度O(nlgn)，空间复杂度O(nlgn)
// 每一层的复杂度为O(n)，层高为lgn
// 稳定排序，归并过程中可不改变相同元素的前后顺序


//归并排序（递归实现）
public class MergeSortRecursion: SortBase
{
    public override string SortName => "归并排序(递归)";

    public override void Sort(int[] nums)
    {
        int[] tmp = new int[nums.Length];
        MergeSort(nums, tmp, 0, nums.Length);
    }

    // [begin, end)
    void MergeSort(int[] nums, int[] tmp, int begin, int end)
    {
        // 只剩一个元素的时候停止划分
        if (begin + 1 == end) return;
        // 偶数个数元素时，mid会偏向右侧
        int mid = begin + (end - begin) / 2;
        // 每次划分，两边都不会出现0个元素的情况
        MergeSort(nums, tmp, begin, mid);
        MergeSort(nums, tmp, mid, end);
        int leftI = begin;
        int rightI = mid;
        int tmpI = begin;
        while(leftI < mid && rightI < end)
        {
            if(nums[leftI] <= nums[rightI])
            {
                tmp[tmpI++] = nums[leftI++];
            }else
            {
                tmp[tmpI++] = nums[rightI++];
            }
        }
        while (leftI < mid) tmp[tmpI++] = nums[leftI++];
        while (rightI < end) tmp[tmpI++] = nums[rightI++];
        for (int i = begin; i < end; i++) nums[i] = tmp[i];
    }
}


// 归并排序（非递归实现）
public class MergeSortNonRecursion : SortBase
{
    public override string SortName => "归并排序(非递归)";

    public override void Sort(int[] nums)
    {
        int[] tmp = new int[nums.Length];
        // 从下往上进行归并
        int len = 1;
        // 循环次数lgn
        while(len < nums.Length)
        {
            for(int i=0; i<nums.Length; i+=2*len)
            {
                int leftI = i;
                int rightI = i + len;
                int leftEnd = i + len;
                if (leftEnd >= nums.Length) break;
                int rightEnd = Math.Min(i+2 * len, nums.Length);
                int tmpI = leftI;
                while(leftI<leftEnd && rightI<rightEnd)
                {
                    if(nums[leftI] <= nums[rightI])
                    {
                        tmp[tmpI++] = nums[leftI++];
                    }else
                    {
                        tmp[tmpI++] = nums[rightI++];
                    }
                }
                while (leftI < leftEnd) tmp[tmpI++] = nums[leftI++];
                while (rightI < rightEnd) tmp[tmpI++] = nums[rightI++];
                for (int j = i; j < rightEnd; j++) nums[j] = tmp[j];
            }
            len *= 2;
        }
    }
}
