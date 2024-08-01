using UnityEngine;
using UnitySceneManager = UnityEngine.SceneManagement.SceneManager;

public class SnakeStoryModeSelectPopUpUI : PopUpUI
{
	protected override void Awake()
	{
		base.Awake();

		buttons["SnakeSUBButton"].onClick.AddListener(() => { LoadSUBScene(); });
		buttons["SnakeBOSSButton"].onClick.AddListener(() => { GameManager.UI.ShowPopUpUI<PopUpUI>("UI/BOSSPopUpUI/SnakeBOSSPopUpUI"); });
		buttons["SnakeBERSERKBOSSButton"].onClick.AddListener(() => { GameManager.UI.ShowPopUpUI<PopUpUI>("UI/BERSERKBOSSPopUpUI/SnakeBERSERKBOSSPopUpUI"); });
		buttons["SnakeStoryModeSelectBackButton"].onClick.AddListener(() => { GameManager.UI.ClosePopUpUI(); });
	}

	public void LoadSUBScene()
	{
		GameManager.UI.ClearPopUpUI();
		UnitySceneManager.LoadScene("SUBSceneSnake");
		Time.timeScale = 1f;	
	}
}
