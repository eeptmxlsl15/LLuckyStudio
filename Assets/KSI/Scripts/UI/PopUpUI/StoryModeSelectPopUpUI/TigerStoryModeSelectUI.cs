using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnitySceneManager = UnityEngine.SceneManagement.SceneManager;

public class TigerStoryModeSelectUI : PopUpUI
{
	protected override void Awake()
	{
		base.Awake();

		buttons["TigerSUBButton"].onClick.AddListener(() => { LoadSUBScene(); });
		buttons["TigerBOSSButton"].onClick.AddListener(() => { GameManager.UI.ShowPopUpUI<PopUpUI>("UI/BossPopUpUI/TigerBossPopUpUI"); });
		buttons["TigerStoryModeSelectBackButton"].onClick.AddListener(() => { GameManager.UI.ClosePopUpUI(); });
	}

	public void LoadSUBScene()
	{
		GameManager.UI.ClosePopUpUI();
		UnitySceneManager.LoadScene("SUBSceneTiger");
		Time.timeScale = 1f;	
	}
}
