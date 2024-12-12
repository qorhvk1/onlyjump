using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class PressRtoRestart : MonoBehaviour
{
	public GameObject objectToTeleport; // 순간이동할 오브젝트
	public Vector3 targetPosition; // 목표 위치

	private void Respawn()
	{
		if (objectToTeleport != null)
		{
			objectToTeleport.transform.position = targetPosition; // 오브젝트의 위치를 목표 위치로 설정
		}
		else
		{
			Debug.LogWarning("Teleport Object is not assigned!"); // 오브젝트가 할당되지 않았을 경우 경고 메시지 출력
		}
	}

	// Update is called once per frame
	void Update()
    {
		if (Input.GetKeyDown(KeyCode.R))
		{
			Respawn();
		}
	}
}
