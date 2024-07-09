using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// 바위
// 고정형 오브젝트(1단 점프)
// 데미지 : -10
public class Rock : Obstacle
{
	private void Start()
	{
		damage = 10;
	}
}
