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
		RABBITTIGERCOWMOUSE,
		SHEEPHORSESNAKEDRAGON,
		PIGDOGCHICKENMONKEY
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
			list.Add(new BerserkTime { zodiacSign = item, startHour = time, endHour = time + 8 });
			time += 8;
		}
		berserkTime = list.ToArray();

		//디버프 초기화
		//zodiacSignDebuff = new ZodiacSignDebuff[]
		//{
		//	new ZodiacSignDebuff { zodiacSign = ZodiacSign.PIG, applyDebuff = () => debuffSystem.OnPigDebuffChanged(20)},
		//	new ZodiacSignDebuff { zodiacSign = ZodiacSign.DOG, applyDebuff = () => debuffSystem.OnDogDebuffChanged(20)},
		//	new ZodiacSignDebuff { zodiacSign = ZodiacSign.CHICKEN, applyDebuff = () => debuffSystem.OnChickenDebuffChanged(5)},
		//	new ZodiacSignDebuff { zodiacSign = ZodiacSign.MONKEY, applyDebuff = () => debuffSystem.OnMonkeyDebuffChanged(5)},
		//	new ZodiacSignDebuff { zodiacSign = ZodiacSign.SHEEP, applyDebuff = () => debuffSystem.OnSheepDebuffChanged(5)},
		//	new ZodiacSignDebuff { zodiacSign = ZodiacSign.HORSE, applyDebuff = () => debuffSystem.OnHorseDebuffChanged(1.5f)},
		//	new ZodiacSignDebuff { zodiacSign = ZodiacSign.SNAKE,applyDebuff = () => debuffSystem.OnSnakeDebuffChanged(5)},
		//	new ZodiacSignDebuff { zodiacSign = ZodiacSign.DRAGON, applyDebuff = () => debuffSystem.OnDragonDebuffChanged(1.5f)},
		//	new ZodiacSignDebuff { zodiacSign = ZodiacSign.RABBIT, applyDebuff = () => debuffSystem.OnSnakeDebuffChanged(5)},
		//	new ZodiacSignDebuff { zodiacSign = ZodiacSign.TIGER, applyDebuff = debuffSystem.OnTigerDebuffChanged},
		//	new ZodiacSignDebuff { zodiacSign = ZodiacSign.COW, applyDebuff = () => debuffSystem.OnCowDebufChanged(1)},
		//	new ZodiacSignDebuff { zodiacSign = ZodiacSign.MOUSE,applyDebuff = () => debuffSystem.OnMouseDebuffChanged(1, 5)}
		//};
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
			if (zodiacSignTime.zodiacSign == ZodiacSign.RABBITTIGERCOWMOUSE && (currentHour >= 23 || currentHour < 7))
			{
				// 쥐시 반환
				return ZodiacSign.RABBITTIGERCOWMOUSE;
			}
		}

		// 기본값으로 쥐시 반환 
		return ZodiacSign.RABBITTIGERCOWMOUSE; 
	}

	// 특정 십이지신에 해당하는 디버프를 적용하는 메소드
	public void ApplyDebuff(ZodiacSign zodiacSign)
	{
		//foreach (ZodiacSignDebuff debuff in zodiacSignDebuff)
		//{
		//	if (debuff.zodiacSign == zodiacSign)
		//	{
		//		// 해당 디버프를 적용
		//		debuff.applyDebuff?.Invoke(); 
		//		return;
		//	}
		//}
		Debug.Log("디버프 적용");
	}

	// 현재 시간을 Unix 타임스탬프로 변환
	private double GetUnixTimestamp()
	{
		return (DateTime.UtcNow - new DateTime(1970, 1, 1)).TotalSeconds;
	}
}
