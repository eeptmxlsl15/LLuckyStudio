using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class JellyPawAdapter : IScore
{
	public void AddScore(int score)
	{
		GameManager.Score.AddJellyPaw(score);
	}
}