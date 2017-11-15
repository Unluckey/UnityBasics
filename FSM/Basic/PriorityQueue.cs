using UnityEngine;
using System.Collections;
using System.Collections.Generic;


public class PriorityQueue<T>
{
	private List<T> list = new List<T>();

	public IComparer<T> SortComparer { set; get; }

	public int Count
	{
		get
		{
			return list.Count;
		}
	}

	public void Enqueue(T item)
	{
		if (Contains(item))
		{
			return;
		}
		list.Add(item);
		if (SortComparer != null)
			list.Sort(SortComparer);
		else
			list.Sort();
	}

	public T Dequeue()
	{
		if (Count == 0)
		{
			return default(T);
		}
		T item = list[0];
		list.RemoveAt(0);
		return item;
	}

	public T Peek()
	{
		if (Count == 0)
		{
			return default(T);
		}
		return list[0];
	}

	public bool Contains(T item)
	{
		return list.Contains(item);
	}

	public void Clear()
	{
		list.Clear();
	}
}
