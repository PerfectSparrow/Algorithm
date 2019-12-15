// 冒泡排序
// 算法复杂度为O(n^2)，空间复杂度为O(1)
// 稳定排序，冒泡的过程中相同元素的前后顺序可以不被交换
public class BubbleSort : SortBase
{
    public override string SortName => "冒泡排序";

    // 稳定排序
    // 最好情况，原数组已经有序，复杂度为O(n)
    // 算法复杂度 S =(n-1) + ... + 2 = O(n^2)
    public override void Sort(int[] nums)
    {
        //i表示i个元素已排序完成，若没有发生交换则说明序列已经有序
        for(int i = 0; i < nums.Length; i++)
        {
            //排序过程中是否发生交换, 没有交换则说明有序
            bool isSwaped = false;
            for(int j = 0; j < nums.Length - i - 1; j++)
            {
                if(nums[j] > nums[j + 1])
                {
                    int tmp = nums[j];
                    nums[j] = nums[j + 1];
                    nums[j + 1] = tmp;

                    isSwaped = true;
                }
            }
            if (!isSwaped) break;
        }
    }
}
