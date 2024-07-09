using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// 통조림(강화 재화)
public class CannedFood : Item
{
	private IScore scoreAdapter;

	private void Awake()
	{
		scoreAdapter = new CannedFoodAdapter();
		// TODO : AudioClip 초기화
	}

	public override void Contact()
	{
		gameObject.SetActive(false);
		scoreAdapter.AddScore(20);
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
