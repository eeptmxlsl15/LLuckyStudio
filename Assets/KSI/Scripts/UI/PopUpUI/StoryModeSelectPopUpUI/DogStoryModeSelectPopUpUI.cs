using UnityEngine;
using static BerserkSystemManager;
using UnitySceneManager = UnityEngine.SceneManagement.SceneManager;

public class DogStoryModeSelectPopUpUI : PopUpUI
{
	private BerserkSystemManager berserkSystemManager;
	private BerserkSystemManager.ZodiacSign currentZodiacSign;

	protected override void Awake()
	{
		base.Awake();
		GameObject berserkBossButton = GameObject.Find("DogBERSERKBOSSButton");
		if (berserkBossButton != null)
			berserkBossButton.SetActive(false);

		buttons["DogSUBButton"].onClick.AddListener(() => { LoadSUBScene(); });
		buttons["DogBOSSButton"].onClick.AddListener(() => { GameManager.UI.ShowPopUpUI<PopUpUI>("UI/BOSSPopUpUI/DogBOSSPopUpUI"); });
		buttons["DogBERSERKBOSSButton"].onClick.AddListener(() => { GameManager.UI.ShowPopUpUI<PopUpUI>("UI/BERSERKBOSSPopUpUI/DogBERSERKBOSSPopUpUI"); });
		buttons["DogStoryModeSelectBackButton"].onClick.AddListener(() => { GameManager.UI.ClosePopUpUI(); });

		ActivateBERSERKBOSSButton(currentZodiacSign);
	}

	private void Update()
	{
		ActivateBERSERKBOSSButton(currentZodiacSign);
	}

	public void LoadSUBScene()
	{
		GameManager.UI.ClosePopUpUI();
		GameManager.UI.ClearPopUpUI();
		UnitySceneManager.LoadScene("SUBSceneDog");
		Time.timeScale = 1f;	
	}

	private void ActivateBERSERKBOSSButton(BerserkSystemManager.ZodiacSign zodiacSign)
	{
		GameObject berserkBossButton = GameObject.Find("ChickenBERSERKBOSSButton");

		switch (zodiacSign)
		{		
			case BerserkSystemManager.ZodiacSign.DOG:
				if (berserkBossButton != null)
					berserkBossButton.SetActive(true);
				break;
			case BerserkSystemManager.ZodiacSign.MOUSE:
			case BerserkSystemManager.ZodiacSign.COW:
			case BerserkSystemManager.ZodiacSign.TIGER:
			case BerserkSystemManager.ZodiacSign.RABBIT:
			case BerserkSystemManager.ZodiacSign.DRAGON:
			case BerserkSystemManager.ZodiacSign.SNAKE:
			case BerserkSystemManager.ZodiacSign.HORSE:
			case BerserkSystemManager.ZodiacSign.SHEEP:
			case BerserkSystemManager.ZodiacSign.MONKEY:
			case BerserkSystemManager.ZodiacSign.CHICKEN:
			case BerserkSystemManager.ZodiacSign.PIG:
				if (berserkBossButton != null)
					berserkBossButton.SetActive(false);
				break;
		}
	}
}
