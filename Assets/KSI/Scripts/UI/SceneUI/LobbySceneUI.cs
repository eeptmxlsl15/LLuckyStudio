using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class LobbySceneUI : SceneUI
{
	[SerializeField] private TMP_Text randomDebuffText1;
	[SerializeField] private TMP_Text randomDebuffText2;

	protected override void Awake()
	{
		base.Awake();

		buttons["StartButton"].onClick.AddListener(() => { GameStart(); });
	}

	void GameStart()
	{
		GameManager.Scene.StartGame();
	}

	public void DisplayInfiniteRandomDebuff(BerserkSystemManager.ZodiacSign debuff1, BerserkSystemManager.ZodiacSign debuff2)
	{
		randomDebuffText1.text = $"First\nDebuff : {debuff1}";
		randomDebuffText2.text = $"Second\nDebuff : {debuff2}";
	}
}
