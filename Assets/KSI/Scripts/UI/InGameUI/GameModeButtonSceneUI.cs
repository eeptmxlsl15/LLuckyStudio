using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameModeButtonSceneUI : SceneUI
{
	private bool isCloseButtonPressed = false;

	protected override void Awake()
	{
		base.Awake();

		//buttons["INFINITEButton"].onClick.AddListener(() => { GameManager.UI.ShowPopUpUI<PopUpUI>("UI/InfiniteModeEntranceUI"); });
		buttons["STROYButton"].onClick.AddListener(() => { GameManager.UI.ShowPopUpUI<PopUpUI>("UI/StoryModeEntranceUI"); });
	}
}