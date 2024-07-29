using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnitySceneManager = UnityEngine.SceneManagement.SceneManager;

public class InfiniteModeEntrancePopUpUI : PopUpUI
{
	protected override void Awake()
	{
		base.Awake();

		buttons["InfiniteModeEntranceBackButton"].onClick.AddListener(() => { GameManager.UI.ClosePopUpUI(); });
	}
}
