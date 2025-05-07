using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Load : MonoBehaviour
{
    public Timer timer;


    void Start()
    {
        float Timer = PlayerPrefs.GetFloat("Timer", 50f);
        Debug.Log($"현재 시간 불러오기{Timer}");

        if(timer != null)
        {
            timer.time = Timer;
        }
        else
        {
            Debug.LogError("타이며 연결 안 됨");
        }

    
    }
}
