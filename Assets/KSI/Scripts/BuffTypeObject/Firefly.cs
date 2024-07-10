using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// 반딧불
// 버프형 오브젝트
// 날아오는 오브젝트
// 버프 : 체력 10회복
// 스토리 모드(서브, 보스, 보스(광폭)), 무한 모드
public class Firefly : BuffTypeObject
{
	public override void Buff()
	{
		player.Heal(10);
	}
}
