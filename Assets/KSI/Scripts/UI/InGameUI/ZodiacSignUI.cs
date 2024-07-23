using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class ZodiacSignUI : MonoBehaviour
{
	[SerializeField] private TextMeshProUGUI zodiacSignText;
	[SerializeField] private TextMeshProUGUI zodiacTimeText;

	private void Start()
	{
		if (zodiacSignText == null)
		{
			Debug.LogError("ZodiacSignText가 할당되지 않았습니다.");
			return;
		}

		if (zodiacTimeText == null)
		{
			Debug.LogError("ZodiacTimeText가 할당되지 않았습니다.");
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
		//string displayText = GetDisplayTextForZodiacSign(currentZodiacSign);
		//zodiacSignText.text = displayText;
		(string signText, string timeText) = GetDisplayTextForZodiacSign(currentZodiacSign);
		zodiacSignText.text = signText;
		zodiacTimeText.text = timeText;
	}

	private IEnumerator UpdateZodiacSignRoutine()
	{
		while (true)
		{
			UpdateZodiacSignUI();

			yield return new WaitForSeconds(8 * 3600);
		}
	}

	private (string, string) GetDisplayTextForZodiacSign(BerserkSystemManager.ZodiacSign zodiacSign)
	{
		switch (zodiacSign)
		{
			case BerserkSystemManager.ZodiacSign.RABBITTIGERCOWMOUSE:
				return ("자/축/인/묘\n23~07", "자시/23~01\n축시/01~03\n인시/03~05\n묘시/05~07");
			case BerserkSystemManager.ZodiacSign.SHEEPHORSESNAKEDRAGON:
				return ("진/사/오/미\n07~15", "진시/07~09)\n사시/09~11\n오시/11~13\n미시/13~15");
			case BerserkSystemManager.ZodiacSign.PIGDOGCHICKENMONKEY:
				return ("신/유/술/해\n15~11", "신시/15~17\n유시/17~19\n술시/19~21\n해시/21~23");;
			default:
				return ("-", "-");
		}
	}
}
