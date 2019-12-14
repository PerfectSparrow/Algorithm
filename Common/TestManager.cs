using System.Collections.Generic;

public class TestManager
{
    // 单例
    public static TestManager Instance = new TestManager();

    List<ITest> tests = new List<ITest>();
    TestManager()
    {
        // 排序测试
        tests.Add(new SortTest());
    }

    public void DoAllTests()
    {
        foreach(var test in tests)
        {
            test.DoTest();
        }
    }
}