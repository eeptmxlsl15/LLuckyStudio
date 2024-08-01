using UnityEngine;
using UnitySceneManager = UnityEngine.SceneManagement.SceneManager;

public class CowBOSSPopUpUI : PopUpUI
{
	protected override void Awake()
	{
		base.Awake();

		buttons["CowBOSSEntranceButton"].onClick.AddListener(() => { LoadBOSScene(); });
		buttons["CowBOSSPopUpBackButton"].onClick.AddListener(() => { GameManager.UI.ClosePopUpUI(); });
	}

	public void LoadBOSScene()
	{
		GameManager.UI.ClearPopUpUI();
		UnitySceneManager.LoadScene("BOSSSceneCow");
		Time.timeScale = 1f;
	}
}
