public class PauseSceneUI : SceneUI
{
	protected override void Awake()
	{
		base.Awake();

		buttons["PauseButton"].onClick.AddListener(() => { OpenPausePopUpUI(); });
	}

	public void OpenPausePopUpUI()
	{
		GameManager.UI.ShowPopUpUI<PopUpUI>("UI/PausePopUpUI");
	}
}
