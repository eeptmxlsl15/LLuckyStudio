using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.SceneManagement;
public class DataManager : MonoBehaviour
{
    // 싱글톤 인스턴스
    public static DataManager Instance { get; private set; }

    // 씬 간에 전달할 데이터
	//염원
    public Dictionary<Button, bool> desireStates = new Dictionary<Button, bool>();
	//스탯


	[Header("# Player Stat")]
	public int skinID;
	public float health;
	public float maxHealth = 100f;
	public float speed = 10f;
	public float jumpForce = 10f;
	public int jumpCount = 0;
	public int maxJumpCount = 2; // 2단 점프를 위해 최대 점프 횟수를 2로 설정
	public int floorRes = 0; // 발판형 장애물 저항
	public int flyRes = 0; // 날아오는 장애물 저항
	public int allRes = 0; // 모든 피해 수치 감소 
	public float healthRegen = 0;
	public float glideTime=0;

	public bool ratDesire;
	public float healthRegenTimer = 0f;
	private const float healthRegenInterval = 10f;

	public float glideCooldown = 120f;
	public float glideCooldownTimer = 0f;

	[Header("# Player Items")]
	public int cannedFood;//유료 재화
	public int brokenBlue;//체력
	public int brokenRed;//활주시간
	public int brokenGreen;//점프횟수
	public int fish;//인게임 재화
	public int goldMarble;
	public int silverMarble;
	public int resurrection;
	public int money;//유료 재화 
	

	public int[] nextExp = { 10, 20	, 30, 40, 50, 60, 70, 80 , 90,100,110};
	[Header("# Cat's Desire Level")]
	public bool haveCatsDesire = true;

	public int redMarbleLv;//체력
	public int[] redMarbleValue =  { 5, 5, 5, 5, 5, 10, 10, 10, 10, 10,20 };

	public int blueMarbleLv;//피해 수치 감소
	public int[] blueMarbleValue = { 1, 1, 1, 1, 1, 3, 3, 3, 3, 3,5 };
	
	
	public int greenMarbleLv;//활공 시간
	public float[] greenMarbleValue = { 5f, 5f, 5f, 5f, 5f,7f, 7f, 7f, 7f, 7f,10f };

	[Header("# Is Buy")]
	public bool isBuyItem1;
	public bool isBuyItem2;
	public bool isBuyItem3;
	public bool isBuyItem4;
	private void Awake()
    {
        // 싱글톤 패턴 구현
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject); // 씬 전환 시 객체 유지
        }
        else
        {
            Destroy(gameObject); // 중복된 인스턴스 제거
        }
		//InitializeUI();
    }

	public void InitializeData(Dictionary<Button, bool> data)
	{
		desireStates = new Dictionary<Button, bool>(data);
	}




}