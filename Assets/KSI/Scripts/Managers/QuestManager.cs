using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEditor.PackageManager.Requests;
using UnityEngine;
using UnityEngine.UI;

public class QuestManager : MonoBehaviour
{
	[SerializeField] private TextMeshProUGUI scoreText;

	public List<Quest> quests;
	private ResultUI resultUI;
	private DeathUI deathUI;

	private void Start()
	{
		InitializeQuests();
		resultUI = FindObjectOfType<ResultUI>();
		deathUI = FindObjectOfType<DeathUI>();

		GameManager.OnGameEndChanged += OnGameEnd;
	}

	private void InitializeQuests()
	{

		foreach (var quest in quests)
		{
			quest.isComplete = false;
			quest.currentScore = 0;
			Debug.Log("퀘스트 시작 : " + quest.curQuestName);
		}
	}

	public void UpdateQuestProgress(Quest.QuestName questName, int score)
	{
		Debug.Log($"퀘스트 진행 상황 업데이트 / 퀘스트 이름: {questName}, 점수 : {score}");
		bool questFound = false;

		foreach (var quest in quests)
		{
			Debug.Log($"확인 중인 퀘스트: {quest.curQuestName}");
			if (quest.curQuestName == questName)
			{
				questFound = true;

				if (!quest.isComplete)
				{
					int previousScore = quest.currentScore;
					quest.currentScore += score;
					Debug.Log($"퀘스트: {quest.curQuestName}, 이전 점수: {previousScore}, 현재 점수: {quest.currentScore}");

					quest.CheckCompleteQuest(quest.currentScore);

					if (scoreText != null)
					{
						scoreText.text = $"{quest.currentScore} / {quest.targetScore}";
					}

					if (quest.isComplete)
					{
						resultUI.DisplayResultUI();
						GiveReward(quest);
					}
				}
				else
				{
					Debug.Log($"퀘스트 {quest.curQuestName}는 이미 완료됨");
				}
			}
		}
		if (!questFound)
		{
			Debug.LogError($"퀘스트 이름 '{questName}'을 찾을 수 없음");
		}
	}

	public void CompleteQuest(Quest.QuestName questName)
	{
		foreach (var quest in quests)
		{
			if (quest.curQuestName == questName)
			{
				quest.isComplete = true;
				Debug.Log(questName + " 완료");
			}
		}
	}

	private void GiveReward(Quest quest)
	{
		GiveSushi(quest);

		if (quest.rewardDesirePiece)
		{
			GiveDesirePiece(quest);
		}
	}

	private void GiveSushi(Quest quest)
	{
		int reward = quest.GetReward() * 5;
		Debug.Log($"퀘스트 보상 : '{quest.curQuestName}' / 초밥 {reward} 개 ");
		DataManager.Instance.sushi += reward;
		resultUI.UpdateRewardSushiText(reward);
	}

	private void GiveDesirePiece(Quest quest)
	{
		int rewardValue = quest.GetDesirePiece();
		Debug.Log($"퀘스트 보상 : '{quest.curQuestName}' / 깨진 염원 조각 {rewardValue} 개");
		resultUI.UpdateDesirePieceiText(rewardValue);
	}

	private void OnGameEnd()
	{
		foreach (var quest in quests)
		{
			if (quest.curQuestName == Quest.QuestName.Quest_INFINITE)
			{
				resultUI.DisplayResultUI();
				GiveReward(quest);
			}
		}
	}
}