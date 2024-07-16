using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// 츄르
// 버프형 오브젝트
// 고정형 오브젝트
// 버프 : 체력 +10
// 스토리 모드(서브, 보스, 보스(광폭)), 무한 모드
// 획득 시 사라짐
public class KSJChur : KSJBuffTypeObject
{
	public override void Buff()
	{
		player.HealByChur(10);
	}
}
