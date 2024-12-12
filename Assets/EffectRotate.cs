using UnityEngine;

public class EffectRotate : MonoBehaviour
{
	public float rotationSpeed = 100f; // 회전 속도

	void Update()
	{
		// 회전 각도를 계산하고 적용
		transform.Rotate(Vector3.forward, rotationSpeed * Time.deltaTime);
	}
}