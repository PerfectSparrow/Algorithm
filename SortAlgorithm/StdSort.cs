// 标准排序，在工程实践中大量使用，是对快速排序的改进

/*
 * 快速排序
 * 快速排序流行的原因在于其实现简单，适用与各种不同的输入数据且在一般应用中比其它排序算法快很多。
 * 快速排序引人注目的特点包括它是原地排序的（只需要一个很小的辅助栈O(lgn)），时间复杂度为O(nlgn)
 * 其它的排序算法都无法将这两个优点结合起来
 * 快速排序的内循环比大多数排序算法都要短小，这意味其无论在理论上还是实践上都要更快。
 * 它的缺点在于其非常脆弱，在实现时要非常小心才能避免低劣的性能（空间O(lgn)，时间O(nlgn)）。
 *
 * 标准排序就是对快速排序的缺点改进后得到的算法。
 */
public class StdSort : SortBase
{
    public override string SortName => "标准排序";

    public override void Sort(int[] nums)
    {
        
    }

    bool Less(int a, int b)
    {
        return a < b;
    }

    void Exch(ref int a, ref int b)
    {
        int tmp = a;
        a = b;
        b = tmp;
    }
}