using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnitySceneManager = UnityEngine.SceneManagement.SceneManager;

public class DeathUI : MonoBehaviour
{
	[Header("Scene")]
	[SerializeField] private string gameModeSceneToLoad;
	[Space]
	[Header("UI")]

	[SerializeField] private GameObject deathUI;
	[SerializeField] private TextMeshProUGUI totalScoreText;

	private void Start()
	{
		GameManager.OnGameEndChanged += DisplayDeathUI;
		deathUI.SetActive(false);
	}

	private void OnDestroy()
	{
		GameManager.OnGameEndChanged -= DisplayDeathUI;
	}

	public void DisplayDeathUI()
	{
		Time.timeScale = 0f;
		int totalScore = GameManager.Score.GetTotalScore();
		totalScoreText.text = totalScore.ToString();
		deathUI.SetActive(true);
	}

	public void RestartButton()
	{
		Time.timeScale = 1f;
		GameManager.Score.Reset();
		GameManager.Instance.ResetAllDebuffs();
		UnitySceneManager.LoadScene(UnitySceneManager.GetActiveScene().buildIndex);
	}

	public void QuitButton()
	{
		Time.timeScale = 1f;
		GameManager.Score.Reset();
		GameManager.Instance.ResetAllDebuffs();
		UnitySceneManager.LoadScene(gameModeSceneToLoad);
	}
}