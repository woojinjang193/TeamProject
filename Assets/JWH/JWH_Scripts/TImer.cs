using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;



public class Timer : MonoBehaviour
{
    public Text[] timeText;
    public Text GameOverText;
    public float time = 10; // 제한 시간
   // [SerializeField] float time = 10; // 제한 시간
    int min, sec; //분이 너무 많다면 초만 사용
    
    void Start()
    {
        UpdateTimeUI(); // 초기 UI 업데이트
        if (GameOverText != null)
        {
            GameOverText.gameObject.SetActive(false); // 게임 오버 텍스트=선택사항
        }

    }

    void Update()
    {
        time -= Time.deltaTime;

        if (time <= 0)
        {
            time = 0;
            GameManager.Instance.OnTimer.Invoke();
            //  UpdateTimeUI();
            //  // 게임 오버 처리 텍스트만 (타이머가 멈추는 경우)
            //  if (GameOverText != null)
            //  {
            //      GameManager.Instance.OnTimer.Invoke();
            //      //GameOverText.gameObject.SetActive(true);// 게임오버 텍스트
            //  }
            //  enabled = false; // 타이머 멈춤 
        }
        else
        {
            UpdateTimeUI();
        }
    }

    void UpdateTimeUI()
    {
        min = Mathf.FloorToInt(time / 60);//분 
        sec = Mathf.FloorToInt(time % 60);//초

        if (timeText != null && timeText.Length >= 2)
        {
            timeText[0].text = min.ToString("D2"); // 분을 두 자리 숫자로 표시 -> D1(한자리로 표시)
            timeText[1].text = sec.ToString("D2"); // 초를 두 자리 숫자로 표시
        }
       
    }
}



/* 타이머 사용법
 * 
 * 캔버스에 Timer 스크립트 넣기
 * Timer에서 엘레멘츠 숫자 2로 변경 (분, 초)
 * 인스펙터에서 시간설정 가능
 * UI에서 레거시 - 텍스트로 3개 생성
 * 각각 분,초,게임오버
 * Timer에 집어넣고 폰트, 사이즈, 위치 등등등 변경
 * 게임오버텍스트 필요 없을 시 폰트를 지우면 해결가능
*/