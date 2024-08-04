using UnityEngine;
using UnitySceneManager = UnityEngine.SceneManagement.SceneManager;

public class DogStoryModeSelectPopUpUI : PopUpUI
{
	protected override void Awake()
	{
		base.Awake();

		buttons["DogSUBButton"].onClick.AddListener(() => { LoadSUBScene(); });
		buttons["DogBOSSButton"].onClick.AddListener(() => { GameManager.UI.ShowPopUpUI<PopUpUI>("UI/BossPopUpUI/DogBossPopUpUI"); });
		buttons["DogBERSERKBOSSButton"].onClick.AddListener(() => { GameManager.UI.ShowPopUpUI<PopUpUI>("UI/BERSERKBossPopUpUI/DogBERSERKBossPopUpUI"); });
		buttons["DogStoryModeSelectBackButton"].onClick.AddListener(() => { GameManager.UI.ClosePopUpUI(); });
	}

	public void LoadSUBScene()
	{
		GameManager.UI.ClearPopUpUI();
		UnitySceneManager.LoadScene("SUBSceneDog");
		GameManager.Scene.LoadSUB();
		Time.timeScale = 1f;	
	}
}
