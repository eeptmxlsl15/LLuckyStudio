using UnityEngine;
using UnitySceneManager = UnityEngine.SceneManagement.SceneManager;

public class DogBOSSPopUpUI : PopUpUI
{
	protected override void Awake()
	{
		base.Awake();

		buttons["DogBOSSEntranceButton"].onClick.AddListener(() => { LoadBOSScene(); });
		buttons["DogBOSSPopUpBackButton"].onClick.AddListener(() => { GameManager.UI.ClosePopUpUI(); });
	}

	public void LoadBOSScene()
	{
		GameManager.UI.ClearPopUpUI();
		UnitySceneManager.LoadScene("BOSSSceneDog");
		Time.timeScale = 1f;
	}
}
