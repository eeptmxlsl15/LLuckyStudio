using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float jumpForce = 10f;
    private Rigidbody2D rb;
    private Animator anim;
    //나중에 플레이어 상태에 따라 적용되는 스킬들이 있을 수 있기 때문에 public으로 설정
    public bool isGrounded = false;
    public bool isSlide;
    private int jumpCount = 0;
    public int maxJumpCount = 2; // 2단 점프를 위해 최대 점프 횟수를 2로 설정

    void Start()
    {

        rb = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
    }

    void Update()
    {
        // 모바일 터치 입력 처리
        if (Input.touchCount > 0 && Input.GetTouch(0).phase == TouchPhase.Began)
        {
            Jump();
        }

        // 키보드 입력 처리 (디버깅용)
        if (Input.GetKeyDown(KeyCode.Space))
        {
            Jump();
        }

        if (Input.GetKeyDown(KeyCode.LeftShift))
        {
            Slide(true);
        }

        if (Input.GetKeyUp(KeyCode.LeftShift))
        {
            Slide(false);
        }
    }

    void Jump()
    {
        if (jumpCount < maxJumpCount)
        {
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

    void Slide(bool _isSlide)
    {
        isSlide = _isSlide;
        anim.SetBool("isSlide", _isSlide);
    }
}
