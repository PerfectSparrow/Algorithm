using System.Text;
using System.Collections.Generic;
using System;

public class TestManager
{
    // 单例
    public static TestManager Instance = new TestManager();

    public string ResultString { get; private set; }

    List<ITest> tests = new List<ITest>();
    TestManager()
    {
        // 排序测试
        tests.Add(new SortTest());
        // 优先队列测试
        tests.Add(new PriorityQueueTest());
    }

    public void DoAllTests()
    {
        string succeedStr = "--------{0} 测试成功--------\n";
        string failStr = "！！！--------{0} 测试失败--------\n";
        StringBuilder resSb = new StringBuilder();
        foreach (var test in tests)
        {
            try
            {
                if (test.DoTest())
                {
                    resSb.AppendFormat(succeedStr, test.TestName);
                }
                else
                {
                    resSb.AppendFormat(failStr, test.TestName);
                }
                resSb.Append(test.ResultString + "\n");
            }
            catch(Exception e)
            {
                resSb.AppendFormat(failStr, test.TestName);
                resSb.Append(e.ToString());
            }
        }

        ResultString = resSb.ToString();
    }
}
