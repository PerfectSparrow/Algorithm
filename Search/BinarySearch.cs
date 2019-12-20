using System.Collections.Generic;
using System;

public class BinarySearch
{
    // listSorted已经有序
    public static int Find<T>(IList<T> listSorted, T target)
        where T: IComparable<T>
    {
        int left = 0, right = listSorted.Count - 1;
        // 循环终止时，[left, right]一定是可以把target包住的区间（在元素不存在的情况下）
        // 这个结论跟mid偏左偏右取值没有关系
        // 则left是元素可以插入的位置
        // 可扩展为寻找最左的相等元素和最右的相等元素
        while (left <= right)
        {
            // left, right都是大于0的数字，这样写不会有溢出风险
            int mid = left + (right - left) / 2;
            int compareRes = listSorted[mid].CompareTo(target);
            if (compareRes == 0) return mid;
            if (compareRes < 0) right = mid - 1;
            else left = mid + 1;
        }
        return -1;
    }

    public static int FindFirst<T>(IList<T> listSorted, T target)
    {
        return -1;
    }

    public static int FindLast<T>(IList<T> listSorted, T target)
    {
        return -1;
    }

    // 元素的下界，第一个小于等于target的位置
    public static int LowerBound<T>(IList<T> listSorted, T target)
        where T: IComparable<T>
    {
        int left = 0, right = listSorted.Count - 1;
        while(left <= right)
        {
            int mid = left + (right - left) / 2;
            int compareRes = target.CompareTo(listSorted[mid]);
            if(compareRes >= 0)
            {
                right--;
            }else
            {
                left++;
            }
        }
        return right;
    }

    // 元素的上界，第一个大于等于target的位置
    public static int UpperBound<T>(IList<T> listSorted, T target)
        where T : IComparable<T>
    {
        int left = 0, right = listSorted.Count - 1;
        while (left <= right)
        {
            int mid = left + (right - left) / 2;
            int compareRes = target.CompareTo(listSorted[mid]);
            if (compareRes <= 0)
            {
                left++;
            }
            else
            {
                right--;
            }
        }
        return left;
    }
}