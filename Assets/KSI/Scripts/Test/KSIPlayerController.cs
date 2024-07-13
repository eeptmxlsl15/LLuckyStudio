using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class KSIPlayerController : MonoBehaviour, IDamagable
{
	// TEST
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

	[Header("KSI")]
	[SerializeField] private float moveSpeed;
	[SerializeField] private Vector3 moveDirection;
	public int health = 100;
	private BackgroundScroller scroller;	
	private bool isInvincible = false;
	private bool isShiled = false;

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
		transform.position += moveDirection * moveSpeed * Time.deltaTime;

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
			//anim.Play("Jump", -1, 0f);
			rb.velocity = new Vector2(rb.velocity.x, jumpForce);
			jumpCount++;
		}
	}

	void OnCollisionEnter2D(Collision2D collision)
	{
		if (collision.collider.CompareTag("Ground"))
		{
			isGrounded = true;
			//anim.SetBool("isGround", true);
			jumpCount = 0;
		}
	}

	void OnCollisionExit2D(Collision2D collision)
	{
		if (collision.collider.CompareTag("Ground"))
		{
			//anim.SetBool("isGround", false);
			isGrounded = false;
		}
	}

	public void Slide(bool _isSlide)
	{
		isSlide = _isSlide;
		//anim.SetBool("isSlide", _isSlide);
	}

	private void AddEventTrigger(EventTrigger trigger, EventTriggerType eventType, UnityEngine.Events.UnityAction action)
	{
		EventTrigger.Entry entry = new EventTrigger.Entry { eventID = eventType };
		entry.callback.AddListener((eventData) => action());
		trigger.triggers.Add(entry);
	}

	/* 강수인 추가 */
	public void TakeDamage(int damage)
	{
		health -= damage;
		Debug.Log("플레이어가 데미지를 입었습니다. 현재 체력: " + health);
		if (health <= 0)
		{
			Die();
		}
	}

	private void Die()
	{
		// TODO : 플레이어 사망 추가
		Debug.Log("플레이어가 죽었습니다.");
	}

	// 츄르 : 체력 10회복
	public void Heal(int value)
	{
		health += value;
	}

	// 무적 : 3초간 모든 피해 무적(낙사 제외)
	public void BecomeInvincible(float duration)
	{
		StartCoroutine(BecomeInvincibleRoutine(duration));
	}

	private IEnumerator BecomeInvincibleRoutine(float duration)
	{
		isInvincible = true;
		yield return new WaitForSeconds(duration);
		isInvincible = false;

		// TODO : 낙사 제외
	}

	// 부스터 : 3초간 모든 장애물을 파괴하면서 질주(이동 속도 수치가 20증가)
	public void Booster(float duration)
	{
		StartCoroutine(BoostRoutine(duration));
	}

	private IEnumerator BoostRoutine(float duration)
	{
		// TODO : 이동 속도 수치가 20증가
		yield return new WaitForSeconds(duration);
	}

	// 쉴드 : 장애물 1회 방어(낙사 제외)
	public void BlockObstacle()
	{
		isShiled = true;
	}

	private void OnTriggerEnter2D(Collider2D other)
	{
		if (other.gameObject.CompareTag("Obstacle"))
		{
			if (isShiled)
			{
				isShiled = false;
				// TODO :  장애물 방어
			}
			else if (!isInvincible)
			{
				// TODO : 플레이어가 무적인지 확인
			}
			else if (other.gameObject.CompareTag("FallZone"))
			{
				// TODO : 낙사 확인
				Die();
			}
		}
	}
}
