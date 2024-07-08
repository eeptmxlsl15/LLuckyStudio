using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using TMPro;
public class Player : MonoBehaviour
{
    
    
    private Rigidbody2D rb;
    private Animator anim;
    //나중에 플레이어 상태에 따라 적용되는 스킬들이 있을 수 있기 때문에 public으로 설정
    public GameObject jumpButton;
    public GameObject slideButton;

    [Header("# Player Stat")]
    public float health;
    public float maxHealth=100f;
    public float speed = 10f;
    public float jumpForce = 10f;
    public int jumpCount = 0;
    public int maxJumpCount = 2; // 2단 점프를 위해 최대 점프 횟수를 2로 설정
    public int floorRes = 0; // 발판형 장애물 저항
    public int flyRes = 0; // 날아오는 장애물 저항
    public float healthRegen=0;
	public float wingTime = 0;

	private bool ratDesire;
    private float healthRegenTimer = 0f;
    private const float healthRegenInterval = 5f;

    [Header("# Player State")]
    public bool isGrounded = false;
    public bool isSlide;

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

    //Data Manager에서 받아온 염원 활성화 데이터를 저장하는 리스트
    public List<bool> activeDesires= new List<bool>();

    void Start()
    {
        
        rb = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
        //점프 트리거
        EventTrigger jumpTrigger = jumpButton.GetComponent<EventTrigger>();
        AddEventTrigger(jumpTrigger, EventTriggerType.PointerDown, Jump);
        //슬라이드 트리거
        EventTrigger slideTrigger = slideButton.GetComponent<EventTrigger>();
        AddEventTrigger(slideTrigger, EventTriggerType.PointerDown, () => Slide(true));
        AddEventTrigger(slideTrigger, EventTriggerType.PointerUp, () => Slide(false));


		//DataManager에서 스탯들을 가져옴
		SetStat();
        //리스트를 12개로 지정
        activeDesires = new List<bool>(new bool[12]);
        
        //DataManager에 딕셔너리를 순회하면서 bool값 순서를 리스트에 저장
        int i = 0;
        foreach (KeyValuePair<Button,bool> desire in DataManager.Instance.desireStates)
        {
            activeDesires[i] = desire.Value;
            if(activeDesires[i])
                ActiveDesire(i);
            i++;

        }

		
        //염원 적용 후 최대 체력에 맞게 조정
        health = maxHealth;
    }

    void Update()
    {
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
    }

    public void Jump()
    {
        
        
        if (jumpCount < maxJumpCount)
        {
            // -1은 현재 애니메이터 레이어 , 0f는 애니메이션 시작 부분(0~1)
            Debug.Log("점프");
            anim.Play("Jump", -1, 0f);
            rb.velocity = new Vector2(rb.velocity.x, jumpForce);
            jumpCount++;
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
	public void SetStat()
	{
		health=DataManager.Instance.health;
		maxHealth = DataManager.Instance.maxHealth;
		speed = DataManager.Instance.speed;
		jumpForce = DataManager.Instance.jumpForce;
		jumpCount = DataManager.Instance.jumpCount;
		
		//점프 카운트가 2개씩 올라가는 버그가 수정될때까지 2 곱하기
		maxJumpCount = 2*DataManager.Instance.maxJumpCount; // 2단 점프를 위해 최대 점프 횟수를 2로 설정
		floorRes = DataManager.Instance.floorRes; // 발판형 장애물 저항
		flyRes = DataManager.Instance.flyRes; // 날아오는 장애물 저항
		healthRegen = DataManager.Instance.healthRegen;
		wingTime = DataManager.Instance.wingTime;

		ratDesire=DataManager.Instance.ratDesire;
		healthRegenTimer = DataManager.Instance.healthRegenTimer;
		
}
	public void ActiveDesire(int animal)
    {
        switch (animal)
        {
            case Constants.Pig:
                maxHealth += 5;
                health = maxHealth;
                break;
            case Constants.Dog:
                speed += 5f;
                break;
            case Constants.Rooster:
                floorRes += 1;
                break;
            case Constants.Monkey:
                jumpForce += 2f;
                break;
            case Constants.Lamb:
                //반딧불의 체력 회복량 증가
                break;
            case Constants.Horse:
                //부스터 아이템 지속 시간 증가
                break;
            case Constants.Snake:
                flyRes += 1;
                break;
            case Constants.Dragon:
                //무적 아이템 지속 시간 증가
                break;
            case Constants.Rabbit:
                //츄르의 체력 회복량 증가
                break;
            case Constants.Tiger:
                //쉴드 효과 증가
                break;
            case Constants.Ox:
                //제한 시간 감소
                break;
            case Constants.Rat:
                ratDesire = true;
                healthRegen += 1f;
                break;
            case Constants.Cat:
                
                break;
            default:
                break;

        }
    }


}
