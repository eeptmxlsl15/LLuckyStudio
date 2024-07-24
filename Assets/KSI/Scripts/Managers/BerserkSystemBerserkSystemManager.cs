using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using TMPro;
using UnityEngine;
using UnityEngine.Events;

// 광폭 시스템
// 자축인묘 : 23 ~ 07 (녹)
// 진사오미 : 07 ~ 15 (청)
// 신유술해 : 15 ~ 23 (적)

public class BerserkSystemManager : MonoBehaviour
{
	public enum ZodiacSign
	{
		RABBIT,
		TIGER,
		COW,
		MOUSE,
		SHEEP,
		HORSE,
		SNAKE,
		DRAGON,
		PIG,
		DOG,
		CHICKEN,
		MONKEY
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
		//debuffSystem = GetComponent<DebuffSystem>();
		debuffSystem = FindObjectOfType<DebuffSystem>();
		if (debuffSystem == null)
		{
			Debug.LogError("DebuffSystem 컴포넌트가 존재하지 않습니다!");
			return;
		}

		// 십이지신 시간대 초기화
		//berserkTime = new BerserkTime[]
		//{
		//	new BerserkTime { zodiacSign = ZodiacSign.RABBITTIGERCOWMOUSE, startHour = 23, endHour = 7},
		//	new BerserkTime { zodiacSign = ZodiacSign.SHEEPHORSESNAKEDRAGON, startHour = 7, endHour = 15},
		//	new BerserkTime { zodiacSign = ZodiacSign.PIGDOGCHICKENMONKEY, startHour = 15, endHour = 23}
		//};

		List<BerserkTime> list = new List<BerserkTime>();
		var values = Enum.GetValues(typeof(BerserkSystemManager.ZodiacSign)).Cast<BerserkSystemManager.ZodiacSign>().ToList();
		byte time = 0;
		foreach (var item in values)
		{
			list.Add(new BerserkTime { zodiacSign = item, startHour = time, endHour = time + 2 });
			time += 2;
		}
		berserkTime = list.ToArray();

		//디버프 초기화
		zodiacSignDebuff = new ZodiacSignDebuff[]
		{
			new ZodiacSignDebuff { zodiacSign = ZodiacSign.PIG, applyDebuff = () => debuffSystem.OnPigDebuffChanged()},
			new ZodiacSignDebuff { zodiacSign = ZodiacSign.DOG, applyDebuff = () => debuffSystem.OnDogDebuffChanged()},
			new ZodiacSignDebuff { zodiacSign = ZodiacSign.CHICKEN, applyDebuff = () => debuffSystem.OnChickenDebuffChanged()},
			new ZodiacSignDebuff { zodiacSign = ZodiacSign.MONKEY, applyDebuff = () => debuffSystem.OnMonkeyDebuffChanged()},
			new ZodiacSignDebuff { zodiacSign = ZodiacSign.SHEEP, applyDebuff = () => debuffSystem.OnSheepDebuffChanged()},
			new ZodiacSignDebuff { zodiacSign = ZodiacSign.HORSE, applyDebuff = () => debuffSystem.OnHorseDebuffChanged()},
			new ZodiacSignDebuff { zodiacSign = ZodiacSign.SNAKE,applyDebuff = () => debuffSystem.OnSnakeDebuffChanged()},
			new ZodiacSignDebuff { zodiacSign = ZodiacSign.DRAGON, applyDebuff = () => debuffSystem.OnDragonDebuffChanged()},
			new ZodiacSignDebuff { zodiacSign = ZodiacSign.RABBIT, applyDebuff = () => debuffSystem.OnSnakeDebuffChanged()},
			new ZodiacSignDebuff { zodiacSign = ZodiacSign.TIGER, applyDebuff = debuffSystem.OnTigerDebuffChanged},
			new ZodiacSignDebuff { zodiacSign = ZodiacSign.COW, applyDebuff = () => debuffSystem.OnCowDebufChanged()},
			new ZodiacSignDebuff { zodiacSign = ZodiacSign.MOUSE,applyDebuff = () => debuffSystem.OnMouseDebuffChanged()}
		};
		//Debug.Log("디버프 초기화 성공");
	}

	// 현재 시간을 기준으로 십이지신을 반환하는 메소드
	public ZodiacSign GetCurZodiacSign()
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
