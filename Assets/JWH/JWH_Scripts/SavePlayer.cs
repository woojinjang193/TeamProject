using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SavePlayer : MonoBehaviour
{
    public PlayerController playerController;
    //public float playerHpSave;

    
    public void SaveHp()
    {
        if (playerController != null)
        {
            //playerHpSave = 
                PlayerPrefs.SetFloat("PlayerHealth", playerController.playerHP);
            PlayerPrefs.Save();
            Debug.Log($"{playerController.playerHP}플레이어 체력 저장");
        }
        else
        {
            Debug.LogError("연결오류");
        }
    }

    
   
}

//플레이어나  넣어서 사용
//인스펙터에 플레이어 넣기 (플레이어에 플레이어컨트롤러 스크립트가 들어있어야함)
