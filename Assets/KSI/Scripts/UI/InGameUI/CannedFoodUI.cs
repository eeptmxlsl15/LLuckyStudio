using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CannedFoodUI : MonoBehaviour
{
	[SerializeField] private TMP_Text cannedFoodUI;

	private void OnEnable()
	{
		GameManager.Score.OnCannedFoodChanged += UpdateScoreText;
	}

	private void OnDisable()
	{
		GameManager.Score.OnCannedFoodChanged -= UpdateScoreText;
	}

	private void UpdateScoreText(int value)
	{
		cannedFoodUI.text = "Canned Food : " + value.ToString();
	}
}