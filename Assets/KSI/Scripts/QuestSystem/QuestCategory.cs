using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/* 삭제 */
[CreateAssetMenu(fileName = "New Quest Category", menuName = "QuestSystem/QuestCategory")]
public class QuestCategory : ScriptableObject
{
	public string categoryName;
	public Quest[] quests;
}