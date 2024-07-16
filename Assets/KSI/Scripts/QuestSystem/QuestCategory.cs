using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Quest Category", menuName = "QuestSystem/QuestCategory")]
public class QuestCategory : ScriptableObject
{
	public string categoryName;
	public Quest[] quests;
}
