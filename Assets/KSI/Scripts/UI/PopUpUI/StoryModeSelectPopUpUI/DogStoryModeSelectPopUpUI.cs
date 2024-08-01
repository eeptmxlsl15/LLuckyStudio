using UnityEngine;
using UnitySceneManager = UnityEngine.SceneManagement.SceneManager;

public class DogStoryModeSelectPopUpUI : PopUpUI
{
	protected override void Awake()
	{
		base.Awake();

		buttons["DogSUBButton"].onClick.AddListener(() => { LoadSUBScene(); });
		buttons["DogBOSSButton"].onClick.AddListener(() => { GameManager.UI.ShowPopUpUI<PopUpUI>("UI/BOSSPopUpUI/DogBOSSPopUpUI"); });
		buttons["DogBERSERKBOSSButton"].onClick.AddListener(() => { GameManager.UI.ShowPopUpUI<PopUpUI>("UI/BERSERKBOSSPopUpUI/DogBERSERKBOSSPopUpUI"); });
		buttons["DogStoryModeSelectBackButton"].onClick.AddListener(() => { GameManager.UI.ClosePopUpUI(); });
	}

	public void LoadSUBScene()
	{
		GameManager.UI.ClearPopUpUI();
		UnitySceneManager.LoadScene("SUBSceneDog");
		Time.timeScale = 1f;	
	}
}
