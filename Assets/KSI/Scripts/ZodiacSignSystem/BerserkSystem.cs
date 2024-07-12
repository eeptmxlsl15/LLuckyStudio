using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

// 광폭 시스템
// 해(돼지)시 : 21 ~ 23시  
// 술(개)시 : 19 ~ 21시
// 유(닭)시 : 17 ~ 19시
// 신(원숭이)시 : 15 ~17시
// 미(양)시 : 13 ~ 15시
// 오(말) : 11 ~ 13시
// 사(뱀)시 : 09 ~ 11시
// 진(용)시 : 07 ~ 09시
// 묘(토끼)시 : 05 ~ 07시
// 인(호랑이)시 : 03 ~ 05시
// 축(소)시 : 01 ~ 03시
// 자(쥐)시 : 23 ~ 01시
public class BerserkSystem : MonoBehaviour
{
	public enum ZodiacSign
	{
		PIG,
		DOG,
		CHICKEN,
		MONKEY,
		SHEEP,
		HORSE,
		SNAKE,
		DRAGON,
		RABBIT,
		TIGER,
		COW,
		MOUSE
	}

	[Serializable]
	public class BerserkTime
	{
		public ZodiacSign zodiacSign;
		public int startHour;
		public int endHour;
	}

	public class ZodiacSignDebuff
	{
		public ZodiacSign zodiacSign;
		public UnityAction applyDebuff;
	}

	public BerserkTime[] berserkTime;
	public ZodiacSignDebuff[] zodiacSignDebuff;

	private DebuffSystem debuffSystem;

	private void Start()
	{
		debuffSystem = GetComponent<DebuffSystem>();

		// 십이지신 시간 초기화
		berserkTime = new BerserkTime[]
		{
			new BerserkTime { zodiacSign = ZodiacSign.PIG, startHour = 21, endHour = 23},
			new BerserkTime { zodiacSign = ZodiacSign.DOG, startHour = 19, endHour = 21},
			new BerserkTime { zodiacSign = ZodiacSign.CHICKEN, startHour = 17, endHour = 19},
			new BerserkTime { zodiacSign = ZodiacSign.MONKEY, startHour= 15, endHour = 17},
			new BerserkTime { zodiacSign = ZodiacSign.SHEEP, startHour= 13, endHour = 15},
			new BerserkTime { zodiacSign = ZodiacSign.HORSE, startHour= 11, endHour = 13},
			new BerserkTime { zodiacSign = ZodiacSign.SNAKE, startHour= 9, endHour = 11},
			new BerserkTime { zodiacSign = ZodiacSign.DRAGON, startHour= 7, endHour = 9},
			new BerserkTime { zodiacSign = ZodiacSign.RABBIT, startHour= 5, endHour = 7},
			new BerserkTime { zodiacSign = ZodiacSign.TIGER, startHour= 3, endHour = 5},
			new BerserkTime { zodiacSign = ZodiacSign.COW, startHour= 1, endHour = 3},
			new BerserkTime { zodiacSign = ZodiacSign.MOUSE, startHour= 23, endHour = 1}
		};

		// 디버프 초기화
		zodiacSignDebuff = new ZodiacSignDebuff[]
		{
			new ZodiacSignDebuff { zodiacSign = ZodiacSign.PIG, applyDebuff = () => debuffSystem.OnPigDebuffChanged(20)},
			new ZodiacSignDebuff { zodiacSign = ZodiacSign.DOG, applyDebuff = () => debuffSystem.OnDogDebuffChanged(20)},
			new ZodiacSignDebuff { zodiacSign = ZodiacSign.CHICKEN, applyDebuff = () => debuffSystem.OnChickenDebuffChanged(5)},
			new ZodiacSignDebuff { zodiacSign = ZodiacSign.MONKEY, applyDebuff = () => debuffSystem.OnMonkeyDebuffChanged(5)},
			new ZodiacSignDebuff { zodiacSign = ZodiacSign.SHEEP, applyDebuff = () => debuffSystem.OnSheepDebuffChanged(5)},
			new ZodiacSignDebuff { zodiacSign = ZodiacSign.HORSE, applyDebuff = () => debuffSystem.OnHorseDebuffChanged(1.5f)},
			new ZodiacSignDebuff { zodiacSign = ZodiacSign.SNAKE,applyDebuff = () => debuffSystem.OnSnakeDebuffChanged(5)},
			new ZodiacSignDebuff { zodiacSign = ZodiacSign.DRAGON, applyDebuff = () => debuffSystem.OnDragonDebuffChanged(1.5f)},
			new ZodiacSignDebuff { zodiacSign = ZodiacSign.RABBIT, applyDebuff = () => debuffSystem.OnSnakeDebuffChanged(5)},
			new ZodiacSignDebuff { zodiacSign = ZodiacSign.TIGER, applyDebuff = debuffSystem.OnTigerDebuffChanged},
			new ZodiacSignDebuff { zodiacSign = ZodiacSign.COW, applyDebuff = () => debuffSystem.OnCowDebufChanged(1)},
			new ZodiacSignDebuff { zodiacSign = ZodiacSign.MOUSE,applyDebuff = () => debuffSystem.OnMouseDebuffChanged(1, 5)}
		};
	}

	// 현재 시간을 기준으로 십이지신을 반환하는 메소드
	public ZodiacSign GetCurrentZodiacSign()
	{
		// 현재 유닉스 타임스탬프를 가져옴
		double unixTimestamp = GetUnixTimestamp();
		// 유닉스 타임스탬프를 DateTime 형식으로 변환하고 로컬 시간대로 변환
		DateTimeOffset currentTime = DateTimeOffset.FromUnixTimeSeconds((long)unixTimestamp).ToLocalTime();
		// 현재 시간을 시간 단위로 가져옴
		int currentHour = currentTime.Hour;

		// 모든 십이지신 시간대를 검사함
		foreach (BerserkTime zodiacSignTime in berserkTime)
		{
			// 현재 시간이 십이지신 시간대에 해당하는지 확인
			if (zodiacSignTime.startHour <= currentHour && currentHour < zodiacSignTime.endHour)
			{
				// 해당 십이지신을 시간대를 반환
				return zodiacSignTime.zodiacSign; 
			}

			// 쥐시는 익일(23:00 - 01:00)까지 연결되기 때문에 따로 처리
			if (zodiacSignTime.zodiacSign == ZodiacSign.MOUSE && (currentHour >= 23 || currentHour < 1))
			{
				// 쥐시 반환
				return ZodiacSign.MOUSE;
			}
		}

		// 기본값으로 쥐시 반환 
		return ZodiacSign.MOUSE; 
	}

	// 특정 십이지신에 해당하는 디버프를 적용하는 메소드
	public void ApplyDebuff(ZodiacSign zodiacSign)
	{
		foreach (ZodiacSignDebuff debuff in zodiacSignDebuff)
		{
			if (debuff.zodiacSign == zodiacSign)
			{
				// 해당 디버프를 적용
				debuff.applyDebuff?.Invoke(); 
				return;
			}
		}
	}

	// 현재 시간을 Unix 타임스탬프로 변환
	private double GetUnixTimestamp()
	{
		return (DateTime.UtcNow - new DateTime(1970, 1, 1)).TotalSeconds;
	}
}
