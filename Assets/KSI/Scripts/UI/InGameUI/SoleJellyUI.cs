using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SoleJellyUI : MonoBehaviour
{
	[SerializeField] private TMP_Text jellyCoinUI;

	private void OnEnable()
	{
		GameManager.Score.OnJellyCoinChanged += UpdateScoreText;
	}

	private void OnDisable()
	{
		GameManager.Score.OnJellyCoinChanged -= UpdateScoreText;
	}

	private void UpdateScoreText(int value)
	{
		jellyCoinUI.text = "Sole Jelly : " + value.ToString();
	}
}