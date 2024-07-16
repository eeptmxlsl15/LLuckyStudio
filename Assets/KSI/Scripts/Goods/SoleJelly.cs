using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// 젤리 발바닥(점수 코인)
// 스토리 및 무한 모드에서 획득한 젤리 코인을 생선으로 환산
// 플레이 점수
// 보상으로 젤리 발바닥 1개당 점수 100점
// 젤리 발바닥 1개당 초밥 5개
public class SoleJelly : Goods
{
	private void Awake()
    {
		scoreAdapter = new JellyCoinAdapter();
		// TODO : AudioClip 초기화
	}

	public override void Contact()
	{
		gameObject.SetActive(false);
		scoreAdapter.AddScore(scoreValue);
	}

	private void OnTriggerEnter2D(Collider2D collision)
	{
		if (collision.gameObject.tag == "Player")
		{
			Contact();
			// TODO : 효과음 추가
		}
	}
}
