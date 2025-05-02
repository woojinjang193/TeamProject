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

//플레이어나 게임매니저에 넣어서 사용? 안해봐서 모르겠음
//인스펙터에 플레이어/플레이어컨트롤러 넣기 아직 뭘 넣을지 모르겠음
//아무튼 체력을 저장하는 시점에 OnDisavle이나 Update에 저장하면 될듯?