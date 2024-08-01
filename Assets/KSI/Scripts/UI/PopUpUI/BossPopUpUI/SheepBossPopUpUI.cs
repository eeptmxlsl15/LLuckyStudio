using UnityEngine;
using UnitySceneManager = UnityEngine.SceneManagement.SceneManager;

public class SheepBOSSPopUpUI : PopUpUI
{
	protected override void Awake()
	{
		base.Awake();

		buttons["SheepBOSSEntranceButton"].onClick.AddListener(() => { LoadBOSScene(); });
		buttons["SheepBOSSPopUpBackButton"].onClick.AddListener(() => { GameManager.UI.ClosePopUpUI(); });
	}

	public void LoadBOSScene()
	{;
		GameManager.UI.ClearPopUpUI();
		UnitySceneManager.LoadScene("BOSSSceneSheep");
		Time.timeScale = 1f;
	}
}
