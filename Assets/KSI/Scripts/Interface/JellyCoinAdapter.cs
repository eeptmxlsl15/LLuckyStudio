using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class JellyCoinAdapter : IScore
{
	public void AddScore(int score)
	{
		GameManager.Score.AddJellyCoin(score);
	}
}
