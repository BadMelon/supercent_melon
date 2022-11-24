using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DictionaryEx : StudyBase
{
	protected override void OnLog()
	{
		// Hash는 알고리즘 마다 저장 순서가 다를수 있습니다
		var map = new testDictionary<int, string>();
		map[101] = "김민준";
		map[201] = "윤서준";
		map[101] = "박민준";
		// [101, 박민준], [201, 윤서준]
		map.LogValues();

		map.Add(302, "김도윤");
		map.Remove(101);
		map.Add(102, "서예준");
		// [102, 서예준], [201, 윤서준], [302, 김도윤]
		map.LogValues();
	}

}
