using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnitySceneManager = UnityEngine.SceneManagement.SceneManager;

public class DeathPopUpUI : PopUpUI
{
	[Header("UI")]
	[SerializeField] private TextMeshProUGUI totalScoreText;

	protected override void Awake()
	{
		base.Awake();

		buttons["DeathPopUpUIReplayButton"].onClick.AddListener(() => { RestartButton(); });
		buttons["DeathPopUpUIQuitButton"].onClick.AddListener(() => { QuitButton(); });
	}

	private void OnEnable()
	{
		GameManager.OnGameEndChanged += DisplayDeathUI;
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
	}

	public void RestartButton()
	{
		Time.timeScale = 1f;
		GameManager.UI.ClearPopUpUI();
		GameManager.Score.Reset();
		GameManager.Instance.ResetAllDebuffs();
		UnitySceneManager.LoadScene(UnitySceneManager.GetActiveScene().buildIndex);
	}

	public void QuitButton()
	{
		Time.timeScale = 1f;
		GameManager.UI.ClearPopUpUI();
		GameManager.Score.Reset();
		GameManager.Instance.ResetAllDebuffs();
		UnitySceneManager.LoadScene("LobbyScene");
	}
}