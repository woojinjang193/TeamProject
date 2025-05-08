using System.Collections;
using System.Collections.Generic;
using System.Threading;
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
    public UnityEvent OnBossDide = new UnityEvent();
    public UnityEvent OnMonsterTimer = new UnityEvent();    

    [Header("Object")]
    [SerializeField] GameObject Player;
    [SerializeField] GameObject Monster;
    [SerializeField] GameObject potal;
    // [SerializeField] GameObject Spawner;

    [Header("UI")]
   [SerializeField] GameObject StopUi;
   [SerializeField] GameObject gameOver;
    [SerializeField] GameObject timer;
    [SerializeField] GameObject HpB;
    [SerializeField] GameObject gameClear;
    [SerializeField] GameObject monsterCount;
    
    

   


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
        Cursor.visible = false;   // 커서 비활성화
        Cursor.lockState = CursorLockMode.Locked; //커서 가운데 고정
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
                Cursor.visible = true;   // 커서 활성화
                Cursor.lockState = CursorLockMode.None; // 커서 가운데 고정해제

                Debug.Log("게임멈춤");
                Player.SetActive(false);
                stopUi();
                Time.timeScale = 0;
                IsPaues = true;
                HpB.SetActive(false);
                Debug.Log("HP 비활성");
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
        OnBossDide.AddListener(GameClear);
        OnMonsterTimer.AddListener(Potal);
    }
    public void GameContinue() //게임 일시정지 해제
    {
        Debug.Log("게임재시작");
        StopUi.SetActive(false);

        Cursor.visible = false;   // 커서 비활성화
        Cursor.lockState = CursorLockMode.Locked; // 커서 가운데 고정

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
    private void Potal()
    {
        potal.SetActive(true);
        monsterCount.SetActive(false);
    }

   
   
    public void GameOver()
    {
        Cursor.visible = true;   // 커서 활성화
        Cursor.lockState = CursorLockMode.None; // 커서 가운데 고정해제
        //TODO : 캐릭터 사망시 게임오버
        Debug.Log("게임오버");
       // Time.timeScale = 0;
        Player.SetActive(false);
      //  Monster.SetActive(false);
        gameOver.SetActive(true);
        timer.SetActive(false);
        HpB.SetActive(false);
        monsterCount.SetActive(false);
    }
    private void OnDisable()
    {
      OnPlayerDide.RemoveListener(GameOver);
    }
    private void GameClear()
    {

        Cursor.visible = true;   // 커서 활성화
        Cursor.lockState = CursorLockMode.None; // 커서 가운데 고정해제
        Time.timeScale = 0;
        gameClear.SetActive(true);
        Player.SetActive(false);
        //timer.SetActive(false);
        HpB.SetActive(false);
    }

}
