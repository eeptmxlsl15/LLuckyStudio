using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnitySceneManager = UnityEngine.SceneManagement.SceneManager;

public class RabbitBossPopUpUI : PopUpUI
{
	protected override void Awake()
	{
		base.Awake();

		buttons["RabbitBossEntranceButton"].onClick.AddListener(() => { LoadBOSScene(); });
		buttons["RabbitBossPopUpBackButton"].onClick.AddListener(() => { GameManager.UI.ClosePopUpUI(); });
	}

	public void LoadBOSScene()
	{
		GameManager.UI.ClosePopUpUI();
		GameManager.UI.ClearPopUpUI();
		UnitySceneManager.LoadScene("BOSSScene");
		Time.timeScale = 1f;
	}
}
