using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public sealed class BST<T> : IEnumerable<T>
{
	public int Count { private set; get; } = 0;
	public BSTNode<T> Root { private set; get; } = null;
	public IComparer<T> Comparer { private set; get; } = Comparer<T>.Default;


	public bool Contains(T value) => Find(value) != null;

	public BSTNode<T> Find(T value)
	{
		var Node = Root;

		while (Root != null)
		{
			if (Comparer.Compare(Node.value, value) == -1) //작을때
			{
				Node = Node.Leftleaf;
			}
			else if (Comparer.Compare(Node.value, value) == 1) //클때
			{
				Node = Node.Rightleaf;
			}
			else //값을 찾았을때
			{
				return Node;
			}
			if (Node == null) //트리가 비어있거나 끝까지 못찾은경우
				break;
		}
		return null;
	}
	void resetVisit(bool check)
    {
		var Node = Root;
		int returnCount = 0;
		while (true)
		{
			if (Node != null && Node.visitCheck == false)
			{
				Node.visitCheck = true;
				if (++returnCount == Count)
					break;
			}
			if (Node.Leftleaf != null && Node.Leftleaf.visitCheck == false) //왼쪽노드가 비어있지 않으면
				Node = Node.Leftleaf; // 왼쪽 노드를 주고
			else
			{
				if (Node.Rightleaf != null && Node.Rightleaf.visitCheck == false)
					Node = Node.Rightleaf;
				else
				{
					Node = Node.parent;
				}
			}

		}
	}
	IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();
	public IEnumerator<T> GetEnumerator()
	{
		var Node = Root;
		Debug.Log(Node.Leftleaf);
		int returnCount = 0;
		if (Node == null)
			throw new Exception("트리가 비어있습니다.");
		while (true)
		{
			if (Node != null && Node.visitCheck == false)
			{
				yield return Node.value;
				Node.visitCheck = true;
				if (++returnCount >= Count)
					break;
			}
			if (null != Node.Leftleaf && Node.Leftleaf.visitCheck == false) //왼쪽노드가 비어있지않고 리턴한적이 없으며
			{
					Node = Node.Leftleaf; // 왼쪽 노드를 주고
			}
			else
			{
				if (Node.Rightleaf != null && Node.Rightleaf.visitCheck == false)
					Node = Node.Rightleaf;
				else
				{
					Node = Node.parent;
				}
			}

		}
		resetVisit(false);
	}




	public IEnumerator<T> GetOverlaps(T min, T max)
	{
		var Node = Root;
		if (Node == null)
			throw new Exception("트리가 비어있습니다");

		while (true)
		{
			if (Node.Leftleaf != null && !Node.Leftleaf.visitCheck)
			{
				Node = Node.Leftleaf;
			}
			else
			{
				if (Node.Rightleaf != null && !Node.Rightleaf.visitCheck)
				{
					Node = Node.Rightleaf;
				}
				else
				{
					if (Node == Root && Node.Leftleaf.visitCheck && Node.Rightleaf.visitCheck)
					{
						if (Comparer.Compare(min, Node.value) != -1 && Comparer.Compare(Node.value, max) != -1)
							yield return Node.value;
						break;
					}
					if (Comparer.Compare(min, Node.value) != -1 && Comparer.Compare(Node.value, max) != -1)
						yield return Node.value;
					Node.visitCheck = true;
					Node = Node.parent;
				}
			}
		}
		resetVisit(false);
	}
	public BSTNode<T> Find_Last_leftLeaf()
	{
		var Node = Root;
		while (Node != null)
		{
			Node = Node.Leftleaf;
		}
		return Node;
	}

	public BSTNode<T> Insert(T value)
	{
		var Node = new BSTNode<T> { value = value };
		var NextNode = Root;
		if (Root == null)
		{
			return Root = Node;
		}
		while (true)
		{
			if (Comparer.Compare(NextNode.value, value) == -1)
			{
				if (NextNode.Leftleaf == null)
				{
					NextNode.Leftleaf = Node;
					Node.parent = NextNode;
					break;
				}
				else
				{
					NextNode = NextNode.Leftleaf;
				}
			}
			else if (Comparer.Compare(NextNode.value, value) == 1)
			{
				if (NextNode.Rightleaf == null)
				{
					NextNode.Rightleaf = Node;
					Node.parent = NextNode;
					break;
				}
				else
				{
					NextNode = NextNode.Rightleaf;
				}
			}
			else
			{
				throw new Exception("중복된값이 Tree에 존재합니다.");
			}
		}
		Count++;
		return Node;
	}

	public bool Remove(T value)
	{
		return false;
	}
	public void Remove(BSTNode<T> node)
	{

	}

	public void Clear()
	{

	}


}