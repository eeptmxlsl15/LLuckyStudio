using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StoryModeEntranceSceneUI : SceneUI
{
	protected override void Awake()
	{
		base.Awake();

		buttons["PigButton"].onClick.AddListener(() => { GameManager.UI.ShowPopUpUI<PopUpUI>("UI/PigStoryModeSelectUI"); });
	}
}
