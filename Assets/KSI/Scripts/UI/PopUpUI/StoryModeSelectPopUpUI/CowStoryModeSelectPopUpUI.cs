using UnityEngine;
using UnitySceneManager = UnityEngine.SceneManagement.SceneManager;

public class CowStoryModeSelectPopUpUI : PopUpUI
{
	protected override void Awake()
	{
		base.Awake();

		buttons["CowSUBButton"].onClick.AddListener(() => { LoadSUBScene(); });
		buttons["CowBOSSButton"].onClick.AddListener(() => { GameManager.UI.ShowPopUpUI<PopUpUI>("UI/BOSSPopUpUI/CowBOSSPopUpUI"); });
		buttons["CowBERSERKBOSSButton"].onClick.AddListener(() => { GameManager.UI.ShowPopUpUI<PopUpUI>("UI/BERSERKBOSSPopUpUI/CowBERSERKBOSSPopUpUI"); });
		buttons["CowStoryModeSelectBackButton"].onClick.AddListener(() => { GameManager.UI.ClosePopUpUI(); });
	}

	public void LoadSUBScene()
	{
		GameManager.UI.ClearPopUpUI();
		UnitySceneManager.LoadScene("SUBSceneCow");
		Time.timeScale = 1f;	
	}
}
