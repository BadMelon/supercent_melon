using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class linkedList : StudyBase
{
	protected override void OnLog()
	{
		var lList = new LinkedList<string>();

		lList.AddFirst("My name is");
		lList.AddLast("AlphaGo");
		lList.AddLast("Hi");
		// My name is, AlphaGo, Hi
		lList.LogValues();

		lList.Remove("Hi");
		lList.AddFirst("Hello");
		// Hello, My name is, AlphaGo
		lList.LogValues();

		lList.RemoveFirst();
		lList.AddLast("I'm glad to meet you");
		// My name is, AlphaGo, I'm glad to meet you
		lList.LogValues();
	}


	public class LinkedListNode<T>
	{
		public LinkedListNode<T> Head;
		public LinkedListNode<T> Tail;
		public T data;
	}

	public sealed class LinkedList<T> : IEnumerable<T>
	{
		// 양방향 링크로 구현하세요
		public int Count { private set; get; } = 0;
		LinkedListNode<T> head = null;
		LinkedListNode<T> tail = null;

		LinkedList<T> linkedlist;
		public LinkedListNode<T> First
		{
            set
            {
				head.Head = null;
				head.Tail = Last.Head;
            }
			get
			{
				return head;
			}
		}
		public LinkedListNode<T> Last
		{
            set
            {
				tail.Head = First.Tail;
				tail.Tail = null;
            }
			get
			{
				return tail;
			}
		}


		public bool Contains(T value)
		{
			foreach(var v in linkedlist)
            {
				if(EqualityComparer<T>.Default.Equals(value, v))
                {
					return true;
                }
            }
			return false;
		}

		IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();
		public IEnumerator<T> GetEnumerator()
		{
			var list = new LinkedList<T>();
			foreach(var v in list)
            {
				yield return v;
            }
		}


		public LinkedListNode<T> AddFirst(T value)
		{
			
			head = First;

			return head;

		}
		public LinkedListNode<T> AddLast(T value)
		{
			
			head = Last;

			return head;
		}

		public LinkedListNode<T> AddBefore(LinkedListNode<T> node, T value)
		{
			return head;
		}
		public LinkedListNode<T> AddAfter(LinkedListNode<T> node, T value)
		{
			return head;
		}

		public bool Remove(T value)
		{
			return true;
		}
		public void Remove(LinkedListNode<T> node)
		{
			if (node == null)
				throw new Exception($"{nameof(node)}가 null 입니다.");
			
		}

		public void RemoveFirst()
		{
			
		}
		public void RemoveLast()
		{
			
		}

		public void Clear()
		{
			
		}
	}
	// Start is called before the first frame update
	void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
