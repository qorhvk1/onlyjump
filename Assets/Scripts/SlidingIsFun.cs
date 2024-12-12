using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class SlidingIsFun : MonoBehaviour
{
	public float slideSpeed = 5f; // 미끄러지는 속도
	private Rigidbody2D rb; // 2D 리지드바디
	public bool isSliding; // 미끄러지고 있는지 여부
	private SpriteRenderer spriteRenderer; // 스프라이트 렌더러
	public Sprite slindingSprite;

	void Start()
	{
		rb = GetComponent<Rigidbody2D>();
		spriteRenderer = GetComponent<SpriteRenderer>();
	}

	void Update()
	{
		// 좌측으로 미끄러지는 상태 체크
		if (isSliding)
		{
			Slide();
		}
	}

	private void Slide()
	{
		rb.velocity = new Vector2(-slideSpeed, rb.velocity.y); // 좌측으로 미끄러짐
	}

	private void OnCollisionEnter2D(Collision2D collision)
	{
		// Slope 태그와 충돌했을 때
		if (collision.gameObject.CompareTag("Slope"))
		{
			Debug.Log("Slide!");
			isSliding = true; // 미끄러지기 시작
			spriteRenderer.flipX = true; // 스프라이트 뒤집기
			spriteRenderer.sprite = slindingSprite;
			//rb.constraints = RigidbodyConstraints2D.None;
		}
	}

	private void OnCollisionExit2D(Collision2D collision)
	{
		// Slope에서 떨어졌을 때
		if (collision.gameObject.CompareTag("Slope"))
		{
			Debug.Log("SlideEnd");
			isSliding = false; // 미끄러지기 종료
			//rb.constraints = RigidbodyConstraints2D.FreezeRotation;
		}
	}
}
