using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnitySceneManager = UnityEngine.SceneManagement.SceneManager;

public class SheepBossPopUpUI : PopUpUI
{
	protected override void Awake()
	{
		base.Awake();

		buttons["SheepBossEntranceButton"].onClick.AddListener(() => { LoadBOSScene(); });
		buttons["SheepBossPopUpBackButton"].onClick.AddListener(() => { GameManager.UI.ClosePopUpUI(); });
	}

	public void LoadBOSScene()
	{
		GameManager.UI.ClosePopUpUI();
		GameManager.UI.ClearPopUpUI();
		UnitySceneManager.LoadScene("BOSSScene");
		Time.timeScale = 1f;
	}
}
