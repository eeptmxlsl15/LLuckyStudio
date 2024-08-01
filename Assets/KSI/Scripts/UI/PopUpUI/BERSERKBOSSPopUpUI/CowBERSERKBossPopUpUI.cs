using UnityEngine;
using UnitySceneManager = UnityEngine.SceneManagement.SceneManager;

public class CowBERSERKBOSSPopUpUI : PopUpUI
{
	protected override void Awake()
	{
		base.Awake();

		buttons["CowBERSERKBOSSEntranceButton"].onClick.AddListener(() => { LoadBERSERKBOSScene(); });
		buttons["CowBERSERKBOSSPopUpBackButton"].onClick.AddListener(() => { GameManager.UI.ClosePopUpUI(); });
	}

	public void LoadBERSERKBOSScene()
	{
		GameManager.UI.ClearPopUpUI();
		UnitySceneManager.LoadScene("BERSERKBOSSSceneCow");
		Time.timeScale = 1f;
	}
}
