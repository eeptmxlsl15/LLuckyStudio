using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using TMPro;

public class Player : MonoBehaviour
{
	private Rigidbody2D rb;
	private Animator anim;

	public GameObject glideCooltimeUI;
	public TMP_Text glideCooltimeText;
	public GameObject jumpButton;
	public GameObject slideButton;
	public GameObject glideButton;
	private Color originalGlideButtonColor;
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
	public float glideTime = 0;

	private bool ratDesire;
	private float healthRegenTimer = 0f;
	private const float healthRegenInterval = 10f;//10초당 healthRegan 만큼 회복

	[Header("# Player State")]
	public bool isGrounded = false;
	public bool isSlide;
	public bool isJumpButtonHeld = false;
	public bool isGlide = false;

	//활주 관련 
	public float glideButtonHoldTimer = 0f;
	
	public bool canGlide = true;
	public float glideCooldown = 10f;
	public float glideCooldownTimer = 0f;
	static class Constants
	{
		public const int Pig = 0;
		public const int Dog = 1;
		public const int Rooster = 2;
		public const int Monkey = 3;
		public const int Lamb = 4;
		public const int Horse = 5;
		public const int Snake = 6;
		public const int Dragon = 7;
		public const int Rabbit = 8;
		public const int Tiger = 9;
		public const int Ox = 10;
		public const int Rat = 11;
		public const int Cat = 12;
	}

	// Data Manager에서 받아온 염원 활성화 데이터를 저장하는 리스트
	public List<bool> activeDesires = new List<bool>();

	void Start()
	{
		rb = GetComponent<Rigidbody2D>();
		anim = GetComponent<Animator>();
		originalGlideButtonColor = glideButton.GetComponent<Image>().color;
		// 점프 트리거
		EventTrigger jumpTrigger = jumpButton.GetComponent<EventTrigger>();
		AddEventTrigger(jumpTrigger, EventTriggerType.PointerDown, OnJumpButtonDown);
		

		// 슬라이드 트리거
		EventTrigger slideTrigger = slideButton.GetComponent<EventTrigger>();
		AddEventTrigger(slideTrigger, EventTriggerType.PointerDown, () => Slide(true));
		AddEventTrigger(slideTrigger, EventTriggerType.PointerUp, () => Slide(false));
		
		// 활주 트리거
		EventTrigger glideTrigger = glideButton.GetComponent<EventTrigger>();
		AddEventTrigger(glideTrigger, EventTriggerType.PointerDown, () => Glide(true));
		AddEventTrigger(glideTrigger, EventTriggerType.PointerUp, () => Glide(false)) ;
		
		// DataManager에서 스탯들을 가져옴
		SetStat();

		// 리스트를 12개로 지정
		activeDesires = new List<bool>(new bool[12]);

		// DataManager에 딕셔너리를 순회하면서 bool값 순서를 리스트에 저장
		int i = 0;
		foreach (KeyValuePair<Button, bool> desire in DataManager.Instance.desireStates)
		{
			activeDesires[i] = desire.Value;
			if (activeDesires[i])
				ActiveDesire(i);
			i++;
		}

		// 염원 적용 후 최대 체력에 맞게 조정
		health = maxHealth;
	}

	void Update()
	{
		//활공 중 이속 빨라짐
		if(isGlide)
			transform.position += new Vector3(speed*1.2f * Time.deltaTime, 0, 0);
		else
			transform.position += new Vector3(speed * Time.deltaTime, 0, 0);

		if (isSlide)
		{
			rb.AddForce(Vector2.down, (ForceMode2D)ForceMode.Acceleration);
		}



		if (ratDesire)
		{
			healthRegenTimer += Time.deltaTime;
			if (healthRegenTimer >= healthRegenInterval)
			{
				// 체력 회복
				health = Mathf.Min(health + healthRegen, maxHealth);
				healthRegenTimer = 0f;
				Debug.Log("체력 회복: " + health);
			}
		}
		//활주 쿨타임이 아닐때
		if (isGlide && canGlide && !isGrounded) {
			rb.velocity = new Vector2(rb.velocity.x, 0.5f);
			
			glideButtonHoldTimer += Time.deltaTime;
			

			if (glideButtonHoldTimer > glideTime)
			{

				Glide(false);
				canGlide = false;
				glideButtonHoldTimer = 0f;
			}
		}
		//활주 쿨타임일때
		if (!canGlide)
		{
			glideCooltimeUI.SetActive(true);

			glideCooldownTimer += Time.deltaTime;
			glideCooltimeText.text = ""+ (glideCooldown - glideCooldownTimer).ToString("F1")+" sec";

			Color glideButtonColor = Color.black;
			glideButtonColor.a = 101/255f;
			
			glideButton.GetComponent<Image>().color = glideButtonColor;

			if (glideCooldownTimer >= glideCooldown)
			{
				glideCooltimeUI.SetActive(false);
				canGlide = true;
				glideCooldownTimer = 0f;
				glideButton.GetComponent<Image>().color = originalGlideButtonColor;
			}
			
		}

		
	}

	public void OnJumpButtonDown()
	{
		Jump();
		isJumpButtonHeld = true;
		
	}

	

	public void Jump()
	{
		if (jumpCount < maxJumpCount)
		{
			// -1은 현재 애니메이터 레이어, 0f는 애니메이션 시작 부분(0~1)
			Debug.Log("점프");
			anim.Play("Jump", -1, 0f);
			rb.velocity = new Vector2(rb.velocity.x, jumpForce);
			jumpCount++;
		}
	}

	public void Glide(bool _isGlide)
	{
		
		isGlide = _isGlide;
		if (!_isGlide)
		{
			canGlide = false;
			glideButtonHoldTimer = 0f;
		}

	}

	void OnCollisionEnter2D(Collision2D collision)
	{
		if (collision.collider.CompareTag("Ground"))
		{
			isGrounded = true;
			anim.SetBool("isGround", true);
			jumpCount = 0;
		}
	}

	void OnCollisionExit2D(Collision2D collision)
	{
		if (collision.collider.CompareTag("Ground"))
		{
			anim.SetBool("isGround", false);
			isGrounded = false;
		}
	}

	public void Slide(bool _isSlide)
	{
		isSlide = _isSlide;
		anim.SetBool("isSlide", _isSlide);
	}

	private void AddEventTrigger(EventTrigger trigger, EventTriggerType eventType, UnityEngine.Events.UnityAction action)
	{
		EventTrigger.Entry entry = new EventTrigger.Entry { eventID = eventType };
		entry.callback.AddListener((eventData) => action());
		trigger.triggers.Add(entry);
	}

	//시작시 DataManager의 스탯을 가져옴
	public void SetStat()
	{
		health = DataManager.Instance.health;
		maxHealth = DataManager.Instance.maxHealth+DataManager.Instance.redMarbleValue[DataManager.Instance.redMarbleLv];
		speed = DataManager.Instance.speed;
		jumpForce = DataManager.Instance.jumpForce;
		jumpCount = DataManager.Instance.jumpCount;


		maxJumpCount = DataManager.Instance.maxJumpCount; // 2단 점프를 위해 최대 점프 횟수를 2로 설정
		floorRes = DataManager.Instance.floorRes; // 발판형 장애물 저항
		flyRes = DataManager.Instance.flyRes; // 날아오는 장애물 저항
		healthRegen = DataManager.Instance.healthRegen;
		glideTime = DataManager.Instance.glideTime+DataManager.Instance.greenMarbleValue[DataManager.Instance.greenMarbleLv];
		if (DataManager.Instance.greenMarbleLv == 10)
			glideCooldown = DataManager.Instance.glideCooldown - 30;
		else
			glideCooldown = DataManager.Instance.glideCooldown;
		allRes = DataManager.Instance.allRes+DataManager.Instance.blueMarbleValue[DataManager.Instance.blueMarbleLv];
		ratDesire = DataManager.Instance.ratDesire;
		healthRegenTimer = DataManager.Instance.healthRegenTimer;
	}

	public void ActiveDesire(int animal)
	{
		switch (animal)
		{
			case Constants.Pig:// 최대 체력 20 증가
				maxHealth += 20;
				health = maxHealth;
				break;
			case Constants.Dog:// 이동 속도 20 증가
				speed += 20f;
				break;
			case Constants.Rooster:// 고정형 장애물 피해 감소
				floorRes += 5;
				break;
			case Constants.Monkey:// 젤리코인 점수 5점 증가
				
				break;
			case Constants.Lamb:// 반딧불의 체력 회복량 5 증가

				break;
			case Constants.Horse:// 부스터 아이템 지속 시간 1.5초 증가
								
				break;
			case Constants.Snake:// 날아오는 장애물 오브젝트 피해 수치 5 감소
				flyRes += 5;
				break;
			case Constants.Dragon:// 무적 아이템 지속 시간 증가

				break;
			case Constants.Rabbit:// 츄르의 체력 회복량 5 증가

				break;
			case Constants.Tiger://  쉴드 효과 횟수 1회 증가

				break;
			case Constants.Ox:// 활공 시간 증가
				glideTime += 1f;
				break;
			case Constants.Rat://10초당 체력 재생
				ratDesire = true;
				healthRegen += 1f;
				break;
			default:
				break;
		}
	}
}