using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class ScoreAdapter : IScore
{
	public void AddScore(int score)
	{
		GameManager.Score.AddJellyCoin(score);
	}
}
