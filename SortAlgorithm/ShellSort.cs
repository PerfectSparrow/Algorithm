// 希尔排序
// 插入排序的改进，比插入排序快
// 希尔排序
// 算法复杂度为O(n^3/2)
// 透彻理解shell排序的性能至今仍然是一个挑战
// 稳定排序，同插入排序
public class ShellSort : SortBase
{
    public override string SortName => "希尔排序";

    public override void Sort(int[] nums)
    {
        // 以h为间隔进行插入排序
        int h = nums.Length / 2;
        while(h >= 1)
        {
            for(int i = h; i < nums.Length; i++)
            {
                for(int j = i; j-h >= 0 && nums[j] < nums[j-h]; j-=h)
                {
                    int tmp = nums[j];
                    nums[j] = nums[j - h];
                    nums[j - h] = tmp;
                }
            }
            h /= 2;
        }
    }
}