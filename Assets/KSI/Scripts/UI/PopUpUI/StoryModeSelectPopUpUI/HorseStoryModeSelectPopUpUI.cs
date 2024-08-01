using UnityEngine;
using UnitySceneManager = UnityEngine.SceneManagement.SceneManager;

public class HorseStoryModeSelectPopUpUI : PopUpUI
{
	protected override void Awake()
	{
		base.Awake();

		buttons["HorseSUBButton"].onClick.AddListener(() => { LoadSUBScene(); });
		buttons["HorseBOSSButton"].onClick.AddListener(() => { GameManager.UI.ShowPopUpUI<PopUpUI>("UI/BOSSPopUpUI/HorseBOSSPopUpUI"); });
		buttons["HorseBERSERKBOSSButton"].onClick.AddListener(() => { GameManager.UI.ShowPopUpUI<PopUpUI>("UI/BERSERKBOSSPopUpUI/HorseBERSERKBOSSPopUpUI"); });
		buttons["HorseStoryModeSelectBackButton"].onClick.AddListener(() => { GameManager.UI.ClosePopUpUI(); });
	}

	public void LoadSUBScene()
	{
		GameManager.UI.ClearPopUpUI();
		UnitySceneManager.LoadScene("SUBSceneHorse");
		Time.timeScale = 1f;	
	}
}
