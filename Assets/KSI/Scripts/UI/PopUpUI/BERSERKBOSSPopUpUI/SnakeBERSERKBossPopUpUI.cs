using UnityEngine;
using UnitySceneManager = UnityEngine.SceneManagement.SceneManager;

public class SnakeBERSERKBOSSPopUpUI : PopUpUI
{
	protected override void Awake()
	{
		base.Awake();

		buttons["SnakeBERSERKBOSSEntranceButton"].onClick.AddListener(() => { LoadBERSERKBOSScene(); });
		buttons["SnakeBERSERKBOSSPopUpBackButton"].onClick.AddListener(() => { GameManager.UI.ClosePopUpUI(); });
	}

	public void LoadBERSERKBOSScene()
	{
		GameManager.UI.ClearPopUpUI();
		UnitySceneManager.LoadScene("BERSERKBOSSSceneSnake");
		Time.timeScale = 1f;
	}
}
