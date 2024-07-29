using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnitySceneManager = UnityEngine.SceneManagement.SceneManager;

public class RabbitStoryModeSelectPopUpUI : PopUpUI
{
	protected override void Awake()
	{
		base.Awake();

		buttons["RabbitSUBButton"].onClick.AddListener(() => { LoadSUBScene(); });
		buttons["RabbitBOSSButton"].onClick.AddListener(() => { GameManager.UI.ShowPopUpUI<PopUpUI>("UI/BossPopUpUI/RabbitBossPopUpUI"); });
		buttons["RabbitStoryModeSelectBackButton"].onClick.AddListener(() => { GameManager.UI.ClosePopUpUI(); });
	}

	public void LoadSUBScene()
	{
		GameManager.UI.ClosePopUpUI();
		GameManager.UI.ClearPopUpUI();
		UnitySceneManager.LoadScene("SUBScene");
		Time.timeScale = 1f;	
	}
}
