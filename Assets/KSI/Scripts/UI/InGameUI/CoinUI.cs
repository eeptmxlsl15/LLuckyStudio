using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEditor.VersionControl;

public class CoinUI : MonoBehaviour
{
	[SerializeField] private TextMeshProUGUI coinUI;

	private void Awake()
    {
		coinUI = GetComponent<TextMeshProUGUI>();
	}


	private void OnEnable()
	{
		GameManager.Score.OnScoreChanged += UpdateScoreText;
	}

	private void OnDisable()
	{
		GameManager.Score.OnScoreChanged -= UpdateScoreText;
	}

	private void UpdateScoreText(int count)
	{
		coinUI.text = count.ToString();
	}
}
