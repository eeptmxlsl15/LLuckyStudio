using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PigStageSelectorUI : MonoBehaviour
{
	public Button subButton;
	public Button bossButton;
	public Button berserkbossButton;

	private void Start()
	{
		DisableAllStageButtons();

		subButton.interactable = true;

		StageManager.OnPigSubComplete.AddListener(() => ActivateButton(bossButton));
		StageManager.OnPigSubComplete.AddListener(() => ActivateButton(berserkbossButton));

		CheckAndActivateUnlockedStages();
	}

	private void DisableAllStageButtons()
	{
		subButton.interactable = false;
		bossButton.interactable = false;
		berserkbossButton.interactable = false;
	}

	private void ActivateButton(Button button)
	{
		if (button != null)
		{
			button.interactable = true;
		}
	}

	// 버튼 활성화와 스테이지 해금을 처리하는 메서드
	private void ActivateButtonAndUnlockStage(Button button, int stageIndex)
	{
		ActivateButton(button);
		Account.Inst.stageUnlockData.UnlockStage(stageIndex);
	}

	// 이미 해금된 스테이지 버튼을 활성화하는 메서드
	private void CheckAndActivateUnlockedStages()
	{
		if (Account.Inst.stageUnlockData.unlockedStages.Contains(1))
		{
			ActivateButton(bossButton);
		}

		if (Account.Inst.stageUnlockData.unlockedStages.Contains(2))
		{
			ActivateButton(berserkbossButton);
		}
	}
}
