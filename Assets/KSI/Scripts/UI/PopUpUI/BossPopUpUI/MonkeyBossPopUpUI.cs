using UnityEngine;
using UnitySceneManager = UnityEngine.SceneManagement.SceneManager;

public class MonkeyBOSSPopUpUI : PopUpUI
{
	protected override void Awake()
	{
		base.Awake();

		buttons["MonkeyBOSSEntranceButton"].onClick.AddListener(() => { LoadBOSScene(); });
		buttons["MonkeyBOSSPopUpBackButton"].onClick.AddListener(() => { GameManager.UI.ClosePopUpUI(); });
	}

	public void LoadBOSScene()
	{
		GameManager.UI.ClearPopUpUI();
		UnitySceneManager.LoadScene("BOSSSceneMonkey");
		Time.timeScale = 1f;
	}
}
