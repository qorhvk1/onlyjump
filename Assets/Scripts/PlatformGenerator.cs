using System;
using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using UnityEngine.WSA;

public class PlatformGenerator : EditorWindow
{

	[MenuItem("OJ Tool/Platform Generator")]
	public static void SampleWindow()
	{
		Debug.Log("메뉴실행");

		var window = CreateInstance<PlatformGenerator>();
		window.Show();
		window.minSize = new Vector2(300, 200); // 최소 크기
		window.maxSize = new Vector2(600, 400); // 최대 크기
	}

	public GameObject prefab;
	//해당 프리팹의 X,Y 위치 속성
	static float X = 0;
	static float Y = 0;
	//해당 프리팹의 폭 높이 속성
	static float scaleX = 0;
	static float scaleY = 0;

	private void OnGUI()
	{
		prefab = EditorGUILayout.ObjectField(prefab, typeof(GameObject), false) as GameObject;
		//해당 프리팹의 X,Y 위치 속성
		X = EditorGUILayout.FloatField("X", X);
		Y = EditorGUILayout.FloatField("Y", Y);
		//해당 프리팹의 X,Y 위치 속성
		scaleX = EditorGUILayout.FloatField("scaleX", scaleX);
		scaleY = EditorGUILayout.FloatField("scaleY", scaleY);


		if (GUILayout.Button("OK"))
		{
			GameObject newObject = Instantiate(prefab, new Vector3(X, Y, 0), Quaternion.identity);
			newObject.transform.localScale = new Vector3(scaleX, scaleY, 1);  // X, Y 크기 설정
		}
	}
}