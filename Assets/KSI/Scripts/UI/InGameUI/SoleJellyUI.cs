using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SoleJellyUI : MonoBehaviour
{
	[SerializeField] private TMP_Text jellyPawUI;

	private void OnEnable()
	{
		if (jellyPawUI == null)
		{
			Debug.LogError("jellyCoinUI 할당되지 않음");
			return;
		}
		GameManager.Score.OnJellyPawChanged += UpdateScoreText;
	}

	private void OnDisable()
	{
		if (jellyPawUI == null)
		{
			Debug.LogError("jellyCoinUI 할당되지 않음");
			return;
		}
		GameManager.Score.OnJellyPawChanged -= UpdateScoreText;
	}

	private void UpdateScoreText(int value)
	{
		jellyPawUI.text = "Sole Jelly : " + value.ToString();
	}
}