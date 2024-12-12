using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    // 게임 상태 상수
    public enum GameState
    {
        Ready,
        Restart,
        Pause,
        Quit
    }

    // 현재 게임 상태 변수
    public GameState gState;

    // game over UI
    public GameObject gameOverUI;

	// Game Over
    public void OpenGameOverUI()
    {
        // 옵션 창 활성화
        gameOverUI.SetActive(true);
        Debug.Log("옵션창을 활성화합니다.");

        // 게임 속도 0배속
        Time.timeScale = 0f;

        // 게임 종료
        gState = GameState.Quit;
    }

    // 처음부터 다시 하기
    public void RestartGame()
    {
        // 게임 속도 1배속으로 설정
        Time.timeScale = 1f;

        // 처음부터 시작
        SceneManager.LoadScene(0);
    }


    // 게임 종료
    public void QuitGame()
    {
        // 게임 종료
        Application.Quit();
        Debug.Log("게임을 종료합니다.");
    }

   
    // 인스턴스
    public static GameManager Instance = null;

    public void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        // 게임 시작시 게임오버 패널 끄기
        gameOverUI.SetActive(false);

    }

    // Update is called once per frame
    void Update()
    {
        
    }
}