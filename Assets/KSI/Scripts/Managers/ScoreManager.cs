using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.Events;

public class ScoreManager : MonoBehaviour
{
	public int jellyCoinText;
	//public int cannedFoodText;

	public UnityAction<int> OnJellyCoinChanged;
	//public UnityAction<int> OnCannedFoodChanged;

	public void AddJellyCoin(int score)
	{
		jellyCoinText += score;
		OnJellyCoinChanged?.Invoke(jellyCoinText);
	}

	//public void AddCannedFood(int score)
	//{
	//	cannedFoodText += score;
	//	OnCannedFoodChanged?.Invoke(cannedFoodText);
	//}
}