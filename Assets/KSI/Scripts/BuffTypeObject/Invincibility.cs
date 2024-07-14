using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// 무적
// 버프형 오브젝트
// 고정형 오브젝트
// 버프 : 3초간 모든 피해 무적(낙사 제외)
// 스토리 모드(서브, 보스, 보스(광폭)), 무한 모드
// 획득 시 사라짐
public class Invincibility : BuffTypeObject
{
	public override void Buff()
	{
		player.BecomeInvincible(3f);
	}
}
