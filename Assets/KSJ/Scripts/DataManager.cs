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
	private const float healthRegenInterval = 5f;


	[Header("# Player Items")]
	public int cannedFood;
	public int brokenBlue;//체력
	public int brokenRed;//활주시간
	public int brokenGreen;//점프횟수
	public int fish;//인게임 재화
	public int goldMarble;
	public int silverMarble;
	public int resurrection;

	

	public int[] nextExp = { 10, 20	, 30, 40, 50, 60, 70, 80};
	[Header("# Player Level")]
	
	public int blueMarbleLv;//체력
	//public int[] blueMarbleValue = { 5, 5, 5, 5, 5, 10, 10, 10, 10,15 };
	public int[] blueMarbleValue = { 5, 10, 15, 20, 25, 35, 45, 55, 65, 80 };
	
	public int redMarbleLv;//활주시간
	//public float[] redMarbleValue = { 0, 0, 1f, 0.5f, 0.5f, 1f, 0.5f, 0.5f, 0.5f,1.5f };
	public float[] redMarbleValue = { 0, 0, 1f, 1.5f, 2f, 3f, 3.5f, 4f, 4.5f, 6f };
	
	public int greenMarbleLv;//점프횟수
	//public int[] greenMarbleValue = { 0, 0, 0, 1,0,1,0,1,0,1 };
	public int[] greenMarbleValue = { 0, 0, 0, 1, 1, 2, 2, 3, 3, 4 };

	[Header("# UI Mapping")]
	//인게임 재화
	public TMP_Text fishText;
	public TMP_Text silverMarbleText;

	//스탯창에 표시되는 텍스트
	public TMP_Text maxHealthText;
	public TMP_Text speedText;
	public TMP_Text jumpForceText;
	public TMP_Text glideTimeText;
	public TMP_Text jumpCountText;

	//염원 Lv, 이름, 성능과 잔여개수
	public TMP_Text blueMarble;
	public TMP_Text brokenBlueText;

	public TMP_Text redMarble;
	public TMP_Text brokenRedText;

	public TMP_Text greenMarble;
	public TMP_Text brokenGreenText;

	//각각의 강화버튼과 텍스트
	public Button upgradeBlueHP;
	public TMP_Text needBlueCan;

	public Button upgradeRedGlide;
	public TMP_Text needRedCan;

	public Button upgradeGreenCount;
	public TMP_Text needGreenCan;

	//슬라이더
	public Slider fishFoodBlueSlider;
	public Slider fishFoodRedSlider;
	public Slider fishFoodGreenSlider;

	public Slider brokenBlueSlider;
	public Slider brokenRedSlider;
	public Slider brokenGreenSlider;


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


	void Start()
	{
		InitializeUI();
	}
	
	void Update()
	{
		//최대치 관리
		if (Input.GetKeyDown(KeyCode.Space))
		{
			Debug.Log("ad");
			InitializeUI();
		}
		if (fish > 999999998)
			fish = 999999999;
		if (silverMarble > 30)
			silverMarble = 30;
		UpdateCatsDesire();
		UpdateCharacterUI();
		UpdateLobbyUI();
		UpdateUpgrade();
		UpdateSliderValue();

	}
	// 데이터 초기화 메서드
	public void InitializeData(Dictionary<Button, bool> data)
    {
        desireStates = new Dictionary<Button, bool>(data);
    }

	public void UpdateCharacterUI()
	{
		
		maxHealthText.text = "HP : " +(maxHealth+ blueMarbleValue[blueMarbleLv]);
		speedText.text = "Speed : " +speed ;
		jumpForceText.text = "JumpForce : " + jumpForce ;
		jumpCountText.text = "JumpCount : "+ (maxJumpCount+ greenMarbleValue[greenMarbleLv]);
		glideTimeText.text = "Glide Time : " + redMarbleValue[redMarbleLv];
		
		//염원 잔여/필요
		brokenBlueText.text = "" + brokenBlue + "/" + nextExp[blueMarbleLv];
		brokenRedText.text = "" + brokenRed + "/" + nextExp[redMarbleLv];
		brokenGreenText.text = "" + brokenGreen + "/" + nextExp[greenMarbleLv];

		//통조림 잔여/필요
		needBlueCan.text = "" + fish + "/" + nextExp[blueMarbleLv];
		needRedCan.text = "" + fish + "/" + nextExp[redMarbleLv];
		needGreenCan.text = "" + fish + "/" + nextExp[greenMarbleLv];

	}

	public void UpdateCatsDesire()
	{
		blueMarble.text = "Lv." + blueMarbleLv + " Blue Marble + HP :" + blueMarbleValue[blueMarbleLv];
		redMarble.text = "Lv." + redMarbleLv + " Red Marble + Glide : " + redMarbleValue[redMarbleLv];
		greenMarble.text = "Lv. " + greenMarbleLv + " Green Marble + JumpCount : " + greenMarbleValue[greenMarbleLv];
	}

	public void UpdateUpgrade()//강화 가능 여부에 따라 버튼 활성화
	{
		if (brokenBlue < nextExp[blueMarbleLv] || fish < nextExp[blueMarbleLv])
			upgradeBlueHP.GetComponent<Image>().color = Color.gray;
		if (brokenRed < nextExp[redMarbleLv] || fish < nextExp[redMarbleLv])
			upgradeRedGlide.GetComponent<Image>().color = Color.gray;
		if (brokenGreen < nextExp[greenMarbleLv] || fish < nextExp[greenMarbleLv])
			upgradeGreenCount.GetComponent<Image>().color = Color.gray;
	}

	public void UpgradeButton(int color)//누르면 강화됨
	{
		
		if (color == 1)//청
		{
			if (brokenBlue >= nextExp[blueMarbleLv] && fish >= nextExp[blueMarbleLv])
			{
				brokenBlue -= nextExp[blueMarbleLv];
				fish -= nextExp[blueMarbleLv];
				blueMarbleLv++;
			}
		}

		if (color == 2)//적
		{
			if (brokenRed >= nextExp[redMarbleLv] && fish >= nextExp[redMarbleLv])
			{
				brokenRed -= nextExp[redMarbleLv];
				fish -= nextExp[redMarbleLv];
				redMarbleLv++;
			}
		}

		if (color == 3)//녹
		{
			if (brokenGreen >= nextExp[greenMarbleLv] && fish >= nextExp[greenMarbleLv])
			{
				brokenGreen -= nextExp[greenMarbleLv];
				fish -= nextExp[greenMarbleLv];
				greenMarbleLv++;
			}
		}

	}

	//무한 모드 또는 스토리 모드 버튼을 누를 경우 실행
	//변화된 데이터를 DataManager에 저장 - DataManager가 플레이어에게 넘김
	public void SetStat()
	{
		maxHealth += blueMarbleValue[blueMarbleLv];
		maxJumpCount +=greenMarbleValue[greenMarbleLv];
		glideTime += redMarbleValue[redMarbleLv];

		
	}

	public void UpdateSliderValue()
	{
		fishFoodBlueSlider.value = (float)fish / nextExp[blueMarbleLv];
		fishFoodRedSlider.value = (float)fish / nextExp[redMarbleLv];
		fishFoodGreenSlider.value = (float)fish / nextExp[greenMarbleLv];

		brokenBlueSlider.value = (float)brokenBlue / nextExp[blueMarbleLv];
		brokenRedSlider.value = (float)brokenRed / nextExp[redMarbleLv];
		brokenGreenSlider.value = (float)brokenGreen / nextExp[greenMarbleLv];
	}
	public void UpdateLobbyUI()
	{
		fishText.text = ""+fish;
		silverMarbleText.text = "" + silverMarble + "/30";
	}
	void InitializeUI()
	{
		// 여기서 모든 UI 요소를 다시 가져와서 맵핑
		fishText = GameObject.Find("/Canvas/Fish/Fish Text").GetComponent<TMP_Text>();
		silverMarbleText = GameObject.Find("/Canvas/Silver Marble/Silver Marble Text").GetComponent<TMP_Text>();

		maxHealthText = GameObject.Find("/Canvas/Character Info/Character Stat/Health").GetComponent<TMP_Text>();
		speedText = GameObject.Find("/Canvas/Character Info/Character Stat/Speed").GetComponent<TMP_Text>();
		jumpForceText = GameObject.Find("/Canvas/Character Info/Character Stat/Jump Force").GetComponent<TMP_Text>();
		glideTimeText = GameObject.Find("/Canvas/Character Info/Character Stat/Glide").GetComponent<TMP_Text>();
		jumpCountText = GameObject.Find("/Canvas/Character Info/Character Stat/Jump Count").GetComponent<TMP_Text>();

		blueMarble = GameObject.Find("/Canvas/Character Info/Cat's Desire/Cat's Stat Blue/Blue Lv. name").GetComponent<TMP_Text>();
		brokenBlueText = GameObject.Find("/Canvas/Character Info/Cat's Desire/Cat's Stat Blue/Blue Desire Next").GetComponent<TMP_Text>();

		redMarble = GameObject.Find("/Canvas/Character Info/Cat's Desire/Cat's Stat Red/Red Lv. name").GetComponent<TMP_Text>();
		brokenRedText = GameObject.Find("/Canvas/Character Info/Cat's Desire/Cat's Stat Red/Red Desire Next").GetComponent<TMP_Text>();

		greenMarble = GameObject.Find("/Canvas/Character Info/Cat's Desire/Cat's Stat Green/Green Lv. name").GetComponent<TMP_Text>();
		brokenGreenText = GameObject.Find("/Canvas/Character Info/Cat's Desire/Cat's Stat Green/Green Desire Next").GetComponent<TMP_Text>();

		upgradeBlueHP = GameObject.Find("/Canvas/Character Info/Cat's Desire/Cat's Stat Blue/Blue Upgrade Material/Blue Upgrade").GetComponent<Button>();
		needBlueCan = GameObject.Find("/Canvas/Character Info/Cat's Desire/Cat's Stat Blue/Blue Upgrade Material").GetComponent<TMP_Text>();

		upgradeRedGlide = GameObject.Find("/Canvas/Character Info/Cat's Desire/Cat's Stat Red/Red Upgrade Material/Red Upgrade").GetComponent<Button>();
		needRedCan = GameObject.Find("/Canvas/Character Info/Cat's Desire/Cat's Stat Red/Red Upgrade Material").GetComponent<TMP_Text>();

		upgradeGreenCount = GameObject.Find("/Canvas/Character Info/Cat's Desire/Cat's Stat Green/Green Upgrade Material/Green Upgrade").GetComponent<Button>();
		needGreenCan = GameObject.Find("/Canvas/Character Info/Cat's Desire/Cat's Stat Green/Green Upgrade Material").GetComponent<TMP_Text>();

		fishFoodBlueSlider = GameObject.Find("/Canvas/Character Info/Cat's Desire/Cat's Stat Blue/Blue Fish Slider").GetComponent<Slider>();
		fishFoodRedSlider = GameObject.Find("/Canvas/Character Info/Cat's Desire/Cat's Stat Red/Red Fish Slider").GetComponent<Slider>();
		fishFoodGreenSlider = GameObject.Find("/Canvas/Character Info/Cat's Desire/Cat's Stat Green/Green Fish Slider").GetComponent<Slider>();

		brokenBlueSlider = GameObject.Find("/Canvas/Character Info/Cat's Desire/Cat's Stat Blue/Blue Slider").GetComponent<Slider>();
		brokenRedSlider = GameObject.Find("/Canvas/Character Info/Cat's Desire/Cat's Stat Red/Red Slider").GetComponent<Slider>();
		brokenGreenSlider = GameObject.Find("/Canvas/Character Info/Cat's Desire/Cat's Stat Green/Green Slider").GetComponent<Slider>();

		upgradeBlueHP.onClick.RemoveAllListeners();
		upgradeBlueHP.onClick.AddListener(() => UpgradeButton(1));

		upgradeRedGlide.onClick.RemoveAllListeners();
		upgradeRedGlide.onClick.AddListener(() => UpgradeButton(2));

		upgradeGreenCount.onClick.RemoveAllListeners();
		upgradeGreenCount.onClick.AddListener(() => UpgradeButton(3));
	}
}