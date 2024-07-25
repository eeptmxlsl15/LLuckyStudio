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

	private void Start()
	{
		Debug.Log("ScoreManager initialized with jellyPawScore: " + jellyPawText);

	}
	public void AddJellyPaw(int score)
	{
		jellyPawText += score;
		Debug.Log("New jellyPawScore: " + jellyPawText);
		OnJellyPawChanged?.Invoke(jellyPawText);
	}

	//public void AddCannedFood(int score)
	//{
	//	cannedFoodText += score;
	//	OnCannedFoodChanged?.Invoke(cannedFoodText);
	//}
}