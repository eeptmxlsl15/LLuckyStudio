using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

// 입장 재화
public class KeyGenerator : MonoBehaviour
{
	[Header("Bell")]
	[SerializeField] private int maxBells;
	[SerializeField] private int minBells;
	[SerializeField] private double generatorTimer = 300f;
	[SerializeField] private double chargingTime;

	[Space]
	[Header("UI")]
	[SerializeField] private TextMeshProUGUI BellText;
	[SerializeField] private TextMeshProUGUI timerText;

	private int curBells;
	private double lastTime;
	private bool isTimerRunning = false;

	private void Start()
	{
		timerText.gameObject.SetActive(false);
		generatorTimer = 0;
		curBells = maxBells;
		lastTime = GetUnixTimestamp();
		StartCoroutine(UpdateUIRoutine());

		Debug.Log("현재 입장 재화 : " + maxBells);
	}

	public void UsedSiverBells()
	{
		if (curBells >= minBells)
		{
			int bellsUsed = minBells;
			curBells -= bellsUsed;
			lastTime = GetUnixTimestamp();
			isTimerRunning = true;
			timerText.gameObject.SetActive(true);

			generatorTimer += chargingTime * bellsUsed;

			UpdateTimerUI();
		}
		else
		{
			Debug.Log("현재 사용가능한 입장 재화가 " + minBells + " 개 미만");
		}
	}

	private IEnumerator UpdateUIRoutine()
	{
		while (true)
		{
			BellText.text = $"{curBells}/{maxBells}";

			if (isTimerRunning)
			{
				UpdateTimerUI();
			}

			Debug.Log(BellText.text + " " + timerText.text);

			yield return new WaitForSeconds(1);
		}
	}

	private void UpdateTimerUI()
	{
		double timePassed = GetUnixTimestamp() - lastTime;
		double timeLeft = generatorTimer - timePassed;

		if (timeLeft > 0)
		{
			TimeSpan timeSpan = TimeSpan.FromSeconds(timeLeft);
			timerText.text = $"{(int)timeSpan.TotalHours:D2}:{timeSpan.Minutes:D2}:{timeSpan.Seconds:D2}";
		}
		else
		{
			if (curBells < maxBells)
				curBells += 1;

			lastTime = GetUnixTimestamp();
			generatorTimer = 0;

			if (curBells < maxBells)
			{
				isTimerRunning = true;
			}
			else
			{
				isTimerRunning = false;
				timerText.text = "00:00:00";
				timerText.gameObject.SetActive(false);
			}
		}
	}

	private double GetUnixTimestamp()
	{
		return (DateTime.UtcNow - new DateTime(1970, 1, 1)).TotalSeconds;
	}
}
