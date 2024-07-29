using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnitySceneManager = UnityEngine.SceneManagement.SceneManager;

public class ChickenBossPopUpUI : PopUpUI
{
	protected override void Awake()
	{
		base.Awake();

		buttons["ChickenBossEntranceButton"].onClick.AddListener(() => { LoadBOSScene(); });
		buttons["ChickenBossPopUpBackButton"].onClick.AddListener(() => { GameManager.UI.ClosePopUpUI(); });
	}

	public void LoadBOSScene()
	{
		GameManager.UI.ClosePopUpUI();
		GameManager.UI.ClearPopUpUI();
		UnitySceneManager.LoadScene("BOSSScene");
		Time.timeScale = 1f;
	}
}
