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
	// 게임 모드를 나타내는 열거형(enum)
	public enum GameMode
	{
		SUB,
		BOSS,
		BERSERKBOSS,
		INFINITE
	}

	public GameMode curGameMode;
	public TMP_Text randomDebuffText1;
	public TMP_Text randomDebuffText2;

	private BerserkSystem berserkSystem;

	private void Start()
	{
		berserkSystem = GetComponent<BerserkSystem>();

		ApplyDebuff(curGameMode);
	}

	public void ApplyDebuff(GameMode gameMode)
	{
		switch (gameMode)
		{
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
		BerserkSystem.ZodiacSign curZodiacSign = berserkSystem.GetCurZodiacSign();
		Debug.Log($"보스 스테이지 : {curZodiacSign}이 적용됨");

		// 해당 십이지신의 디버프를 적용
		berserkSystem.ApplyDebuff(curZodiacSign);
	}

	// 광폭 보스 스테이지 디버프
	private void ApplyBerserkBossDebuff()
	{
		// 현재 시간에 해당하는 십이지신을 가져옴
		BerserkSystem.ZodiacSign curZodiacSign = berserkSystem.GetCurZodiacSign();
		Debug.Log($"광폭 보스 스테이지 : {curZodiacSign}이 적용됨");

		// 해당 십이지신의 디버프를 적용
		berserkSystem.ApplyDebuff(curZodiacSign);
	}

	// 무한 모드 스테이지 디버프
	private void ApplyInfiniteDebuff()
	{
		Array values = Enum.GetValues(typeof(BerserkSystem.ZodiacSign));
		System.Random random = new System.Random();
		BerserkSystem.ZodiacSign randomZodiac1 = (BerserkSystem.ZodiacSign)values.GetValue(random.Next(values.Length));
		BerserkSystem.ZodiacSign randomZodiac2 = (BerserkSystem.ZodiacSign)values.GetValue(random.Next(values.Length));

		Debug.Log($"무한모드 : {randomZodiac1}, {randomZodiac2}가 적용됨");
		berserkSystem.ApplyDebuff(randomZodiac1);
		berserkSystem.ApplyDebuff(randomZodiac2);

		randomDebuffText1.text = $"Debuff 1: {randomZodiac1}";
		randomDebuffText2.text = $"Debuff 2: {randomZodiac2}";
	}
}
