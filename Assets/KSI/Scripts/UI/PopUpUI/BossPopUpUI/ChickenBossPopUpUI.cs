using UnityEngine;
using UnitySceneManager = UnityEngine.SceneManagement.SceneManager;

public class ChickenBOSSPopUpUI : PopUpUI
{
	protected override void Awake()
	{
		base.Awake();

		buttons["ChickenBOSSEntranceButton"].onClick.AddListener(() => { LoadBOSScene(); });
		buttons["ChickenBOSSPopUpBackButton"].onClick.AddListener(() => { GameManager.UI.ClosePopUpUI(); });
	}

	public void LoadBOSScene()
	{
		GameManager.UI.ClearPopUpUI();
		UnitySceneManager.LoadScene("BOSSSceneChicken");
		Time.timeScale = 1f;
	}
}
