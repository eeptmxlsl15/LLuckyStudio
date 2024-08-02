using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class SoleJellyUI : MonoBehaviour
{
	[SerializeField] private TextMeshProUGUI jellyPawText;
	[SerializeField] private TextMeshProUGUI jellyPawCountText;

	private void OnEnable()
	{
		GameManager.Score.OnJellyPawChanged += UpdateScoreText;
		GameManager.Score.OnJellyPawChanged += UpdateCountText;
	}

	private void UpdateScoreText(int value)
	{
		jellyPawText.text = value.ToString();
	}

	private void UpdateCountText(int value)
	{
		jellyPawCountText.text = (value / 100).ToString();
	}
}