using UnityEngine;
using UnitySceneManager = UnityEngine.SceneManagement.SceneManager;

public class RabbitBOSSPopUpUI : PopUpUI
{
	protected override void Awake()
	{
		base.Awake();

		buttons["RabbitBOSSEntranceButton"].onClick.AddListener(() => { LoadBOSScene(); });
		buttons["RabbitBOSSPopUpBackButton"].onClick.AddListener(() => { GameManager.UI.ClosePopUpUI(); });
	}

	public void LoadBOSScene()
	{
		GameManager.UI.ClearPopUpUI();
		UnitySceneManager.LoadScene("BOSSSceneRabbit");
		Time.timeScale = 1f;
	}
}
