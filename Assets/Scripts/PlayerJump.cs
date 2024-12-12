using System.Collections;
using UnityEngine;

public class PlayerJump : MonoBehaviour
{
	public float maxJumpHeight = 10f; // �ִ� ���� ����
	public float jumpDuration = 1f; // ���� ���� �ð�
	public float horizontalJumpForce = 3f; // �������� �̵��� ���� ��
	public float jumpForce; // ���� ��
	public bool isGrounded; // ���� �ִ��� ����
	private Rigidbody2D rb; // 2D ������ٵ�
	public bool isCharging; // ������ ���� ������ ����
	private SpriteRenderer spriteRenderer; // ��������Ʈ ������
	public Sprite Ready; //�������� ĳ���� ��������Ʈ
	public Sprite Jumping; //���� ĳ���� ��������Ʈ
	public Sprite Idling; //���� ĳ���� ��������Ʈ
	

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
		// ���� �Է� ó��
		if (Input.GetKeyDown(KeyCode.Space) && isGrounded)
		{
			isCharging = true; // ���� ���� ����
			SwitchSpriteToReady();
			StartCoroutine(ChargeJump());
		}

		// �����̽��ٸ� ���� ���� ����
		if (Input.GetKeyUp(KeyCode.Space) && isCharging)
		{
			isCharging = false; // ���� ����
			SwitchSpriteToJump();
			Jump();
		}
	}

	private IEnumerator ChargeJump()
	{
		float time = 0;
		jumpForce = 0; // ���� �� �ʱ�ȭ

		while (isCharging && time < jumpDuration)
		{
			time += Time.deltaTime;
			jumpForce = Mathf.Lerp(0, maxJumpHeight, time / jumpDuration); // ���� �� ����
			yield return null; // ���� �����ӱ��� ���
		}

		// �ִ� ���� ���� �����ϴ��� ���� ���¿��� �����̽��ٸ� ���� ����
		if (!isCharging)
		{
			Jump();
		}
	}

	private void Jump()
	{
		rb.velocity = new Vector2(horizontalJumpForce, jumpForce); // �������� ���� ���� ���� �� ����
		isGrounded = false; // ���� �� ���� ���� �� �ֵ��� ����
	}

	private void OnCollisionEnter2D(Collision2D collision)
	{
		// ���� �������� ��
		if (collision.gameObject.CompareTag("Ground"))
		{
			SwitchSpriteToIdle();
			isGrounded = true; // ���� ����
			spriteRenderer.flipX = false;
		}
	}

	private void OnCollisionExit2D(Collision2D collision)
	{
		// ������ �������� ��
		if (collision.gameObject.CompareTag("Ground"))
		{
			isGrounded = false; // ���� ����
		}
	}
}

