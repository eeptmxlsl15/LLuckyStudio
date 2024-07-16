using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class QuestManager : MonoBehaviour
{
	public List<QuestCategory> questCategories;

	private void Start()
	{
		InitializeQuests();
	}

	private void InitializeQuests()
	{
		foreach (var category in questCategories)
		{
			foreach (var quest in category.quests)
			{
				// 모든 퀘스트를 초기화
				quest.isComplete = false;
				Debug.Log("퀘스트 시작 : " + quest.questName);
			}
		}
	}

	public void UpdateQuestProgress(string questName, int score)
	{
		Debug.Log($"퀘스트 진행 상황 업데이트 / 퀘스트 이름: {questName}, 점수 : {score}");
		foreach (var category in questCategories)
		{
			foreach (var quest in category.quests)
			{
				if (quest.questName == questName && !quest.isComplete)
				{				
					quest.CheckCompleteQuest(score);
					Debug.Log($"퀘스트 확인 중 : {quest.questName}");
				}
			}
		}
	}

	public void CompleteQuest(string questName)
	{
		foreach (var category in questCategories)
		{
			foreach (var quest in category.quests)
			{
				if (quest.questName == questName)
				{
					quest.isComplete = true;
					Debug.Log(questName + " 완료");
				}
			}
		}
	}
}
