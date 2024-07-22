using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class ZodiacSignUI : MonoBehaviour
{
	public TextMeshProUGUI zodiacSignText; 

	private void Start()
	{
		if (zodiacSignText == null)
		{
			Debug.LogError("ZodiacSignText가 할당되지 않았습니다.");
			return;
		}

		if (GameManager.BerserkSystem == null)
		{
			Debug.LogError("BerserkSystemManager가 할당되지 않았습니다.");
			return;
		}


		UpdateZodiacSignUI();

		StartCoroutine(UpdateZodiacSignRoutine());
	}

	private void UpdateZodiacSignUI()
	{
		var currentZodiacSign = GameManager.BerserkSystem.GetCurZodiacSign();
		string displayText = GetDisplayTextForZodiacSign(currentZodiacSign);
		zodiacSignText.text = displayText;
	}

	private IEnumerator UpdateZodiacSignRoutine()
	{
		while (true)
		{
			UpdateZodiacSignUI();

			yield return new WaitForSeconds(8 * 3600);
		}
	}

	private string GetDisplayTextForZodiacSign(BerserkSystemManager.ZodiacSign zodiacSign)
	{
		switch (zodiacSign)
		{
			case BerserkSystemManager.ZodiacSign.RABBITTIGERCOWMOUSE:
				return "자축인묘";
			case BerserkSystemManager.ZodiacSign.SHEEPHORSESNAKEDRAGON:
				return "진사오미";
			case BerserkSystemManager.ZodiacSign.PIGDOGCHICKENMONKEY:
				return "신유술해";
			default:
				return "-";
		}
	}
}
