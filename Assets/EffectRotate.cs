using UnityEngine;

public class EffectRotate : MonoBehaviour
{
	public float rotationSpeed = 100f; // ȸ�� �ӵ�

	void Update()
	{
		// ȸ�� ������ ����ϰ� ����
		transform.Rotate(Vector3.forward, rotationSpeed * Time.deltaTime);
	}
}