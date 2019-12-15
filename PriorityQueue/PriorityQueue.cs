using System;
using System.Collections;
using System.Collections.Generic;



// 优先级队列
public class PriorityQueue<T>: IReadOnlyCollection<T>
    where T: IComparer<T>
{
    bool isComparerReverse = false;

    // 支持动态改变大小，支持动态变大，未处理动态变小的情况
    List<T> pq = new List<T>();
    public int Count { get; private set; } = 0;

    public PriorityQueue()
    {

    }

    public PriorityQueue(IEnumerator<T> enumerator)
    {

    }

    public void Insert(T item)
    {
        if(pq.Count == Count)
        {
            pq.Add(item);
        }else
        {
            pq[Count] = item;
        }
        Count++;
    }

    public T Top()
    {
        CheckEmpty();
        return pq[0];
    }

    public T DelTop()
    {
        CheckEmpty();
        T top = pq[0];
        pq[0] = pq[--Count];
        return top;
    }

    void CheckEmpty()
    {
        if (IsEmpty())
        {
            throw new InvalidOperationException("PriorityQueue is Empty!");
        }
    }

    public bool IsEmpty()
    {
        return Count == 0;
    }

    // 元素上浮使堆重新满足定义
    void Swim(int k)
    {

    }

    // 元素下沉使堆重新满足定义
    void Sink(int k)
    {

    }

    void Swap(int i, int j)
    {
        T tmp = pq[i];
        pq[i] = pq[j];
        pq[j] = tmp;
    }

    protected virtual bool Less(T item1, T item2)
    {
        return item1.Compare(item1, item2) < 0;
    }

    public IEnumerator<T> GetEnumerator()
    {
        for(int i=0; i<Count; i++)
        {
            yield return pq[i];
        }
        yield break;
    }

    IEnumerator IEnumerable.GetEnumerator()
    {
        return GetEnumerator();
    }
}

// 最大堆优先级队列
public class MaxPriorityQueue<T>: PriorityQueue<T>
    where T : IComparer<T>
{
    protected override bool Less(T item1, T item2)
    {
        return !base.Less(item1, item2);
    }
}

// 最小堆优先级队列
public class MinPriorityQueue<T>: PriorityQueue<T>
    where T : IComparer<T>
{

}