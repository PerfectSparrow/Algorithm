public abstract class SortBase
{
    public abstract string SortName { get; }
    public abstract void Sort(int[] nums);
    public virtual string Description { get
        {
            return "排序算法";
        } }
}