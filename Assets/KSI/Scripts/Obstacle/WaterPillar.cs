using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// 물기둥
// 고정형 오브젝트
// 데미지 : -10
// 무한 모드
public class WaterPillar : Obstacle
{
	[SerializeField] private float speedReduction = 0.5f;
	[SerializeField] private float durationTime = 2f;

	private void Start()
	{
		damage = 0;
	}

	//void OnTriggerEnter2D(Collider2D other)
	//{
	//	BackgroundScroller bgScroller = other.GetComponent<BackgroundScroller>();
	//	if (bgScroller != null)
	//	{
	//		bgScroller.ReduceSpeed(speedReduction, durationTime);
	//	}
	//}
}
