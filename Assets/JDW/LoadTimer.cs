using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Load : MonoBehaviour
{
    public float TimerNextScene; // 다음 씬에서 사용할 플레이어 체력


    void Start()
    {
        LoadTimer();

        Debug.Log($"타이머 불러오기");
    }

    void LoadTimer()
    {

        TimerNextScene = PlayerPrefs.GetFloat("Timer");
    }


    public float Timer
    {
        get { return TimerNextScene; }
    }
}
