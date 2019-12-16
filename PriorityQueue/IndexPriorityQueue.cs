// 索引优先级队列
// 队列中每个位置的元素对应一个索引
// 可用来实现将多个排序数组合并成一个排序数组
// 每个索引可以理解为优先队列的一个输入管道
// 索引优先级队列将优先级队列中的元素变成了元素的索引，相当于(k, v)键值对的优先级队列

public class IndexPriorityQueue<T>
{
    public void Delete(int k)
    {

    }

    public void Insert(int k, T item)
    {

    }

    // 修改某一个元素值后再重新调整堆
    public void Change(int k, T item)
    {

    }

    public bool Contains(int k)
    {
        return false;
    }

    public T Top()
    {
        T t = default(T);
        return t;
    }

    // 最上层元素的索引
    public int TopIndex()
    {
        return -1;
    }

    public T DelTop()
    {
        T t = default(T);
        return t;
    }

    public bool IsEmpty()
    {
        return true;
    }
}