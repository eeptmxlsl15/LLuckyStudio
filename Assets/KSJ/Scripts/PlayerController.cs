using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class PlayerController : MonoBehaviour
{
    public float jumpForce = 10f;
    private Rigidbody2D rb;
    private Animator anim;
    //나중에 플레이어 상태에 따라 적용되는 스킬들이 있을 수 있기 때문에 public으로 설정
    public bool isGrounded = false;
    public bool isSlide;
    public int jumpCount = 0;
    public int maxJumpCount = 2; // 2단 점프를 위해 최대 점프 횟수를 2로 설정
    
    public GameObject jumpButton;
    public GameObject slideButton;
    void Start()
    {

        rb = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
        
        EventTrigger jumpTrigger = jumpButton.GetComponent<EventTrigger>();
        AddEventTrigger(jumpTrigger, EventTriggerType.PointerDown, Jump);

        EventTrigger slideTrigger = slideButton.GetComponent<EventTrigger>();
        AddEventTrigger(slideTrigger, EventTriggerType.PointerDown, () => Slide(true));
        AddEventTrigger(slideTrigger, EventTriggerType.PointerUp, () => Slide(false));
    }

    void Update()
    {
        // 모바일 터치 입력 처리
        
        
        
        
        
        if (Input.GetKeyDown(KeyCode.LeftShift))
        {
            Slide(true);
        }

        if (Input.GetKeyUp(KeyCode.LeftShift))
        {
            Slide(false);
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
}
