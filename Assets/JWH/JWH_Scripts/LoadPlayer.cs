using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LoadPlayer : MonoBehaviour
{

    
    public float playerHpNextScene; // 다음 씬에서 사용할 플레이어 체력

   
    void Start()
    {
        LoadPlayerHp();
        
        Debug.Log($"플레이어 체력 불러오기");
    }

    void LoadPlayerHp()
    {
        
        playerHpNextScene = PlayerPrefs.GetFloat("PlayerHealth");
    }


    public float PlayerHealth
    {
        get { return playerHpNextScene; }
    }
}
// 플레이어에게 넣는 스크립트