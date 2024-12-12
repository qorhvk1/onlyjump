using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class PressRtoRestart : MonoBehaviour
{
	public GameObject objectToTeleport; // �����̵��� ������Ʈ
	public Vector3 targetPosition; // ��ǥ ��ġ

	private void Respawn()
	{
		if (objectToTeleport != null)
		{
			objectToTeleport.transform.position = targetPosition; // ������Ʈ�� ��ġ�� ��ǥ ��ġ�� ����
		}
		else
		{
			Debug.LogWarning("Teleport Object is not assigned!"); // ������Ʈ�� �Ҵ���� �ʾ��� ��� ��� �޽��� ���
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
