using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
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
	public UnityAction OnCowDebuffChanged;
	public UnityAction OnMouseDebuffChanged;

	private Player player;
	private DebuffSystem debuffSystem;
	
	private void Start()
	{
		player = FindObjectOfType<Player>();
		debuffSystem = FindObjectOfType<DebuffSystem>();

		OnPigDebuffChanged += PigDebuff;
		OnDogDebuffChanged += DogDebuff;
		OnChickenDebuffChanged += ChickenDebuff;
		OnMonkeyDebuffChanged += MonkeyDebuff;
		OnSheepDebuffChanged += SheepDebuff;
		OnHorseDebuffChanged += HorseDebuff;
		OnSnakeDebuffChanged += SnakeDebuff;
		OnDragonDebuffChanged += DragonDebuff;
		OnRabbitDebuffChanged += RabbitDebuff;
		OnTigerDebuffChanged += TigerDebuff;
		OnCowDebuffChanged += CowDebuff;
		OnMouseDebuffChanged += MouseDebuff;
	}

	public void PigDebuff()
	{
		FindPlayer();
		player.PigDebuff();
	}

	public void DogDebuff()
	{
		FindPlayer();
		player.DogDebuff();
	}

	public void ChickenDebuff()
	{
		FindPlayer();
		player.RoosterDebuff();
	}

	public void MonkeyDebuff()
	{

		FindPlayer();
		player.MonkeyDebuff();
	}

	public void SheepDebuff()
	{
		FindPlayer();
		player.LamnDebuff();
	}

	public void HorseDebuff()
	{
		FindPlayer();
		player.HorseDebuff();
	}

	public void SnakeDebuff()
	{
		FindPlayer();
		player.SnakeDebuff();
	}

	public void DragonDebuff()
	{
		FindPlayer();
		player.DragonDebuff();
	}

	public void RabbitDebuff()
	{
		FindPlayer();
		player.RabbitDebuff();
	}

	public void TigerDebuff()
	{

		FindPlayer();
		player.TigerDebuff();
	}

	public void CowDebuff()
	{

		FindPlayer();
		player.OxDebuff();
	}

	public void MouseDebuff()
	{

		FindPlayer();
		player.RatDebuff();
	}

	public void FindPlayer()
	{
		if (player == null)
			player = FindObjectOfType<Player>();
	}
}
