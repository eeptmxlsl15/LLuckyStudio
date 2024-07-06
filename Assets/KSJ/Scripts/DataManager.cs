using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class DataManager : MonoBehaviour
{
    // 싱글톤 인스턴스
    public static DataManager Instance { get; private set; }

    // 씬 간에 전달할 데이터
	//염원
    public Dictionary<Button, bool> desireStates = new Dictionary<Button, bool>();
	//스탯
	[Header("# Player Stat")]
	public float health;
	public float maxHealth = 100f;
	public float speed = 10f;
	public float jumpForce = 10f;
	public int jumpCount = 0;
	public int maxJumpCount = 2; // 2단 점프를 위해 최대 점프 횟수를 2로 설정
	public int floorRes = 0; // 발판형 장애물 저항
	public int flyRes = 0; // 날아오는 장애물 저항
	public float healthRegen = 0;

	private bool ratDesire;
	private float healthRegenTimer = 0f;
	private const float healthRegenInterval = 5f;

	public TMP_Text maxHealthText;
	public TMP_Text speedText;
	public TMP_Text jumpText;

	public TMP_Text catDesireHP;
	public TMP_Text catDesireSpeed;
	public TMP_Text catDesireJump;

	public Button upgradeCatDesireHP;
	public Button upgradeCatDesireSpeed;
	public Button upgradeCatDesireJump;


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
    }


	void Start()
	{
		
	}

	void Update()
	{
		UpdateCharacterUI();
	}
	// 데이터 초기화 메서드
	public void InitializeData(Dictionary<Button, bool> data)
    {
        desireStates = new Dictionary<Button, bool>(data);
    }

	public void UpdateCharacterUI()
	{
		maxHealthText.text = "HP : " + maxHealth;
		speedText.text = "Speed : " + speed;
		jumpText.text = "Jump : " + jumpForce;
	}
}