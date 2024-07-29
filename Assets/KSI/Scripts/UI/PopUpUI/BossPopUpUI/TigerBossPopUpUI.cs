using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnitySceneManager = UnityEngine.SceneManagement.SceneManager;

public class TigerBossPopUpUI : PopUpUI
{
	protected override void Awake()
	{
		base.Awake();

		buttons["TigergBossEntranceButton"].onClick.AddListener(() => { LoadBOSScene(); });
		buttons["TigerBossPopUpBackButton"].onClick.AddListener(() => { GameManager.UI.ClosePopUpUI(); });
	}

	public void LoadBOSScene()
	{
		GameManager.UI.ClosePopUpUI();
		GameManager.UI.ClearPopUpUI();
		UnitySceneManager.LoadScene("BOSSScene");
		Time.timeScale = 1f;
	}
}
