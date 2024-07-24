using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

// 디버프 시스템
// 해(돼지) : 최대 체력 20감소
// 술(개) : 이동 속도 20 감소
// 유(닭) : 고정형 장애물 오브젝트 피해 수치 5 증가
// 신(원숭이) : 젤리 코인 점수 5 감소
// 미(양) : 반딧불 회복량 5 감소
// 오(말) : 부스터 아이템 지속시간 1.5초 감소
// 사(뱀) : 날아오는 장애물 오브젝트 피해 수치 5 증가
// 진(용) : 무적 아이템 지속시간 1.5초 감소
// 묘(토끼)) : 츄르의 회복량 5 감소
// 인(호랑이) : 쉴드 효과 무효화
// 축(소) : 활공 1초 감소
// 자(쥐) : 체력이 5초당 1 감소
public class DebuffSystem : MonoBehaviour
{
	public UnityAction OnPigDebuffChanged;
	public UnityAction OnDogDebuffChanged;
	public UnityAction OnChickenDebuffChanged;
	public UnityAction OnMonkeyDebuffChanged;
	public UnityAction OnSheepDebuffChanged;
	public UnityAction OnHorseDebuffChanged;
	public UnityAction OnSnakeDebuffChanged;
	public UnityAction OnDragonDebuffChanged;
	public UnityAction OnRabbitDebuffChanged;
	public UnityAction OnTigerDebuffChanged;
	public UnityAction OnCowDebufChanged;
	public UnityAction OnMouseDebuffChanged;

	private Player player;

	private void Start()
	{
		player = FindObjectOfType<Player>();
		if (player == null)
		{
			Debug.LogError("씬에 플레이어 없음");
		}
	}

	public void PigDebuff()
	{
		if (player != null)
		{
			player.PigDebuff();
		}

		OnPigDebuffChanged?.Invoke();
	}

	public void DogDebuff()
	{
		if (player != null)
		{
			player.DogDebuff();
		}

		OnDogDebuffChanged?.Invoke();
	}

	public void ChickenDebuff()
	{
		if (player != null)
		{
			player.RoosterDebuff();
		}

		OnChickenDebuffChanged?.Invoke();
	}

	public void MonkeyDebuff(int value)
	{
		if (player != null)
		{
			player.MonkeyDebuff();
		}

		OnMonkeyDebuffChanged?.Invoke();
	}

	public void SheepDebuff()
	{
		if (player != null)
		{
			player.LamnDebuff();
		}

		OnSheepDebuffChanged?.Invoke();
	}

	public void HorseDebuff()
	{
		if (player != null)
		{
			player.HorseDebuff();
		}

		OnHorseDebuffChanged?.Invoke();
	}

	public void SnakeDebuff()
	{
		if (player != null)
		{
			player.SnakeDebuff();
		}

		OnSnakeDebuffChanged?.Invoke();
	}

	public void DragonDebuff()
	{
		if (player != null)
		{
			player.DragonDebuff();
		}

		OnDragonDebuffChanged?.Invoke();
	}

	public void RabbitDebuff()
	{
		if (player != null)
		{
			player.RabbitDebuff();
		}

		OnRabbitDebuffChanged?.Invoke();
	}

	public void TigerDebuff()
	{
		if (player != null)
		{
			player.TigerDebuff();
		}

		OnTigerDebuffChanged?.Invoke();
	}

	public void CowDebuff()
	{
		if (player != null)
		{
			player.OxDebuff();
		}

		OnCowDebufChanged?.Invoke();
	}

	public void MouseDebuff()
	{
		if (player != null)
		{
			player.RatDebuff();
		}

		OnMouseDebuffChanged?.Invoke();
	}
}
