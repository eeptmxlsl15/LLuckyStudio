using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class DataManager : MonoBehaviour
{
	// 싱글톤 인스턴스
	public static DataManager Instance { get; private set; }

	// 씬 간에 전달할 데이터
	//염원
	public Dictionary<Button, bool> desireStates = new Dictionary<Button, bool>();
	//스탯
	[Header("# Player Skin")]
	public RuntimeAnimatorController[] playerSkin;
	public List<bool> havePlayerSkin;
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
	public float glideTime = 0;

	public bool ratDesire;
	public float healthRegenTimer = 0f;
	private const float healthRegenInterval = 10f;

	public float glideCooldown = 45;
	public float glideCooldownTimer = 0f;

	[Header("# Player Items")]
	public int cannedFood;//유료 재화
	public int brokenBlue;//체력
	public int brokenRed;//활주시간
	public int brokenGreen;//점프횟수
	public int sushi;//인게임 재화


	/// <summary>
	/// silverKey : 현재 은열쇠 수
	/// maxSilverKey : 최대 보유 가능한 은열쇠 수 
	/// goldKey : 현재 금열쇠 수
	/// goldKey : 최대 보유 가능한 금열쇠 수
	/// </summary>
	public int silverKey;
	public int maxSilverKey = 999;
	public int goldKey;
	public int maxGoldKey;

	public int resurrection;

	public int money;//유료 재화 
	[Header("# Effect & Wallpaper")]
	//이펙트
	public int effectID;

	//배경
	public int wallpaper;

	public int[] nextSushi = { 10000, 15000, 18000, 20000, 26000, 30000, 40000, 50000, 55000, 60000 };
	public int[] nextExp = { 10, 20, 30, 40, 50, 60, 70, 80, 90, 100, 110 };
	[Header("# Cat's Desire Level")]
	public bool haveCatsDesire = true;

	public int redMarbleLv;//체력
	public int[] redMarbleValue = { 0, 2, 4, 6, 8, 10, 12, 14, 16, 18, 20 };

	public int blueMarbleLv;//피해 수치 감소
	public float[] blueMarbleValue = { 0, 0.5f, 1f, 1.5f, 2f, 2.5f, 3f, 3.5f, 4f, 4.5f, 5f };


	public int greenMarbleLv;//활공 시간
	public float[] greenMarbleValue = { 0f, 0.5f, 1f, 1.5f, 2f, 2.5f, 3f, 3.5f, 4f, 4.5f, 5f };

	[Header("# Reset Item")]
	public List<int> resetItemID;

	//일일 초기화 시resetNum , advResetNum 은 0으로 초기화
	//UIMapping 스크립트
	public int resetNum;
	public int resetMaxNum;

	public int advResetNum;
	public int advResetMaxNum;

	public bool isDead = false;

	[Header("# Package")]
	public float catGage;
	public float premiumGage;

	public List<int> haveSkin = new List<int>();
	public List<int> haveWallpaper = new List<int>();
	public List<int> haveEffect = new List<int>();


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