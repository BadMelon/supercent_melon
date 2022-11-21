using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace melon
{

    public class list : StudyBase
    {
		protected override void OnLog()
		{
			var aList = new List<int>();

			aList.Add(2);
			// 2
			aList.LogValues();

			aList.Insert(0, 1);
			// 1, 2
			aList.LogValues();

			aList.Add(4);
			aList.Insert(aList.Count - 1, 3);
			// 1, 2, 3, 4
			aList.LogValues();

			aList.Remove(2);
			aList.RemoveAt(0);
			// 4
			Log(aList[aList.Count - 1]);
		}
		public sealed class List<T> : IEnumerable<T>
		{
			
			public int Count { private set; get; } = 0;
			T[] array = new T[4];
			
			public T this[int index]
			{
				
				set
				{
					array[index] = value;
				}
				get
				{
					return array[index];
				}
			}
			

			public bool Contains(T value)
			{
				for(int i = 0; i < array.Length; i++)
                {
					if (EqualityComparer<T>.Default.Equals(array[i], value))
						return true;
                }
				return false;
			}

			IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();
			public IEnumerator<T> GetEnumerator()
			{
				for(int i = 0; i< Count; i++)
                {
					yield return array[i];
                }
			}


			public void Add(T value)
			{
				if(Count == array.Length)
                {
					//array의 길이 2배증가
					System.Array.Resize(ref array, array.Length * 2);
                }
				array[Count++] = value;
			}
			public void Insert(int index, T value)
			{
				if (Count == array.Length)
				{
					//array의 길이 2배증가
					System.Array.Resize(ref array, array.Length * 2);
				}
				for (int i = Count; index < i ; i--)
                {
					array[i] = array[i - 1];
                }
				array[index] = value;
				Count++;

			}

			public bool Remove(T value)
			{
				for(int i = 0; i< Count; i++)
                {
					if(EqualityComparer<T>.Default.Equals(array[i], value))
                    {
						for(int j = i; j<Count - 1; j++)
                        {
							array[j] = array[j + 1];
                        }
                    }
                }
				Count--;
				return false;
			}
			public void RemoveAt(int index)
			{
				for(int i = index; i< Count; i++)
                {
					array[i] = array[i + 1];
                }
				Count--;
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

}
