using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// 불기둥(화상 피해)
// 고정형 오브젝트
// 데미지 : -10
public class FirePillar : Obstacle
{
	private void Start()
	{
		damage = 10;
	}
}
