using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnitySceneManager = UnityEngine.SceneManagement.SceneManager;

public class HorseBossPopUpUI : PopUpUI
{
	protected override void Awake()
	{
		base.Awake();

		buttons["HorseBossEntranceButton"].onClick.AddListener(() => { LoadBOSScene(); });
		buttons["HorseBossPopUpBackButton"].onClick.AddListener(() => { GameManager.UI.ClosePopUpUI(); });
	}

	public void LoadBOSScene()
	{
		GameManager.UI.ClosePopUpUI();
		GameManager.UI.ClearPopUpUI();
		UnitySceneManager.LoadScene("BOSSScene");
		Time.timeScale = 1f;
	}
}
