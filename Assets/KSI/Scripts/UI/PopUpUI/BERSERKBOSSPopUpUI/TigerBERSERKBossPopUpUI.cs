using UnityEngine;
using UnitySceneManager = UnityEngine.SceneManagement.SceneManager;

public class TigerBERSERKBOSSPopUpUI : PopUpUI
{
	protected override void Awake()
	{
		base.Awake();

		buttons["TigerBERSERKBOSSEntranceButton"].onClick.AddListener(() => { LoadBERSERKBOSScene(); });
		buttons["TigerBERSERKBOSSPopUpBackButton"].onClick.AddListener(() => { GameManager.UI.ClosePopUpUI(); });
	}

	public void LoadBERSERKBOSScene()
	{
		GameManager.UI.ClearPopUpUI();
		UnitySceneManager.LoadScene("BERSERKBOSSSceneTiger");
		Time.timeScale = 1f;
	}
}
