using UnityEngine;
using UnitySceneManager = UnityEngine.SceneManagement.SceneManager;

public class MonkeyBERSERKBOSSPopUpUI : PopUpUI
{
	protected override void Awake()
	{
		base.Awake();

		buttons["MonkeyBERSERKBOSSEntranceButton"].onClick.AddListener(() => { LoadBERSERKBOSScene(); });
		buttons["MonkeyBERSERKBOSSPopUpBackButton"].onClick.AddListener(() => { GameManager.UI.ClosePopUpUI(); });
	}

	public void LoadBERSERKBOSScene()
	{
		GameManager.UI.ClearPopUpUI();
		UnitySceneManager.LoadScene("BERSERKBOSSSceneMonkey");
		Time.timeScale = 1f;
	}
}
