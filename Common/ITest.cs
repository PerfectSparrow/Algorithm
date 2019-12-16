// 测试用基础类
public interface ITest
{

    // 测试名称
    public string TestName { get; }
    public bool DoTest();
    public string ResultString { get; set; }
}