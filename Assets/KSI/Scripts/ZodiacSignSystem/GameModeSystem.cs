using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

// 게임 모드
// 서브 스테이지 : 디버프 적용 없음
// 보스 스테이지 : 해당 보스 스테이지의 십이지신의 디버프 적용
// 광폭 보스 스테이지 : 플레이 시간 대의 십이지신의 디버프 1개 적용
// 무한 모드 스테이지 : 십이지신의 디버프 중 랜덤으로 2개 적용
public class GameModeSystem : MonoBehaviour
{
	public enum GameMode
	{
		LOBBY,
		SUB,
		BOSS,
		BERSERKBOSS,
		INFINITE
	}
	public GameMode curGameMode;

	private BerserkSystemManager berserkSystem;	
	private LobbySceneUI lobbySceneUI;
	private KSITestSceneUI testSceneUI;

	private void Start()
	{
		berserkSystem = GameManager.BerserkSystem;
		lobbySceneUI = FindAnyObjectByType<LobbySceneUI>();
		testSceneUI = FindAnyObjectByType<KSITestSceneUI>();

		if (curGameMode == GameMode.INFINITE)
		{
			if (GameManager.Instance.InfiniteDebuff1 == default && GameManager.Instance.InfiniteDebuff2 == default)
			{
				SelectInfiniteRandomDebuff();
			}
			UpdateInfiniteRandomDebuff();
		}

		ApplyDebuff(curGameMode);
	}

	public void ApplyDebuff(GameMode gameMode)
	{
		switch (gameMode)
		{
			case GameMode.LOBBY:
				Debug.Log("로비");
				break;
			case GameMode.SUB:
				Debug.Log("디버프 적용 없음");
				break;
			case GameMode.BOSS:
				ApplyBossDebuff();
				Debug.Log("해당 보스 스테이지의 십이지신의 디버프 적용");
				break;
			case GameMode.BERSERKBOSS:
				ApplyBerserkBossDebuff();
				Debug.Log("플레이 시간 대의 십이지신의 디버프 1개 적용");
				break;
			case GameMode.INFINITE:
				ApplyInfiniteDebuff();
				Debug.Log("십이지신의 디버프 중 랜덤으로 2개 적용");
				break;
		}
	}

	// 보스 스테이지 디버프
	private void ApplyBossDebuff()
	{
		// 현재 시간에 해당하는 십이지신을 가져옴
		BerserkSystemManager.ZodiacSign curZodiacSign = berserkSystem.GetCurZodiacSign();
		Debug.Log($"보스 스테이지 : {curZodiacSign}이 적용됨");

		// 해당 십이지신의 디버프를 적용
		berserkSystem.ApplyDebuff(curZodiacSign);
	}

	// 광폭 보스 스테이지 디버프
	private void ApplyBerserkBossDebuff()
	{
		// 현재 시간에 해당하는 십이지신을 가져옴
		BerserkSystemManager.ZodiacSign curZodiacSign = berserkSystem.GetCurZodiacSign();
		Debug.Log($"광폭 보스 스테이지 : {curZodiacSign}이 적용됨");

		// 해당 십이지신의 디버프를 적용
		berserkSystem.ApplyDebuff(curZodiacSign);
	}

	// 무한 모드 스테이지 디버프
	private void ApplyInfiniteDebuff()
	{
		berserkSystem.ApplyDebuff(GameManager.Instance.InfiniteDebuff1);
		berserkSystem.ApplyDebuff(GameManager.Instance.InfiniteDebuff2);
		Debug.Log($"무한모드 : {GameManager.Instance.InfiniteDebuff1}, {GameManager.Instance.InfiniteDebuff2}가 적용됨");
	}

	private void SelectInfiniteRandomDebuff()
	{
		Array values = Enum.GetValues(typeof(BerserkSystemManager.ZodiacSign));
		System.Random random = new System.Random();
		GameManager.Instance.InfiniteDebuff1 = (BerserkSystemManager.ZodiacSign)values.GetValue(random.Next(values.Length));

		// 최초 실행 보장과 중복 방지
		BerserkSystemManager.ZodiacSign tempZodiac;
		do
		{
			tempZodiac = (BerserkSystemManager.ZodiacSign)values.GetValue(random.Next(values.Length));
		}while (tempZodiac == GameManager.Instance.InfiniteDebuff1);

		GameManager.Instance.InfiniteDebuff2 = tempZodiac;
	}

	private void UpdateInfiniteRandomDebuff()
	{
		if (lobbySceneUI != null )
		{
			lobbySceneUI.DisplayInfiniteRandomDebuff(GameManager.Instance.InfiniteDebuff1, GameManager.Instance.InfiniteDebuff2);
		}

		if (testSceneUI != null)
		{
			testSceneUI.DisplayInfiniteRandomDebuff(GameManager.Instance.InfiniteDebuff1, GameManager.Instance.InfiniteDebuff2);
		}
	}

	// TODO : 게임 끝나는 시점에 호출하기
	private void InfinitGameEnd()
	{
		if (curGameMode == GameMode.INFINITE)
		{
			GameManager.Instance.ResetInfiniteDebuff();
		}
	}
}
