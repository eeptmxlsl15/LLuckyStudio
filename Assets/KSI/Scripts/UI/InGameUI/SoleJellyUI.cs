using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class JellyPawUI : MonoBehaviour
{
	[SerializeField] private TextMeshProUGUI jellyPawText;

	private void OnEnable()
	{
		//if (jellyPawText == null)
		//{
		//	Debug.LogError("jellyPawText 할당되지 않음"); 
		//	return;
		//}
		GameManager.Score.OnJellyPawChanged += UpdateScoreText;
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
		jellyPawText.text = "Jelly Paw : " + value.ToString();
	}
}