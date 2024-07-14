using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// 쉴드
// 버프형 오브젝트
// 고정형 오브젝트
// 버프 : 장애물 1회 방어(낙사 제외)
// 스토리 모드(서브, 보스, 보스(광폭)), 무한 모드
// 획득 시 사라짐
public class Shield : BuffTypeObject
{
	public override void Buff()
	{
		player.BlockObstacle();
	}
}
