// 插入排序
// 算法复杂度为O(n^2)，空间复杂度为O(1)
// 最好的情况，元素已经有序，复杂度为O(n)
// 稳定排序，插入过程中相同元素的前后顺序可以不被交换
public class InerstionSort : SortBase
{
    public override string SortName => "插入排序";

    // 稳定排序
    public override void Sort(int[] nums)
    {
        // 最好情况下O(n)
        // 算法复杂度 S = 1 + 2 + ... + (n-1) = O(n^2)
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