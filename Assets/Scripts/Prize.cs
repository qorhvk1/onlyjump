using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Prize : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
     

    }

    // Update is called once per frame
    void Update()
    {
    
    }

         void OnTriggerEnter2D(Collider2D other) {
    if (other.gameObject.CompareTag("Player")) {
        // 게임 오버 UI 활성화
        GameManager.Instance.OpenGameOverUI();
    }
}
}
