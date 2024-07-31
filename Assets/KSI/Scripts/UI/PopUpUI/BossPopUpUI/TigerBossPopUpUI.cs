using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnitySceneManager = UnityEngine.SceneManagement.SceneManager;

public class TigerBossPopUpUI : PopUpUI
{
	protected override void Awake()
	{
		base.Awake();

		buttons["TigerBossEntranceButton"].onClick.AddListener(() => { LoadBOSScene(); });
		buttons["TigerBossPopUpBackButton"].onClick.AddListener(() => { GameManager.UI.ClosePopUpUI(); });
	}

	public void LoadBOSScene()
	{
		GameManager.UI.ClearPopUpUI();
		UnitySceneManager.LoadScene("BOSSSceneTiger");
		Time.timeScale = 1f;
	}
}
