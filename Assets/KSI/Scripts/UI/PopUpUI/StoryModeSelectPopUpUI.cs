using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnitySceneManager = UnityEngine.SceneManagement.SceneManager;

public class StoryModeSelectPopUpUI : PopUpUI
{
	protected override void Awake()
	{
		base.Awake();

		buttons["PigSUBButton"].onClick.AddListener(() => { LoadSUBScene(); });
		buttons["PigBOSSButton"].onClick.AddListener(() => { OpenPigBossPopUpUI(); });
	}

	public void LoadSUBScene()
	{
		GameManager.UI.ClosePopUpUI();
		UnitySceneManager.LoadScene("SUBScene");
		Time.timeScale = 1f;
	}

	public void OpenPigBossPopUpUI()
	{
		GameManager.UI.ShowPopUpUI<PopUpUI>("UI/PigBossPopUpUI");
	}
}
