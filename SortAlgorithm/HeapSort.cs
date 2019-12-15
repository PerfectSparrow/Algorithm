using System;

// 堆排序
// 空间复杂度O(nlgn)，空间复杂度为O(1)
// 不稳定排序，元素下降的过程中会打破相同元素的前后顺序
public class HeapSort : SortBase
{
    public override string SortName => "堆排序";

    public override void Sort(int[] nums)
    {
        if (nums.Length == 0) return;

        // 初始化最大堆，复杂度为O(n)
        // 调整的过程是一个从下到上不停调整的过程
        // nums.Length为0会报错
        // 从非叶子节点开始调整
        for (int i = nums.Length / 2; i >=0; i--)
        {
            MaxHeapify(nums, i, nums.Length);
        }
        
        // 堆排序，复杂度为O(nlgn)
        for (int heapLen = nums.Length; heapLen > 0; heapLen--)
        {
            int tmp = nums[0];
            nums[0] = nums[heapLen - 1];
            nums[heapLen - 1] = tmp;
            MaxHeapify(nums, 0, heapLen - 1);
        }
    }

    // 左右子树已符合最大堆要求的情况下，对顶点元素进行下沉操作，区间[left, right)
    // 复杂度为O(lgn)
    void MaxHeapify(int[] nums, int begin, int end)
    {
        int num = nums[begin];
        int foundI = begin;
        int leftChildI = 2 * foundI + 1;
        while(leftChildI < end)
        {
            int maxI = leftChildI;
            if(leftChildI + 1 < end && nums[leftChildI] < nums[leftChildI + 1])
            {
                maxI = leftChildI + 1;
            }
            if(num < nums[maxI])
            {
                nums[foundI] = nums[maxI];
                foundI = maxI;
                leftChildI = 2 * foundI + 1;
            }else
            {
                break;
            }
        }
        nums[foundI] = num;
    }
}
