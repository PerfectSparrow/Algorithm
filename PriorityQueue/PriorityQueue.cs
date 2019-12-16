using System;
using System.Collections;
using System.Collections.Generic;



// 优先级队列
public class PriorityQueue<T>: IReadOnlyCollection<T>
    where T: IComparable<T>
{
    // 依赖于List的动态大小变化
    List<T> pq = new List<T>();
    public int Count
    {
        get
        {
            return pq.Count;
        }
    }

    public PriorityQueue()
    {
    }

    public PriorityQueue(IEnumerator<T> enumerator)
    {
        while(enumerator.MoveNext())
        {
            pq.Add(enumerator.Current);
        }
        InitHeap();
    }

    // 初始化堆
    void InitHeap()
    {
        if (Count == 0) return;

        // 从非叶子节点开始调整
        for(int i=Count/2; i>=0; i--)
        {
            Sink(i);
        }
    }

    public void Clear()
    {
        pq.Clear();
    }

    // 时间复杂度为O(lgn)
    public void Insert(T item)
    {
        pq.Add(item);
        Swim(Count - 1);
    }

    public T Top()
    {
        CheckEmpty();
        return pq[0];
    }

    // 时间复杂度为O(lgn)
    public T DelTop()
    {
        CheckEmpty();
        T top = pq[0];
        pq[0] = pq[Count - 1];
        Sink(0);
        pq.RemoveAt(pq.Count - 1);
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
        // 序号从0开始，父节点为(k-1)/2
        while (k > 0 && Less(pq[k], pq[(k - 1) / 2]))
        {
            Swap((k - 1) / 2, k);
            k = (k - 1) / 2;
        }
    }

    // 元素下沉使堆重新满足定义
    void Sink(int k)
    {
        while(2*k+1 < Count)
        {
            int child = 2 * k + 1;
            if (child + 1 < Count && Less(pq[child + 1], pq[child]))
            {
                child = child + 1;
            }
            if (Less(pq[child], pq[k]))
            {
                Swap(child, k);
                k = child;
            }
            else
            {
                break;
            }
        }
    }

    void Swap(int i, int j)
    {
        T tmp = pq[i];
        pq[i] = pq[j];
        pq[j] = tmp;
    }

    protected virtual bool Less(T a, T b)
    {
        return a.CompareTo(b) < 0;
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
    where T : IComparable<T>
{
    public MaxPriorityQueue(IEnumerator<T> enumerator)
        :base(enumerator)
    {

    }

    protected override bool Less(T a, T b)
    {
        return !base.Less(a, b);
    }
}

// 最小堆优先级队列
public class MinPriorityQueue<T>: PriorityQueue<T>
    where T : IComparable<T>
{
    public MinPriorityQueue(IEnumerator<T> enumerator)
        : base(enumerator)
    {

    }
}