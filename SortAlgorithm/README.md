# 排序算法
-----------------------

## 目录
1、排序算法分类
2、排序算法实现 
3、快排、堆排序和归并排序比较
4、STL中的sort实现

## 1、排序算法分类

### 1.1、简介
>排序算法大致可以分为两类：比较类排序和非比较类排序。比较类排序通过比较来觉得元素间的次序，其算法复杂度不能超过O(nlog(n)),也成为非线性排序；非比较类排序不通过比较来排序，其算法复杂度可以达到O(n)。

### 1.2、算法复杂度

| 排序算法     | 平均         | 最坏        | 最好        | 空间       | 稳定性 |
| ------------ | ------------ | ----------- | ----------- | ---------- | ------ |
| 冒泡排序     | O(n^2)       | O(n^2)      | O(n)        | O(1)       | 稳定   |
| 快速排序     | O(nlog2(n))  | O(n^2)      | O(nlog2(n)  | O(nlog2(n) | 不稳定 |
| 简单插入排序 | O(n^2)       | O(n^2)      | O(n)        | O(1)       | 稳定   |
| 希尔排序     | **O(n^1.3)** | O(n^2)      | O(n)        | O(1)       | 不稳定 |
| 简单选择排序 | O(n^2)       | O(n^2)      | O(n^2)      | O(1)       | 不稳定 |
| 堆排序       | O(nlog2(n))  | O(nlog2(n)) | O(nlog2(n)) | O(1)       | 不稳定 |
| 二路归并排序 | O(nlog2(n))  | O(nlog2(n)) | O(nlog2(n)) | O(n)       | 稳定   |
||
|计数排序|
|桶排序|
|基数排序|




## 2、算法具体实现

### 2.1、冒泡排序（Bubble Sort）
##### 2.1.1、算法描述和分析
> 1. 重头到尾依次比较相邻的两个元素，若次序不对则交换两个元素，每扫描一遍都会将最大的元素移动到最后位置，若扫描的过程没有发生元素移动，则表示排序已完成。
> 2. 若每次选择的基准元素在中间，则递归栈的深度为log2(n)，则复杂度为O(nlog2(n))；若数组已排好序，则复杂度会变为O(n^2)。空间复杂度为栈的深度，为O(log2(n))~O(n)。排序过程中，各元素会来回颠倒，是不稳定的。
> 3. 算法复杂度一般为O(n^2)，若数组已经排好序，循环会提前退出，复杂度减少为O(n)；空间复杂度为O(n)；排序是稳定的，相等的元素并不会交换前后位置。


### 2.2、快速排序(Quick Sort)
##### 2.2.1、算法描述和分析
> 1. 选择一个基准元素（一般是第一个），将比基准元素的小的放其在左边，其它的放在其右边，每一趟将排列好一个元素，递归排序左右两边，递归完成后，左右两边将变成有序的。这是分治的算法思想。
> 2. 若每次选择的基准元素在中间，则递归栈的深度为log2(n)，则复杂度为O(nlog2(n))；若数组已排好序，则复杂度会变为O(n^2)。空间复杂度为栈的深度，为O(log2(n))~O(n)。排序过程中，各元素会来回颠倒，是不稳定的。


### 2.3、简单插入排序（Instertion Sort）
##### 2.3.1、算法描述
>从第二个元素开始，将元素往前面已排序好的序列中进行插入，直到整个数组有序。
>算法复杂度为O(n^2)，若数组已排序好，则算法复杂度变为O(n)；空间复杂度为O(1)；排序是稳定的。


### 2.4、希尔排序（Shell Sort）
##### 2.4.1、算法描述
>1959年Shell发明的，第一个突破O(n^2)的算法，是简单插入排序的改进版。每次取间隔为m的子序列进行插入排序，m每次变为原先的一半，直到变为1。希尔排序又称缩小增量排序。
>希尔排序的下届是O(log2(n))，比O(n^2)要快很多；中等规模数据表现良好，没有快排快。希尔排序过程中，间隔较大时，排序的元素较少；间隔较小时，元素已基本有序，需要移动的元素较少，所以要比简单的插入排序快很多。时间复杂平均为**O(n^1.3)**,空间复杂度为O(1)，是不稳定的排序算法。


### 2.5、简单选择排序（Selection Sort）
##### 2.5.1、算法描述
>每次选择最大的元素与最后一个交换，n-1次交换后，数组变为有序的。
>时间复杂度总是O(n^2)，最为简单直观的算法，不如冒泡排序，选择排序元素的交换次数要比冒泡排序少。空间复杂度为O(1)，是不稳定的排序算法。**选择排序根据算法的实现细节可以是稳定的算法，比较每次取最大的数放到最后时，两个数相同时取后一个数，这样排序就是稳定的。但是网上都说简单选择排序是不稳定的，这里不深究了（ps：可能是我错了）。**

### 2.6、堆排序（Heap Sort）
##### 2.6.1、算法描述和分析
> 堆排序是将数组想象成一个二叉树的结构进行排序。
> 1. 将数组初始化为了一个最大堆。
> 2. 将数组的第一个元素和最末尾的一个元素进行交换，再采用堆调整算法，使其重新成为一个最大堆。
> 3. 堆调整算法：左右子树都符合堆的要求，只有堆顶的元素不符合，从上往下从新调整堆，从而使整个堆符合要求。2^k * 1 + 2^(k-1) * 2 + … + k，调整算法的复杂度为O(lg(n))。
> 4. 初始化堆的过程：从最后一个元素开始对堆进行调整，则调整某个元素的时候，其左右子树已符合堆的要求。采用堆调整算法对其进行调整，每次调整的复杂度为O(lg(n))，2^k * k + 2^(k-1) * (k-1) + … + 1，其总的复杂度为O(nlgn)。
>堆排序是在一个二叉树上进行排序，初始化堆的复杂度为O(n)，调整堆每次操作的时间为log2(n),log2(n-1).... 其时间复杂度为O(log2(n))，空间复杂度为O(1)，元素在二叉上中上升的过程是杂乱的，其是不稳定的排序算法。

###2.7、二路归并排序（Merge Sort）
#####2.7.1、算法描述
>采用分治法（Divide and Conquer）的典型例子，将原数组分成两个子序列，再对偏好的子序列进行合并。
>归并排序的算法复杂度为O(nlog2(n))，其空间复杂度为O(n),排序过程是稳定的。

###2.8、计数排序（Counting Sort）
#####2.8.1、算法描述
>按照数组最大值最小值得范围分配辅助空间的大小，对每个数出现的次数进行统计，之后辅助空间按序输出即可得到排好序的数组。设数的范围为k，则空间时间复杂度都为O(n+k)。

###2.9、桶排序（Bukket Sort）
#####2.9.1、算法描述
>将元素分配预先设置好的桶中，然后再对桶中的元素进行排序，有点类似于归并排序。

###2.10、基数排序（Radix Sort）
#####2.10.1、算法描述
>先按低位排序，再按高位排序，相当于不停地将元素分配到0~9十个桶中，属于桶排序的一种。基数排序基于分别排序，分别收集，所以是稳定的。但基数排序的性能比桶排序要略差，每一次关键字的桶分配都需要O(n)的时间复杂度，而且分配之后得到新的关键字序列又需要O(n)的时间复杂度。假如待排数据可以分为d个关键字，则基数排序的时间复杂度将是O(d*2n) ，当然d要远远小于n，因此基本上还是线性级别的。基数排序的空间复杂度为O(n+k)，其中k为桶的数量。一般来说n>>k，因此额外空间需要大概n个左右。


##4、快排、堆排序和归并排序比较（来源维基百科）
- 1、快速排序是二叉查找树（二叉搜索树）的一个空间最优化版本。不是循序地把数据项插入到一个明确的树中，而是由快速排序组织这些数据项到一个由递归调用所隐含的树中。这两个算法完全地产生相同的比较次数，但是顺序不同。对于排序算法的稳定性指标，原地分割版本的快速排序算法是不稳定的。其他变种是可以通过牺牲性能和空间来维护稳定性的。

- 2、快速排序的最直接竞争者是堆排序（Heapsort）。堆排序通常比快速排序稍微慢，但是最坏情况的运行时间总是O(nlog2(n))。快速排序是经常比较快，除了introsort变化版本外，仍然有最坏情况性能的机会。如果事先知道堆排序将会是需要使用的，那么直接地使用堆排序比等待introsort再切换到它还要快。堆排序也拥有重要的特点，仅使用固定额外的空间（堆排序是原地排序），而即使是最佳的快速排序变化版本也需要O(log2(n))的空间。然而，**堆排序需要有效率的随机存取才能变成可行**。

- 3、快速排序也与归并排序（Mergesort）竞争，这是另外一种递归排序算法，但有坏情况O(log2(n))运行时间的优势。不像快速排序或堆排序，归并排序是一个**稳定排序**，且可以轻易地被采用在链表（linked list）和存储在慢速访问媒体上像是磁盘存储或网络连接存储的非常巨大数列。**尽管快速排序可以被重新改写使用在链串列上，但是它通常会因为无法随机存取而导致差的基准选择。**归并排序的主要缺点，是在最佳情况下需要O(n)额外的空间。


##4、STL中的sort实现
>STL的sort算法，数据量大时采用QuickSort快排算法，分段归并排序。一旦分段后的数据量小于某个门槛（16），为避免QuickSort快排的递归调用带来过大的额外负荷，就改用Insertion Sort插入排序（插入排序在面对几乎排序号的序列时，表现更好）。如果递归层次过深，还会改用HeapSort堆排序。

>快速排序最关键的地方在于枢轴的选择，最坏的情况发生在分割时产生了一个空的区间，这样就完全没有达到分割的效果。STL采用的做法称为median-of-three，即取整个序列的首、尾、中央三个地方的元素，以其中值作为枢轴。

```
template <class _RandomAccessIter>
 
inline void sort(_RandomAccessIter __first, _RandomAccessIter __last) {
	__STL_REQUIRES(_RandomAccessIter, _Mutable_RandomAccessIterator);
	__STL_REQUIRES(typename iterator_traits<_RandomAccessIter>::value_type,_LessThanComparable);
	if (__first != __last) {
		__introsort_loop(__first, __last,
	__VALUE_TYPE(__first), 
	__lg(__last - __first) * 2);
	__final_insertion_sort(__first, __last);
}
```

###4.1、算法描述
>STL中的sort不是普通的快排，除了对普通的快速排序进行优化，它还结合了插入排序和堆排序。根据不同的数量级别以及不同情况，能自动选用合适的排序方法。当数据量较大时采用快速排序，分段递归。一旦分段后的数据量小于某个阀值，为避免递归调用带来过大的额外负荷，便会改用插入排序；而如果递归层次过深，有出现最坏情况的倾向，还会改用堆排序。

#####4.1.1、普通的快排
>快速排序的描述如下：
- 从序列中选取排序基准（pivot）；
- 对序列进行排序，所有比基准值小的摆放在基准左边，所有比基准值大的摆在基准的右边，序列分为左右两个子序列。称为分区操作（partition）；
- 递归，对左右两个子序列分别进行快速排序。

>其中分区操作的方法通常采用两个迭代器head和tail，head从头端往尾端移动，tail从尾端往头端移动，当head遇到大于等于pivot的元素就停下来，tail遇到小于等于pivot的元素也停下来，若head迭代器仍然小于tail迭代器，即两者没有交叉，则互换元素，然后继续进行相同的动作，向中间逼近，直到两个迭代器交叉，结束一次分割。

>快速排序最关键的地方在于基准的选择，最坏的情况发生在分割时产生了一个空的区间，这样就完全没有达到分割的效果。STL采用的做法称为median-of-three，即取整个序列的首、尾、中央三个地方的元素，以其中值作为基准。

#####4.1.2、内省式排序 Introsort
>不当的基准选择会导致不当的分割，会使快速排序恶化为 O(n^2)。David R.Musser于1996年提出一种混合式排序算法：Introspective Sorting（内省式排序），简称IntroSort，其行为大部分与上面所说的median-of-three Quick Sort完全相同，但是当分割行为有恶化为二次方的倾向时，能够自我侦测，转而改用堆排序，使效率维持在堆排序的 O(nlgn)，又比一开始就使用堆排序来得好。

###4.2、代码剖析

#####4.2.1、函数声明
```
#include <algorithm>

template <class RandomAccessIterator>
  void sort (RandomAccessIterator first, RandomAccessIterator last);

template <class RandomAccessIterator, class Compare>
  void sort (RandomAccessIterator first, RandomAccessIterator last, Compare comp);
```
>函数有两种形式，一种采用默认的比较函数，另一种可自定义比较函数。

#####4.2.2、__sort代码实现
```
template<typename _RandomAccessIterator, typename _Compare>
inline void __sort(_RandomAccessIterator __first,
					_RandomAccessIterator __last,
					_Compare __comp)
{
  if (__first != __last)
	{
	  std::__introsort_loop(__first, __last,
	            std::__lg(__last - __first) * 2,
	            __comp);
	  std::__final_insertion_sort(__first, __last, __comp);
	}
}
```
>函数先调用了了__introsort_loop进行排序，std::__lg(__last - __first) * 2表示容许递归的最大深度，用来控制分割最恶劣的情况。最后调用了_final_insertion_sort进行插入排序，插入排序在序列已经几乎有序的情况表现是非常好的。

####4.2.3、__introsort_loop代码实现
```
/// This is a helper function for the sort routine.
template<typename _RandomAccessIterator, typename _Size, typename _Compare>
void __introsort_loop(_RandomAccessIterator __first,
         _RandomAccessIterator __last,
         _Size __depth_limit, _Compare __comp)
{
  	while (__last - __first > int(_S_threshold))
	{
		if (__depth_limit == 0)
		{
		  std::__partial_sort(__first, __last, __last, __comp);
		  return;
		}
		--__depth_limit;
		_RandomAccessIterator __cut = std::__unguarded_partition_pivot(__first, __last, __comp);
		std::__introsort_loop(__cut, __last, __depth_limit, __comp);
		__last = __cut;
	}
}
```
- 首先判断元素规模是否大于阀值_S_threshold，_S_threshold是一个常整形的全局变量，值为16，表示若元素规模小于等于16，则结束内省式排序算法，返回sort函数，改用插入排序 __final_insertion_sort。
- 若元素规模大于_S_threshold，则判断递归调用深度是否超过限制。若已经到达最大限制层次的递归调用，则改用堆排序。代码中的 __partial_sort 即用堆排序实现。
- 若没有超过递归调用深度，则调用函数 __unguarded_partition_pivot 对当前元素做一趟快速排序，并返回基准位置。
- 快排之后，再递归对右半部分调用内省式排序算法。然后回到while循环，对左半部分进行排序。源码写法和我们一般的写法不同，但原理是一样的，这是很明显的尾递归优化，需要注意。这种写法可降低递归的深度。**这里的算法并不理解，有机会了再好好学习。**

#####4.2.4、__unguarded_partition_pivot代码实现
```
/// This is a helper function...
template<typename _RandomAccessIterator, typename _Compare>
_RandomAccessIterator
__unguarded_partition(_RandomAccessIterator __first,
          _RandomAccessIterator __last,
          _RandomAccessIterator __pivot, _Compare __comp)
{
	while (true)
	{
		while (__comp(__first, __pivot))
			++__first;
		--__last;
		while (__comp(__pivot, __last))
			--__last;
		if (!(__first < __last))
			return __first;
		std::iter_swap(__first, __last);
		++__first;
	}
}

/// This is a helper function...
template<typename _RandomAccessIterator, typename _Compare>
inline _RandomAccessIterator
__unguarded_partition_pivot(_RandomAccessIterator __first,
            _RandomAccessIterator __last, _Compare __comp)
{
  _RandomAccessIterator __mid = __first + (__last - __first) / 2;
  std::__move_median_to_first(__first, __first + 1, __mid, __last - 1,
              __comp);
  return std::__unguarded_partition(__first + 1, __last, __first, __comp);
}
```
> 快速排序，并返回枢轴位置。\__unguarded_partition()函数采用的便是上面所讲的使用两个迭代器的方法，将序列分为左右两个子序列。其中还注意到 \__move_median_to_first 函数，就是之前提到的 median-of-three，目的是从头部、中部、尾部三个数中选出中间值作为“基准”，基准保存在 __first 中，实现代码如下：
```
/// Swaps the median value of *__a, *__b and *__c under __comp to *__result
template<typename _Iterator, typename _Compare>
void __move_median_to_first(_Iterator __result,_Iterator __a, _Iterator __b,
           _Iterator __c, _Compare __comp)
{
	if (__comp(__a, __b))
	{
		if (__comp(__b, __c))
			std::iter_swap(__result, __b);
		else if (__comp(__a, __c))
			std::iter_swap(__result, __c);
		else
			std::iter_swap(__result, __a);
	}
	else if (__comp(__a, __c))
		std::iter_swap(__result, __a);
	else if (__comp(__b, __c))
		std::iter_swap(__result, __c);
	else
		std::iter_swap(__result, __b);
}
```
#####4.2.3、其它部分不再分析，以后有机会可再对这块代码进行深入学习