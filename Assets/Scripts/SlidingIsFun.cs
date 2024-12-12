using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class SlidingIsFun : MonoBehaviour
{
	public float slideSpeed = 5f; // �̲������� �ӵ�
	private Rigidbody2D rb; // 2D ������ٵ�
	public bool isSliding; // �̲������� �ִ��� ����
	private SpriteRenderer spriteRenderer; // ��������Ʈ ������
	public Sprite slindingSprite;

	void Start()
	{
		rb = GetComponent<Rigidbody2D>();
		spriteRenderer = GetComponent<SpriteRenderer>();
	}

	void Update()
	{
		// �������� �̲������� ���� üũ
		if (isSliding)
		{
			Slide();
		}
	}

	private void Slide()
	{
		rb.velocity = new Vector2(-slideSpeed, rb.velocity.y); // �������� �̲�����
	}

	private void OnCollisionEnter2D(Collision2D collision)
	{
		// Slope �±׿� �浹���� ��
		if (collision.gameObject.CompareTag("Slope"))
		{
			Debug.Log("Slide!");
			isSliding = true; // �̲������� ����
			spriteRenderer.flipX = true; // ��������Ʈ ������
			spriteRenderer.sprite = slindingSprite;
			//rb.constraints = RigidbodyConstraints2D.None;
		}
	}

	private void OnCollisionExit2D(Collision2D collision)
	{
		// Slope���� �������� ��
		if (collision.gameObject.CompareTag("Slope"))
		{
			Debug.Log("SlideEnd");
			isSliding = false; // �̲������� ����
			//rb.constraints = RigidbodyConstraints2D.FreezeRotation;
		}
	}
}
