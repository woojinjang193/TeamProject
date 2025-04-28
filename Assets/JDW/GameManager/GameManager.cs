using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Android;
using UnityEngine.Events;


public class GameManager : MonoBehaviour
{
    public static GameManager Instance;

    [Header("UI")]
    [SerializeField] GameObject StopUi;

    private bool IsPaues;

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
               // StopUi.SetActive(true);
                Time.timeScale = 0;
                IsPaues = true;
                return;
            }
            if (IsPaues == true)
            {
              //  StopUi.SetActive(false);
                Time.timeScale = 1;
                IsPaues = false;
                return;
            }
        }
    }
   
    public void GameOver()
    {
        //TODO : 캐릭터 사망시 게임오버
    }
}
