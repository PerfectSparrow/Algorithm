// #define SORT_DEBUG

using System;
using System.Collections.Generic;


public class SortTest
{
#if !SORT_DEBUG
    // 测试用的数组长度
    const int NUMS_LENGTH = 10000;
#else
    const int NUMS_LENGTH = 10;
#endif

    List<SortBase> sorts = new List<SortBase>();

    public SortTest()
    {
        // 冒泡排序
        sorts.Add(new BubbleSort());
        // 快速排序
        sorts.Add(new QuickSort());
        // 堆排序
        sorts.Add(new HeapSort());
    }

    public void DoTest()
    {
        foreach(var sort in sorts)
        {
            int[] nums1, nums2;
            GenerateNums(out nums1, out nums2);
            Array.Sort(nums1);
            sort.Sort(nums2);
            bool isPass = true;
            for(int i = 0; i < NUMS_LENGTH; i++)
            {
                if(nums1[i] != nums2[i])
                {
                    isPass = false;
                    break;
                }
            }
            string passStr = "";
            if(isPass)
            {
                passStr = "测试通过！";
            }else
            {
                passStr = "测试失败失败失败！";
            }
        }
    }

    void GenerateNums(out int[] nums1, out int[] nums2)
    {
        nums1 = new int[NUMS_LENGTH];
        nums2 = new int[NUMS_LENGTH];
        Random random = new Random();
        for(int i = 0; i < NUMS_LENGTH; i++)
        {
            int num = random.Next(NUMS_LENGTH);
            nums1[i] = num;
            nums2[i] = num;
        }
    }

    public static void PrintNums(int[] nums)
    {
        foreach(var num in nums)
        {
            Console.Write(num + " ");
        }
        Console.WriteLine();
    }

    public static void Main()
	{
        SortTest sortTest = new SortTest();
        sortTest.DoTest();
	}
}