using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//젤리 코인(점수 코인)
public class JellyCoin : Goods
{ 
	private IScore scoreAdapter;

	private void Awake()
    {
		scoreAdapter = new JellyCoinAdapter();
		// TODO : AudioClip 초기화
	}

	public override void Contact()
	{
		gameObject.SetActive(false);
		scoreAdapter.AddScore(10);
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
