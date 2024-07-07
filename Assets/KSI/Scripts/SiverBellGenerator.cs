using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

// 입장 재화
public class SiverBellGenerator : MonoBehaviour
{
	private int maxSiverBells = 60;
	private int curSiverBells;
	private double generatorTimer = 300f;	
	private double lastTime;
	private bool isTimerRunning = false;

	[Header ("UI")]
	[SerializeField] private TextMeshProUGUI siverBellsText;
	[SerializeField] private TextMeshProUGUI timerText;

	private void Start()
	{
		curSiverBells = maxSiverBells;
		lastTime = GetUnixTimestamp();
		StartCoroutine(UpdateUIRoutine());
		timerText.gameObject.SetActive(false);

		Debug.Log("현재 입장 재화 : " + maxSiverBells);
	}

	private void UsedSiverBells()
	{
		if (curSiverBells > 0)
		{
			curSiverBells--;
			lastTime = GetUnixTimestamp();
			isTimerRunning = true;
			timerText.gameObject.SetActive(true);

			Debug.Log("남아있는 입장 재화 : " + curSiverBells);
		}
		else
		{
			Debug.Log("현재 사용가능한 입장 재화 없음");
		}
	}


	private IEnumerator UpdateUIRoutine()
	{
		while (true)
		{
			siverBellsText.text = $"{curSiverBells}/{maxSiverBells}";
			// 타이머가 실행 중인 경우
			if (isTimerRunning)
			{
				// 경과 시간 계산
				double timePassed = GetUnixTimestamp() - lastTime;
				// 남은 시간 계산
				double timeLeft = generatorTimer - timePassed;
				// 남은 시간이 있는 경우
				if (timeLeft > 0)
				{
					TimeSpan timeSpan = TimeSpan.FromSeconds(timeLeft);
					timerText.text = $"{timeSpan.Minutes:D2}:{timeSpan.Seconds:D2}";
				}
				// 남은 시간이 없는 경우
				else
				{
					curSiverBells = maxSiverBells;
					isTimerRunning = false;
					timerText.text = "00:00";
					timerText.gameObject.SetActive(false);
				}
			}

			Debug.Log(siverBellsText.text + " " + timerText.text);

			yield return new WaitForSeconds(1);
		}
	}

	private double GetUnixTimestamp()
	{
		return (DateTime.UtcNow - new DateTime(1970, 1, 1)).TotalSeconds;
	}
}
