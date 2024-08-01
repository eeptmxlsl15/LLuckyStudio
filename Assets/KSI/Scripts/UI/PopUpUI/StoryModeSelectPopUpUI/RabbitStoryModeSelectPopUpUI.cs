using UnityEngine;
using UnitySceneManager = UnityEngine.SceneManagement.SceneManager;

public class RabbitStoryModeSelectPopUpUI : PopUpUI
{
	protected override void Awake()
	{
		base.Awake();

		buttons["RabbitSUBButton"].onClick.AddListener(() => { LoadSUBScene(); });
		buttons["RabbitBOSSButton"].onClick.AddListener(() => { GameManager.UI.ShowPopUpUI<PopUpUI>("UI/BOSSPopUpUI/RabbitBOSSPopUpUI"); });
		buttons["RabbitBERSERKBOSSButton"].onClick.AddListener(() => { GameManager.UI.ShowPopUpUI<PopUpUI>("UI/BERSERKBOSSPopUpUI/RabbitBERSERKBOSSPopUpUI"); });
		buttons["RabbitStoryModeSelectBackButton"].onClick.AddListener(() => { GameManager.UI.ClosePopUpUI(); });

	}
	public void LoadSUBScene()
	{
		GameManager.UI.ClosePopUpUI();
		UnitySceneManager.LoadScene("SUBSceneRabbit");
		Time.timeScale = 1f;	
	}
}
