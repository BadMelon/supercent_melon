using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace melon
{
    public class TestQueue : StudyBase
    {
        
        protected override void OnLog()
        {
            var queue = new Queue<string>();
            queue.Enqueue("1stJob");
            queue.Enqueue("2ndJob");
            // 1stJob
            Log(queue.Peek());

            queue.Enqueue("3rdJob");
            var str = queue.Dequeue();
            // 1stJob;
            Log(str);

            queue.Enqueue("4thJob");
            // 2ndJob, 3rdJob, 4thJob
            queue.LogValues();
        }
		public sealed class Queue<T> : IEnumerable<T>
		{
			// 링버퍼 구조로 구현하세요
			int front = 0;
			int rear = 0;
			const int DefaultCapacity = 4;
			public int Count { private set; get; } = 0;
			T[] array = null;
			public Queue() => array = new T[DefaultCapacity];
			public Queue(int capacity) => array = new T[capacity];
			bool overLengthCheck = false; //배열이 가득 찼을시 대응방법 선택 외부에서 사용하기가 불가, 생성자에서 진입필요
										  //프로그래밍을 할때 다른사람의 사용유무 파악필요

			
			

			public bool Contains(T value)
			{
				if (Count == 0)
					throw new Exception("Queue가 비어있습니다."); // return false가 적합하다.
				for(int i = front; i< Count + front; i++)
                {
					if (EqualityComparer<T>.Default.Equals(array[i % array.Length], value))
						return true;
                }
				return false;
			}

			public T Peek()
			{
				if(Count==0)
                {
					throw new Exception("Queue가 비어있습니다.");
                }
				return array[front];
			}

			IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();
			public IEnumerator<T> GetEnumerator()
			{
				for(int i = front; i< Count+front; i++)
                {
					yield return array[i % array.Length];
                }
			}


			public void Enqueue(T value)
			{
				//if (EqualityComparer<T>.Default.Equals(value, default(T))) //Null을 대응하기위한 default대응
				//Null은 vaule이자 비어있는 ptr, 변수도 역시 value(값)
				//NUll 역시 값으로 받을수있다.
				//	throw new Exception("입력값이 Default입니다.");
				//Nullable<T>를 통해 초기화가 되었는지 유무를 파악한다
				if (front == (rear + 1) % array.Length)// front랑 rear가 만났을때
                {
					if (overLengthCheck)
						System.Array.Resize(ref array, array.Length * 2);
					else
						throw new Exception("Queue가 가득찼습니다.");
				}
				array[rear] = value;
				rear = (rear + 1) % array.Length;
				Count++;
			}
			public T Dequeue()
			{
				if (Count == 0)
					throw new Exception("Queue가 비어있습니다.");
				T num = array[front];
				array[front] = default;
				front = (front+1) % array.Length;
				Count--;
				return num;
				
			}

			public void Clear()
			{
				System.Array.Resize(ref array, 0);
				front = 0;
				rear = 0;
				Count = 0;
			}

        }

	}
}
