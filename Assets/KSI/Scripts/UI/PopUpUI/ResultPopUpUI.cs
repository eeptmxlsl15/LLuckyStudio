using TMPro;
using UnityEngine;
using UnityEngine.Events;
using UnitySceneManager = UnityEngine.SceneManagement.SceneManager;

public class ResultPopUpUI : PopUpUI
{
	[Header("UI")]
	[SerializeField] private TextMeshProUGUI totalScoreText;
	[SerializeField] private TextMeshProUGUI rewardSushiText;
	[SerializeField] private TextMeshProUGUI DesirePieceiText;
	
	public UnityAction OnDisplayDeathUIChanged;

	private void OnEnable()
	{
		OnDisplayDeathUIChanged += DisplayResultUI;
	}

	protected override void Awake()
	{
		base.Awake();

		buttons["ResultPopUpUIReplayButton"].onClick.AddListener(() => { RestartButton(); });
		buttons["ResultPopUpUIQuitButton"].onClick.AddListener(() => { QuitButton(); });
	}

	private void Start()
	{
		totalScoreText = GameObject.Find("TotalScoreText").GetComponent<TextMeshProUGUI>();
		rewardSushiText = GameObject.Find("SushiText").GetComponent<TextMeshProUGUI>();
		DesirePieceiText = GameObject.Find("DesireText").GetComponent<TextMeshProUGUI>();
	}

	private void Update()
	{
		DisplayResultUI();
	}

	public void RestartButton()
	{
		GameManager.UI.ClosePopUpUI();
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

	public void DisplayResultUI()
	{
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
}
