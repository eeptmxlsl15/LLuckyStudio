using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// 통조림
// 고양이 염원을 강화시킬 때 필요한 강화 재화
// 보상 : 일일상점, 랭킹 보상을 통해 획득 가능
public class CannedFood : Goods
{
	private void Awake()
	{
		scoreAdapter = new CannedFoodAdapter();
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
