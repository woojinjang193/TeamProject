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

    public void Awake()
    {
        if(Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }
    public void Start()
    {
        
    }
    public void Update()
    {
        if (Input.GetKeyDown(KeyCode.Q))
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
    public void GameContinue()
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
