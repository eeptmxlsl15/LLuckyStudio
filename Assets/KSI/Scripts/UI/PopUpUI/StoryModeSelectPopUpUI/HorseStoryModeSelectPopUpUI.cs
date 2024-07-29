using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnitySceneManager = UnityEngine.SceneManagement.SceneManager;

public class HorseStoryModeSelectPopUpUI : PopUpUI
{
	protected override void Awake()
	{
		base.Awake();

		buttons["HorseSUBButton"].onClick.AddListener(() => { LoadSUBScene(); });
		buttons["HorseBOSSButton"].onClick.AddListener(() => { GameManager.UI.ShowPopUpUI<PopUpUI>("UI/BossPopUpUI/HorseBossPopUpUI"); });
		buttons["HorseStoryModeSelectBackButton"].onClick.AddListener(() => { GameManager.UI.ClosePopUpUI(); });
	}

	public void LoadSUBScene()
	{
		GameManager.UI.ClosePopUpUI();
		GameManager.UI.ClearPopUpUI();
		UnitySceneManager.LoadScene("SUBScene");
		Time.timeScale = 1f;	
	}
}
