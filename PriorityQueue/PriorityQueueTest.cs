using System;
using System.Collections.Generic;

public class PriorityQueueTest : ITest
{

    const int NUM_RANGE = 10000;
    const int INIT_NUM = 1000;
    const int INSERT_NUM = 500;

    public string TestName => "优先级队列测试";

    public string ResultString { get; set; } = "nothing more";

    public bool DoTest()
    {
        Random random = new Random(Guid.NewGuid().GetHashCode());
        List<int> nums = new List<int>();

        for(int i=0; i<INIT_NUM; i++)
        {
            nums.Add(random.Next(NUM_RANGE));
        }

        MinPriorityQueue<int> testPq = new MinPriorityQueue<int>(nums.GetEnumerator());
        for(int i=0; i<INSERT_NUM; i++)
        {
            testPq.Insert(random.Next(NUM_RANGE));
        }
        List<int> orginNums = new List<int>();
        List<int> sortedNums = new List<int>();
        while(!testPq.IsEmpty())
        {
            int top = testPq.DelTop();
            orginNums.Add(top);
            sortedNums.Add(top);
        }
        sortedNums.Sort();

        for(int i=0; i<orginNums.Count; i++)
        {
            if(orginNums[i] != sortedNums[i])
            {
                return false;
            }
        }

        return true;
    }
}