// using System;
// using System.Collections;
// using System.Collections.Generic;
// using UnityEditor;
// using UnityEngine;
// using UnityEngine.WSA;

// public class PlatformGenerator : EditorWindow
// {

// 	[MenuItem("OJ Tool/Platform Generator")]
// 	public static void SampleWindow()
// 	{
// 		Debug.Log("�޴�����");

// 		var window = CreateInstance<PlatformGenerator>();
// 		window.Show();
// 		window.minSize = new Vector2(300, 200); // �ּ� ũ��
// 		window.maxSize = new Vector2(600, 400); // �ִ� ũ��
// 	}

// 	public GameObject prefab;
// 	//�ش� �������� X,Y ��ġ �Ӽ�
// 	static float X = 0;
// 	static float Y = 0;
// 	//�ش� �������� �� ���� �Ӽ�
// 	static float scaleX = 0;
// 	static float scaleY = 0;

// 	private void OnGUI()
// 	{
// 		prefab = EditorGUILayout.ObjectField(prefab, typeof(GameObject), false) as GameObject;
// 		//�ش� �������� X,Y ��ġ �Ӽ�
// 		X = EditorGUILayout.FloatField("X", X);
// 		Y = EditorGUILayout.FloatField("Y", Y);
// 		//�ش� �������� X,Y ��ġ �Ӽ�
// 		scaleX = EditorGUILayout.FloatField("scaleX", scaleX);
// 		scaleY = EditorGUILayout.FloatField("scaleY", scaleY);


// 		if (GUILayout.Button("OK"))
// 		{
// 			GameObject newObject = Instantiate(prefab, new Vector3(X, Y, 0), Quaternion.identity);
// 			newObject.transform.localScale = new Vector3(scaleX, scaleY, 1);  // X, Y ũ�� ����
// 		}
// 	}
// }