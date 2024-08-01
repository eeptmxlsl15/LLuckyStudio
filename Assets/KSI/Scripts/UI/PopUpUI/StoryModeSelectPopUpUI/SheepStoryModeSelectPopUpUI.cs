using UnityEngine;
using UnitySceneManager = UnityEngine.SceneManagement.SceneManager;

public class SheepStoryModeSelectPopUpUI : PopUpUI
{
	protected override void Awake()
	{
		base.Awake();

		buttons["SheepSUBButton"].onClick.AddListener(() => { LoadSUBScene(); });
		buttons["SheepBOSSButton"].onClick.AddListener(() => { GameManager.UI.ShowPopUpUI<PopUpUI>("UI/BOSSPopUpUI/SheepBOSSPopUpUI"); });
		buttons["SheepBERSERKBOSSButton"].onClick.AddListener(() => { GameManager.UI.ShowPopUpUI<PopUpUI>("UI/BERSERKBOSSPopUpUI/SheepBERSERKBOSSPopUpUI"); });
		buttons["SheepStoryModeSelectBackButton"].onClick.AddListener(() => { GameManager.UI.ClosePopUpUI(); });
	}

	public void LoadSUBScene()
	{
		GameManager.UI.ClearPopUpUI();
		UnitySceneManager.LoadScene("SUBSceneSheep");
		Time.timeScale = 1f;	
	}
}
