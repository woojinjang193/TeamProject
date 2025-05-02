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
    public UnityEvent OnMonsterCount = new UnityEvent();

    [Header("Object")]
    [SerializeField] GameObject Player;
    [SerializeField] GameObject Monster;
   // [SerializeField] GameObject Spawner;

   [Header("UI")]
   [SerializeField] GameObject StopUi;//일시정지 ui
   [SerializeField] GameObject gameOver;//게임오버ui
    [SerializeField] GameObject Timer;//타이머ui
    [SerializeField] GameObject HpB;//체력바
    [SerializeField] GameObject gameClear;//게임클리어
    [SerializeField] GameObject timer;
    [SerializeField] GameObject monsterCount;//몬스터카운트
    [SerializeField] GameObject potal;
    

   


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
                monsterCount.SetActive(false);
                //Monster.SetActive(false);
               // Player.SetActive(false);
                //Spawner.SetActive(false);
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
        OnTimer.AddListener(GameOver);
       // OnMonsterCount.AddListener(Potal); 2스테이지 만들때 추가
        OnMonsterCount.AddListener(GameClear);
    }
    private void Potal()
    {
        potal.SetActive(true);
        monsterCount.SetActive(false);
    }
    public void GameContinue() //게임 일시정지 해제
    {
        Debug.Log("게임재시작");
        StopUi.SetActive(false);

        Time.timeScale = 1;
        Player.SetActive(true);
        HpB.SetActive(true);
        timer.SetActive(true);
        monsterCount.SetActive(true);
        // Monster.SetActive(true);
        // Player.SetActive(true);
        // Spawner.SetActive(true);

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
        monsterCount.SetActive(false); 
    }

}
