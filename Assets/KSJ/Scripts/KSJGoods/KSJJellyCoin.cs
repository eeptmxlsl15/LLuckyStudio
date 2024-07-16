using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// 젤리 코인(점수 코인)
// 스토리 및 무한 모드에서 획득한 젤리 코인을 생선으로 환산
// 환산 : 젤리 1코인 = 생선 1마리
public class KSJJellyCoin : Goods
{
	Player player;
	private void Awake()
    {
		player = FindAnyObjectByType<Player>();
		scoreAdapter = new JellyCoinAdapter();
		// TODO : AudioClip 초기화
	}

	public override void Contact()
	{
		gameObject.SetActive(false);
		if (player.activeDesires[3])
		{
			
			scoreAdapter.AddScore(scoreValue+5);
		}
		else
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
