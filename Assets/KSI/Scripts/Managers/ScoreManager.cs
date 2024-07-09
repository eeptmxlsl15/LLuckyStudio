using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.Events;

public class ScoreManager : MonoBehaviour
{
	public int scoreText;

	public UnityAction<int> OnScoreChanged;

	public void AddScore(int value)
	{
		scoreText += value;
		OnScoreChanged?.Invoke(scoreText);
	}
}