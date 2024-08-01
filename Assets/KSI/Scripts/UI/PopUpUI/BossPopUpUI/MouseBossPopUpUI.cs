using UnityEngine;
using UnitySceneManager = UnityEngine.SceneManagement.SceneManager;

public class MouseBOSSPopUpUI : PopUpUI
{
	protected override void Awake()
	{
		base.Awake();

		buttons["MouseBOSSEntranceButton"].onClick.AddListener(() => { LoadBOSScene(); });
		buttons["MouseBOSSPopUpBackButton"].onClick.AddListener(() => { GameManager.UI.ClosePopUpUI(); });
	}

	public void LoadBOSScene()
	{
		GameManager.UI.ClearPopUpUI();
		UnitySceneManager.LoadScene("BOSSSceneMouse");
		Time.timeScale = 1f;
	}
}
