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

}
