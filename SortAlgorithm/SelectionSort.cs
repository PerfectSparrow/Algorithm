// 选择排序，最基础的排序
// 算法复杂度O(n^2)，空间复杂度O(1)
// 每次将剩余元素的最小值与第一个元素交换

public class SelectionSort : SortBase
{
    public override string SortName => "选择排序";

    public override void Sort(int[] nums)
    {
        for(int i = 0; i < nums.Length; i++)
        {
            int minI = i;
            for(int j = i+1; j < nums.Length; j++)
            {
                if(nums[j] < nums[minI])
                {
                    minI = j;
                }
            }
            int tmp = nums[i];
            nums[i] = nums[minI];
            nums[minI] = tmp;
        }
    }
}