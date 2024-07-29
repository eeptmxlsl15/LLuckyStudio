using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnitySceneManager = UnityEngine.SceneManagement.SceneManager;

public class ChickenStoryModeSelectPopUpUI : PopUpUI
{
	protected override void Awake()
	{
		base.Awake();

		buttons["ChickenSUBButton"].onClick.AddListener(() => { LoadSUBScene(); });
		buttons["ChickenBOSSButton"].onClick.AddListener(() => { GameManager.UI.ShowPopUpUI<PopUpUI>("UI/PigBossPopUpUI"); });
		buttons["ChickenStoryModeSelectBackButton"].onClick.AddListener(() => { GameManager.UI.ClosePopUpUI(); });
	}

	public void LoadSUBScene()
	{
		GameManager.UI.ClosePopUpUI();
		GameManager.UI.ClearPopUpUI();
		UnitySceneManager.LoadScene("SUBScene");
		Time.timeScale = 1f;
	}
}
