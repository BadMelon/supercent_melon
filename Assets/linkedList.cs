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


	/*public class LinkedListNode<T>
	{
		public LinkedList<T> List { set; get; } = null;

		internal LinkedListNode<T> prev = null;
		internal LinkedListNode<T> next = null;

		//public LinkedListNode<T> Prev => prev != null && this != List.First ? prev : null;
		//public LinkedListNode<T> Next => next != null && this != List.First ? next : null;
		
		public T Value { set; get; } = default;

		internal LinkedListNode(LinkedList<T> list)
        {
			if (list == null)
				throw new Exception($"{nameof(list)}가 null입니다.");

			List = list;
        }

		internal void Release()
        {
			List = null;
			prev = null;
			next = null;
			Value = default;
        }
	}

	public sealed class LinkedList<T> : IEnumerable<T>
	{
		// 양방향 링크로 구현하세요
		public int Count { private set; get; } = 0;
		LinkedListNode<T> head = null;
		
		public LinkedListNode<T> First => head; //get만 존재하는 읽기전용 프로퍼티는 람다로 정리가 가능하다.
		public LinkedListNode<T> Last => head?.prev;
		
		public LinkedList() { }

		void SetLink(LinkedListNode<T> nodeAdd,LinkedListNode<T> nodeNext)
        {
			if (nodeAdd == null)
				throw new Exception($"{nodeAdd}가 null입니다.");
			if (nodeNext == null)
				throw new Exception($"{nodeNext}가 null입니다.");

			nodeAdd.prev = nodeNext.prev;
			nodeNext.prev.next = nodeAdd;

			nodeAdd.next = nodeNext;
			nodeNext.prev = nodeAdd;
        }

		public bool Contains(T value)
		{
			var node = head;

			while(node !=null)
            {
				if (EqualityComparer<T>.Default.Equals(node.Value, value))
					return true;
				node = node.next;
				if (node == head)
					break;
            }
			return false;
		}

		IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();
		public IEnumerator<T> GetEnumerator()
		{
			var node = head;
			while(node != null)
            {
				yield return node.Value;
				node = node.next;
				if (node == head)
					break;
            }
		}


		public LinkedListNode<T> AddFirst(T value)
		{
			var addNode = new LinkedListNode<T>(this) { Value = value };

			if (head != null) //노드가 비어있지 않으면
				SetLink(addNode, head);
            else //비어있으면 head설저
            {
				addNode.prev = addNode;
				addNode.next = addNode;
            }

			return head;

		}
		public LinkedListNode<T> AddLast(T value)
		{
			
			

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
	}*/
	// Start is called before the first frame update
	void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
