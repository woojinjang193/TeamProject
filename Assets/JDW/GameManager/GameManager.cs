using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Android;
using UnityEngine.Events;
using UnityEngine.Experimental.GlobalIllumination;
using UnityEngine.UI;


public class GameManager : MonoBehaviour
{
    public static GameManager Instance;

    // [SerializeField] private GameObject Player;

    //[SerializeField] GameObject Monster;
    //[SerializeField] GameObject timer;

    //[SerializeField] PlayerController player;

    public UnityEvent OnTimer = new UnityEvent();
    public UnityEvent OnPlayerDide = new UnityEvent();
    public UnityEvent OnMonsterTimer = new UnityEvent();

    [Header("Object")]
    [SerializeField] GameObject Player;
    [SerializeField] GameObject Monster;

   [Header("UI")]
   [SerializeField] GameObject StopUi;
   [SerializeField] GameObject gameOver;
    [SerializeField] GameObject Timer;
    [SerializeField] GameObject HpB;
    [SerializeField] GameObject gameClear;
    [SerializeField] GameObject timer;
    

   


   [SerializeField] private bool IsPaues;

    public void Awake() // 게임매니저 자동생성
    {
        if(Instance == null)
        {
            Instance = this;
            Resources.Load<GameObject>("GameManager");
            //DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject); // 그 외 자동 제거
        }
    }
    public void Start()
    {
        Time.timeScale =1;
    }
    public void Update()
    {
        StopUiManager();
        
        
           
       
    }
    private void StopUiManager()
    {
        if (Input.GetKeyDown(KeyCode.Q)) // 몬스터와 플레이어 오브젝트 비활성화 와 함께 ui출력
        {
            if (IsPaues == false)
            {
                Debug.Log("게임멈춤");
                Player.SetActive(false);
                stopUi();
                Time.timeScale = 0;
                IsPaues = true;
                HpB.SetActive(false);
                timer.SetActive(false);
                //  Monster.SetActive(false);
                //  Player.SetActive(false);
                return;
            }
            if (IsPaues == true)
            {
                GameContinue();
            }

        }
    }
    private void OnEnable()
    {
        OnPlayerDide.AddListener(GameOver);
        OnTimer.AddListener(GameClear);
    }
    public void GameContinue() //게임 일시정지 해제
    {
        Debug.Log("게임재시작");
        StopUi.SetActive(false);

        Time.timeScale = 1;
        Player.SetActive(true);
        HpB.SetActive(true);
        timer.SetActive(true);
        //  Monster.SetActive(true);
        //  Player.SetActive(true);

        IsPaues = false;
    }
    private void stopUi()
    {
        StopUi.SetActive(true);

    }

   
   
    public void GameOver()
    {
        //TODO : 캐릭터 사망시 게임오버
        Debug.Log("게임오버");
        Player.SetActive(false);
      //  Monster.SetActive(false);
        gameOver.SetActive(true);
        Timer.SetActive(false);
        HpB.SetActive(false);
    }
    private void OnDisable()
    {
      OnPlayerDide.RemoveListener(GameOver);
    }
    private void GameClear()
    {
        gameClear.SetActive(true);
        Player.SetActive(false);
        Timer.SetActive(false);
        HpB.SetActive(false);
    }

}
