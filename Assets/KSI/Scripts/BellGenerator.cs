using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

// 입장 재화
public class BellGenerator : MonoBehaviour
{
	[Header("Bell")]
	[SerializeField] private int maxBells = 60;
	[SerializeField] private int minBells = 5;
	[SerializeField] private double generatorTimer = 300f;
	[Space]
	[Header("UI")]
	[SerializeField] private TextMeshProUGUI siverBellsText;
	[SerializeField] private TextMeshProUGUI timerText;

	private int curBells;
	private double lastTime;
	private bool isTimerRunning = false;

	private void Start()
	{
		timerText.gameObject.SetActive(false);
		generatorTimer = 0;
		curBells = maxBells;
		// 마지막 시간을 현재로 초기화
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

			// 1개당 5분씩 충전되도록 함
			generatorTimer += 300 * bellsUsed;

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
			siverBellsText.text = $"{curBells}/{maxBells}";
			// 타이머가 실행 중인 경우
			if (isTimerRunning)
			{
				UpdateTimerUI();
			}

			Debug.Log(siverBellsText.text + " " + timerText.text);

			yield return new WaitForSeconds(1);
		}
	}

	private void UpdateTimerUI()
	{
		// 경과 시간 계산(현재 시간 - 마지막으로 타이머를 시작한 시간)
		double timePassed = GetUnixTimestamp() - lastTime;
		// 남은 시간 계산
		double timeLeft = generatorTimer - timePassed;

		// 남은 시간이 있는 경우
		if (timeLeft > 0)
		{
			// 남은 시간을 시간:분:초로 변환
			TimeSpan timeSpan = TimeSpan.FromSeconds(timeLeft);
			timerText.text = $"{(int)timeSpan.TotalHours:D2}:{timeSpan.Minutes:D2}:{timeSpan.Seconds:D2}";
		}
		// 남은 시간이 없는 경우
		else
		{
			if (curBells < maxBells)
				// 입장 재화 충전
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

	// 현재 시간을 Unix 타임스탬프로 변환
	private double GetUnixTimestamp()
	{
		return (DateTime.UtcNow - new DateTime(1970, 1, 1)).TotalSeconds;
	}
}
