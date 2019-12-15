// #define SORT_DEBUG

using System;
using System.Collections.Generic;
using System.Text;


public class SortTest: ITest
{
#if !SORT_DEBUG
    // 测试用的数组长度
    const int NUMS_LENGTH = 10000;
#else
    const int NUMS_LENGTH = 10;
#endif

    public string TestName => "排序算法测试";

    public string ResultString { get; set; }

    // 用于注册排序算法
    List<SortBase> sorts = new List<SortBase>();

    public SortTest()
    {
        // 冒泡排序
        sorts.Add(new BubbleSort());
        // 快速排序
        sorts.Add(new QuickSort());
        // 堆排序
        sorts.Add(new HeapSort());
        // 选择排序
        sorts.Add(new SelectionSort());
        // 插入排序
        sorts.Add(new InerstionSort());
        // 希尔排序
        sorts.Add(new ShellSort());
        // 归并排序（递归）
        sorts.Add(new MergeSortRecursion());
        // 归并排序（非递归）
        sorts.Add(new MergeSortNonRecursion());
    }

    public bool DoTest()
    {
        StringBuilder resSb = new StringBuilder();
        bool isSuccess = true;
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
            isSuccess = isSuccess && isPass;
            // Console.WriteLine(string.Format("{0}: {1}", sort.SortName, passStr));
            resSb.AppendFormat("{0}: {1}\n", sort.SortName, passStr);
        }

        ResultString = resSb.ToString();

        return isSuccess;
    }

    void GenerateNums(out int[] nums1, out int[] nums2)
    {
        nums1 = new int[NUMS_LENGTH];
        nums2 = new int[NUMS_LENGTH];
        Random random = new Random(Guid.NewGuid().GetHashCode());
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
}