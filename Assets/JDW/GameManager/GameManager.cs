using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Android;
using UnityEngine.Events;
using UnityEngine.UI;


public class GameManager : MonoBehaviour
{
    public static GameManager Instance;

    [Header("object")]
    [SerializeField] GameObject Player;
    [SerializeField] GameObject Monster;

  [Header("UI")]
  [SerializeField] GameObject StopUi;

    [SerializeField] private bool IsPaues;

    public void Awake() // 게임매니저 자동생성
    {
        if(Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject); // 그 외 자동 제거
        }
    }
    public void Start()
    {
        
    }
    public void Update()
    {
        if (Input.GetKeyDown(KeyCode.Q)) // 게임 일시정지와 함께 몬스터와 플레이어 오브젝트 비활성화 
        {
            if (IsPaues == false)
            {
                Debug.Log("게임멈춤");
                StopUi.SetActive(true);
                Time.timeScale = 0;
                IsPaues = true;
                Monster.SetActive(false);
                Player.SetActive(false);
                return;
            }
            if (IsPaues == true)
            {
                GameContinue();
            }
        }
    }
    public void GameContinue() //게임 일시정지 해제
    {
        Debug.Log("게임재시작");
        StopUi.SetActive(false);
        Time.timeScale = 1;
        Monster.SetActive(true);
        Player.SetActive(true);
        IsPaues = false;
    }
   
   
    public void GameOver()
    {
        //TODO : 캐릭터 사망시 게임오버
    }
}
