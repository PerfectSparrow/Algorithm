public class BubbleSort : SortBase
{
    public override string SortName => "冒泡排序";

    public override void Sort(int[] nums)
    {
        //i表示i个元素已排序完成，若没有发生交换则说明序列已经有序
        for(int i = 0; i < nums.Length; i++)
        {
            //排序过程中是否发生交换
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
