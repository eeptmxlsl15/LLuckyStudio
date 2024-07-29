using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StoryModeEntrancePopUpUI : PopUpUI
{
	protected override void Awake()
	{
		base.Awake();

		buttons["PigButton"].onClick.AddListener(() => { GameManager.UI.ShowPopUpUI<PopUpUI>("UI/PigStoryModeSelectUI"); });
		buttons["ChickenButton"].onClick.AddListener(() => { GameManager.UI.ShowPopUpUI<PopUpUI>("UI/PigStoryModeSelectUI"); });
		buttons["SheepButton"].onClick.AddListener(() => { GameManager.UI.ShowPopUpUI<PopUpUI>("UI/PigStoryModeSelectUI"); });
		buttons["SnakeButton"].onClick.AddListener(() => { GameManager.UI.ShowPopUpUI<PopUpUI>("UI/PigStoryModeSelectUI"); });
		buttons["RabbitButton"].onClick.AddListener(() => { GameManager.UI.ShowPopUpUI<PopUpUI>("UI/PigStoryModeSelectUI"); });
		buttons["CowButton"].onClick.AddListener(() => { GameManager.UI.ShowPopUpUI<PopUpUI>("UI/PigStoryModeSelectUI"); });
		buttons["DogButton"].onClick.AddListener(() => { GameManager.UI.ShowPopUpUI<PopUpUI>("UI/PigStoryModeSelectUI"); });
		buttons["MonkeyButton"].onClick.AddListener(() => { GameManager.UI.ShowPopUpUI<PopUpUI>("UI/PigStoryModeSelectUI"); });
		buttons["HorseButton"].onClick.AddListener(() => { GameManager.UI.ShowPopUpUI<PopUpUI>("UI/PigStoryModeSelectUI"); });
		buttons["DragonButton"].onClick.AddListener(() => { GameManager.UI.ShowPopUpUI<PopUpUI>("UI/PigStoryModeSelectUI"); });
		buttons["TigerButton"].onClick.AddListener(() => { GameManager.UI.ShowPopUpUI<PopUpUI>("UI/PigStoryModeSelectUI"); });
		buttons["MouseButton"].onClick.AddListener(() => { GameManager.UI.ShowPopUpUI<PopUpUI>("UI/PigStoryModeSelectUI"); });

		buttons["StoryModeEntranceBackButton"].onClick.AddListener(() => { GameManager.UI.ClosePopUpUI(); });
	}
}
