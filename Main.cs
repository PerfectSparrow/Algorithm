using System;

public class Algorithm
{
    public static int Main(string[] args)
    {
        TestManager.Instance.DoAllTests();
        Console.WriteLine(TestManager.Instance.ResultString);
        return 0;
    }
}