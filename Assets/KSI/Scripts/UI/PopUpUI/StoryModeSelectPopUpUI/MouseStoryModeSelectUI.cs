using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnitySceneManager = UnityEngine.SceneManagement.SceneManager;

public class MouseStoryModeSelectUI : PopUpUI
{
	protected override void Awake()
	{
		base.Awake();

		buttons["MouseSUBButton"].onClick.AddListener(() => { LoadSUBScene(); });
		buttons["MouseBOSSButton"].onClick.AddListener(() => { GameManager.UI.ShowPopUpUI<PopUpUI>("UI/BossPopUpUI/MouseBossPopUpUI"); });
		buttons["MouseStoryModeSelectBackButton"].onClick.AddListener(() => { GameManager.UI.ClosePopUpUI(); });
	}

	public void LoadSUBScene()
	{
		GameManager.UI.ClosePopUpUI();
		GameManager.UI.ClearPopUpUI();
		UnitySceneManager.LoadScene("SUBSceneMouse");
		Time.timeScale = 1f;	
	}
}
