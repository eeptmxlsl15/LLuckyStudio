using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.SocialPlatforms.Impl;

public class JellyPawAdapter : IScore
{
	public void AddScore(int score)
	{
		GameManager.Score.AddJellyPaw(score);
	}

	public void AddCount(int count)
	{
		GameManager.Score.AddJellyPawCount(count);
	}
}