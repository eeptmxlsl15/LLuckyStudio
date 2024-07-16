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
	public int reward;

	public void CheckCompleteQuest(int score)
	{
		Debug.Log($"{questName} 완료 체크, 현재 점수 : {score}, 목표 점수: {scoreTarget}");
		if (score >= scoreTarget)
		{
			isComplete = true;
			Debug.Log(questName + " 완료");
		}
		else
		{
			Debug.Log($"{questName} 완료 못함. 현재 점수 : {score}, 목표 점수: {scoreTarget}");
		}
	}

	public int GetReward()
	{
		// 젤리 발바닥 1개당 초밥 5개로 계산
		return reward * 5;
	}
}
