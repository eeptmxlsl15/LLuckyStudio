using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Quest", menuName = "QuestSystem/Quest")]
public class Quest : ScriptableObject
{
	public string questName;
	public string description;
	public bool isComplete;
	public int scoreTarget;

	public void CheckComplete(int score)
	{
		if (score >= scoreTarget)
		{
			isComplete = true;
			Debug.Log(questName + " is completed.");
		}
	}
}
