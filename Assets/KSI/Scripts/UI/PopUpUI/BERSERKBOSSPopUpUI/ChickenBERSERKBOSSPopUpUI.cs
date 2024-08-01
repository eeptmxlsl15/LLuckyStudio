using UnityEngine;
using UnitySceneManager = UnityEngine.SceneManagement.SceneManager;

public class ChickenBERSERKBOSSPopUpUI : PopUpUI
{
	protected override void Awake()
	{
		base.Awake();

		buttons["ChickenBERSERKBOSSEntranceButton"].onClick.AddListener(() => { LoadBERSERKBOSScene(); });
		buttons["ChickenBERSERKBOSSPopUpBackButton"].onClick.AddListener(() => { GameManager.UI.ClosePopUpUI(); });
	}

	public void LoadBERSERKBOSScene()
	{
		GameManager.UI.ClosePopUpUI();
		GameManager.UI.ClearPopUpUI();
		UnitySceneManager.LoadScene("BERSERKBOSSSceneChicken");
		Time.timeScale = 1f;
	}
}
