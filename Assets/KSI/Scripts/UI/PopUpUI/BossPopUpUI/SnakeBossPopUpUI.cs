using UnityEngine;
using UnitySceneManager = UnityEngine.SceneManagement.SceneManager;

public class SnakeBOSSPopUpUI : PopUpUI
{
	protected override void Awake()
	{
		base.Awake();

		buttons["SnakeBOSSEntranceButton"].onClick.AddListener(() => { LoadBOSScene(); });
		buttons["SnakeBOSSPopUpBackButton"].onClick.AddListener(() => { GameManager.UI.ClosePopUpUI(); });
	}

	public void LoadBOSScene()
	{
		GameManager.UI.ClearPopUpUI();
		UnitySceneManager.LoadScene("BOSSSceneSnake");
		Time.timeScale = 1f;
	}
}
