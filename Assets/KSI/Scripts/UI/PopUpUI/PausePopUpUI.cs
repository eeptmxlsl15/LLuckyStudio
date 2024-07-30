using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnitySceneManager = UnityEngine.SceneManagement.SceneManager;

public class PausePopUpUI : PopUpUI
{

	protected override void Awake()
	{
		base.Awake();

		buttons["PauseUIResumeButton"].onClick.AddListener(() => { ResumeGame(); });
		buttons["PauseUIQuitButton"].onClick.AddListener(() => { QuitGame(); });
	}

	public void ResumeGame()
	{
		GameManager.UI.ClosePopUpUI();
		GameManager.UI.ClearPopUpUI();
		Time.timeScale = 1f;
	}

	public void QuitGame()
	{
		GameManager.UI.ClosePopUpUI();
		GameManager.UI.ClearPopUpUI();
		Time.timeScale = 1f;
		UnitySceneManager.LoadScene("LobbyScene");
	}
}
