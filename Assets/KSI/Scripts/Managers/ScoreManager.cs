using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.Events;

public class ScoreManager : MonoBehaviour
{
	public int jellyPawText;
	//public int cannedFoodText;

	public UnityAction<int> OnJellyPawChanged;
	//public UnityAction<int> OnCannedFoodChanged;

	public void AddJellyPaw(int score)
	{
		jellyPawText += score;
		OnJellyPawChanged?.Invoke(jellyPawText);
	}

	//public void AddCannedFood(int score)
	//{
	//	cannedFoodText += score;
	//	OnCannedFoodChanged?.Invoke(cannedFoodText);
	//}
}