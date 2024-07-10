using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// 부스터
// 버프형 오브젝트
// 고정형 오브젝트
// 버프 : 3초간 모든 장애물을 파괴하면서 질주(이동 속도 수치가 20증가)
// 스토리 모드(서브, 보스, 보스(광폭)), 무한 모드
public class Booster : BuffTypeObject
{
	public override void Buff()
	{
		player.Booster(3f);
	}
}
