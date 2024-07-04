using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class Player : MonoBehaviour
{
    
    
    private Rigidbody2D rb;
    private Animator anim;
    //나중에 플레이어 상태에 따라 적용되는 스킬들이 있을 수 있기 때문에 public으로 설정
    public GameObject jumpButton;
    public GameObject slideButton;

    [Header("# Player Stat")]
    public int health;
    public int maxHealth=100;
    public float speed = 10f;
    public float jumpForce = 10f;
    public int jumpCount = 0;
    public int maxJumpCount = 2; // 2단 점프를 위해 최대 점프 횟수를 2로 설정

    [Header("# Player State")]
    public bool isGrounded = false;
    public bool isSlide;

    static class Constants
    {
        public const int Pig = 0;
        public const int Dog = 1;
        public const int Rooster = 2;
        public const int Monket = 3;
        public const int Lamb = 4;
        public const int Horse = 5;
        public const int Snake = 6;
        public const int Dragon = 7;
        public const int Rabbit = 8;
        public const int Tiger = 9;
        public const int Ox = 10;
        public const int Rat = 11;
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
        if (isSlide)
        {
            rb.AddForce(Vector2.down, (ForceMode2D)ForceMode.Acceleration);
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

   public void ActiveDesire(int animal)
    {
        switch (animal)
        {
            case Constants.Pig:
                maxHealth += 5;
                break;
            case Constants.Dog:
                speed += 5f;
                break;
            default:
                break;

        }
    }
}
