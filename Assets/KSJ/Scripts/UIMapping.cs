using System;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class UIMapping : MonoBehaviour
{
	// DataManager의 인스턴스를 캐싱
	private DataManager dataManager;

	[Header("# UI Mapping")]
	// 인게임 재화
	public TMP_Text sushiText;
	public TMP_Text silverKeyText;
	public TMP_Text cannedFoodText;
	// 스탯창에 표시되는 텍스트
	public TMP_Text maxHealthText;
	public TMP_Text speedText;
	public TMP_Text jumpForceText;
	public TMP_Text glideTimeText;
	public TMP_Text jumpCountText;

	// 염원 Lv, 이름, 성능과 잔여개수
	public TMP_Text redMarble;
	public TMP_Text brokenRedText;

	public TMP_Text blueMarble;
	public TMP_Text brokenBlueText;

	public TMP_Text greenMarble;
	public TMP_Text brokenGreenText;

	// 각각의 강화버튼과 텍스트
	public Button upgradeRedGlide;
	public TMP_Text needRedSushi;
	
	public Button upgradeBlueHP;
	public TMP_Text needBlueSushi;

	public Button upgradeGreenCount;
	public TMP_Text needGreenSushi;

	// 슬라이더
	

	public Slider brokenRedSlider;
	public Slider brokenBlueSlider;
	public Slider brokenGreenSlider;

	// 일일 상점 초기화 시간 텍스트
	public TMP_Text dayTimeText;

	// 일일 상점 리셋 횟수
	public TMP_Text IngameResetText;
	public TMP_Text AdvResetText;

	void Start()
	{
		// DataManager 인스턴스 캐싱
		dataManager = DataManager.Instance;
		//InitializeUI();
	}

	void Update()
	{
		// 최대치 관리
		if (dataManager.sushi > 999999998)
			dataManager.sushi = 999999999;
		if (dataManager.silverKey > dataManager.maxSilverKey)
			dataManager.silverKey = dataManager.maxSilverKey;
		UpdateCatsDesire();
		UpdateCharacterUI();
		UpdateLobbyUI();
		UpdateUpgrade();
		UpdateSliderValue();
		UpdateDayTime();
		UpdateResetText();
	}

	public void UpdateCharacterUI()
	{
		// 스탯창
		maxHealthText.text = "체력 : " + (dataManager.maxHealth + dataManager.redMarbleValue[dataManager.redMarbleLv]);
		glideTimeText.text = "활공 시간 : " + (dataManager.glideTime + dataManager.greenMarbleValue[dataManager.greenMarbleLv]);
		speedText.text = "속도 : " + dataManager.speed;
		jumpForceText.text = "점프력 : " + dataManager.jumpForce;
		jumpCountText.text = "점프 횟수 : " + dataManager.maxJumpCount;

		// 염원 잔여/필요
		brokenBlueText.text = "" + dataManager.brokenBlue + "/" + dataManager.nextExp[dataManager.blueMarbleLv];
		brokenRedText.text = "" + dataManager.brokenRed + "/" + dataManager.nextExp[dataManager.redMarbleLv];
		brokenGreenText.text = "" + dataManager.brokenGreen + "/" + dataManager.nextExp[dataManager.greenMarbleLv];

		// 생선 잔여/필요
		if (dataManager.redMarbleLv == 10)
			needRedSushi.text = "강화 완료";
		else
			needRedSushi.text = "강화    " + dataManager.nextSushi[dataManager.redMarbleLv];

		if (dataManager.blueMarbleLv == 10)
			needBlueSushi.text = "강화 완료";
		else
			needBlueSushi.text = "강화    " + dataManager.nextSushi[dataManager.blueMarbleLv];

		if(dataManager.greenMarbleLv == 10)
			needGreenSushi.text = "강화 완료";
		else
			needGreenSushi.text = "강화    " + dataManager.nextSushi[dataManager.greenMarbleLv];
	}

	public void UpdateCatsDesire()
	{
		redMarble.text = "Lv." + dataManager.redMarbleLv + " 최대 체력 " + dataManager.redMarbleValue[dataManager.redMarbleLv]+" 증가";
		blueMarble.text = "Lv." + dataManager.blueMarbleLv + " 모든 피해 " + dataManager.blueMarbleValue[dataManager.blueMarbleLv]+" 감소";
		greenMarble.text = "Lv. " + dataManager.greenMarbleLv + " 활공  " + dataManager.greenMarbleValue[dataManager.greenMarbleLv]+"초 증가";
	}

	public void UpdateUpgrade()
	{
		if (dataManager.brokenBlue < dataManager.nextExp[dataManager.blueMarbleLv] || dataManager.sushi < dataManager.nextSushi[dataManager.blueMarbleLv] || dataManager.blueMarbleLv == 11)
		{
			upgradeBlueHP.GetComponent<Image>().color = Color.gray;
			upgradeBlueHP.interactable = false; // 버튼 비활성화
		}
		else
		{
			upgradeBlueHP.GetComponent<Image>().color = Color.white;
			upgradeBlueHP.interactable = true; // 버튼 활성화
		}

		if (dataManager.brokenRed < dataManager.nextExp[dataManager.redMarbleLv] || dataManager.sushi < dataManager.nextSushi[dataManager.redMarbleLv] || dataManager.redMarbleLv == 11)
		{
			upgradeRedGlide.GetComponent<Image>().color = Color.gray;
			upgradeRedGlide.interactable = false; // 버튼 비활성화
		}
		else
		{
			upgradeRedGlide.GetComponent<Image>().color = Color.white;
			upgradeRedGlide.interactable = true; // 버튼 활성화
		}

		if (dataManager.brokenGreen < dataManager.nextExp[dataManager.greenMarbleLv] || dataManager.sushi < dataManager.nextSushi[dataManager.greenMarbleLv] || dataManager.greenMarbleLv == 11)
		{
			upgradeGreenCount.GetComponent<Image>().color = Color.gray;
			upgradeGreenCount.interactable = false; // 버튼 비활성화
		}
		else
		{
			upgradeGreenCount.GetComponent<Image>().color = Color.white;
			upgradeGreenCount.interactable = true; // 버튼 활성화
		}
	}

	public void UpgradeButton(int color)
	{
		if (color == 1) // 적
		{
			if (dataManager.brokenRed >= dataManager.nextExp[dataManager.redMarbleLv] && dataManager.sushi >= dataManager.nextSushi[dataManager.redMarbleLv] && dataManager.redMarbleLv < 10)
			{
				dataManager.brokenRed -= dataManager.nextExp[dataManager.redMarbleLv];
				dataManager.sushi -= dataManager.nextSushi[dataManager.redMarbleLv];
				dataManager.redMarbleLv++;
			}
		}
		if (color == 2) // 청
		{
			if (dataManager.brokenBlue >= dataManager.nextExp[dataManager.blueMarbleLv] && dataManager.sushi >= dataManager.nextSushi[dataManager.blueMarbleLv] && dataManager.blueMarbleLv < 10)
			{
				dataManager.brokenBlue -= dataManager.nextExp[dataManager.blueMarbleLv];
				dataManager.sushi -= dataManager.nextSushi[dataManager.blueMarbleLv];
				dataManager.blueMarbleLv++;
			}
		}
		if (color == 3) // 녹
		{
			if (dataManager.brokenGreen >= dataManager.nextExp[dataManager.greenMarbleLv] && dataManager.sushi >= dataManager.nextSushi[dataManager.greenMarbleLv] && dataManager.greenMarbleLv < 10)
			{
				dataManager.brokenGreen -= dataManager.nextExp[dataManager.greenMarbleLv];
				dataManager.sushi -= dataManager.nextSushi[dataManager.greenMarbleLv];
				dataManager.greenMarbleLv++;
			}
		}
		DataManager.Instance.SaveDataToJson();
	}

	public void UpdateSliderValue()
	{
		

		brokenBlueSlider.value = (float)dataManager.brokenBlue / dataManager.nextExp[dataManager.blueMarbleLv];
		brokenRedSlider.value = (float)dataManager.brokenRed / dataManager.nextExp[dataManager.redMarbleLv];
		brokenGreenSlider.value = (float)dataManager.brokenGreen / dataManager.nextExp[dataManager.greenMarbleLv];
	}

	public void UpdateLobbyUI()
	{
		sushiText.text = "" + dataManager.sushi;
		silverKeyText.text = "" + dataManager.silverKey + "/30";

		cannedFoodText.text = "" + dataManager.cannedFood;
	}

	public void UpdateDayTime()
	{
		// 현재 유닉스 시간
		long currentUnixTime = DateTimeOffset.UtcNow.ToUnixTimeSeconds();

		// 오늘 자정의 유닉스 시간 계산
		DateTimeOffset now = DateTimeOffset.UtcNow;
		DateTimeOffset endOfDay = new DateTimeOffset(now.Year, now.Month, now.Day, 23, 59, 59, TimeSpan.Zero);
		long endOfDayUnixTime = endOfDay.ToUnixTimeSeconds();

		// 남은 시간 계산
		long secondsRemaining = endOfDayUnixTime - (currentUnixTime + 32400); // UTC에서 9시간(32400초)을 더하면 한국 시간
		if (secondsRemaining == 0)
		{// 하루가 바뀔 때 리셋되는 것들
			ShopList.Instance.PickRandomItems();
			ShopList.Instance.DisplayRandomItems();
			dataManager.resetNum = 0;
			dataManager.advResetNum = 0;
		}

		// 남은 시간을 시간, 분, 초로 변환
		TimeSpan timeRemaining = TimeSpan.FromSeconds(secondsRemaining);
		// 남은 시간을 텍스트로 표시
		dayTimeText.text = string.Format("초기화 시간 : {0:D2}:{1:D2}:{2:D2}", timeRemaining.Hours, timeRemaining.Minutes, timeRemaining.Seconds);
	}

	public void UpdateResetText()
	{
		IngameResetText.text = "10\n" + dataManager.resetNum +"/"+ dataManager.resetMaxNum;
		AdvResetText.text = "광고 보기\n" + dataManager.advResetNum + "/" + dataManager.advResetMaxNum;
	}
}