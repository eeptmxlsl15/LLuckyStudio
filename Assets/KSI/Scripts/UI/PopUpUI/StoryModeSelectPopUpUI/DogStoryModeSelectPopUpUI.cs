using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnitySceneManager = UnityEngine.SceneManagement.SceneManager;

public class DogStoryModeSelectPopUpUI : PopUpUI
{
	protected override void Awake()
	{
		base.Awake();

		buttons["DogSUBButton"].onClick.AddListener(() => { LoadSUBScene(); });
		buttons["DogBOSSButton"].onClick.AddListener(() => { GameManager.UI.ShowPopUpUI<PopUpUI>("UI/BossPopUpUI/DogBossPopUpUI"); });
		buttons["DogStoryModeSelectBackButton"].onClick.AddListener(() => { GameManager.UI.ClosePopUpUI(); });
	}

	public void LoadSUBScene()
	{
		GameManager.UI.ClosePopUpUI();
		GameManager.UI.ClearPopUpUI();
		UnitySceneManager.LoadScene("SUBScene");
		Time.timeScale = 1f;	
	}
}
