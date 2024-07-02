using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float jumpForce = 10f;
    private Rigidbody2D rb;
    private bool isGrounded = false;
    private int jumpCount = 0;
    public int maxJumpCount = 2; // 2단 점프를 위해 최대 점프 횟수를 2로 설정
    private Animator anim;

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

    void Slide(bool isSlide)
    {
        anim.SetBool("isSlide", isSlide);
    }
}
