using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// 반딧불
// 버프형 오브젝트
// 날아오는 오브젝트
// 오른쪽에서 왼쪽으로 위아래로 움직이면서 날아옴
// 버프 : 체력 10회복
// 스토리 모드(서브, 보스, 보스(광폭)), 무한 모드
// 획득 시 사라짐
public class KSJFirefly : KSJBuffTypeObject
{
	public float range = 1f; // 이동 범위
	public float cycle = 1f; // 이동 주기

	private Vector3 startPosition;

	public override void Buff()
	{
		player.HealByFirfly(10);
	}

	private void Start()
	{
		// 초기 위치 저장
		startPosition = transform.position; 
	}

	private void Update()
	{
		// Sin을 사용하여 위아래 움직임 계산
		float y = Mathf.Sin(Time.time * cycle) * range;
		// 오른쪽에서 왼쪽으로 이동하면서 위아래로 움직이면서 날아옴
		transform.position = startPosition + Vector3.left * speed * Time.time + Vector3.up * y;
	}
}
