using UnityEngine;
using UnitySceneManager = UnityEngine.SceneManagement.SceneManager;

public class ChickenStoryModeSelectPopUpUI : PopUpUI
{
	private const float updateCycle = 1f;
	private float lastUpdate = 0f;


	protected override void Awake()
	{
		base.Awake();

		buttons["ChickenSUBButton"].onClick.AddListener(() => { LoadSUBScene(); });
		buttons["ChickenBOSSButton"].onClick.AddListener(() => { GameManager.UI.ShowPopUpUI<PopUpUI>("UI/BossPopUpUI/ChickenBossPopUpUI"); });
		buttons["ChickenBERSERKBOSSButton"].onClick.AddListener(() => { GameManager.UI.ShowPopUpUI<PopUpUI>("UI/BERSERKBossPopUpUI/ChickenBERSERKBossPopUpUI"); });
		buttons["ChickenStoryModeSelectBackButton"].onClick.AddListener(() => { GameManager.UI.ClosePopUpUI(); });
	}

	private void Update()
	{
		lastUpdate += Time.deltaTime;

		if (lastUpdate >= updateCycle)
		{
			UpdateBERSERKBOSSButton();
			lastUpdate = 0f;
		}
	}

	private void UpdateBERSERKBOSSButton()
	{
		var currentZodiacSign = GameManager.BerserkSystem.GetCurZodiacSign();
		ActivateBERSERKBOSSButton(currentZodiacSign);
	}

	public void LoadSUBScene()
	{
		GameManager.UI.ClearPopUpUI();
		UnitySceneManager.LoadScene("SUBSceneChicken");
		Time.timeScale = 1f;
	}

	private void ActivateBERSERKBOSSButton(BerserkSystemManager.ZodiacSign zodiacSign)
	{
		GameObject berserkBossButton = GameObject.Find("ChickenBERSERKBOSSButton");

		switch (zodiacSign)
		{
			case BerserkSystemManager.ZodiacSign.CHICKEN:				
					berserkBossButton.SetActive(true);
				break;
			default:
					berserkBossButton.SetActive(false);
				break;
		}
	}
}
