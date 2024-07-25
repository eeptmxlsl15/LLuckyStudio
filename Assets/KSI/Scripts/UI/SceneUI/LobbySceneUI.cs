using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class LobbySceneUI : SceneUI
{
	protected override void Awake()
	{
		base.Awake();

		buttons["StartButton"].onClick.AddListener(() => { GameStart(); });
	}

	void GameStart()
	{
		GameManager.Scene.StartGame();
	}
}
