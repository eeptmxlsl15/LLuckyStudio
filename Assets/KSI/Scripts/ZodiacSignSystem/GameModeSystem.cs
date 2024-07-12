using System.Collections;
using System.Collections.Generic;
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

	private void ApplyBossDebuff()
	{ 
	
	}

	private void ApplyBerserkBossDebuff()
	{
		
	}

	private void ApplyInfiniteDebuff()
	{ 
	
	}
}
