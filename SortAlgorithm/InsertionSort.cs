// 插入排序
// 最坏情况下复杂度为O(n^2)
// 最好的情况，元素已经有序，复杂度为O(n)

public class InerstionSort : SortBase
{
    public override string SortName => "插入排序";

    public override void Sort(int[] nums)
    {
        for(int i = 1; i < nums.Length; i++)
        {
            int insertNum = nums[i];
            int insertPos = i;
            while (insertPos > 0 && nums[insertPos - 1] > insertNum)
            {
                nums[insertPos] = nums[insertPos - 1];
                insertPos--;
            }
            nums[insertPos] = insertNum;
        }
    }
}