using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class JellyPawUI : MonoBehaviour
{
	[SerializeField] private TextMeshProUGUI jellyPawText;
	[SerializeField] private TextMeshProUGUI jellyPawCountText;

	private void OnEnable()
	{
		//if (jellyPawText == null)
		//{
		//	Debug.LogError("jellyPawText 할당되지 않음"); 
		//	return;
		//}

		if (GameManager.Score == null)
		{
			Debug.LogError("GameManager.Score가 초기화되지 않았습니다.");
			return;
		}

		GameManager.Score.OnJellyPawChanged += UpdateScoreText;
		GameManager.Score.OnJellyPawChanged += UpdateCountText;
	}

	private void OnDisable()
	{
		//if (jellyPawText == null)
		//{
		//	Debug.LogError("jellyPawText 할당되지 않음");
		//	return;
		//}
		GameManager.Score.OnJellyPawChanged -= UpdateScoreText;
	}

	private void UpdateScoreText(int value)
	{
		jellyPawText.text = value.ToString();
	}

	private void UpdateCountText(int count)
	{
		jellyPawCountText.text = (count/100).ToString();
	}
}