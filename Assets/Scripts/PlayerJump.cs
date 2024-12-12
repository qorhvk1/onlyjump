using System.Collections;
using UnityEngine;

public class PlayerJump : MonoBehaviour
{
	public float maxJumpHeight = 10f; // 최대 점프 높이
	public float jumpDuration = 1f; // 점프 지속 시간
	public float horizontalJumpForce = 3f; // 우측으로 이동할 때의 힘
	public float jumpForce; // 점프 힘
	public bool isGrounded; // 땅에 있는지 여부
	private Rigidbody2D rb; // 2D 리지드바디
	public bool isCharging; // 점프를 충전 중인지 여부
	private SpriteRenderer spriteRenderer; // 스프라이트 렌더러
	public Sprite Ready; //점프장전 캐릭터 스프라이트
	public Sprite Jumping; //점프 캐릭터 스프라이트
	public Sprite Idling; //평상시 캐릭터 스프라이트
	

	void Start()
	{
		rb = GetComponent<Rigidbody2D>();
		spriteRenderer = GetComponent<SpriteRenderer>();
	}

	private void SwitchSpriteToReady()
	{
		spriteRenderer.sprite = Ready;
	}
	private void SwitchSpriteToJump()
	{
		spriteRenderer.sprite = Jumping;
	}
	private void SwitchSpriteToIdle()
	{
		spriteRenderer.sprite = Idling;
	}

	void Update()
	{
		// 점프 입력 처리
		if (Input.GetKeyDown(KeyCode.Space) && isGrounded)
		{
			isCharging = true; // 점프 충전 시작
			SwitchSpriteToReady();
			StartCoroutine(ChargeJump());
		}

		// 스페이스바를 떼면 점프 수행
		if (Input.GetKeyUp(KeyCode.Space) && isCharging)
		{
			isCharging = false; // 충전 종료
			SwitchSpriteToJump();
			Jump();
		}
	}

	private IEnumerator ChargeJump()
	{
		float time = 0;
		jumpForce = 0; // 점프 힘 초기화

		while (isCharging && time < jumpDuration)
		{
			time += Time.deltaTime;
			jumpForce = Mathf.Lerp(0, maxJumpHeight, time / jumpDuration); // 점프 힘 조절
			yield return null; // 다음 프레임까지 대기
		}

		// 최대 점프 힘에 도달하더라도 충전 상태에서 스페이스바를 떼면 점프
		if (!isCharging)
		{
			Jump();
		}
	}

	private void Jump()
	{
		rb.velocity = new Vector2(horizontalJumpForce, jumpForce); // 우측으로 힘과 위쪽 점프 힘 적용
		isGrounded = false; // 점프 후 땅에 있을 수 있도록 설정
	}

	private void OnCollisionEnter2D(Collision2D collision)
	{
		// 땅에 착지했을 때
		if (collision.gameObject.CompareTag("Ground"))
		{
			SwitchSpriteToIdle();
			isGrounded = true; // 땅에 있음
			spriteRenderer.flipX = false;
		}
	}

	private void OnCollisionExit2D(Collision2D collision)
	{
		// 땅에서 떨어졌을 때
		if (collision.gameObject.CompareTag("Ground"))
		{
			isGrounded = false; // 땅에 없음
		}
	}
}

