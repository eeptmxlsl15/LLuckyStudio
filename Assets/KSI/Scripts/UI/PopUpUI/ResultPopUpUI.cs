using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnitySceneManager = UnityEngine.SceneManagement.SceneManager;

public class ResultPopUpUI : PopUpUI
{
	[Header("UI")]
	[SerializeField] private TextMeshProUGUI totalScoreText;
	[SerializeField] private TextMeshProUGUI rewardSushiText;
	[SerializeField] private TextMeshProUGUI DesirePieceiText;

	protected override void Awake()
	{
		base.Awake();

		buttons["ResultPopUpUIReplayButton"].onClick.AddListener(() => { RestartButton(); });
		buttons["ResultPopUpUIQuitButton"].onClick.AddListener(() => { QuitButton(); });
	}

	private void Start()
    {
		GameManager.OnGameEndChanged += DisplayResultUI;
	}

	private void OnDestroy()
	{
		GameManager.OnGameEndChanged -= DisplayResultUI;
	}

	public void DisplayResultUI()
	{
		Time.timeScale = 0f;
		int totalScore = GameManager.Score.GetTotalScore();
		totalScoreText.text = totalScore.ToString();
	}

	public void UpdateRewardSushiText(int reward)
	{
		rewardSushiText.text = reward.ToString();
	}

	public void UpdateDesirePieceiText(int rewardValue)
	{
		DesirePieceiText.text = rewardValue.ToString();
	}

	public void RestartButton()
	{
		GameManager.UI.ClearPopUpUI();
		Time.timeScale = 1f;
		GameManager.Score.Reset();
		GameManager.Instance.ResetAllDebuffs();
		UnitySceneManager.LoadScene(UnitySceneManager.GetActiveScene().buildIndex);
	}

	public void QuitButton()
	{
		GameManager.UI.ClearPopUpUI();
		Time.timeScale = 1f;
		GameManager.Score.Reset();
		GameManager.Instance.ResetAllDebuffs();
		UnitySceneManager.LoadScene("LobbyScene");
	}
}
