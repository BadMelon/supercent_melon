using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public sealed class testDictionary<K, T> : IEnumerable<KeyValuePair<K, T>>
{


	// buckets, entries 구현이 필요합니다.
	const int Defaultcapacity = 4;
	Entry[] buckets = null;
	public testDictionary() => buckets = new Entry[Defaultcapacity];
	public testDictionary(int capacity) => buckets = new Entry[capacity];
	public int Count { private set; get; } = 0;




    public T this[K key]
	{
		set
		{
			Add(key, value);
		}
		get
		{
			if (buckets[Hash_setting(key.GetHashCode())].value != null)
				return buckets[Hash_setting(key.GetHashCode())].value;
			else
				throw new Exception("해당 Key값의 Value가 존재하지 않습니다.");
		}
	}


	public bool ContainsKey(K key)
	{
		int hash = key.GetHashCode() % buckets.Length;
		if(buckets[hash].value != null)
			return true;
		return false;
	}
	public bool ContainsValue(T value)
	{
		for(int i = 0; i< buckets.Length; i++)
           {
			if (EqualityComparer<T>.Default.Equals(buckets[i].value, value))
				return true;
           }
		return false;
	}

	public bool TryGetValue(K key, out T result) //검색을 한번만 하기 위한 기능
	{
		int hash = key.GetHashCode() % buckets.Length ;
		result = buckets[hash].value;
		if (result != null)
			return true;
		return false;
	}

	IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();
	public IEnumerator<KeyValuePair<K, T>> GetEnumerator()
	{
		KeyValuePair<K, T> kv;
		foreach (var pair in buckets)
           {
			 yield return kv = new KeyValuePair<K, T>(pair.key, pair.value);
           }
	}


	public bool Add(K key, T value)
	{
		
		int hash = key.GetHashCode();
		int index = Hash_setting(hash);
		
		 
		buckets[index].key = key;
		buckets[index].value = value;
		Count++;
		return true; //왜 bool을 리턴하는거지???? => 값을 넣으면 true 이미 있으면 fasle??? 안들어가는경우가 없는데???
	}
	int Hash_setting(int hash) //Linear probing방식 구현
	{
		int checkIndex = hash % buckets.Length;
		int count = 0;
		
		if(buckets[checkIndex].value != null)
	    {
			while(count < buckets.Length)
	        {
				if (buckets[(++checkIndex) % buckets.Length].value == null)
	            {
					return checkIndex % buckets.Length;
	            }
				count++;
	        }
	    }
		if (count == 0)
			return checkIndex;
		else
        {
			int NextArrIndex = buckets.Length;
			Array.Resize(ref buckets, buckets.Length * 2);
			return NextArrIndex;
        }
	}


	public bool Remove(K key)
	{
		if (Count == 0)
			return false;
		int hash = key.GetHashCode() % buckets.Length;
		buckets[hash % buckets.Length].key = default;
		buckets[hash % buckets.Length].value = default;
		return true;
	}

	public void Clear()
	{
		Array.Resize(ref buckets, 0);
		Count = 0;
	}


	struct Entry
	{
		public int hashCode;
		public int next;
		public K key;
		public T value;
	}
}

