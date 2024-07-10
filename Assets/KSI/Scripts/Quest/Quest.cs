using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Quest", menuName = "Quest/Quest")]
public class Quest : ScriptableObject
{
	public enum QuestType
	{
		CollectJellyCoins,
		Jump,
		ClearWithoutHit,
		Slide
	}

	public string questName;
	public string description;
	public QuestType questType;
	public bool isCompleted;
}
