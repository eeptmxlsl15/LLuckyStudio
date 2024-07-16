using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class SoleJellyAdapter : IScore
{
	public void AddScore(int score)
	{
		GameManager.Score.AddJellyCoin(score);
	}
}