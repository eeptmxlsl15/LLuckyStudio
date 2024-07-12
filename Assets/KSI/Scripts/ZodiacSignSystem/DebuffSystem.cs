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
	public UnityAction<int> OnPigDebuffChanged;
	public UnityAction<int> OnDogDebuffChanged;
	public UnityAction<int> OnChickenDebuffChanged;
	public UnityAction<int> OnMonkeyDebuffChanged;
	public UnityAction<int> OnSheepDebuffChanged;
	public UnityAction<float> OnHorseDebuffChanged;
	public UnityAction<int> OnSnakeDebuffChanged;
	public UnityAction<float> OnDragonDebuffChanged;
	public UnityAction<int> OnRabbitDebuffChanged;
	public UnityAction OnTigerDebuffChanged;
	public UnityAction<int> OnCowDebufChanged;
	public UnityAction<int, int> OnMouseDebuffChanged;

	public void PigDebuff(int value)
	{
		// TODO : 최대 체력 20감소	
		OnPigDebuffChanged?.Invoke(value);
		Debug.Log($"최대 체력 감소 {value}");
	}

	public void DogDebuff(int value)
	{
		// TODO : 이동 속도 20 감소
		OnDogDebuffChanged?.Invoke(value);
		Debug.Log($"이동 속도 {value} 감소");
	}

	public void ChickenDebuff(int value)
	{
		// TODO : 고정형 장애물 오브젝트 피해 수치 5 증가
		OnChickenDebuffChanged?.Invoke(value);
		Debug.Log($"고정형 장애물 오브젝트 피해 수치 {value} 증가");
	}

	public void MonkeyDebuff(int value)
	{
		// TODO : 젤리 코인 점수 5 감소
		OnMonkeyDebuffChanged?.Invoke(value);
		Debug.Log($"젤리 코인 점수 {value} 감소");
	}

	public void SheepDebuff(int value)
	{
		// TODO : 반딧불 회복량 5 감소
		OnSheepDebuffChanged?.Invoke(value);
		Debug.Log($"반딧불 회복량 {value} 감소");
	}

	public void HorseDebuff(float value)
	{
		// TODO : 부스터 아이템 지속시간 1.5초 감소
		OnHorseDebuffChanged?.Invoke(value);
		Debug.Log($"부스터 아이템 지속시간 {value} 감소");
	}

	public void SnakeDebuff(int value)
	{
		// TODO : 날아오는 장애물 오브젝트 피해 수치 5 증가
		OnSnakeDebuffChanged?.Invoke(value);
		Debug.Log($"날아오는 장애물 오브젝트 피해 수치 {value} 증가");
	}

	public void DragonDebuff(float value)
	{
		// TODO : 무적 아이템 지속시간 1.5초 감소
		OnDragonDebuffChanged?.Invoke(value);
		Debug.Log($"무적 아이템 지속시간 {value}초 감소");
	}

	public void RabbitDebuff(int value)
	{
		// TODO : 츄르의 회복량 5 감소
		OnRabbitDebuffChanged?.Invoke(value);
		Debug.Log($"츄르의 회복량 {value} 감소");
	}

	public void TigerDebuff()
	{
		// TODO : 쉴드 효과 무효화
		OnTigerDebuffChanged?.Invoke();
		Debug.Log($"쉴드 효과 무효화");
	}

	public void CowDebuff(int value)
	{
		// TODO : 활공 1초 감소
		OnCowDebufChanged?.Invoke(value);
		Debug.Log($"활공 {value} 감소");
	}

	public void MouseDebuff(int value, int persecond)
	{
		// TODO : 체력이 5초당 1 감소
		OnMouseDebuffChanged?.Invoke(value, persecond);
		Debug.Log($"체력이 {value} 초당 {value} 감소");
	}
}
