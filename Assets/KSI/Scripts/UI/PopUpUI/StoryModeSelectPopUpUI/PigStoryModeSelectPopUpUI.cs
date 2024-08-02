using UnityEngine;
using UnitySceneManager = UnityEngine.SceneManagement.SceneManager;

public class PigStoryModeSelectPopUpUI : PopUpUI
{
	protected override void Awake()
	{
		base.Awake();

		buttons["PigSUBButton"].onClick.AddListener(() => { LoadSUBScene(); });
		buttons["PigBOSSButton"].onClick.AddListener(() => { GameManager.UI.ShowPopUpUI<PopUpUI>("UI/BossPopUpUI/PigBossPopUpUI"); });
		buttons["PigBERSERKBOSSButton"].onClick.AddListener(() => { GameManager.UI.ShowPopUpUI<PopUpUI>("UI/BERSERKBOSSPopUpUI/PigBERSERKBOSSPopUpUI"); });
		buttons["PigStoryModeSelectBackButton"].onClick.AddListener(() => { GameManager.UI.ClosePopUpUI(); });
	}

	public void LoadSUBScene()
	{
		GameManager.UI.ClearPopUpUI();
		UnitySceneManager.LoadScene("SUBScenePig");
		Time.timeScale = 1f;	
	}
}
